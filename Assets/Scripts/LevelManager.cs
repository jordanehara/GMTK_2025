using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Range(1, 5)]
    public int level;

    public Creature creature;
    private List<Creature> creatures = new List<Creature>();

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
