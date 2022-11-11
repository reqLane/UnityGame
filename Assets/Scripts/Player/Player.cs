using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private PlayerStatsSO statsSO;
    private float hp;
    private float speed;
    private float jumpForce;

    private float moveInput;

    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    private bool isGrounded;
    [SerializeField]
    private Transform feetPos;
    [SerializeField] 
    private float checkRadius;
    [SerializeField]
    private LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = statsSO.HP;
        speed = statsSO.Speed;
        jumpForce = statsSO.JumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
