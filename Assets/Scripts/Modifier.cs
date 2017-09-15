using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public void PrintMessage(string messageString)
    {
        var nodes = GameObject.FindGameObjectsWithTag(Tags.Node);
        foreach (var node in nodes)
        {
            node.SendMessage("NewMessage", messageString);        
        }
    }
}
