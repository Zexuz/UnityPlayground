using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {

	
	public GameObject attractedTo;
	public float strengthOfAttraction = 5.0f;

	private Rigidbody _rigidbody;
	
	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = attractedTo.transform.position - transform.position;
		_rigidbody.AddForce(strengthOfAttraction * direction);
	}
}
