using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class PlayerStateMachine : MonoBehaviour
{
    public Joystick joystick;
    public GameObject joystickObj;
    public Movement movementScript;
    public PlayerBaseState currentState;
    //STATES
    public IdleState IdleState = new IdleState();
    public RunState RunState = new RunState();
    public AimState AimState = new AimState();
    public ActionState ActionState = new ActionState();

    public Vector2 movementAxis;
    public float movementSpeed;

    public float sqrMagn;
    public float magn;
    public float multiply;
    //Other
    public Animator anim;

    public CinemachineVirtualCamera movementCamera; //Priority 
    public CinemachineVirtualCamera aimingCamera;
    public CinemachineVirtualCamera actionCamera;

    private void Awake()
    {
        movementScript = GetComponent<Movement>();
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
        magn = movementAxis.magnitude;
       
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
