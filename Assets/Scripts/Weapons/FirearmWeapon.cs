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
    private Transform muzzle;


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
        if (difference.x < 0) transform.localScale = new Vector3(-1, -1, 0);
        else transform.localScale = new Vector3(1, 1, 0);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 directionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            directionVector = Vector3.Normalize(directionVector);
            GameObject i = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
            i.GetComponent<SimpleBullet>().Direction = directionVector;
            Debug.Log(directionVector);
        }
    }
}
