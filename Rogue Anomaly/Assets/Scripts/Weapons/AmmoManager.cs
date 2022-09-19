using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField, Min(0)] int clipSize = 10;
    [SerializeField, Min(0)] float cooldownTime = 0.5f;
    [SerializeField, Min(0)] float reloadTime = 2f;

    int currentAmmo;
    bool isReloading = false;
    bool isInCooldown = false;

    void Start()
    {
        currentAmmo = clipSize;
    }

    public bool CanFire()
    {
        if (isInCooldown || isReloading) return false;

        if (currentAmmo > 0)
        {
            currentAmmo--;
            if (cooldownTime > 0) StartCoroutine(CooldownRoutine());
            return true;
        }
        else if (currentAmmo <= 0)
        {
            if (reloadTime > 0) StartCoroutine(ReloadAmmoRoutine());
            else currentAmmo = clipSize;
        }
        
        return false;
    }

    public void ReloadAmmo()
    {
        StartCoroutine(ReloadAmmoRoutine());
    }

    IEnumerator ReloadAmmoRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipSize;
        isReloading = false;
    }

    IEnumerator CooldownRoutine()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isInCooldown = false;
    }
}
