using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    int BulletDamage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(BulletDamage);
        }

        if(other.tag != "Enemy")
        {
            Destroy(gameObject);
        }

        
    }
}
