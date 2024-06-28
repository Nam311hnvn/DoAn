using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SetFloatBehavior : StateMachineBehaviour
{

    public string floatName;
    public bool updateOnStateEnter,updateOnStateExit;
    public bool updateOnStateMachineEnter,updateOnstateMachineExit;
    public float valueOnEnter, valueOnExit;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnStateEnter)
        {
            animator.SetFloat(floatName, valueOnEnter);
        }
    }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnStateExit)
        {
            animator.SetFloat(floatName, valueOnExit);
        }
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if(!updateOnStateMachineEnter)
        {
            animator.SetFloat(floatName,valueOnEnter);
        }
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (!updateOnstateMachineExit)
        {
            animator.SetFloat(floatName, valueOnExit);
        }
    }
    


}