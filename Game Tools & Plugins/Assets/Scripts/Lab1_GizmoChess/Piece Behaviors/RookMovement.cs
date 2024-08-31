using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMovement : MonoBehaviour
{
    float movementDistance = 7f;

    Vector3[] cardinalDirections = 
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, -1, 0)
    };

    GizmoArrow arrowMaker = new GizmoArrow();

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        DrawArrows();
    }

    void DrawArrows()
    {
        foreach(Vector3 direction in cardinalDirections)
        {
            arrowMaker.DrawArrow(transform.position, direction, movementDistance);
        }
    }
    #endif
}
