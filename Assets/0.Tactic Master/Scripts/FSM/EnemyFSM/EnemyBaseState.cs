using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemyStateMachine);

    public abstract void UpdateState(EnemyStateManager enemyStateMachine);

    public abstract void OnEnterTrigger(EnemyStateManager enemyStateMachine, string objTag);
}
    

