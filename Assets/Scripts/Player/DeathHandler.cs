using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        DisplayCanvas();
        DisplayCursor();
        FreezeTime();
        DisableWeaponSwitch();
    }

    private void DisplayCanvas()
    {
        gameOverCanvas.enabled = true;
    }

    private void DisplayCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void FreezeTime()
    {
        Time.timeScale = 0;
    }

    private void DisableWeaponSwitch()
    {
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }
}
