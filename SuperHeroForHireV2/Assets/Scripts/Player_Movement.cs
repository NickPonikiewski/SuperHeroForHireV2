using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;
    public bool isMoving = false;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMove();
	}

    void playerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if(moveX > 0.0f || moveX < 0.0f)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
        anim.SetBool("isMoving", isMoving);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Debug.Log("Jump button");
            Jump();
        }
        //Animations

        //player dir
        //if(moveX < 0.0f && facingRight == false)
        //{
        //    FlipPlayer();
        //} else if(moveX > 0.0f && facingRight == true )
        //{
        //    FlipPlayer();
        //}
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
        Debug.Log("Jumping");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
        anim.SetBool("isGrounded", isGrounded);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            anim.SetBool("isGrounded", isGrounded);
        }
    }
}
