using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpellEffect : MonoBehaviour
{
    [Header("Spell Properties")]
    [SerializeField]
    float SpellCost = 10f;
    [SerializeField]
    float SpellDamage = 10f;
    public float GetSpellCost() { return SpellCost; }
    public float GetSpellDamage() { return SpellDamage; }

    public abstract void TriggerSpellEffect(Collider other);
}
