#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor

{
    string res = "";
    string data = "0000000000000000";
    float interval = 0.0f;

    private int number = 1;

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

        number = EditorGUILayout.IntField(number);
        if (GUILayout.Button("Create random messages sender"))
        {
            for (int i = 0; i < number; i++)
            {
                var messageSender = generator.createSender();
                MessageSenderBehaviour script = messageSender.GetComponent<MessageSenderBehaviour>();
                script.data = RandomString(1);
                script.interval = Random.value;
                senders.Add(messageSender);
            }
        }
        

        List<GameObject> toRemove = new List<GameObject>();
        foreach (GameObject sender in senders)
        {
            MessageSenderBehaviour script = sender.GetComponent<MessageSenderBehaviour>();
            script.data = EditorGUILayout.TextField("Data", script.data);
            script.interval = EditorGUILayout.FloatField("Interval", script.interval);

            if (GUILayout.Button("Destroy"))
            {
                toRemove.Add(sender);
            }
        }

        foreach (GameObject sender in toRemove)
        {
            senders.Remove(sender);
            Destroy(sender);
        }
    }
    
    private static System.Random random = new System.Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
#endif