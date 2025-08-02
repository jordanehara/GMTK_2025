using System.Collections;
using UnityEngine;

public class Goblin : Creature
{
    void Start()
    {
        AddToActionsList("Walk", 4);
        AddToActionsList("Idle", 1);
        AddToActionsList("Attack", 4);
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
