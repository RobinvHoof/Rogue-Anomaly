using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SniperMutation : BaseMutation
{
    [SerializeField]
    public GameObject weaponGroup;

    public SniperMutation() : base("Sniper Mode", "Ready your scopes and pull out the campfire. You fire four times slower but your shots deal five times as much damage!") {}
    
    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {           
            case "startMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.attackspeedModifier -= 0.75f;
                    gun.gunSettings.damageModifier += 4f;
                }
                break;

            case "stopMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.attackspeedModifier += 0.75f;
                    gun.gunSettings.damageModifier -= 4f;
                }                
                break;
        }
    }

    private List<Gun> GetAllGuns()
    {
        List<GameObject> gunGameObjectList = new List<GameObject>();
        foreach(Transform child in weaponGroup.transform)
            gunGameObjectList.Add(child.gameObject);

        List<Gun> gunList = new();
        foreach(GameObject gun in gunGameObjectList)
        {
            gunList.Add(gun.GetComponent<Gun>());
        }
        return gunList;
    }
}