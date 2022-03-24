using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateMachine)
    {
        Debug.Log("Enter Patroling State");
        enemyStateMachine.agent.speed = 2;
        enemyStateMachine.anim.SetBool("Relaxing", false);
        enemyStateMachine.anim.SetBool("Patroling", true);
        enemyStateMachine.agent.SetDestination(enemyStateMachine.waypoints[Random.Range(0, enemyStateMachine.waypoints.Length)].position);
        enemyStateMachine.fov.enabled = true;
    }

    public override void UpdateState(EnemyStateManager enemyStateMachine)
    {
        float distanceToDestination = Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.agent.destination);
        if (distanceToDestination < enemyStateMachine.agent.stoppingDistance)
        {
            enemyStateMachine.SwitchEnemyState(enemyStateMachine.RelaxingState);
        }
    }

    public override void OnEnterTrigger(EnemyStateManager enemyStateMachine, string objTag)
    {
      
    }
 
}
