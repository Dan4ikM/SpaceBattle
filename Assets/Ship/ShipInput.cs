﻿using UnityEngine;
using System;

public class ShipInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool FireWeapons { get; private set; }

    public event Action OnFire = delegate {};

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        FireWeapons = Input.GetButtonDown("Fire1");
        if (FireWeapons)
            OnFire();
    }
}
