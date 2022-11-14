using System;
using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    private int waitBetweenWaves = 1;
    private int currentWave = 0;
    private int numOfEnemies = 0;
    
    //method which will start battle in current room
    public void StartBattle()
    {
        EnemyBase.Death += OnEnemyDeath;
        currentWave = 0;
        numOfEnemies = 0;
        if (LevelManager.Instance.CurrentRoom.Waves.Length == 0)
            OnBattleEnd();
        else
            SpawnWave();
    }

    private void SpawnWave()
    {
        Debug.Log("Wave: " + currentWave);
        numOfEnemies = 0;
        foreach(EnemyOfWave enemyOfWave in this.getCurrentWaveEnemiesList())
        {   
            Instantiate(enemyOfWave.EnemyToSpawn, enemyOfWave.SpawnPoint);
            numOfEnemies++;
        }
    }

    public void OnEnemyDeath()
    {
        numOfEnemies--;
        if(numOfEnemies <= 0)
        {
            StartCoroutine(StartNextWaveWithDelay());
        }
    }

    private void OnWaveChange()
    {
        numOfEnemies = 0;
        currentWave++;
        if (currentWave >= LevelManager.Instance.CurrentRoom.Waves.Length)
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
        LevelManager.Instance.EndBattle();
    }

    public EnemyOfWave[] getCurrentWaveEnemiesList()
    {
        return LevelManager.Instance.CurrentRoom.Waves[currentWave].EnemiesOfWave;
    }

    private IEnumerator StartNextWaveWithDelay()
    {
        yield return new WaitForSeconds(waitBetweenWaves);
        OnWaveChange();
        yield break;
    }
}
