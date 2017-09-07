using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour {

    public byte id;
    public GameObject MessageBlob;
    public GameObject CenterOfGravity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NewMessage(byte[] data) {
        if (data[0] != id) {
            return;
        } 

        var obj = Instantiate(MessageBlob);
        obj.GetComponent<Attract>().attractedTo = CenterOfGravity;
    }
}
