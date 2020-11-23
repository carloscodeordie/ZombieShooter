using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player was hitted, player's health is: " + health);
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GetComponent<DeathHandler>().HandleDeath();
        FreezeTime();
        DisplayCursor();
    }

    private void FreezeTime()
    {
        Time.timeScale = 0;
    }

    private void DisplayCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
