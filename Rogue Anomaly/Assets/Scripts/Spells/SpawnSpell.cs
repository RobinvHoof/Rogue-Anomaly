using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject currentSpell;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(currentSpell, transform.position, transform.rotation);
            obj.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        }
    }
}
