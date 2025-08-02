using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    [SerializeField] public List<GameObject> levels = new List<GameObject>();

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

    }
}
