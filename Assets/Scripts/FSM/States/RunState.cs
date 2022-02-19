using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.movementCamera.Priority = 10;
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.anim.SetFloat("Speed", playerStateMachine.movementAxis.magnitude);
        playerStateMachine.movementAxis.x = playerStateMachine.joystick.Horizontal;
        playerStateMachine.movementAxis.y = playerStateMachine.joystick.Vertical;
        playerStateMachine.movementScript.move.x = playerStateMachine.movementAxis.x;
        playerStateMachine.movementScript.move.z = playerStateMachine.movementAxis.y;
        if (playerStateMachine.movementAxis.magnitude > 0 && playerStateMachine.movementAxis.magnitude < 0.75f)
        {
            playerStateMachine.movementScript.playerSpeed = playerStateMachine.movementSpeed * playerStateMachine.movementAxis.magnitude*4;
        }
        else
        {
            playerStateMachine.movementScript.playerSpeed = playerStateMachine.movementSpeed * playerStateMachine.movementAxis.magnitude*2;
        }
      

        //If player DOES NOT touch the joystick
        if (playerStateMachine.movementAxis.magnitude <= 0)
        {
            playerStateMachine.SwitchState(playerStateMachine.IdleState);
        }
    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {
        playerStateMachine.SwitchState(playerStateMachine.ActionState);

    }
}
