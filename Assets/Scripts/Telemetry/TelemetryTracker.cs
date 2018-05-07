using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryTracker : MonoBehaviour {

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private SQLiteAdapter _db;

    public bool isTracked;

	// Use this for initialization
	void Start () {
        if (!_player)
            _player = GameObject.FindGameObjectWithTag("Player");
        //Start Tracker
        StartCoroutine(PositionTracking());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetPlayerPos()
    {
        return _player.transform.position;
    }

    IEnumerator PositionTracking()
    {
        while (isTracked)
        {
            _db.InsertPosition(0, 1, _player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
            yield return new WaitForSeconds(2f);
        }
       
    }
}
