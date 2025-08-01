using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;
    private List<Vector2> points = new List<Vector2>();
    private const int maxLength = 40;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        line.transform.position = Vector3.zero;
        polygonCollider = GetComponent<PolygonCollider2D>();
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
            line.Simplify(0.01f);
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

    public void CheckCapture(Vector3 collisionPosition)
    {
        List<Vector2> loop = new List<Vector2>
        {
            collisionPosition
        };

        for (int i = line.positionCount - 2; i - 1 >= 0; i--)
        {
            if (IsIntersectionInBounds(line.GetPosition(i), line.GetPosition(i - 1), collisionPosition))
            {
                loop.Add(line.GetPosition(i));
                break;
            }
            loop.Add(line.GetPosition(i));
        }

        polygonCollider.points = loop.ToArray();
        SearchForCreatures();
    }

    public bool IsIntersectionInBounds(Vector3 lineStart, Vector3 lineEnd, Vector3 intersection)
    {
        float distAC = Vector3.Distance(lineStart, intersection);
        float distBC = Vector3.Distance(lineEnd, intersection);
        float distAB = Vector3.Distance(lineStart, lineEnd);
        if (Math.Abs(distAC + distBC - distAB) > 0.02f)
        {
            return false;
        }

        return true;
    }

    private void SearchForCreatures()
    {
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        foreach (GameObject creature in creatures)
        {
            var exists = polygonCollider.OverlapPoint(creature.transform.position);
            if (exists)
            {
                creature.gameObject.GetComponent<Creature>().Capture(GetInstanceID());
            }
        }
    }
}
