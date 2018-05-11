using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerMove();
	}

    void playerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        //Animations
        //player dir
        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        } else if(moveX > 0.0f && facingRight == true )
        {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2d>().velocity = new vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2d>().velocity.y);


    }

    void Jump()
    {

    }

    void FlipPlayer()
    {

    }

}
