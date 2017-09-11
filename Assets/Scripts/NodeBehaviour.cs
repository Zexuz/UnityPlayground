using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour {

    public byte id;
    public Camera Camera;
    public GameObject MessageBlob;
    public GameObject CenterOfGravity;

    private Dictionary<string, GameObject> blobs = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void createMessageBlob(string data) {
        var obj = Instantiate(MessageBlob);
        obj.GetComponent<Attract>().attractedTo = CenterOfGravity;
        obj.GetComponent<Attract>().Camera = Camera;

        blobs.Add(data, obj);
    }

    private void feedMessageBlob(string data) {
        var obj = blobs[data];
        if (obj == null) // the object has been destroyed
        {
            blobs.Remove(data);
            createMessageBlob(data);
            return;    
        }
        obj.SendMessage("Feed", data);
    }

    void NewMessage(string data) {
        if (blobs.ContainsKey(data))
        {
            feedMessageBlob(data);
        }
        else
        {
            createMessageBlob(data);
        }
    }
}
