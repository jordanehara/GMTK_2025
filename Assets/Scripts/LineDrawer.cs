using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;
    public EdgeCollider2D edgeCollider;
    private readonly List<Vector2> points = new List<Vector2>();
    void Start()
    {
        line.transform.position = Vector3.zero;
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void SetPosition(Vector3 pos)
    {
        if (!CanAppend(pos)) return;

        line.positionCount++;
        line.SetPosition(line.positionCount - 1, pos);

        points.Add(pos);
        edgeCollider.points = points.ToArray();
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
