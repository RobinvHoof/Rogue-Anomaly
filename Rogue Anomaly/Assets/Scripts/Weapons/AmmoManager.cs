using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField, Min(0)] int clipSize = 10;
    [SerializeField, Min(0)] float cooldownTime = 0.5f;
    [SerializeField, Min(0)] float reloadTime = 2f;
    [SerializeField] bool autoReload = false;

    int currentAmmo;
    bool isReloading = false;
    bool isInCooldown = false;

    public int ClipSize => clipSize;
    public int CurrentAmmo => currentAmmo;

    void Start()
    {
        currentAmmo = clipSize;
    }

    public AmmoFireResponse FireStatus()
    {
        if (isInCooldown) return AmmoFireResponse.Cooldown;
        if (isReloading) return AmmoFireResponse.Reloading;
        if (currentAmmo <= 0) return AmmoFireResponse.Empty;
        return AmmoFireResponse.Ready;
    }

    public bool Fire()
    {
        AmmoFireResponse status = FireStatus();
        if (status == AmmoFireResponse.Ready)
        {
            currentAmmo--;
            if (currentAmmo == 0 && autoReload && reloadTime > 0)
            {
                StartCoroutine(ReloadAmmoRoutine());
                return true;
            }
            if (cooldownTime > 0) StartCoroutine(CooldownRoutine());
            return true;
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
