﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }

    public void IncreaseCurrentAmmo()
    {
        if (ammoAmount < 5) {
            ammoAmount += 5 - ammoAmount;
        }
    }
}
