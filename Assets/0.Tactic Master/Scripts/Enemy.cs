using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAlive;

    public Collider mainCollider;
    public Collider[] AllCollider;

    public Rigidbody[] AllRigidbodies;


    public Transform[] bones; //0-Head, 1-Body, 2-L hand, 3-R.hand, 4-L.Leg, 5-R.Leg
    public GameObject canvas;
    private void Awake()
    {
        mainCollider = GetComponent<Collider>();
        AllCollider = GetComponentsInChildren<Collider>(true);
        AllRigidbodies = GetComponentsInChildren<Rigidbody>();
        ActivateRagdoll(false);
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
