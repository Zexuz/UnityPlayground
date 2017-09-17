using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {

    public Camera Camera;
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
        Vector3 position = attractedTo.transform.position;
        position.y = Camera.gameObject.transform.position.y;
        position.y -= 0.1f;
        Vector3 direction = position - transform.position;
		_rigidbody.AddForce(strengthOfAttraction * direction);
	}
}
