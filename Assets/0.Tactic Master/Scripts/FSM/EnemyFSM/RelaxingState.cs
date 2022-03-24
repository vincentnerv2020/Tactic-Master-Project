using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelaxingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateMachine)
    {
        Debug.Log("Enter Relax State");
        enemyStateMachine.anim.SetBool("Relaxing", true);
        enemyStateMachine.agent.speed = 0;
        enemyStateMachine.fov.enabled = false;
        enemyStateMachine.StartCoroutine("Relaxing");
    }

    public override void UpdateState(EnemyStateManager enemyStateMachine)
    {
       
    }

    public override void OnEnterTrigger(EnemyStateManager enemyStateMachine, string objTag)
    {

    }

   

}
