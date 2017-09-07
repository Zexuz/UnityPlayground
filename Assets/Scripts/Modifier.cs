using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public GameObject Node;

    private byte[] StringToByteArray(String hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }

    private void Start()
    {
        
    }

    public void PrintMessage(string messageString)
    {
        Node.SendMessage("NewMessage", StringToByteArray(messageString.PadRight(16, '0')));        
    }

    private void Update()
    {
    
    }
}
