using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using Random = UnityEngine.Random;

public class DebugInput : MonoBehaviour, IInputClickHandler
{
    public TextMesh AnchorDebugText;
    private int _nrOfClicks;
    public Generator Generator;

    void Update()
    {
        UpdateText();
    }
	
    private void RemoveAllMessageSender()
    {
        var action = new Action(() =>
        {
            var messageSenders = GameObject.FindGameObjectsWithTag(Tags.MessageSenderHolder);

            foreach (var sender in messageSenders)
            {
                Destroy(sender.gameObject);
            }
        });

        StartCoroutine(Wait(0.0f, action));
    }
	
    private void RemoveAllCubes()
    {
        var action = new Action(() =>
        {
            var nodes = GameObject.FindGameObjectsWithTag(Tags.Node);

            foreach (var node in nodes)
            {
                var nodeBehaviour = node.GetComponent<NodeBehaviour>();
                nodeBehaviour.RemoveAllChilds();
            }
        });

        StartCoroutine(Wait(0.1f, action));
    }
	
    IEnumerator Wait(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    private void UpdateText()
    {
        if (AnchorDebugText != null)
            AnchorDebugText.text = string.Format(
                "Clicks: {0}", _nrOfClicks);
    }

    private void GenerateMesseageSenders(int nr)
    {
       var action = new Action(() =>
       {
           for (int i = 0; i < nr; i++)
           {
               Generator.CreateSender(RandomString(1), Random.value);
           }
       } );

        StartCoroutine(Wait(0.2f, action));
    }
    

    public void OnInputClicked(InputClickedEventData eventData)
    {
        RemoveAllMessageSender();
        RemoveAllCubes();
        GenerateMesseageSenders(100);
        _nrOfClicks++;
    }
    
    private static System.Random random = new System.Random();
    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
}