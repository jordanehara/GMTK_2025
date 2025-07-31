using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;

    public void SetPosition(Vector3 pos)
    {
        if (CanAppend(pos))
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, pos);
        }
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
