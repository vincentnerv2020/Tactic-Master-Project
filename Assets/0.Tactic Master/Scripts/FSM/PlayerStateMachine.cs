using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class PlayerStateMachine : MonoBehaviour
{
    

    public Movement movementScript;
    public InputManager inputManager;

    //STATES
    public PlayerBaseState currentState;
    public IdleState IdleState = new IdleState();
    public RunState RunState = new RunState();
    public AimState AimState = new AimState();
    public ActionState ActionState = new ActionState();

    //CAMERAS
    public CinemachineVirtualCamera movementCamera; 
    public CinemachineVirtualCamera aimingCamera;
    public CinemachineVirtualCamera actionCamera;

    //Other
    public Animator anim;
    private void Awake()
    {
        movementScript = GetComponent<Movement>();
        inputManager = GetComponent<InputManager>();
    }
    private void OnEnable()
    {
        //GameActions.TurnLeft += LeanPlayerLeft;
    }
 
    private void OnDisable()
    {
       // GameActions.TurnLeft -= LeanPlayerLeft;
    }
    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnEnterTrigger(this, other.tag);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

  
}
