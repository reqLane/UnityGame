using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    public int HP { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
}
