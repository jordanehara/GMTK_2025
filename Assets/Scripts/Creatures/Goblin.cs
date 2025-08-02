using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creature
{
    public Transform attackPoint;
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
        // print("attack");
        setState(CreatureStates.Attack);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        stateComplete = true;
        // print("attack done");
    }
}
