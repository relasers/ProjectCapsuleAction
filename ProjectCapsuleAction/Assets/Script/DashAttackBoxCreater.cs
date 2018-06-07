using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackBoxCreater : StateMachineBehaviour {

    public int damage;
    public GameObject AttackBox;

    public GameObject PlayerHeader;
    public GameObject Particle;

    public bool attackExecuted = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackExecuted = false;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        float myTime = animationState.normalizedTime;


        if (attackExecuted == false && myTime > 0.1f)
        {
            attackExecuted = true;
            GameObject new_attack_box = Instantiate(AttackBox, animator.rootPosition - animator.transform.forward * 2.5f, animator.rootRotation);
            GameObject new_particle = Instantiate(Particle, animator.rootPosition - animator.transform.forward * 2.5f, animator.rootRotation);
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
