using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAndPrayMutation : BaseMutation
{
    [SerializeField]
    public GameObject weaponGroup;

    public SprayAndPrayMutation() : base("Spray and Pray", "Go wild and go hard! Time to lube up your gun and pockets! Your gun will fire twice as faster but deal slightly less damage, but your ammo will deplete twice as fast as well!") {}

    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {   
            case "startMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.attackspeedModifier += 1f;
                    gun.gunSettings.damageModifier -= 0.25f;
                }
                break;

            case "stopMutation":
                foreach(Gun gun in GetAllGuns())
                {
                    gun.gunSettings.attackspeedModifier -= 1f;
                    gun.gunSettings.damageModifier += 0.25f;
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
