using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTriggerEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject impactParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            if (other.tag == "Enemy")
            {
                this.GetComponent<BaseSpellEffect>().TriggerSpellEffect(other);
            }
            GameObject obj = Instantiate(impactParticle, gameObject.transform.position, gameObject.transform.rotation); // Make sure this looks at the camera!
            Destroy(obj, 1f);
            Destroy(gameObject);
        }
    }
}
