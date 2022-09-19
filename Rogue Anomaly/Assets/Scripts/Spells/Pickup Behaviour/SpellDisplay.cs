using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpellDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject DisplayParticle;

    [SerializeField]
    GameObject SpellToGive;


    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        DisplayParticle = Instantiate(DisplayParticle,transform);
        DisplayParticle.transform.position = spawnPos;
        DisplayParticle.transform.rotation = rotation;

        GetComponent<TextMeshPro>().text = SpellToGive.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<SpawnSpell>().currentSpell = SpellToGive;
            Destroy(gameObject);
        }
    }
}
