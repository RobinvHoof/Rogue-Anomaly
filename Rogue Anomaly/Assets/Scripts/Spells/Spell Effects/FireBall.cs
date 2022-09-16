using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : BaseSpellEffect
{
    [SerializeField]
    float radius = 10;
    

    public override void TriggerSpellEffect(Collider other)
    {
        RaycastHit[] entities;
        entities = Physics.SphereCastAll(other.transform.position, radius, transform.up);
        foreach (RaycastHit entity in entities)
        {
            if(entity.collider.gameObject.tag == "Enemy")
            {
                Destroy(entity.collider.gameObject);
            }
        }
       
    }
}
