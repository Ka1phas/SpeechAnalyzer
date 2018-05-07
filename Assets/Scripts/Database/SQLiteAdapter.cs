using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class SQLiteAdapter : MonoBehaviour {

    [SerializeField]
    private string _databaseName;

    private string _dbPath;

	// Use this for initialization
	void Start () {
		_dbPath = "URI=file:" + Application.persistentDataPath + "/" + _databaseName + ".db";
        CreateSchemas();
    }

    public void CreateSchemas()
    {
        using (var conn = new SqliteConnection(_dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'player_pos' ( " +
                                      "  'id' INTEGER PRIMARY KEY, " +
                                      "  'session_id' INTEGER NOT NULL, " +
                                      "  'player_id' INTEGER NOT NULL, " +
                                      "  'pos_x' REAL NOT NULL," +
                                      "  'pos_y' REAL NOT NULL," +
                                      "  'pos_z' REAL NOT NULL" +
                                      ");";

                var result = cmd.ExecuteNonQuery();
                Debug.Log("[SQLite]: create schema: " + result);
            }
        }
    }

    public void InsertPosition(int sessionID, int playerID, float pos_x, float pos_y, float pos_z)
    {
        using (var conn = new SqliteConnection(_dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO player_pos (session_id, player_id, pos_x, pos_y, pos_z) " +
                                  "VALUES (@SessionID, @PlayerID, @PosX, @PosY, @PosZ);";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "SessionID",
                    Value = sessionID
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "PlayerID",
                    Value = playerID
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "PosX",
                    Value = pos_x
                });


                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "PosY",
                    Value = pos_y
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "PosZ",
                    Value = pos_z
                });

                var result = cmd.ExecuteNonQuery();
                Debug.Log("[SQLite]: insert position: " + result);
            }
        }
    }

    public void GetPlayerPositions(int session, int player)
    {
        using (var conn = new SqliteConnection(_dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM player_pos WHERE session_id=@SessionID AND player_id=@PlayerID;";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "SessionID",
                    Value = session
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "PlayerID",
                    Value = player
                });

                Debug.Log("[SQLite]: positions (begin)");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var pos_x = reader.GetFloat(3);
                    var pos_y = reader.GetFloat(4);
                    var pos_z = reader.GetFloat(5);
                    var text = string.Format("{0}: ( {1}, {2}, {3} )", id, pos_x, pos_y, pos_z);
                    Debug.Log(text);
                }
                Debug.Log("scores (end)");
            }
        }
    }
}
