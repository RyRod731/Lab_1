using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoArrow
{
    float arrowheadSize = 0.25f;

    // draws an arrow as a gizmo
    public void DrawArrow(Vector3 startPos, Vector3 direction, float length)
    {
        // calculates the arrow's end point
        Vector3 endPos = startPos + (direction * length);

        DrawShaft(startPos, endPos);

        DrawArrowhead(endPos, direction, arrowheadSize);
    }

    // draws the arrow's shaft
    void DrawShaft(Vector3 startPos, Vector3 endPos)
    {
        Gizmos.DrawLine(startPos, endPos);
    }

    // draws the arrowhead
    void DrawArrowhead(Vector3 endPos, Vector3 direction, float arrowheadSize)
    {
        if(direction.x == 0 || direction.y == 0)
        {
            // draws one side of the arrowhead
            Gizmos.DrawLine(endPos, endPos - DiagonalVector(direction, arrowheadSize));

            // draws the other side
            Gizmos.DrawLine(endPos, endPos + DiagonalVector(-direction, arrowheadSize));
        }
        else
        {
            DrawCardinalArrowhead(direction.x, true, endPos, arrowheadSize);

            DrawCardinalArrowhead(direction.y, false, endPos, arrowheadSize);
        }
    }

    // draws an arrowhead with cardinal directions based on direction's x or y axis
    void DrawCardinalArrowhead(float directionAxis, bool isVertical, Vector3 endPos, float arrowheadSize)
    {
        if(directionAxis < 0)
        {
            Gizmos.DrawLine(endPos, endPos + CardinalVector(isVertical, arrowheadSize));
        }
        else
        {
            Gizmos.DrawLine(endPos, endPos - CardinalVector(isVertical, arrowheadSize));
        }
    }

    // creates a vector for the arrowhead based on the shaft's cardinal direction
    Vector3 DiagonalVector(Vector3 direction, float arrowheadSize)
    {
        Vector3 arrowheadVector = new Vector3(1, 1, 0);

        // modifies the vector based on the arrow's non-zero coordinates
        if(direction.x != 0)
        {
            arrowheadVector.x = direction.x;
        }
        if(direction.y != 0)
        {
            arrowheadVector.y = direction.y;
        }

        arrowheadVector *= arrowheadSize;

        return arrowheadVector;
    }

    // creates a vector for the arrowhead based on the shaft's diagonal direction
    Vector3 CardinalVector(bool isVertical, float arrowheadSize)
    {
        Vector3 arrowheadVector = new Vector3(1, 1, 0);

        // modifies the vector based on the arrowhead's verticality/lack thereof
        if(isVertical)
        {
            arrowheadVector.y = 0;
        }
        else
        {
            arrowheadVector.x = 0;
        }

        arrowheadVector *= arrowheadSize;

        return arrowheadVector;
    }
}
