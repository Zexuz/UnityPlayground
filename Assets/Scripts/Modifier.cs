using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public GameObject GameObjectPrefab;
    public float ShrinkFactor = 1;
    public float IncreseFactor = 1;

    private Dictionary<string, GameObjectNode> _nodes;
    public int LifeTime = 1;

    private void Start()
    {
        _nodes = new Dictionary<string, GameObjectNode>();
    }

    public void PrintMessage(string messageString)
    {
        if (!_nodes.ContainsKey(messageString))
        {
            var messageWeapper = new MsgWrapper(messageString);
            var gObj = Instantiate(GameObjectPrefab, new Vector3(), Quaternion.identity);
            _nodes[messageString] = new GameObjectNode(messageWeapper, gObj);
        }
        _nodes[messageString].MsgWrapper.AddToList(new Message(LifeTime));
        _nodes[messageString].GameObject.transform.localScale *= IncreseFactor;
    }

    private void Update()
    {
        var keysToRemove = new List<string>();
        foreach (var kvp in _nodes)
        {
            var gameObjectNode = kvp.Value;
            gameObjectNode.MsgWrapper.Update();
            var messageCount = gameObjectNode.MsgWrapper.Messages.Count;
            if (messageCount == 0)
                keysToRemove.Add(kvp.Key);

            if (gameObjectNode.GameObject.transform.localScale.magnitude < 0.5f)
                keysToRemove.Add(kvp.Key);

            var factor = (messageCount * ShrinkFactor) - messageCount + 1;
            Debug.Log(factor);
            gameObjectNode.GameObject.transform.localScale /= factor;
        }

        foreach (var key in keysToRemove)
        {
            Destroy(_nodes[key].GameObject);
            _nodes.Remove(key);
        }
    }
}


public class GameObjectNode
{
    public MsgWrapper MsgWrapper { get; private set; }
    public GameObject GameObject { get; private set; }

    public GameObjectNode(MsgWrapper msgWrapper, GameObject gameObject)
    {
        MsgWrapper = msgWrapper;
        GameObject = gameObject;
    }
}


public class MsgWrapper
{
    public string MessageString { get; private set; }
    private List<Message> _messages;

    public List<Message> Messages
    {
        get { return _messages; }
    }

    public MsgWrapper(string messageString)
    {
        MessageString = messageString;

        _messages = new List<Message>();
    }

    public void AddToList(Message message)
    {
        _messages.Add(message);
    }

    public void Update()
    {
        for (int i = _messages.Count - 1; i >= 0; i--)
        {
            if (_messages[i].ShouldDestory())
                _messages.RemoveAt(i);
        }
    }
}

public class Message
{
    public DateTime Created { get; private set; }
    public int LifeTime { get; private set; }


    public Message(int lifeTime)
    {
        Created = DateTime.Now;
        LifeTime = lifeTime;
    }

    public bool ShouldDestory()
    {
        var timeLeft = Created.AddSeconds(LifeTime) - DateTime.Now;
        return timeLeft.TotalMilliseconds < 0;
    }
}