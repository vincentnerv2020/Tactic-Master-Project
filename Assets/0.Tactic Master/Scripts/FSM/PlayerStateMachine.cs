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
    public CinemachineVirtualCamera selectionCamera;

    //Other
    public Animator anim;

    public GameObject ActionButton;
    public GameObject CompleteSelectionButton;

    private void Awake()
    {
        movementScript = GetComponent<Movement>();
        inputManager = GetComponent<InputManager>();

        ActionButton.SetActive(false);
        CompleteSelectionButton.SetActive(false);
    }
    private void OnEnable()
    {
        GameActions.OnTargetSelected += OnTargetIdentified;
        GameActions.OnBoneSelected += ReturnToAim;
    }
 
    private void OnDisable()
    {
        GameActions.OnTargetSelected -= OnTargetIdentified;
        GameActions.OnBoneSelected -= ReturnToAim;
    }
    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
        //Test enemy canvas showing
      
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

    void OnTargetIdentified(Transform enemy)
    {
        //Handle camera view
        SetCameraToTarget(enemy.transform);
    }
    void SetCameraToTarget(Transform enemyBody)
    {
        movementCamera.Priority = 0;
        actionCamera.Priority = 0;
        aimingCamera.Priority = 0;
        selectionCamera.Priority = 10;
        selectionCamera.m_LookAt = enemyBody;
        selectionCamera.m_Follow = enemyBody;
        selectionCamera.m_Lens.FieldOfView = 75;
    }


    void ReturnToAim(Transform enemy)
    {
        selectionCamera.Priority = 0;
        aimingCamera.Priority = 10;
    }

    //When All targets setup
    public void FinishSelection()
    {
        this.SwitchState(this.ActionState);
    }
}
