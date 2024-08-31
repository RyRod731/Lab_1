using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public bool isWhite = true;

    float[] movementDistance = {2f, 1f};

    GizmoArrow arrowMaker = new GizmoArrow();

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        // 2 spaces horizontal, 1 space vertical
        DrawLPath(Vector3.right, VerticalDirection(isWhite));
        DrawLPath(Vector3.left, VerticalDirection(isWhite));

        // 2 spaces vertical, 1 space horizontal
        DrawLPath(VerticalDirection(isWhite), Vector3.right);
        DrawLPath(VerticalDirection(isWhite), Vector3.left);
    }

    void DrawLPath(Vector3 firstDirection, Vector3 secondDirection)
    {
        // draw initial arrow
        arrowMaker.DrawArrow(transform.position, firstDirection, movementDistance[0]);

        // draw second arrow
        Vector3 nextStartPos = transform.position + (firstDirection * movementDistance[0]);
        arrowMaker.DrawArrow(nextStartPos, secondDirection, movementDistance[1]);
    }

    // moves up if rook is white, down if black
    Vector3 VerticalDirection(bool isWhite)
    {
        if(isWhite)
        {
            return Vector3.up;
        }
        else
        {
            return Vector3.down;
        }
    }
    #endif
}
