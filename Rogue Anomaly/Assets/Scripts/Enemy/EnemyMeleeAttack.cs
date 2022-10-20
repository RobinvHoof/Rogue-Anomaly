using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        int damageAmount = (int)damage;
        target.TakeDamage(damageAmount);
        Debug.Log(name + " has struck " + target.name + " for " + damageAmount);
    }
}