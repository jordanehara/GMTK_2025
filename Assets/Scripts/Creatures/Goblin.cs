using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creature
{

    void Start()
    {
        AddToActionsList("Walk", 3);
        AddToActionsList("Idle", 1);
        AddToActionsList("Attack", 6);
    }

    public override void Update()
    {
        base.Update();
        if (stateComplete)
        {
            StartCoroutine(ChooseRandomActionFromList());
        }
    }

    protected override void Attack()
    {
        print("goblin attack");
        stateComplete = true;
    }
}
