using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHandler : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI currentAmmoCounter;

    [SerializeField]
    public TextMeshProUGUI ammoPoolCounter;

    [SerializeField]
    public AmmoManager ammoManager;

    [SerializeField]
    public GameObject weaponGroup;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        List<GameObject> gunList = new List<GameObject>();
        foreach(Transform child in weaponGroup.transform)
            gunList.Add(child.gameObject);

        GameObject activeGun = gunList.Find(x => x.activeSelf);
        if (activeGun == null)
        {
            currentAmmoCounter.SetText("");
            ammoPoolCounter.SetText("");
            return;
        }

        AmmoType activeAmmoType = activeGun.GetComponent<Gun>().gunSettings.ammoType;
        
        currentAmmoCounter.SetText(activeGun.GetComponent<Gun>().ammoInClip.ToString());
        ammoPoolCounter.SetText(ammoManager.GetCurrentAmmo(activeAmmoType).ToString());
    }
}
