using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileVampirismMutation : BaseMutation
{
    [SerializeField]
    public MutationManager mutationManager;

    [SerializeField]
    public PlayerHealth playerHealth;

    [SerializeField]
    [Min(0)]
    public int healingOnHit = 2;

    [SerializeField]
    [Min(0)]
    public int damageOnMiss = 1;

    
    
    public FragileVampirismMutation() : base("Fragile Vampirism", "Nom! Give me that health! You steal some of your enemies life on a hit shot, but take a small amount of damage on a missed shot") {}


    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "hitShot":
                    if (mutationManager.IsMutationActive(this))
                    {
                        playerHealth.RestoreHealth(healingOnHit);
                    }
                break;

            case "shotFired":
                    if (mutationManager.IsMutationActive(this))
                    {
                        playerHealth.TakeDamage(damageOnMiss);
                    }
                break;
        }
    }
}
