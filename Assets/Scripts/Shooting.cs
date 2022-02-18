using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;
public class Shooting : MonoBehaviour
{
    private Animator anim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletRadius;
    public List<Transform> targetsList = new List<Transform>();
    public float bulletSpeed;
    public Ease bulletEase;
    public float bulletForce;
    public float upForce;

    public MMFeedbacks bodyHitFeedBack;


    public MMFeedbacks slowMo;

    public int index = 0;
    public float rotationSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Action()
    {
        if (targetsList.Count > 0)
        {
            //Check how Many Targets we have and play special animation by trigger
            switch (targetsList.Count)
            {
                case 1:
                    {
                       anim.SetTrigger("SingleShot");
                       break;
                    }
                case 2:
                    {
                        anim.SetTrigger("DoubleShot");
                        break;
                    }
                case 3:
                    {
                        anim.SetTrigger("TrippleShot");
                        break;
                    }
                case 4:
                    {
                        anim.SetTrigger("QuadroShot");
                        break;
                    }
            }
        }
    }
    public void Shoot()
    {
        var currentIndex = index;
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
        bulletInstance.transform.DOMove(targetsList[currentIndex].position, bulletSpeed).SetEase(bulletEase).SetSpeedBased(true).OnStart(SlowMo).OnComplete(() => BulletContact(bulletInstance, targetsList[currentIndex]));
        index++;
    }

    void BulletContact(GameObject obj, Transform target)
    {
        Enemy enemyInstance = target.GetComponentInParent<Enemy>();
        
        enemyInstance.Death();
        Collider[] bones = Physics.OverlapSphere(obj.transform.position, bulletRadius);
        foreach (var col in bones)
        {
            if (col.GetComponent<Rigidbody>())
            {
                Rigidbody bone = col.GetComponent<Rigidbody>();
                bone.AddForce(obj.transform.forward * bulletForce + Vector3.up*upForce);
                break;
            }
            else
            {
                continue;
            }

        }
        bodyHitFeedBack.PlayFeedbacks();
       
        Destroy(obj);
    }



    public void RotateTargetAndShoot()
    {
        if (index >= targetsList.Count)
        {
            index = 0;
        }
        transform.DOLookAt(targetsList[index].position,rotationSpeed,AxisConstraint.None, Vector3.up).OnComplete(Shoot);
    }
    void SlowMo()
    {
        slowMo.PlayFeedbacks();
    }
}
