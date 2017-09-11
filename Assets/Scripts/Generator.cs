using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Modifier Modifier;
    public GameObject MessageSender;
    private GameObject _holder;

    public void GenerateHex()
    {
        SendHex("00:00:00:00:00:00:00:00");
    }

    public void SendHex(string hex)
    {
        Modifier.PrintMessage(hex);
    }

    public GameObject CreateSender()
    {
        if (_holder == null)
            CreateHolder();
        GameObject obj = Instantiate(MessageSender);
        obj.GetComponent<MessageSenderBehaviour>().Modifier = Modifier;
        obj.transform.parent = _holder.transform;
        return obj;
    }
    
    public GameObject CreateSender(string data, float interval)
    {
        var gameObj = CreateSender();
        var sender = gameObj.GetComponent<MessageSenderBehaviour>();
        sender.data = data;
        sender.interval = interval;
        return gameObj;
    }
    
    private void CreateHolder()
    {
        _holder = new GameObject
        {
            name = "MessageSenderHolder",
            tag = Tags.MessageSenderHolder
        };
    }
}