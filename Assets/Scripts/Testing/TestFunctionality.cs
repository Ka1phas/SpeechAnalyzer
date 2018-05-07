using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFunctionality : MonoBehaviour {

    [SerializeField]
    private SQLiteAdapter _db;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _db.GetPlayerPositions(0, 1);
        }
		
	}
}
