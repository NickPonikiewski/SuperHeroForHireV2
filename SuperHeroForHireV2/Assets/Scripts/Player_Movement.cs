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
    public bool isCrouch = false;
    public bool isCoverCrouch = false;
    private Animator anim;
    public bool MoveDir;
    public bool SaveDir;
    public bool AltCont = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        MoveDir = gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction;
        SaveDir = gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction;
    }
	
	// Update is called once per frame
	void Update () {
        playerMove();
	}
    public void SetCoverCrouch(bool isCrouch)
    {
        isCoverCrouch = isCrouch;
    }
    void playerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        
        //invert MoveDir when dir is changed 
        if(SaveDir != gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction)
        {
            MoveDir = !MoveDir;
            SaveDir = gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction;
        }
        
        if (moveX > 0.0f || moveX < 0.0f)
        {
            isMoving = true;
            SetCoverCrouch(false);
            if (!MoveDir && AltCont)
            {
                moveX = moveX * -1f;
            }
        } else
        {
            isMoving = false;
            if (!gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction && AltCont) // set master only when stoped
            {
                MoveDir = !gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction;
            }
            else
            {
                MoveDir = gameObject.transform.GetChild(0).GetComponent<ArmRotation>().direction;
            }
        }
        anim.SetBool("isMoving", isMoving);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            SetCoverCrouch(false);
            Jump();
        }
        if((Input.GetKey(KeyCode.S) && isGrounded == true) || (isCoverCrouch == true && isGrounded == true))
        {
            isCrouch = true;
            anim.SetBool("isCrouch", isCrouch);
        }
        else
        {
            isCrouch = false;
        }
        anim.SetBool("isCrouch", isCrouch);
        //Animations

       
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
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
