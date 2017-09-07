using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public GameObject GameObjectPrefab;

    private Dictionary<string, GameObjectNode> _nodes;
    private TimeSpan LifeTime = new TimeSpan(0, 0, 0, 1);

    private void Start()
    {
        _nodes = new Dictionary<string, GameObjectNode>();
    }

    public void PrintMessage(string messageString)
    {
        if (!_nodes.ContainsKey(messageString))
        {
            var messageWeapper = new MsgWrapper(messageString);
            var gObj = Instantiate(GameObjectPrefab, GameObjectPrefab.transform.position, Quaternion.identity);
            _nodes[messageString] = new GameObjectNode(messageWeapper, gObj);
        }
        _nodes[messageString].MsgWrapper.AddToList(new Message(LifeTime));
    }

    private void Update()
    {
        var keysToRemove = new List<string>();
        foreach (var kvp in _nodes)
        {
            var gameObjectNode = kvp.Value;
            gameObjectNode.MsgWrapper.Update();
            if (gameObjectNode.MsgWrapper.Messages.Count == 0)
                keysToRemove.Add(kvp.Key);
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
        if (_messages.Where(message => message.ShouldDestory()).Any(message => !_messages.Remove(message)))
            throw new Exception("We could not remove the object!");
    }
}

public class Message
{
    public DateTime Created { get; private set; }
    public TimeSpan LifeTime { get; private set; }


    public Message(TimeSpan lifeTime)
    {
        Created = DateTime.Now;
        LifeTime = lifeTime;
    }

    public bool ShouldDestory()
    {
        var timeLeft = (Created + LifeTime) - DateTime.Now;
        return timeLeft.TotalMilliseconds < 0;
    }
}