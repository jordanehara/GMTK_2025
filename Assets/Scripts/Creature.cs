using System.Collections.Generic;
using System.Linq;
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

    void Start()
    {

    }

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
        print(lineId);
        if (lineManager.isDrawing && !captureLines.Contains(lineId))
        {
            health -= 1;
            if (health == 0)
            {
                print("captured");
            }
            else
            {
                print(health);
                captureLines.Add(lineId);
                print(captureLines.Count);
            }
        }
    }
}
