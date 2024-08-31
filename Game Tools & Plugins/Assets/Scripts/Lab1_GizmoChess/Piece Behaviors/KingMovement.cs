using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{
    float movementDistance = 1f;

    Vector3[] cardinalDirections = 
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, -1, 0)
    };

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
        DrawArrows();
    }

    void DrawArrows()
    {
        foreach(Vector3 direction in cardinalDirections)
        {
            arrowMaker.DrawArrow(transform.position, direction, movementDistance);
        }

        foreach(Vector3 direction in diagonalDirections)
        {
            arrowMaker.DrawArrow(transform.position, direction, movementDistance);
        }
    }
    #endif
}
