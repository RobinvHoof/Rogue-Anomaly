using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lightning : BaseSpellEffect
{
    public override void TriggerSpellEffect(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)GetSpellDamage());
    }
}
