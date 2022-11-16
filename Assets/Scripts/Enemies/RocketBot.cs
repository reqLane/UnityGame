using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class RocketBot : CrabEnemy
{
    // Start is called before the first frame update
    // Update is called once per frame
    protected Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyStats.facesRight = Random.Range(0, 2) == 1 ? true : false;
        enemyStats.collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (enemyStats.facesRight) walkRightAnimation();
        else walkLeftAnimation();
    }
    private void Update()
    {
        crabMovement();
        crabMovementIntelligence();
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
