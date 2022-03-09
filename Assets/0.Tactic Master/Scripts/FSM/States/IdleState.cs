using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        //Trasfer axis magnitude to the animation BlendTree
        playerStateMachine.anim.SetFloat("Speed", playerStateMachine.inputManager.movementAxis.magnitude);

        //Change camera 
        playerStateMachine.selectionCamera.Priority = 0;
        playerStateMachine.movementCamera.Priority = 10;
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 0;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {

        playerStateMachine.inputManager.magn = playerStateMachine.inputManager.movementAxis.magnitude;

        //If player drag the joystick
        if (playerStateMachine.inputManager.movementAxis.magnitude > 0)
        {
            playerStateMachine.SwitchState(playerStateMachine.RunState);
        }
    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }
}
