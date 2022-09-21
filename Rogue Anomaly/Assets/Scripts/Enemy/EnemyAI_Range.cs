using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Range : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform target;

    const float turningSpeed = 2;


    void Start()
    {
        
        
    }

    void Update()
    {
       
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
    }
}

