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
    public EnemyHealth bossHealth;

    [SerializeField] GameObject minionPrefab;
    [SerializeField] float meleeRange = 10f;

    private bool bossSpawnMinions;

    [SerializeField] Transform minionPoint1;
    [SerializeField] Transform minionPoint2;

    [SerializeField] float navmeshStoppingDistanceRange = 20f;
    [SerializeField] float navmeshStoppingDistanceMelee = 2f;
    [SerializeField] EnemyWeapon weapon;
    [SerializeField] bool canSeePlayer = true;
    private Animator animator;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        weapon = GetComponent<EnemyWeapon>();
        animator = GetComponent<Animator>();
        bossHealth = GetComponent<EnemyHealth>();
        bossSpawnMinions = true;
    }

    void Update()
    {
        if(bossSpawnMinions && bossHealth.hitPoints <= bossHealth.maxHealth / 2)
        {
            bossSpawnMinions = false;
            Instantiate(minionPrefab, minionPoint1.position, minionPoint1.rotation);
            Instantiate(minionPrefab, minionPoint2.position, minionPoint2.rotation);
        }
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();
        
        Debug.DrawLine(transform.position, target.position, Color.red);

        int bitmask = ~((1 << 8) | (1 << 9));
        RaycastHit hit;
        if (Physics.Linecast(weapon.transform.position, target.position, out hit, bitmask))
        {
            Debug.Log(hit.collider.transform.gameObject.name + "de name");
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
        navMeshAgent.isStopped = false;
        animator.SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void EngageTarget()
    {
            if(!canSeePlayer)
            {
                animator.SetTrigger("walk");
                ChaseTarget();
            }
            else
            {
                if (DistanceToTarget < meleeRange)
                {
                    weapon.enabled = false;
                    if (DistanceToTarget >= navmeshStoppingDistanceMelee)
                    {
                        animator.SetTrigger("walk");
                        ChaseTarget();
                    }

                    if (DistanceToTarget <= navmeshStoppingDistanceMelee)
                    {
                        RotateToTarget();
                        MeleeAttackTarget();

                    }
                }
                else
                {
                    weapon.enabled = true;
                    if (DistanceToTarget >= navmeshStoppingDistanceRange)
                    {
                        animator.SetTrigger("walk");
                        ChaseTarget();
                    }

                    if (DistanceToTarget <= navmeshStoppingDistanceRange)
                    {
                        navMeshAgent.isStopped = true;
                        RotateToTarget();
                        animator.SetTrigger("idle");
                    }

                }
            }
           
        
        
        
    }

    private void MeleeAttackTarget()
    {     
        animator.SetBool("attack", true);       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, navmeshStoppingDistanceRange);
    }

    private void AttackHitEvent()
    {
        Debug.Log("attack");
    }
}
