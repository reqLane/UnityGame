using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmWeapon : WeaponBase
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private bool isCurrent;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        //  isCurrent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrent)
        {
            
        }
    }
}
