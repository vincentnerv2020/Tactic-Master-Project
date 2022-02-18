using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAlive;

    public Collider mainCollider;
    public Collider[] AllCollider;

    public Rigidbody[] AllRigidbodies;
    private void Awake()
    {
        mainCollider = GetComponent<Collider>();
        AllCollider = GetComponentsInChildren<Collider>(true);
        AllRigidbodies = GetComponentsInChildren<Rigidbody>();
        ActivateRagdoll(false);
    }
    private void Start()
    {
        
    }

    void ActivateRagdoll(bool isRagdoll)
    {
        isAlive = !isRagdoll;

        foreach(var col in AllCollider)
        col.enabled = isRagdoll;

        foreach (var rbs in AllRigidbodies)
            rbs.isKinematic = !isRagdoll;

        mainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponentInChildren<Animator>().enabled = !isRagdoll;

    }

    public void Death()
    {

        ActivateRagdoll(true);
    }
}
