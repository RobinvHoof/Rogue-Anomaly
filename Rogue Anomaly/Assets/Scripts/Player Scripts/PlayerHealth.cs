using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int hitPoints;

    void Start()
    {
        hitPoints = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            // TODO Trigger death
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        hitPoints = Mathf.Clamp(hitPoints + healthAmount, 0, maxHealth);
    }
}
