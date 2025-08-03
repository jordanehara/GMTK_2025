using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level = 1;
    bool loaded = false;

    [SerializeField] public List<GameObject> levels = new List<GameObject>();
    [SerializeField] public GameObject canvas;
    // [SerializeField] private LevelButton levelButton;

    void Awake()
    {
        // Get the background and proper enemy prefabs
        LoadLevel();
    }

    void Start()
    {
        // Add background and creatures to the scene
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        if (creatures.Count() == 0)
        {
            print("none found");
            canvas.SetActive(true);
        }
    }

    public void LoadLevel()
    {
        levels[level - 1].SetActive(true);
    }

    public void UnloadLevel()
    {
        levels[level - 1].SetActive(false);
    }
}
