using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField, Min(0)] int clipSize = 10;
    [SerializeField, Min(0)] float reloadTime = 2f;
    [SerializeField] bool autoReload = false;

    int currentAmmo;
    bool isReloading = false;

    public int ClipSize => clipSize;
    public int CurrentAmmo => currentAmmo;

    void Start()
    {
        currentAmmo = clipSize;
    }

    public AmmoStatusResponse AmmoStatus()
    {
        if (isReloading) return AmmoStatusResponse.Reloading;
        if (currentAmmo <= 0) return AmmoStatusResponse.Empty;
        return AmmoStatusResponse.Ready;
    }

    public bool ReduceAmmo()
    {
        AmmoStatusResponse status = AmmoStatus();
        if (status == AmmoStatusResponse.Ready)
        {
            currentAmmo--;
            if (currentAmmo == 0 && autoReload && reloadTime > 0)
            {
                StartCoroutine(ReloadAmmoRoutine());
            }
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
}
