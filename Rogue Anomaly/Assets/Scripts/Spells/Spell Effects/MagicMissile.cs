using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : BaseSpellEffect
{
    float ManaDamage;

    public override float GetSpellCost()
    {
        return ManaDamage;
    }

    private void Start()
    {
        ManaDamage = GameObject.Find("SpellSystem").GetComponent<SpawnSpell>().CurrentMana;
    }
    public override void TriggerSpellEffect(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)ManaDamage);
    }
}
