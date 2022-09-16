using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2)]
    float fireDelay = 2;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    [Range(0, 2)]
    float bulletSpeed;

    Transform target;

    bool readyToShoot = true;

    private void Start()
    {
        target = GameObject.Find("FPSController").transform;
    }

    private void Update()
    {
        if (readyToShoot)
        { 
            StartCoroutine(FireWeapon());
        }
    }

    private IEnumerator FireWeapon()
    {
        readyToShoot = false;
        GameObject instance = Instantiate(bulletPrefab,transform.position,transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * bulletSpeed, ForceMode.Impulse);
        Destroy(instance, 3f);
        yield return new WaitForSeconds(fireDelay);
        readyToShoot = true;
    }
}
