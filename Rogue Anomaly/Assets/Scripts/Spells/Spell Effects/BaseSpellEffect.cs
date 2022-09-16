using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpellEffect : MonoBehaviour
{
    public abstract void TriggerSpellEffect(Collider other);
}
