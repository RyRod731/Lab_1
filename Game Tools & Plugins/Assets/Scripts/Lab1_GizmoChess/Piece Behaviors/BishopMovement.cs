using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
{
    float movementDistance = 5f;

    Vector3[] diagonalDirections = 
    {
        new Vector3(1, 1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0)
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
        foreach(Vector3 direction in diagonalDirections)
        {
            arrowMaker.DrawArrow(transform.position, direction, movementDistance);
        }
    }
    #endif
}
