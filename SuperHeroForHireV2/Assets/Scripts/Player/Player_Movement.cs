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
    public bool isCrouchToggle = false;
    private Animator anim;
    public bool MoveDir;
    public bool SaveDir;
    public bool AltCont = false;
    public Vector2 NormalBoxCollSize = new Vector2(0.2f, 0.39f);
    public Vector2 NormalBocCollOffset = new Vector2(0, 0.03168509f);

    public Vector2 CrouchBoxCollSize = new Vector2(0.2f, 0.2228197f);
    public Vector2 CrouchBocCollOffset = new Vector2(0, -0.05190507f);
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
        if(Input.GetKeyDown(KeyCode.S) && isGrounded == true && isCrouchToggle == true)
        {
            isCrouch = !isCrouch;
            if(isCrouch)
            {
                gameObject.GetComponent<BoxCollider2D>().size = CrouchBoxCollSize;
                gameObject.GetComponent<BoxCollider2D>().offset = CrouchBocCollOffset;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().size = NormalBoxCollSize;
                gameObject.GetComponent<BoxCollider2D>().offset = NormalBocCollOffset;
            }
        }
        if((Input.GetKey(KeyCode.S) && isGrounded == true && isCrouchToggle == false) || (isCoverCrouch == true && isGrounded == true))
        {
            isCrouch = true;
            gameObject.GetComponent<BoxCollider2D>().size = CrouchBoxCollSize;
            gameObject.GetComponent<BoxCollider2D>().offset = CrouchBocCollOffset;
        }
        else if(isCrouchToggle == false)
        {
            isCrouch = false;
            gameObject.GetComponent<BoxCollider2D>().size = NormalBoxCollSize;
            gameObject.GetComponent<BoxCollider2D>().offset = NormalBocCollOffset;
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
