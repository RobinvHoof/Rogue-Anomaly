using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicMissile : BaseSpellEffect
{
    float ManaDamage = 100;
    
    public override float GetSpellCost()
    {
        return 100;
    }

    public override void TriggerSpellEffect(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)ManaDamage);
    }
}
