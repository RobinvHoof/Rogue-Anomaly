using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTriggerEnviorment : MonoBehaviour
{
    [SerializeField]
    public GameObject impactParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            this.GetComponent<BaseSpellEffect>().TriggerSpellEffect(other);
            GameObject obj = Instantiate(impactParticle, gameObject.transform.position, gameObject.transform.rotation); // Make sure this looks at the camera!
            Destroy(obj, 1f);
            Destroy(gameObject);
        }
    }
}
