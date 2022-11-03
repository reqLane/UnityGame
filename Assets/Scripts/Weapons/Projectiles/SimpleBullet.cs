using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : ProjectileBase
{
    Vector3 direction;
    [SerializeField]
    float speed;
    BoxCollider2D bcollider;

    public Vector2 Direction { get => direction; set => direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        bcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += direction*speed;
        transform.position += direction*speed;
    }
}
