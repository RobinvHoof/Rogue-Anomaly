using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBastardMutation : BaseMutation
{
    [SerializeField]
    public MutationManager mutationManager;

    [SerializeField]
    public PlayerHealth playerHealth;

    [SerializeField]
    [Range(0, 100)]
    public float dodgeChance = 25f;

    public LuckyBastardMutation() : base("Lucky Bastard", "Oh you luck bastrad! Have a change to negate any form of damage") {}

    // playerHit:
    //   - parameters[0] : The amount of damage the player was hit for
    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "playerHit":
                if (mutationManager.IsMutationActive(this))
                {
                    if (dodgeChance > Random.Range(0, 100))
                    {                        
                        playerHealth.RestoreHealth(System.Convert.ToInt32(parameters[0]));
                    }                    
                }
                break;
        }
    }
}
