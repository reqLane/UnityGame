using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public StandartEnemyStats enemyStats;

    public delegate void OnDeathEvent();
    public static event OnDeathEvent Death;
    private bool isDead = false;

    private void Awake()
    {
        enemyStats.currentHp = enemyStats.maxHp;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamage(int amountOfDamage)
    {
        if (isDead) return;
        enemyStats.currentHp -= amountOfDamage;
        if(enemyStats.currentHp <= 0)
        {
            isDead = true;
            die();
        }
    }

    public void die()
    {
        if (Death != null)
        {
            Death();
        }
        Destroy(this.gameObject);
    }
}
