using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annoyed : StateMachineBehaviour

{
 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I angry cause no cheese!");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("I am angry, player has cheese!");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Got my cheese no more angry!");
    }
}
    