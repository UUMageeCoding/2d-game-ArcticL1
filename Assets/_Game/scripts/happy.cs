using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happy : StateMachineBehaviour

{
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Yipppeee!");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I am yipppping, cos I am happy.");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I'm not yipppe anymore.");
    }

}

