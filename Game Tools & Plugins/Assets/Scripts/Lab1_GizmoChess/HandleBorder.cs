using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HandleBorder : MonoBehaviour
{
    public float borderSize = 5f;
}

[CustomEditor(typeof(HandleBorder))]
public class BorderEditor : Editor
{
    public void OnSceneGUI()
    {
        var t = target as HandleBorder;
        Transform tr = t.transform;

        // display a border
        Handles.color = Color.white;
        Handles.DrawSelectionFrame(0, tr.position + new Vector3(4, 4, 0), Quaternion.identity, t.borderSize, EventType.Repaint);
    }
}