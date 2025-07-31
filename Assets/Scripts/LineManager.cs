using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineDrawer captureLine;
    private LineDrawer currentLine;

    void Update()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 1f;

        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(captureLine, currentPosition, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
            currentLine.SetPosition(currentPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
            // foreach (GameObject line in lines)
            // {
            //     Destroy(line);
            // }
        }
    }
}
