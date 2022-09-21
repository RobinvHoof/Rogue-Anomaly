using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Range : MonoBehaviour
{
    const float turningSpeed = 2;
    float distanceToTarget = Mathf.Infinity;

    Transform target;
    NavMeshAgent navMeshAgent;
    Animator enemyAnimator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget >= navMeshAgent.stoppingDistance) ChaseTarget();
        RotateToTarget();
    }

    void ChaseTarget()
    {
        enemyAnimator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
    }
}
