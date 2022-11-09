using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public StandartEnemyStats enemyStats;

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
        enemyStats.currentHp -= amountOfDamage;
        if(enemyStats.currentHp <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
