using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StandartEnemyStats
{
    public int maxHp;

    public int currentHp;

    public int speed;

    public int damage;

    public bool facesRight;

    public Collider2D collider;

    public Vector2 feetPos;
}
