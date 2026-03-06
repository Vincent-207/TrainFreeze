using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
[CustomEditor(typeof(GridHolder))]
public class GridHolderInspector : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        GridHolder gridHolder = (GridHolder)target;
        if(GUILayout.Button("Generate"))
        {
            gridHolder.GenerateGrid();
        }
        if(GUILayout.Button("Delete grid"))
        {
            gridHolder.DeleteGrid();
        }
    }
    
}
