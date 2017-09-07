using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor

{
    string res = "";
    string data = "0000000000000000";
    float interval = 0.0f;

    List<GameObject> senders = new List<GameObject>();

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

        List<GameObject> toRemove = new List<GameObject>();
        foreach(GameObject sender in senders)
        {
            MessageSenderBehaviour script = sender.GetComponent<MessageSenderBehaviour>();
            script.data = EditorGUILayout.TextField("Data", script.data);
            script.interval = EditorGUILayout.FloatField("Interval", script.interval);

            if (GUILayout.Button("Destroy"))
            {
                toRemove.Add(sender);
            }
        }

        foreach (GameObject sender in toRemove) {
            senders.Remove(sender);
            Destroy(sender);
        }
    }
}