using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int EnemySpeed = 1;
    public int EnemySprint = 10; 
    public int XMoveDirection = 1;
    public Transform target; // player
    private bool isAttacking = false;
    private bool Hold = false;
    public int MaxDist = 20, MinDist = 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir = target.position - transform.position;
        int MoveDir = 1;
        Vector3 forward = XMoveDirection * transform.right;
        float angle = Vector3.Angle(targetDir, forward);
        var dist = Vector3.Distance(target.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDir);

        if (targetDir.x < 0)
        {
            MoveDir = -1;
        }
        else
        {
            MoveDir = 1;
        }
        if ((angle < 15.0F) && (Mathf.Abs(dist) < MaxDist && Mathf.Abs(dist) > MinDist) && (Hold == false) && (Mathf.Floor(hit.distance) >= Mathf.Floor(dist))) // sees if player is in view angle and within distance
        {
            isAttacking = true;
            //shoot at player too
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveDir * EnemySprint, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        }
        else if(isAttacking == true)
        {
            Hold = true;
            // stop moving and attack
            //set timer to resume chase
            if(Mathf.Abs(dist) >= MaxDist-3)
            {
                Hold = false;
            }
        }
        else
        {
            Movement();
        }

    }

    void Movement()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hole = Physics2D.Raycast(new Vector2(transform.position.x + (XMoveDirection * 2), transform.position.y), new Vector2(XMoveDirection, -1));

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection * EnemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (((hit.distance < 1.1f) && (hit.distance != 0)) || (hole.distance == 0))
        {
            Flip();
        }
    }
    void Chase()
    {
        
    }
    void Flip()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            XMoveDirection = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
