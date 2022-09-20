using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2)]
    public float fireDelay = 2;

    [SerializeField]
    public GameObject bulletPrefab;

    [SerializeField]
    [Range(0, 2)]
    public float bulletSpeed = 1;


    private Transform target;
    // private bool readyToShoot = true; ()

    private void Start()
    {
        target = GameObject.Find("FPSController").transform;
        StartCoroutine(FireWeapon());
    }

    /*
    private void Update()
    {
        if (readyToShoot)
        { 
            StartCoroutine(FireWeapon());
        }
    }
    */

    private IEnumerator FireWeapon()
    {
        while (true) // New (replaces readyToShoot variable)
        {
            //readyToShoot = false; ( Not needed? The "yield return new WaitForSeconds()" already ensures the unit cant fire when supposed to be on cooldown. In case need for animations or other purpose comment out again )
            GameObject instance = Instantiate(bulletPrefab,transform.position,transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(instance, 3f);
            yield return new WaitForSeconds(fireDelay);
            //readyToShoot = true;
        }
    }
}
