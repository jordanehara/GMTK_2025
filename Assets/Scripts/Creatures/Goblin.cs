using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creature
{
    void Start()
    {
        StartCoroutine(WalkPattern());
    }

    public override void Update()
    {
        base.Update();
    }

    public IEnumerator WalkPattern()
    {
        List<string> actionList = new List<string>() { "Walk", "Walk", "Walk", "Walk", "Walk" };
        foreach (string action in actionList)
        {
            yield return StartCoroutine(action);
        }
    }

    protected override void Attack()
    {
        print("goblin attack");
    }
}
