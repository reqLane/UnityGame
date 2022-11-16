using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SmallRocket : ProjectileBase
{
    [SerializeField]
    private float speed;
    Player player;
    Vector3 currentDirection = new Vector2(1, 0);
    Vector2 nextDirection;
    Vector2 toPlayer;

    public Vector3 CurrentDirection { get => currentDirection; set => currentDirection = value; }

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Vector3.Angle(new Vector2(1, 0), currentDirection));
        player = FindObjectOfType<Player>();
        toPlayer = player.transform.position - transform.position;
        //Vector3.Angle(currentDirection, toPlayer);
        //transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = player.transform.position - transform.position;
        nextDirection = (Quaternion.AngleAxis(Vector3.SignedAngle(currentDirection, toPlayer, Vector3.forward) * Time.deltaTime*5, Vector3.forward) * currentDirection).normalized;
        transform.Rotate(0, 0, Vector3.SignedAngle(currentDirection, nextDirection, Vector3.forward));
        currentDirection = nextDirection;
        transform.position += currentDirection * speed*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          //  collision.gameObject.GetComponent<Player>().getDamage(this.damage);
        }
        Destroy(this.gameObject);
    }
}
