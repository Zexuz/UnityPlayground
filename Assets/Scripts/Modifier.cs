using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public GameObject Node;

    private void Start()
    {
        
    }

    public void PrintMessage(string messageString)
    {
        Node.SendMessage("NewMessage", messageString);        
    }

    private void Update()
    {
    
    }
}
