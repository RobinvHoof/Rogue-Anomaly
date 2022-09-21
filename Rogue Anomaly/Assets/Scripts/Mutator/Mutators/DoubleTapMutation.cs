using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapMutation : BaseMutation
{
    [SerializeField]
    public GameObject weaponGroup;

    public DoubleTapMutation() : base("Doubletap", "If one shot isnt enough make sure to doubletap to secure the kill! Your accuracy is slightly reduced but you shoot an extra pallet per shot for free!") {}

    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {           
            case "startMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.palletsPerShot += 1;
                    gun.gunSettings.palletSpread += 10f;
                }
                break;

            case "stopMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.attackspeedModifier -= 1;
                    gun.gunSettings.damageModifier -= 10f;
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
