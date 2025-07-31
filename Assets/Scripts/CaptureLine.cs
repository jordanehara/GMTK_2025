using UnityEngine;

public class CaptureLine : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;

    [SerializeField]
    private float minDistance = 0.1f;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        previousPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 1f;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, currentPosition);
                previousPosition = currentPosition;
            }
        }
    }
}
