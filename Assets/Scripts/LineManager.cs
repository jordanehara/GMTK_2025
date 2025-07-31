using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineDrawer captureLine;
    private LineDrawer currentLine;
    public Pointer pointer;
    public EdgeCollider2D edgeCollider;
    private Vector3 currentPosition;

    void Update()
    {
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 1f;

        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(captureLine, currentPosition, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
            pointer.transform.position = currentPosition;
            currentLine.SetPosition(currentPosition, edgeCollider);
        }

        if (Input.GetMouseButtonUp(0))
        {
            DestroyLines();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyLines();
        currentLine = Instantiate(captureLine, currentPosition, Quaternion.identity);
    }

    private void DestroyLines()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }
}
