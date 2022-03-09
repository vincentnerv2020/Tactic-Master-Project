using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : PlayerBaseState
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
        playerStateMachine.actionCamera.Priority = 0;
        playerStateMachine.selectionCamera.Priority = 0;
        playerStateMachine.aimingCamera.Priority = 10;
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                GameActions.OnTargetSelected(hitInfo.transform);
                playerStateMachine.SwitchState(playerStateMachine.ActionState);
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("It's working!");
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }
    }

    public override void OnEnterTrigger(PlayerStateMachine playerStateMachine, string triggerTag)
    {

    }


  
}
