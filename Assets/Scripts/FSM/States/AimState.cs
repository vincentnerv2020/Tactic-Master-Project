using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.joystickObj.SetActive(false);
        playerStateMachine.movementCamera.Priority = 0;
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 10;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {

    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }
}
