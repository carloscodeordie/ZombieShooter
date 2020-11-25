using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamara;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 1f;

    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ammoSlot.ReduceAmmo();
            PlayMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamara.transform.position, FPCamara.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            // Makes damage to enemy
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);

            //TODO: Add some visual effect when shooting
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.05f);
    }
}