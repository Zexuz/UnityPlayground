using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowMod : MonoBehaviour {

	public GameObject Node;
	
	public void PrintMessage(string messageString)
    {
        Node.SendMessage("NewMessage", messageString);        
    }
}
