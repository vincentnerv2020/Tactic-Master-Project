using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
       
        playerStateMachine.anim.SetFloat("Speed", playerStateMachine.movementAxis.magnitude);
        playerStateMachine.movementCamera.Priority = 10;
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.movementAxis.x = playerStateMachine.joystick.Horizontal;
        playerStateMachine.movementAxis.y = playerStateMachine.joystick.Vertical;
        playerStateMachine.movementScript.move.z = playerStateMachine.movementAxis.y;

        //If player drag the joystick
        if (playerStateMachine.movementAxis.magnitude > 0)
        {
            playerStateMachine.SwitchState(playerStateMachine.RunState);
        }
    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }
}
