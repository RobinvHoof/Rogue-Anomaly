using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            Debug.Log("Boom!");
            
        }

        if(other.tag != "Enemy")
        {
            Destroy(gameObject);
        }

        
    }
}
