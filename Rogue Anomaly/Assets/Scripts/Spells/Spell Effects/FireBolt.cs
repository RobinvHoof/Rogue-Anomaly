using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;

public class FireBolt : BaseSpellEffect
{
    public override void TriggerSpellEffect(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)GetSpellDamage());
    }
}
