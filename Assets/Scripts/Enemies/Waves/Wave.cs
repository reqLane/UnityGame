using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    [SerializeField]
    private EnemyOfWave[] enemiesOfWave;

    public EnemyOfWave[] EnemiesOfWave { get => enemiesOfWave; set => enemiesOfWave = value; }
}
