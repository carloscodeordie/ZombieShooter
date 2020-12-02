using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IncreaseAmmoOnPlayer(other.gameObject);
            DestroyPickup();
        }
    }

    private void IncreaseAmmoOnPlayer(GameObject player)
    {
        Ammo playerAmmo = player.GetComponent<Ammo>();
        if (playerAmmo)
        {
            playerAmmo.IncreaseAmmo(ammoType, ammoAmount);
        }
    }

    private void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
