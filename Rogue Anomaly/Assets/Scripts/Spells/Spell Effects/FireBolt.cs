using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;

public class FireBolt : BaseSpellEffect
{
    public override void TriggerSpellEffect(Collider other)
    {
        other.GetComponent<EnemyHealth>().TakeDamage((int)this.GetSpellDamage());
    }
}
