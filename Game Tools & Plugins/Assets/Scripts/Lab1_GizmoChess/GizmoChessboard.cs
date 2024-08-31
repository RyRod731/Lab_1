using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoChessboard : MonoBehaviour
{
    int boardSize = 8;

    Color white = Color.white;
    Color black = Color.black;

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        // defines the gizmo's initial color
        Gizmos.color = black;

        // initial loop defines columns and swaps colors
        // nested loop defines rows, draws cols and rows, and swaps colors
        for(int col = 1; col <= boardSize; ++col)
        {
            for(int row = 0; row < boardSize; ++row)
            {
                DrawRowCol(row, col - 1);
                
                // completes the board's borders
                if(col == boardSize)
                {
                    DrawRow(row, boardSize);
                    DrawCol(boardSize, row);
                }

                SwitchColor();
            }
            
            SwitchColor();          // second swap is necessary for even number-spaced boards
        }
    }

    // draws 1 horizontal and 1 vertical line (1 unit long each)
    void DrawRowCol(float row, float col)
    {
        DrawRow(row, col);
        DrawCol(row, col);
    }

    // draws a horizontal line (1 unit long)
    void DrawRow(float rowStart, float colStart)
    {
        Gizmos.DrawLine(new Vector3(rowStart, colStart, 0), new Vector3(rowStart + 1, colStart, 0));
    }

    // draws a vertical line (1 unit long)
    void DrawCol(float rowStart, float colStart)
    {
        Gizmos.DrawLine(new Vector3(rowStart, colStart, 0), new Vector3(rowStart, colStart + 1, 0));
    }

    // swaps gizmo color from white to black and vice versa
    void SwitchColor()
    {
        if(Gizmos.color == white)
        {
            Gizmos.color = black;
        }
        else
        {
            Gizmos.color = white;
        }
    }
    #endif
}
