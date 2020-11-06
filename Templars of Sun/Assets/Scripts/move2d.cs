using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float mspeed = 3;
    private bool facingright;
    [SerializeField]
    private Transform[] groundPionts;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;


    private void Start()
    {
        facingright = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isInput();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement(horizontal);
        flip(horizontal);
        isGrounded = IsGrounded();
        resetValues();
    }


    private void movement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * mspeed, rb.velocity.y);

        if(isGrounded && jump)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void isInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void flip(float horizontal)
    {
        if(horizontal >0 && !facingright || horizontal < 0 && facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        if(rb.velocity.y <= 0)
        {
            foreach( Transform point in groundPionts)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for(int i=0; i< colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void resetValues()
    {
        jump = false;
    }
}