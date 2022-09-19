using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int increasePercentage = 25;
    [SerializeField] AmmoType ammoType;

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AmmoManager>().IncreaseAmmo(ammoType, increasePercentage);
            Destroy(gameObject);
        }  
    }
}
