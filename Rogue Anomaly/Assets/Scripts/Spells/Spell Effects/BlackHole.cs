using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : BaseSpellEffect
{

    [Header("Black Hole Settings")]
    [SerializeField]
    float InitialAreaOfEffect = 1;

    [SerializeField]
    float GrowthPerSecond = 3;

    [SerializeField]
    float RadiusMultiplierOnHit = 1.5f;

    [SerializeField]
    [Range(0,45)]
    int ContactDestructionTime = 5;

    [SerializeField]
    GameObject impactParticle;

    bool isGrowing = false;

    bool baseSize = true;

    bool hasHitEnemy = false;

    SpellTriggerDrag drag;

    private void Start()
    {
        GetComponent<SphereCollider>().radius = InitialAreaOfEffect;
        drag = GetComponent<SpellTriggerDrag>();
    }

    public override void TriggerSpellEffect(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        { 
            hasHitEnemy = true;
            return;
        }
        if (other.gameObject.tag == "Untagged" && hasHitEnemy)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void Update()
    {
        foreach (GameObject Enemy in drag.TaggedEntities)
        {
            Enemy.transform.position = gameObject.transform.position;
        }

        if (!isGrowing)
        {
            StartCoroutine(GrowRadius());
        }

        if (!drag.isMoving && baseSize)
        {
            impactParticle = Instantiate(impactParticle, transform);
            GetComponent<SphereCollider>().radius = InitialAreaOfEffect * RadiusMultiplierOnHit;
            baseSize = false;
            Destroy(gameObject, ContactDestructionTime);
        }
    }

    IEnumerator GrowRadius()
    {
        isGrowing = true;
        GetComponent<SphereCollider>().radius += GrowthPerSecond;
        yield return new WaitForSeconds(1);
        isGrowing = false;
    }

    private void OnDestroy()
    {
        drag.TaggedEntities.Clear();
    }
}
