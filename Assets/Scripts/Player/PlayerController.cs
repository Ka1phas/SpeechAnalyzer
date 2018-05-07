using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody _rb;

    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Start () {
        _rb = gameObject.GetComponent<Rigidbody>();
	}
	
    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal") * _speed, 0f, Input.GetAxis("Vertical") * _speed);
        _rb.AddForce(input);
    }
}
