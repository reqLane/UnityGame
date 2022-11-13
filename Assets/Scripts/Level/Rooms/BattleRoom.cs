using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : MonoBehaviour
{
    private bool roomIsActivated;
    private int enemiesLeftCount;

    [SerializeField]
    private List<EnemyBase> enemyList;

    [SerializeField]
    private Door[] doors;

    void Start()
    {
        roomIsActivated = false;
        SpawnEnemies();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAllDoors()
    {
        foreach (Door door in doors)
        {
            door.openDoor();
        }
    }

    public void CloseAllDoors()
    {
        foreach (Door door in doors)
        {
            door.closeDoor();
        }
    }

    public bool anyMonstersInRoom()
    {
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&!roomIsActivated)
        {
            roomIsActivated = true;
            StartCoroutine(ActivateRoom());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && roomIsActivated)
        {
            roomIsActivated = false;
            StartCoroutine(ActivateRoom());
        }

    }
    private IEnumerator ActivateRoom()
    {
        if (roomIsActivated)
        {
            CloseAllDoors();

            //yield return new WaitForSeconds(2);
            enemiesLeftCount = enemyList.Count;
        }

        yield return new WaitForSeconds(0.5f);
        
        yield break;
    }
    //whole spawning system will be added soon
    private void SpawnEnemies()
    {
        EnemyBase.Death += enemyKilled;
    }

    private void enemyKilled()
    {
        enemiesLeftCount--;
        if (!EnemiesLeft())
        {
            OpenAllDoors();
        }
    }
    private bool EnemiesLeft()
    {
        return enemiesLeftCount > 0;
    }
}
