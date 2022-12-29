using System;
using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private const int waitBetweenWaves = 1;
    private int currentWave = 0;
    private int numOfEnemies = 0;
    
    //method which will start battle in current room
    public void StartBattle()
    {
        EnemyBase.Death += OnEnemyDeath;
        currentWave = 0;
        numOfEnemies = 0;
        if (GameManager.Instance.LevelManager.CurrentRoom.Waves.Length == 0)
            OnBattleEnd();
        else
            SpawnWave();
    }

    private void SpawnWave()
    {
        numOfEnemies = getCurrentWaveEnemiesList().Length;
        foreach(EnemyOfWave enemyOfWave in getCurrentWaveEnemiesList())
        {
            Instantiate(enemyOfWave.EnemyToSpawn, enemyOfWave.SpawnPoint);
        }
    }

    public void OnEnemyDeath()
    {
        numOfEnemies--;
        if (numOfEnemies <= 0)
        {
            StartCoroutine(StartNextWaveWithDelay());
        }
    }

    private void OnWaveChange()
    {
        currentWave++;
        if (currentWave >= GameManager.Instance.LevelManager.CurrentRoom.Waves.Length)
        {
            OnBattleEnd();
        }
        else
        {
            SpawnWave();
        }
    }

    private void OnBattleEnd()
    {
        EnemyBase.Death -= OnEnemyDeath;
        GameManager.Instance.LevelManager.EndBattle();
    }

    public EnemyOfWave[] getCurrentWaveEnemiesList()
    {
        return GameManager.Instance.LevelManager.CurrentRoom.Waves[currentWave].EnemiesOfWave;
    }

    private IEnumerator StartNextWaveWithDelay()
    {
        yield return new WaitForSeconds(waitBetweenWaves);
        OnWaveChange();
        yield break;
    }
}
