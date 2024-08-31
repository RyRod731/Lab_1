using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement: MonoBehaviour
{
    public bool isWhite = true;

    float movementDistance = 1f;

    Vector3 movementDirection;

    GizmoArrow arrowMaker = new GizmoArrow();

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        DetermineDirection();

        // pawn can move forward 1 space.
        arrowMaker.DrawArrow(transform.position, movementDirection, movementDistance);

        // initially, a pawn can move forward 2 spaces
        arrowMaker.DrawArrow(transform.position, movementDirection, movementDistance + 1f);
    }

    // moves up if pawn is white, down if black
    void DetermineDirection()
    {
        if(isWhite == true)
        {
            movementDirection = Vector3.up;
        }
        else
        {
            movementDirection = Vector3.down;
        }
    }

    #endif
}
