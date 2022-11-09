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
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameManager.instance.player.GetComponent<Collider2D>());
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        }
        StartCoroutine(WaitAndDestroy(10));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += direction*speed;
        transform.position += direction*speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBase>().getDamage(this.damage);
        }
        Destroy(this.gameObject);
    }

    private IEnumerator WaitAndDestroy(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
