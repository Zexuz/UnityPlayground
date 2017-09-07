using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public float ShrinkFactor = 0.1f;

    private float size = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        size -= Time.deltaTime * ShrinkFactor;
        transform.localScale = new Vector3(size, size, size);

        if (size < 0.0f) {
            Destroy(gameObject);
        } 
	}

    void Feed(string data) {
        size += 1.0f;
    }
}
