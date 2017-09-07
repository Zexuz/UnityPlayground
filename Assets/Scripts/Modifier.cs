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
            var messageWeapper = new Messages(messageString);
            var gObj = Instantiate(GameObjectPrefab, new Vector3(), Quaternion.identity);
            _nodes[messageString] = new GameObjectNode(messageWeapper, gObj);
        }
        _nodes[messageString].Messages.Add(new MessageInfo(LifeTime));
        _nodes[messageString].GameObject.transform.localScale *= IncreseFactor;
    }

    private void Update()
    {
        var keysToRemove = new List<string>();
        foreach (var kvp in _nodes)
        {
            var gameObjectNode = kvp.Value;
            var msgWrapper = gameObjectNode.Messages;
            var messageCount = msgWrapper.Values.Count;
            
            msgWrapper.Update();
            
            if (messageCount == 0)
                keysToRemove.Add(kvp.Key);

            var trans = gameObjectNode.GameObject.transform;
            if (trans.localScale.magnitude < 0.5f)
                keysToRemove.Add(kvp.Key);

            var factor = (messageCount * ShrinkFactor) - messageCount + 1;
            Debug.Log(factor);
            trans.localScale /= factor;
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
    public Messages Messages { get; private set; }
    public GameObject GameObject { get; private set; }

    public GameObjectNode(Messages messages, GameObject gameObject)
    {
        Messages = messages;
        GameObject = gameObject;
    }
}


public class Messages
{
    public string MessageString { get; private set; }
    private readonly List<MessageInfo> _values;

    public List<MessageInfo> Values
    {
        get { return _values; }
    }

    public Messages(string messageString)
    {
        MessageString = messageString;

        _values = new List<MessageInfo>();
    }

    public void Add(MessageInfo messageInfo)
    {
        _values.Add(messageInfo);
    }

    public void Update()
    {
        for (int i = _values.Count - 1; i >= 0; i--)
        {
            if (_values[i].ShouldDestory())
                _values.RemoveAt(i);
        }
    }
}

public class MessageInfo
{
    public DateTime Created { get; private set; }
    public int LifeTime { get; private set; }


    public MessageInfo(int lifeTime)
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