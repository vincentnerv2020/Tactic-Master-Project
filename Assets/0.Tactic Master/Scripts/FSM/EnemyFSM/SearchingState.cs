using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateMachine)
    {
        Debug.Log("Enter Patroling State");
        enemyStateMachine.agent.speed = 2;
        enemyStateMachine.anim.SetBool("Relaxing", false);
        enemyStateMachine.anim.SetBool("Patroling", false);
        // enemyStateMachine.anim.SetBool("Patroling", false);
        enemyStateMachine.agent.SetDestination(enemyStateMachine.waypoints[Random.Range(0, enemyStateMachine.waypoints.Length)].position);
        enemyStateMachine.fov.enabled = true;
    }

    public override void UpdateState(EnemyStateManager enemyStateMachine)
    {

    }

    public override void OnEnterTrigger(EnemyStateManager enemyStateMachine, string objTag)
    {

    }

}
