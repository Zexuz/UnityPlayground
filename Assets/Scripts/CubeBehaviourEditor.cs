#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CubeBehaviour))]
public class CubeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CubeBehaviour script = (CubeBehaviour)target;
        if (GUILayout.Button("Feed"))
        {
            script.Feed(script.data);    
        }
    }
}
#endif