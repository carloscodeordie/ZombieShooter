using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamara;
    [SerializeField] float range = 100f;

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
            Debug.Log("The raycast hit the following: " + hit.transform.name);
        }
        
    }
}
