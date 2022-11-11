using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrabEnemy : GroundEnemy
{
    private static Vector2 helpFeetPoint;
    private static Vector2 helpFrontPoint1;
    private static Vector2 helpFrontPoint2;
    // Start is called before the first frame update
    void Start()
    {
        enemyStats.facesRight = Random.Range(0, 2) == 1 ? true : false;
        if(!enemyStats.facesRight) transform.localScale = new Vector3(-1 * Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
        enemyStats.collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        helpFeetPoint.x = enemyStats.feetPos.x + (enemyStats.facesRight ? 1 : -1) * enemyStats.collider.bounds.size.x / 4;
        helpFeetPoint.y = enemyStats.feetPos.y;
        helpFrontPoint1.x = enemyStats.collider.transform.position.x + (enemyStats.facesRight ? 1 : -1) * enemyStats.collider.bounds.size.x / 3;
        helpFrontPoint1.y = enemyStats.feetPos.y + enemyStats.collider.bounds.size.y / 20;
        helpFrontPoint2.x = helpFrontPoint1.x+ (enemyStats.facesRight ? 1 : -1)*0.2f* enemyStats.collider.bounds.size.x;
        helpFrontPoint2.y = helpFrontPoint1.y + enemyStats.collider.bounds.size.y * 0.95f;
        enemyStats.feetPos.x = enemyStats.collider.transform.position.x;
        enemyStats.feetPos.y = enemyStats.collider.transform.position.y - enemyStats.collider.bounds.size.y / 2;
            if((Physics2D.OverlapCircle(helpFeetPoint, 0.04f, LayerMask.GetMask("Collidable")) == null||(Physics2D.OverlapArea(helpFrontPoint1, helpFrontPoint2, LayerMask.GetMask("Collidable")) !=null)) && Physics2D.OverlapCircle(enemyStats.feetPos, 0.01f, LayerMask.GetMask("Collidable")) != null)
            {
                if (enemyStats.facesRight)
                {
                    transform.localScale = new Vector3(-1*Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
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
                transform.position = new Vector2(transform.position.x+enemyStats.speed * (enemyStats.facesRight ? 1 : -1)*Time.deltaTime, transform.position.y);
            }
        }
    }
