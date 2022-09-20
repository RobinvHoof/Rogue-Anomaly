using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellTriggerDrag : MonoBehaviour
{

    public List<GameObject> TaggedEntities;

    public bool isMoving { get; private set; }

    private void Start()
    {
        isMoving = true;
        TaggedEntities = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TaggedEntities.Add(other.gameObject);
        }
        else if(other.tag == "Player") { return; }
        this.GetComponent<BaseSpellEffect>().TriggerSpellEffect(other);

    }

    private void Update()
    { 
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 1 && isMoving)
        {
            isMoving = false;
        }
    }
}
