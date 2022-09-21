using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    GameObject weaponGroup;

    private void Start()
    {
        weaponGroup = GameObject.Find("Weapons");
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            foreach (Transform child in weaponGroup.transform)
            {
                if (child.gameObject.name == weapon.name) child.gameObject.SetActive(true);
                else child.gameObject.SetActive(false);
            }
            Destroy(gameObject);
        }  
    }
}
