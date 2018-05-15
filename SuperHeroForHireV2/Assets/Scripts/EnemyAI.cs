using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int EnemySpeed = 1;
    public int XMoveDirection = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hole = Physics2D.Raycast(new Vector2(transform.position.x+5,transform.position.y), new Vector2(0, 1));
        

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if ((hit.distance < 1.1f) && (hit.distance != 0))
        {
            Flip();
        }
    }
    void Flip()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
        } else
        {
            XMoveDirection = 1;
        }
    }
}
