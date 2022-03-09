using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        //Turn off movement and joystick
        playerStateMachine.inputManager.HandleJoystick(false);
        playerStateMachine.movementScript.enabled = false;

        //Handle animation
        playerStateMachine.anim.SetBool("IsAiming", true);

        //Handle camera view
        playerStateMachine.movementCamera.Priority = 0;
        playerStateMachine.actionCamera.Priority = 10;
        playerStateMachine.aimingCamera.Priority = 0;
        playerStateMachine.selectionCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {

    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }
}
