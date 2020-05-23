using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro2Behaviour : StateMachineBehaviour
{
    float rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(rand == 0)
        {
            animator.SetTrigger("sideToSide2");
        } else
        {
            animator.SetTrigger("chargeUp2");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
