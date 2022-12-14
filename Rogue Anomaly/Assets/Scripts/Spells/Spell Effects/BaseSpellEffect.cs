using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSpellEffect : MonoBehaviour
{
    [Header("Spell Icon")]
    [SerializeField]
    public Texture2D SpellIcon;

    [Header("Spell Properties")]
    [SerializeField]
    protected float SpellCost = 10f;
    [SerializeField]
    protected float SpellDamage = 10f;
    [SerializeField]
    protected float SpellFireRate = 1f;
    public virtual float GetSpellCost() { return SpellCost; }
    public float GetSpellDamage() { return SpellDamage; }
    public abstract void TriggerSpellEffect(Collider other);
    public float GetSpellFireRate() { return SpellFireRate; }
}
