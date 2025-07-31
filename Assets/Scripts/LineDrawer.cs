using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;
    private List<Vector2> points = new List<Vector2>();
    private const int maxLength = 100;

    void Start()
    {
        line.transform.position = Vector3.zero;
    }

    public void SetPosition(Vector3 pos, EdgeCollider2D edgeCollider)
    {
        if (!CanAppend(pos)) return;

        // If max length, remove earliest point
        if (line.positionCount == maxLength) RemoveFirstLinePoint();

        // Add new point and simplify the line
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, pos);

        if (line.positionCount > 1)
        {
            line.Simplify(0.02f);
            points = new List<Vector2>();
        }

        for (int i = 0; i < line.positionCount - 2; i++)
        {
            points.Add(line.GetPosition(i));
        }
        edgeCollider.points = points.ToArray();
    }

    private void RemoveFirstLinePoint()
    {
        Vector3[] newPositions = new Vector3[maxLength - 1];

        for (int i = 0; i < maxLength - 1; i++)
        {
            newPositions[i] = line.GetPosition(i + 1);
        }
        line.SetPositions(newPositions);
    }

    private bool CanAppend(Vector3 pos)
    {
        if (line.positionCount == 0)
        {
            return true;
        }
        return Vector3.Distance(pos, line.GetPosition(line.positionCount - 1)) > 0.1f;
    }
}
