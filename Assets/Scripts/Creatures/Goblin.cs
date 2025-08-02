using System.Collections;
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
        setState(CreatureStates.Attack);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        stateComplete = true;
    }
}
