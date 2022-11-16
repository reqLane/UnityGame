using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyOfWave
{
    [SerializeField]
    private GameObject enemyToSpawn;

    [SerializeField]
    private Transform spawnPoint;

    public GameObject EnemyToSpawn { get => enemyToSpawn; set => enemyToSpawn = value; }
    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }
}
