using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Range(1, 5)]
    public int level;

    void Awake()
    {
        // Get the background and proper enemy prefabs
        switch (level)
        {

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
