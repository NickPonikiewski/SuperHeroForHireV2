using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float speedX;
    public float jumpSpeedY;

    bool Jumping;
    bool facingRight;
    float speed;

    Animator anim;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        //allows this script to access ridgidbody and anim
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //player movement
        MovePlayer(speed);

    }

    void MovePlayer (float playerSpeed)
    {
        //code for player movement
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    public void WalkLeft()
    {
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }

    public void StopMoving()
    {
        speed = 0;
    }

    public void Jump()
    {
        Jumping = true;
        rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
        
    }
    

    
}
