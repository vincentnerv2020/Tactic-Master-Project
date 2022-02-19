using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateMachine playerStateMachine);

    public abstract void UpdateState(PlayerStateMachine playerStateMachine);

    public abstract void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag);
}
