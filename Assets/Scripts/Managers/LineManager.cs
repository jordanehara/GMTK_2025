using System;
using TMPro;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    #region Stats
    [SerializeField] public int health = 10;
    public int score = 0;
    #endregion

    [SerializeField] private AudioClip drawSound;
    public LineDrawer captureLine;
    private LineDrawer currentLine;
    public Pointer pointer;
    public EdgeCollider2D edgeCollider;
    private Vector3 currentPosition;
    public bool isDrawing = false;

    void Update()
    {
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 1f;

        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            currentLine = Instantiate(captureLine, currentPosition, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
            if (currentLine != null)
            {
                pointer.transform.position = currentPosition;
                currentLine.SetPosition(currentPosition, edgeCollider);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetLineDrawer();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            currentLine.CheckCapture(collision.transform.position);
        }
        else
        {
            GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
            foreach (GameObject creature in creatures)
            {
                creature.GetComponent<Creature>().ResetHealth();
            }
        }
        DestroyLines();
        isDrawing = true;
        currentLine = Instantiate(captureLine, currentPosition, Quaternion.identity);
    }

    public void DestroyLines()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }

    public void ResetLineDrawer()
    {
        DestroyLines();
        isDrawing = false;
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        foreach (GameObject creature in creatures)
        {
            creature.GetComponent<Creature>().ResetHealth();
        }
    }

    #region Stat modification
    public void TakeDamage()
    {
        health -= 1;
        print("remaining health: " + health);
        if (health == 0)
        {
            print("dead");
        }
    }

    #endregion
}

