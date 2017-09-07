using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor

{
    string res = "";
    string data = "0000000000000000";
    float interval = 0.0f;

    public override void OnInspectorGUI()

    {
        DrawDefaultInspector();

        res = GUILayout.TextField(res, 25);
        
        Generator generator = (Generator)target;
        if (GUILayout.Button("Send"))
        {
            generator.SendHex(res);
        }

        data = EditorGUILayout.TextField("Data", data);
        interval = EditorGUILayout.FloatField("Interval", interval);
        if (GUILayout.Button("Start Send"))
        {
            generator.StartSendHex(interval, data);
        }

    }
}