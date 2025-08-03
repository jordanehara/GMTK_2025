using System.Collections;
using UnityEngine;

public class OrcMage : Creature
{
    private GameObject orbInst;

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
        var attackType = Random.Range(2, 4);
        setState((CreatureStates)attackType);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        stateComplete = true;
    }


}
