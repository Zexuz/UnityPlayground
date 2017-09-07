using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor

{
    string res = "";
    string data = "0000000000000000";
    float interval = 0.0f;

    List<MessageSender> senders = new List<MessageSender>();

    public override void OnInspectorGUI()

    {
        DrawDefaultInspector();

        res = GUILayout.TextField(res, 25);
        
        Generator generator = (Generator)target;
        if (GUILayout.Button("Send"))
        {
            generator.SendHex(res);
        }

        if (GUILayout.Button("Create Sender"))
        {
            senders.Add(generator.createSender());

        }

        List<MessageSender> toRemove = new List<MessageSender>();
        foreach(MessageSender sender in senders)
        {
            sender.data = EditorGUILayout.TextField("Data", sender.data);
            sender.interval = EditorGUILayout.FloatField("Interval", sender.interval);

            if (GUILayout.Button("Destroy"))
            {
                toRemove.Add(sender);
            }
        }

        foreach (MessageSender sender in toRemove) {
            senders.Remove(sender);
            Destroy(sender);
        }
    }
}