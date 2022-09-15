using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            this.GetComponent<BaseSpellEffect>().TriggerSpellEffect(other);
            Destroy(gameObject);
        }
    }
}
