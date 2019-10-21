using UnityEngine;
using System.Collections;
using UnityEditor;

namespace InfoDev
{
    [CustomEditor(typeof(Vis))]
    public class VisInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Vis visObject = (Vis)target;
            if (GUILayout.Button("Update Vis"))
            {
                visObject.UpdateVisSpecsFromTextSpecs();
                Debug.Log("Update Vis");
            }
        }
    }
}