using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirearmWeapon : WeaponBase
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform muzzle;
    protected bool onReload = false;
    protected bool isShooting = false;
    protected float reloadTime = 0.2f;
    private Animator animator;
    void Start()
    {
        isCurrent = false;
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrent)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            if (difference.x < 0) transform.localScale = new Vector3(-1, -1, 0);
            else transform.localScale = new Vector3(1, 1, 0);
            if (!onReload && Input.GetMouseButton(0))
            {
                if (!isShooting) animator.Play("FirearmWeaponAnim");
                isShooting = true;
                Vector2 directionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                directionVector = Vector3.Normalize(directionVector);
                GameObject i = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
                i.GetComponent<SimpleBullet>().Direction = directionVector;

                GameManager.Instance.AudioManager.Play("BulletShot");

                StartCoroutine(reloadWait());
            }
            else if(isShooting&&!onReload){
                animator.Play("FirearmWeaponIdle");
                isShooting = false;
            }
        }
        takeWeapon();
    }

    private IEnumerator reloadWait()
    {
        onReload = true;
        yield return new WaitForSeconds(reloadTime);
        onReload = false;
        yield break;
    }
}
