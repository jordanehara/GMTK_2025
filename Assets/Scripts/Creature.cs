using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    #region Stats
    [SerializeField]
    public int maxHealth;
    private int health;
    #endregion

    public List<int> captureLines = new List<int>();
    public LineManager lineManager;

    void Update()
    {
        if (!lineManager.isDrawing)
        {
            health = maxHealth;
            captureLines.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer" || collision.gameObject.tag == "Line")
        {
            lineManager.DestroyLines();
            health = maxHealth;
        }
    }

    public void Capture(int lineId)
    {
        if (lineManager.isDrawing && health > 0)
        {
            health -= 1;
            if (health == 0)
            {
                print(name + " captured");
            }
            else
            {
                captureLines.Add(lineId);
            }
        }
    }
}
