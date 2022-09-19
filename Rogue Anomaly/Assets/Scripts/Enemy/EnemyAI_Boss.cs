using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Boss : MonoBehaviour
{
    Transform target;

    const float turningSpeed = 2;
    float DistanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    [SerializeField] float meleeRange = 10f;

    [SerializeField] float navmeshStoppingDistanceRange = 20f;
    [SerializeField] float navmeshStoppingDistanceMelee = 2f;
    [SerializeField] EnemyWeapon weapon;
    [SerializeField] bool canSeePlayer;

    void Start()
    {
        target = GameObject.Find("FPSController").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        weapon = GetComponent<EnemyWeapon>();
    }

    void Update()
    {
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();
        
        Debug.DrawLine(transform.position, target.position, Color.red);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            if(hit.collider.tag != "Player")
            {
                canSeePlayer = false;
            }
            else
            {
                canSeePlayer = true;
            }
            
        }
        
            
        
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void EngageTarget()
    {
        if (DistanceToTarget >= navMeshAgent.stoppingDistance && canSeePlayer)
        {
            
            if(DistanceToTarget > meleeRange && canSeePlayer)
            {
                weapon.enabled = true;
                navMeshAgent.stoppingDistance = navmeshStoppingDistanceRange;
            }
            else
            {
                navMeshAgent.stoppingDistance = navmeshStoppingDistanceMelee;
                weapon.enabled = false;
                
            }
            ChaseTarget();
            
        }
        else
        {
            ChaseTarget();
            navMeshAgent.stoppingDistance = navmeshStoppingDistanceMelee;
        }

        if (DistanceToTarget <= navMeshAgent.stoppingDistance)
        {
            RotateToTarget();
            MeleeAttackTarget();
           
        }
    }

    private void MeleeAttackTarget()
    {
        Debug.Log("attack");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}
