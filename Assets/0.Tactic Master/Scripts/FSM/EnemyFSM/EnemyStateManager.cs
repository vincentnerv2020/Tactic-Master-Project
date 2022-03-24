using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{

    //STATES
    public EnemyBaseState currentEnemyState;

    // IDLE RELAXING - PATROLING - SEARCHING - TERMINATION(FOLLOW AND DESTROY)
    public RelaxingState RelaxingState = new RelaxingState();
    public PatrolingState PatrolingState = new PatrolingState();
    public SearchingState SearchingState = new SearchingState();
    public TerminationState TerminatonState = new TerminationState();

    public NavMeshAgent agent;
    public Animator anim;

    public Enemy enemyClass;

    public Transform[] waypoints;

    public FieldOfView fov;

    private void OnEnable()
    {
        GameActions.OnEnemyDied += Allert;
    }
    private void OnDisable()
    {
        GameActions.OnEnemyDied -= Allert;
    }
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponentInChildren<FieldOfView>();
        enemyClass = GetComponent<Enemy>();
    }

    private void Start()
    {
        currentEnemyState = PatrolingState;
        currentEnemyState.EnterState(this);
    }
    private void Update()
    {
        currentEnemyState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentEnemyState.OnEnterTrigger(this, other.tag);
    }
    public void SwitchEnemyState(EnemyBaseState state)
    {
        currentEnemyState = state;
        state.EnterState(this);
    }

    public IEnumerator Relaxing()
    {
        int randomTime = Random.Range(5, 10);
        yield return new WaitForSeconds(randomTime);
        SwitchEnemyState(PatrolingState);
    }


    public void Allert()
    {
        Debug.Log("I die...");
        //SwitchEnemyState(SearchingState);
    }
}
