using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator:MonoBehaviour
{
	public Modifier Modifier;
    public MessageSender MessageSender;

    public void GenerateHex()
	{
		SendHex("00:00:00:00:00:00:00:00");
	}
	public void SendHex(string hex)
	{
		Modifier.PrintMessage(hex);
	}

    public void StartSendHex(float interval, string data)
    {
        if (interval <= 0.0f) {
            return;
        }

        MessageSender obj = Instantiate(MessageSender);
        obj.Modifier = Modifier;
        obj.SendMessage("Begin", interval);
    }
}
