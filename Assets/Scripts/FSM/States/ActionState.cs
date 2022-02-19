using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.joystickObj.SetActive(false);
        playerStateMachine.movementScript.enabled = false;
        playerStateMachine.anim.SetBool("IsAiming", true);
        playerStateMachine.movementCamera.Priority = 0;
        playerStateMachine.actionCamera.Priority = 10;
        playerStateMachine.aimingCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {

    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }
}
