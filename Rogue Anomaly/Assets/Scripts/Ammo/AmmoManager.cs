using System;
using System.Collections;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    class AmmoSlot
    {
        public AmmoType ammoType;
        [Min(0)] public int ammoAmount;
        [Min(0)] public int maxAmmo;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoType, int percentage)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        int increase = Mathf.FloorToInt(((float)percentage / 100) * ammoSlot.maxAmmo);
        ammoSlot.ammoAmount = Mathf.Clamp(ammoSlot.ammoAmount + increase, 0, ammoSlot.maxAmmo);
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
