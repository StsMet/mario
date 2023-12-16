using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public float horizontal;
    private bool flipRight = true;
    public Animator animator;
    public int jumpForse = 6;
    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    public float vertical;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);//(x,y)
        // rb.velocity = new Vector2(horizontal * speed, vertical);
        animator.SetFloat("moveX", Mathf.Abs(horizontal));


        /*
                 if ((Horizontal > 0 && !flipRight) || (Horizontal < 0 && flipRight))
                {
                    transform.localScale *= new Vector2(-1, 1);
                    flipRight = !flipRight;
                }
                */
        if (horizontal > 0 && !flipRight)
        {
            Flip();
        }
        else if (horizontal < 0 && flipRight)
        {
            Flip();

        }
        Jump();
        CheckingGround();

    }

    void Flip()
    {
        flipRight = !flipRight;
        transform.Rotate(0, 180, 0);
        /*    flipRight = !flipRight;
            Vector3 theScale = transform.localScale;
            theScale.x = theScale.x * (-1);
            transform.localScale = theScale;*/
    }

    void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForse);
        }

    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        animator.SetFloat("moveY", Mathf.Abs(rb.velocity.y));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "ChekPoint")
        {
            respawnPoint = transform.position;
        }




    }

}
