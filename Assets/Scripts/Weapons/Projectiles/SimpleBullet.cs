using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : ProjectileBase
{
    Vector3 direction;
    [SerializeField]
    float speed;
    BoxCollider bcollider;

    public Vector3 Direction { get => direction; set => direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        bcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*speed;
    }
}
