using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun
{
    [SerializeField] public ParticleSystem laser;

    // private AmmoManager ammoManager;
    // private FragileVampirismMutation fragileVampirismMutation;

    private void Start() {
        ammoManager = FindObjectOfType<AmmoManager>();
        fragileVampirismMutation = FindObjectOfType<FragileVampirismMutation>();

        fillClip();
        StartCoroutine(CheckShoot());
    }

    private void OnEnable() {
        if (ammoManager != null && ammoInClip > ammoManager.GetCurrentAmmo(gunSettings.ammoType))
        {
            ammoInClip = ammoManager.GetCurrentAmmo(gunSettings.ammoType);
        }
    }

    private IEnumerator CheckShoot() 
    {
        while(true)
        {
            if (Input.GetButton("Fire1") && !isReloading)
            {
                if (ammoInClip > 0)
                {
                    for (int i = 0; i < gunSettings.palletsPerShot; i++)
                    {
                        if (ammoInClip <= 0) break;
                        ammoInClip--;
                        ammoManager.ReduceAmmo(gunSettings.ammoType);

                        RaycastHit hit;

                        Vector3 randomVector = 
                            Quaternion.AngleAxis(Random.Range(-gunSettings.palletSpread, gunSettings.palletSpread), Vector3.Cross((FPCamera.transform.forward).normalized, Vector3.up)) * (FPCamera.transform.forward).normalized +
                            Quaternion.AngleAxis(Random.Range(-gunSettings.palletSpread, gunSettings.palletSpread), Vector3.Cross((FPCamera.transform.forward).normalized, Vector3.right)) * (FPCamera.transform.forward).normalized;

                        // Trigger Fragile Vampirism mutation
                        fragileVampirismMutation.TriggerEvent(this.gameObject, "shotFired");

                        if (Physics.Raycast(FPCamera.transform.position, randomVector, out hit, gunSettings.range, ~gunSettings.penetrateLayers.value, QueryTriggerInteraction.Collide))
                        {                    
                            IHittable target = hit.collider.GetComponent<IHittable>();
                            if (target != null) 
                            {
                                target.Hit(this, FPCamera.gameObject);
                            }

                            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impact, 0.2f);
                        }
                    }
                
                    muzzleFlash.Play();
                    laser.Play();
                    gunEffectSound.Play();
                    FPCamera.transform.rotation *= Quaternion.Euler(-gunSettings.recoil, 0, 0);
                    yield return new WaitForSeconds(60 / gunSettings.rpm);
                }
                else if (ammoInClip <= 0 && ammoManager.GetCurrentAmmo(gunSettings.ammoType) > 0)
                {
                    StartCoroutine(ReloadGun());
                }
                
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator ReloadGun()
    {
        isReloading = true;
        gunReloadEffect.Play();
        yield return new WaitForSeconds(gunSettings.reloadTime);
        fillClip();
        isReloading = false;
    }

    void fillClip()
    {
        ammoInClip = Mathf.Clamp(ammoManager.GetCurrentAmmo(gunSettings.ammoType), 0, gunSettings.clipSize);
    }
}
