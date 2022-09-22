using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTriggerEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject impactParticle;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.tag != "Player")
        {
            if(other.tag == "Enemy")
            {
                this.GetComponent<BaseSpellEffect>().TriggerSpellEffect(other);
            }
            GameObject obj = Instantiate(impactParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(obj, 1f);
            Destroy(gameObject);
        }
    }
}
