using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor

{
    string res = "";

    public override void OnInspectorGUI()

    {
        DrawDefaultInspector();

        res = GUILayout.TextField(res, 25);


        var myScript = (Generator) target;
        if (GUILayout.Button("Send"))
        {
            myScript.SendHex(res);
        }

    }
}