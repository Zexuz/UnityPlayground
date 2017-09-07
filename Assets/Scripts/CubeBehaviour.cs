using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public float ShrinkFactor = 0.1f;
    public float GrowthRoof = 1000.0f;
    public float GrowthFactor = 1.0f;
    public float MaxSize = 5.0f;

    private float size = 1.0f;
    private float messages = 1.0f;

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
        messages += 1;
        float growth = System.Math.Min((float)messages*GrowthFactor, GrowthRoof);
        size = (MaxSize-1.0f) * (growth / GrowthRoof) + 1.0f;        
    }
}
