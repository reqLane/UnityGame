using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : SimpleBullet
{
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameManager.Instance.Player.GetComponent<Collider2D>());
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        }
        transform.rotation = Quaternion.AngleAxis(-Vector3.SignedAngle(direction, Vector3.right, Vector3.forward), Vector3.forward);
        StartCoroutine(WaitAndDestroy(10));
    }
}
