using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SniperMutation : BaseMutation
{
    [SerializeField]
    public GameObject weaponGroup;
    
    public SniperMutation() : base("Sniper Mode", "Make you shoot twice as slow but deal twice the amount of damage") {}
    
    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "mutationTick":            
                GetActiveGun().gunSettings.attackspeedModifier = 0.1f;
                GetActiveGun().gunSettings.damageModifier = 5;

                foreach (Gun gun in GetInactiveGuns())
                {
                    gun.gunSettings.attackspeedModifier = 1;
                    gun.gunSettings.damageModifier = 1;
                }
                break;

            case "stopMutation":
                GetActiveGun().gunSettings.attackspeedModifier = 1;
                GetActiveGun().gunSettings.damageModifier = 1;
                break;
        }
    }

    private Gun GetActiveGun()
    {
        List<GameObject> gunList = new List<GameObject>();
        foreach(Transform child in weaponGroup.transform)
            gunList.Add(child.gameObject);

        GameObject activeGun = gunList.Find(x => x.activeSelf);

        if (activeGun == null)
            return null;

        return activeGun.GetComponent<Gun>();
    }

    private List<Gun> GetInactiveGuns()
    {
        List<GameObject> gunGameObjectList = new List<GameObject>();
        foreach(Transform child in weaponGroup.transform)
            gunGameObjectList.Add(child.gameObject);
        
        List<GameObject> inactiveGuns = gunGameObjectList.FindAll(x => x.activeSelf == false);

        List<Gun> gunList = new();
        foreach(GameObject gun in inactiveGuns)
        {
            gunList.Add(gun.GetComponent<Gun>());
        }
        return gunList;
    }
}