using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSynthesizerMutation : BaseMutation
{
    [SerializeField]
    public MutationManager mutationManager;

    [SerializeField]
    public AmmoManager ammoManager;

    [SerializeField]
    [Range(0, 1)]
    public float maxAmmoMultiplier = 0.75f;

    [SerializeField]
    [Range(0, 100)]
    public int regenAmountPerTick = 20;

    public AmmoSynthesizerMutation() : base("Doubletap", "If one shot isnt enough make sure to doubletap to secure the kill! Your accuracy is slightly reduced but you shoot an extra pallet per shot for free!") {}

    private Dictionary<AmmoType, int> subtractedAmmoCap;

    public void Start() 
    {
        subtractedAmmoCap = new();
    }

    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {           
            case "startMutation":
                foreach(AmmoManager.AmmoSlot slot in ammoManager.ammoSlots)
                {
                    subtractedAmmoCap.Add(slot.ammoType, (int)(slot.maxAmmo * (1 - maxAmmoMultiplier)));
                    slot.maxAmmo = (int)((float)slot.maxAmmo * maxAmmoMultiplier);
                }
                
                break;
            
            case "stopMutation":
                foreach(AmmoManager.AmmoSlot slot in ammoManager.ammoSlots)
                {
                    slot.maxAmmo += subtractedAmmoCap[slot.ammoType];
                }
                break;

            case "timerTick":
                if (mutationManager.IsMutationActive(this))
                {
                    foreach(AmmoManager.AmmoSlot slot in ammoManager.ammoSlots)
                    {
                        ammoManager.IncreaseAmmo(slot.ammoType, regenAmountPerTick);
                    }
                }
                break;
        }
    }
}
