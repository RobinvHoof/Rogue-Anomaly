using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Attack
{
    [System.Serializable]
    public class GunSettings {
        public AmmoType ammoType;

        [Min(0)]
        public int clipSize = 10;

        [Min(0)]
        public float rpm = 60;

        [Min(0)]//
        public float reloadTime = 2;

        [Min(0)]
        public float range = 100;

        [Min(1)]
        public int palletsPerShot = 1;

        [Range(0, 90)]
        public float palletSpread = 0;

        [Range(0, 45)]
        public float recoil = 0;

        [Min(0)]
        public float damageModifier = 1;

        [Min(0)]
        public float attackspeedModifier = 1;

        public LayerMask penetrateLayers;
    }

    [SerializeField] 
    public GunSettings gunSettings;

    [SerializeField] 
    public Camera FPCamera;

    [SerializeField] 
    public ParticleSystem muzzleFlash;

    [SerializeField] 
    public GameObject hitEffect;

    public AudioSource gunEffectSound;
    public AudioSource gunReloadEffect;

    protected AmmoManager ammoManager;
    public int ammoInClip {get; set;}
    public bool isReloading {get; set;} = false;
    
    protected FragileVampirismMutation fragileVampirismMutation;

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
                        if (ammoInClip <= 0) break;//
                        ammoInClip--;
                        ammoManager.ReduceAmmo(gunSettings.ammoType);//
                        
                        RaycastHit hit;

                        Vector3 randomVector = 
                            Quaternion.AngleAxis(Random.Range(-gunSettings.palletSpread, gunSettings.palletSpread), Vector3.Cross((FPCamera.transform.forward).normalized, Vector3.up)) * (FPCamera.transform.forward).normalized +
                            Quaternion.AngleAxis(Random.Range(-gunSettings.palletSpread, gunSettings.palletSpread), Vector3.Cross((FPCamera.transform.forward).normalized, Vector3.right)) * (FPCamera.transform.forward).normalized;

                        //Trigger Fragile Vampirism mutation
                        fragileVampirismMutation.TriggerEvent(this.gameObject, "shotFired");

                        if (Physics.Raycast(FPCamera.transform.position, randomVector, out hit, gunSettings.range, ~gunSettings.penetrateLayers.value, QueryTriggerInteraction.Collide))
                        {                    
                            IAttackable target = hit.collider.GetComponent<IAttackable>();
                            if (target != null) 
                            {
                                target.TakeDamage((int)(attackSettings.damage * gunSettings.damageModifier));
                            }                            

                            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impact, 0.2f);
                        }
                    }

                    muzzleFlash.Play();
                    gunEffectSound.Play(); 
                    FPCamera.transform.rotation *= Quaternion.Euler(-gunSettings.recoil, 0, 0);
                    
                    yield return new WaitForSeconds(60 / (gunSettings.rpm * gunSettings.attackspeedModifier));
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
        yield return new WaitForSeconds(gunSettings.reloadTime);//
        fillClip();
        isReloading = false;
    }

    void fillClip()
    {
        ammoInClip = Mathf.Clamp(ammoManager.GetCurrentAmmo(gunSettings.ammoType), 0, gunSettings.clipSize);
    }
}
