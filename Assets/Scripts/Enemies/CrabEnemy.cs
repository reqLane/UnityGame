using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrabEnemy : GroundEnemy
{
    protected Vector2 helpFeetPoint;
    protected Vector2 helpFrontPoint1;
    protected Vector2 helpFrontPoint2;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        enemyStats.facesRight = Random.Range(0, 2) == 1 ? true : false;
        if(!enemyStats.facesRight) transform.localScale = new Vector3(-1 * Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
        enemyStats.collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        damagedSound = "CrabDamaged";
    }

    // Update is called once per frame
    private void Update()
    {
        crabMovement();
        crabMovementIntelligence();
    }
    protected void crabMovement()
    {
        helpFeetPoint.x = enemyStats.feetPos.x + (enemyStats.facesRight ? 1 : -1) * enemyStats.collider.bounds.size.x / 4;
        helpFeetPoint.y = enemyStats.feetPos.y;
        helpFrontPoint1.x = enemyStats.collider.transform.position.x + (enemyStats.facesRight ? 1 : -1) * enemyStats.collider.bounds.size.x / 3;
        helpFrontPoint1.y = enemyStats.feetPos.y + enemyStats.collider.bounds.size.y / 20;
        helpFrontPoint2.x = helpFrontPoint1.x + (enemyStats.facesRight ? 1 : -1) * 0.2f * enemyStats.collider.bounds.size.x;
        helpFrontPoint2.y = helpFrontPoint1.y + enemyStats.collider.bounds.size.y * 0.95f;
        enemyStats.feetPos.x = enemyStats.collider.transform.position.x;
        enemyStats.feetPos.y = enemyStats.collider.transform.position.y - enemyStats.collider.bounds.size.y / 2;
    }
    private void crabMovementIntelligence()
    {
        if ((Physics2D.OverlapCircle(helpFeetPoint, 0.01f, LayerMask.GetMask("Collidable")) == null || (Physics2D.OverlapArea(helpFrontPoint1, helpFrontPoint2, LayerMask.GetMask("Collidable")) != null)) && rb.velocity.y == 0)
        {
            if (enemyStats.facesRight)
            {
                transform.localScale = new Vector3(-1 * Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
                enemyStats.facesRight = false;
            }
            else
            {
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
                enemyStats.facesRight = true;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x + enemyStats.speed * (enemyStats.facesRight ? 1 : -1) * Time.deltaTime, transform.position.y);
        }
    }
}
