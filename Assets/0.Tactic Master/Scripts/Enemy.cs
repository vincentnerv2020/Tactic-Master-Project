using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool isAlive;

    public Collider mainCollider;
    public Collider[] AllCollider;

    public Rigidbody[] AllRigidbodies;


    public Transform[] bones; //0-Head, 1-Body, 2-L hand, 3-R.hand, 4-L.Leg, 5-R.Leg
    public GameObject canvas;
    public NavMeshAgent ai;
    EnemyStateManager esm;
    private void Awake()
    {
        ai = GetComponent<NavMeshAgent>();
        esm = GetComponent<EnemyStateManager>();
        mainCollider = GetComponent<Collider>();
        AllCollider = GetComponentsInChildren<Collider>(true);
        AllRigidbodies = GetComponentsInChildren<Rigidbody>();
        ActivateRagdoll(false);
    }

    void ActivateRagdoll(bool isRagdoll)
    {
        
        //ai.enabled = !isRagdoll;
        //esm.enabled = !isRagdoll;
        foreach (var col in AllCollider)
        col.enabled = isRagdoll;

        foreach (var rbs in AllRigidbodies)
            rbs.isKinematic = !isRagdoll;

        mainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponentInChildren<Animator>().enabled = !isRagdoll;
        isAlive = !isRagdoll;

    }

    public void Death()
    {
        ActivateRagdoll(true);
        GameActions.OnEnemyDied();
    }

    public void ShowBodyHitCanvas()
    {
        canvas.SetActive(true);
        Debug.Log("Canvas showed");
    }


     public void BoneSelect(int boneIndex)
     {
        GameActions.OnBoneSelected(bones[boneIndex]);
        canvas.SetActive(false);
    }
}
