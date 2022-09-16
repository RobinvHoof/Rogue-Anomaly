using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject WeaponProjectile;

    [SerializeField]
    GameObject ImpactEffect;

    [SerializeField]
    [Range(0, 2)]
    float fireDelay = 2;

    [SerializeField]
    GameObject bulletPrefab;

    Transform target;


    private void Start()
    {
        target = GameObject.Find("FPSController").transform;
    }

    private void Update()
    {
        FireWeapon();
    }

    private IEnumerator FireWeapon()
    {
        GameObject instance =Instantiate(bulletPrefab,transform.position,transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce(target.position * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(fireDelay);
    }
}
