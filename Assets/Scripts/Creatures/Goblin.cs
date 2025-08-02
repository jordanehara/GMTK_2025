using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creature
{

    void Start()
    {
        AddToActionsList("Walk", 3);
        AddToActionsList("Idle", 2);
        AddToActionsList("Attack", 5);
    }

    public override void Update()
    {
        base.Update();
        if (stateComplete)
        {
            StartCoroutine(ChooseRandomActionFromList());
        }
    }

    protected IEnumerator Attack()
    {
        print("attack");
        var length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        print(length);
        setState(CreatureStates.Attack);
        yield return new WaitForSeconds(length);
        stateComplete = true;
        print("attack done");
    }
}
