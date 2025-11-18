using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annoyed : StateMachineBehaviour
{
      override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I smell cat!");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I'm still smell cat and it makes annoys me!");
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Sweet relief from cat stink. I'm not angry anymore.");
    }
}
