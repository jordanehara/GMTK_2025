using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Range(1, 5)]
    public int level;
    public

    void Awake()
    {
        // Get the background and proper enemy prefabs
        switch (level)
        {
            case 1:
                break;
        }
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
