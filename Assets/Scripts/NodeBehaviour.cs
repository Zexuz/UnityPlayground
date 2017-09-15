using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class NodeBehaviour : MonoBehaviour {

    public byte id;
    public Camera Camera;
    public GameObject MessageBlob;
    public GameObject CenterOfGravity;
    

    private Dictionary<string, GameObject> blobs = new Dictionary<string, GameObject>();

    public void RemoveAllChilds()
    {
        foreach (Transform child in gameObject.transform)
        {
            if(!child.CompareTag(Tags.Cube))continue;
            Destroy(child.gameObject);
        }
        
        
    }

    private void createMessageBlob(string data) {
        var obj = Instantiate(MessageBlob);
        obj.GetComponent<Attract>().attractedTo = CenterOfGravity;
        obj.GetComponent<Attract>().Camera = Camera;
        obj.GetComponent<CubeBehaviour>().Camera = Camera;

        obj.transform.position = gameObject.transform.position;

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
