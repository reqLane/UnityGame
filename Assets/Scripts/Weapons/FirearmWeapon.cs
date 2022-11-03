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
        Vector3 difference= Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (isCurrent)
        {
            
        }
    }
}
