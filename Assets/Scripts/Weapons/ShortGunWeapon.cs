using System.Collections;
using UnityEngine;

public class ShortGunWeapon : WeaponBase
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform muzzle;
    protected bool onReload = false;
    protected float reloadTime = 1;
    protected int amountOfBullets = 4;
    // Start is called before the first frame update

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
            if (!onReload && Input.GetMouseButtonDown(0))
            {
                animator.Play("ShortGunAnimation");
                Vector2 directionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                Vector2 setDirection;
                directionVector = Vector3.Normalize(directionVector);
                for (int j = 0; j < amountOfBullets; j++)
                {
                    setDirection = (Quaternion.AngleAxis(Random.Range(-10f, 10f), Vector3.forward) * directionVector).normalized;
                    GameObject i = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
                    i.GetComponent<SimpleBullet>().Direction = setDirection;
                }

                GameManager.Instance.AudioManager.Play("LaserShotgun");

                StartCoroutine(reloadWait());
            }
        }
        takeWeapon();
    }

    private IEnumerator reloadWait()
    {
        onReload = true;
        yield return new WaitForSeconds(reloadTime);
        animator.Play("ShortGunIdle");
        onReload = false;
        yield break;
    }
}