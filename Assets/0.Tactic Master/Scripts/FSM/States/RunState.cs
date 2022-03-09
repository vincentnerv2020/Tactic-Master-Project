using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.inputManager.HandleJoystick(true);
        playerStateMachine.selectionCamera.Priority = 0;
        playerStateMachine.movementCamera.Priority = 10;
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        //Trasfer axis magnitude to the animation BlendTree
        playerStateMachine.anim.SetFloat("Speed", playerStateMachine.inputManager.movementAxis.magnitude);


        //Modify player speed
        if (playerStateMachine.inputManager.movementAxis.magnitude > 0 && playerStateMachine.inputManager.movementAxis.magnitude < 0.75f)
        {
            playerStateMachine.movementScript.playerSpeed = playerStateMachine.inputManager.movementSpeed * playerStateMachine.inputManager.movementAxis.magnitude * playerStateMachine.movementScript.runModifier;
        }
        else
        {
            playerStateMachine.movementScript.playerSpeed = playerStateMachine.inputManager.movementSpeed * playerStateMachine.inputManager.movementAxis.magnitude* playerStateMachine.movementScript.walkModifier;
        }

        //If player DOES NOT touch the joystick
        if (playerStateMachine.inputManager.movementAxis.magnitude <= 0)
        {
            playerStateMachine.SwitchState(playerStateMachine.IdleState);
        }
    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

        
        //Must be aim state
       // playerStateMachine.SwitchState(playerStateMachine.ActionState);
        playerStateMachine.SwitchState(playerStateMachine.AimState);

    }
}
