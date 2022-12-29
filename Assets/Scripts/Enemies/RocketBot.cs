using System;
using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
public class RocketBot : CrabEnemy
{
    // Start is called before the first frame update
    // Update is called once per frame
    protected Animator animator;
    protected Vector2 helpShootPoint1;
    protected Vector2 helpShootPoint2;
    protected Vector3 helpShootPoint3;
    RaycastHit hit;
    protected bool onReload = false;
    [SerializeField]
    private GameObject projectilePrefab;
    Player player;
    float shootingDistance = 15;
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        enemyStats.facesRight = Random.Range(0, 2) == 1 ? true : false;
        enemyStats.collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (enemyStats.facesRight) walkRightAnimation();
        else walkLeftAnimation();
        damagedSound = "RobotDamaged";
    }
    private void Update()
    {
        Debug.DrawRay(helpShootPoint3, player.transform.position - helpShootPoint3, Color.red);
        if (!onReload)
        {
            helpShootPoint1.x = transform.position.x - enemyStats.collider.bounds.size.x / 2;
            helpShootPoint1.y = transform.position.y + enemyStats.collider.bounds.size.y / 2;
            helpShootPoint2.x = transform.position.x + enemyStats.collider.bounds.size.x / 2;
            helpShootPoint2.y = transform.position.y + enemyStats.collider.bounds.size.y*2;
            helpShootPoint3.x = transform.position.x;
            helpShootPoint3.y = transform.position.y + (enemyStats.collider.bounds.size.y*2);
            if (Physics2D.OverlapArea(helpShootPoint1, helpShootPoint2, LayerMask.GetMask("Collidable")) == null
            && rb.velocity.y == 0
            && Physics2D.Raycast(helpShootPoint3, player.transform.position - helpShootPoint3, shootingDistance, LayerMask.GetMask("Player")))
            {
                 StartCoroutine(shootRocket());
            }
            else
            {
                crabMovement();
                crabMovementIntelligence();
            }  
        }
    }
    private void crabMovementIntelligence()
    {
        if ((Physics2D.OverlapCircle(helpFeetPoint, 0.01f, LayerMask.GetMask("Collidable")) == null || (Physics2D.OverlapArea(helpFrontPoint1, helpFrontPoint2, LayerMask.GetMask("Collidable")) != null)) && rb.velocity.y == 0)
        {
            if (enemyStats.facesRight)
            {
                walkLeftAnimation();
                enemyStats.facesRight = false;
            }
            else
            {
                walkRightAnimation();
                enemyStats.facesRight = true;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x + enemyStats.speed * (enemyStats.facesRight ? 1 : -1) * Time.deltaTime, transform.position.y);
        }
    }

    private IEnumerator shootRocket()
    {
        onReload = true;
        shootAnimation();
        GameObject rocket = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + enemyStats.collider.bounds.size.y), Quaternion.identity);
        rocket.GetComponent<SmallRocket>().CurrentDirection = new Vector3(0, 1);

        GameManager.Instance.AudioManager.Play("RocketLaunch");

        yield return new WaitForSeconds(1);
        onReload = false;
        enemyStats.facesRight = transform.position.x < player.transform.position.x;
        if (enemyStats.facesRight) walkRightAnimation();
        else walkLeftAnimation();
        yield break;
    }
    private void walkRightAnimation()
    {
        animator.Play("RocketBotMoveLeft");
    }

    private void walkLeftAnimation()
    {
        animator.Play("RocketBotMoveRight");
    }

    private void shootAnimation()
    {
        animator.Play("RocketBotShoot");
    }
}
