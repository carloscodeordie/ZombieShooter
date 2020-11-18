using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamara;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    // Update is called once per frame
    void Update()
    {
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamara.transform.position, FPCamara.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            
            // Makes damage to enemy
            InflictsDamageToEnemy(target);

            //TODO: Add some visual effect when shooting
        }
        else
        {
            return;
        }
    }

    private void InflictsDamageToEnemy(EnemyHealth target)
    {
        if (target == null) {
            return;
        }
        target.TakeDamage(damage);
    }
}