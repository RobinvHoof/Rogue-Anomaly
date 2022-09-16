using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : BaseSpellEffect
{
    public override void TriggerSpellEffect(Collider other)
    {
        Destroy(other.gameObject);
    }
}
