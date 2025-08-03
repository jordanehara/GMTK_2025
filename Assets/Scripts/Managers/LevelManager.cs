using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level = 1;

    [SerializeField] public List<GameObject> levels = new List<GameObject>();
    [SerializeField] private GameObject canvas;
    // [SerializeField] private LevelButton levelButton;

    void Awake()
    {
        // Get the background and proper enemy prefabs
        levels[level - 1].SetActive(true);
    }

    void Start()
    {
        // Add background and creatures to the scene
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        if (creatures.Length == 0)
        {
            canvas.SetActive(true);
        }
    }
}
