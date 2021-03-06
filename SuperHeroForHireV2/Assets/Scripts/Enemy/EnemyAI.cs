﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int EnemySpeed = 1;
    public int EnemySprint = 10; 
    public int XMoveDirection = 1;
    public Transform target; // player
    public Transform bulletPre;
    public Transform _FirePoint;
    public LayerMask hitWhat;
    public bool direction;
    private bool isAttacking = false;
    private bool Hold = false;
    private int MaxDist = 1000; 
    public int MinDist = 5;
    private bool FirstAttack = true;
    private bool LookingForCover = false;
    private bool MoveToCover = false;

    public float _TimeToFire = 0f;
    public float _FireRate = 5f;

    public float _TimeToAim = 0f;
    public float maxHealth = 100;
    public float CurrHealth = 100;

    public bool IsVisible = false;
    float disToClosestCover = Mathf.Infinity;
    BehindCover closestCover = null;
    BehindCover[] allCover;
    
    EnemyAI[] allEnemies;

    float disToClosestEnemy = Mathf.Infinity;
    EnemyAI closestEnemy = null;

    // Use this for initialization
    void Start ()
    {
        direction = true;
        allCover = FindObjectsOfType<BehindCover>();
        allEnemies = FindObjectsOfType<EnemyAI>();
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir = target.position - transform.position;
        int MoveDir = 1;
        Vector3 forward = XMoveDirection * transform.right;
        float angle = Vector3.Angle(targetDir, forward);
        var dist = Vector3.Distance(target.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDir, Mathf.Infinity, ~ LayerMask.GetMask("Ignore Raycast")); // see if player is in sight of enemy 
        float EnemyDis = MinDist + 1;
        if(isAttacking == true)
        {
            Attack(hit);
            foreach (EnemyAI currEnemy in allEnemies)
            {
                if(currEnemy != null)
                {
                    float disToEnemy = (currEnemy.transform.position - transform.position).sqrMagnitude;
                    if (disToEnemy < disToClosestCover && currEnemy != this /*&& currEnemy.transform.position.y == transform.position.y*/)
                    {
                        disToClosestEnemy = disToEnemy;
                        closestEnemy = currEnemy;
                    }
                }
            }
            EnemyDis = Vector2.Distance(closestEnemy.transform.position, transform.position);
        }
        else
        {
            //Movement();
        }

        if (targetDir.x < 0)
        {
            MoveDir = -1;
        }
        else
        {
            MoveDir = 1;
        }
        //if ((angle < 35.0F) && (Mathf.Abs(dist) < MaxDist) && (Mathf.Abs(dist) > MinDist) && (Hold == false) && (Mathf.Floor(hit.distance) >= Mathf.Floor(dist)) && LookingForCover == false && isAttacking == false && IsVisible) // sees if player is in view angle and within distance and if enemy can see them
       // {
        if (/*(Mathf.Abs(dist) < MaxDist) && (Mathf.Abs(dist) > MinDist) &&*/ (Mathf.Floor(hit.distance) >= Mathf.Floor(dist)) && LookingForCover == false && isAttacking == false && IsVisible) // sees if player is in view angle and within distance and if enemy can see them
        {
            isAttacking = true;
            LookingForCover = true;
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveDir * EnemySprint, gameObject.GetComponent<Rigidbody2D>().velocity.y); // enemy sprint

        }
        else if (LookingForCover == true)
        {
            //FindClosestCover();
        }
/*      else if(isAttacking == true)
        {
            Hold = true;
            Attack(hit);
            // stop moving and attack
            //set timer to resume chase
            if (Mathf.Abs(dist) >= MaxDist + 1)// and a timer 
            {
                Hold = false;
                isAttacking = false;
                FirstAttack = true;

                if (direction)
                {
                    gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    
                }
                else
                {
                    gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                  
                }
            }
        } */

        /*else if ((Mathf.Abs(dist) > MinDist))
        {
            if(isAttacking)
            {
                if((Mathf.Abs(EnemyDis) > MinDist))//maybe enemies don't run at player when they have guns?
                {
                    Movement();
                }
            }
            else
            {
                Movement();
            }
            
        }*/

    }

    void FindClosestCover()
    {
        if (MoveToCover == false)
        {
            foreach (BehindCover currCover in allCover)
            {
                float disToCover = (currCover.transform.position - transform.position).sqrMagnitude;
                if (disToCover < disToClosestCover /*&& closestCover.transform.position.y >= transform.position.y - 10 && closestCover.transform.position.y <= transform.position.y + 5*/)//range not working
                {
                    disToClosestCover = disToCover;
                    closestCover = currCover;
                }
            }
            MoveToCover = true;
        }
        //goto cover
        Vector2 CoverDir = target.position - transform.position;
        //Vector2 targetDir = target.position - transform.position;
        int Movedir;
        if (CoverDir.x < 0)
        {
            Movedir = -1;
        }
        else
        {
            Movedir = 1;
        }
        //check player isn't between enemy and cover
        float CoverDis = Vector2.Distance(closestCover.transform.position, transform.position);
        float TargetDis = Vector2.Distance(target.position, transform.position);
        if(CoverDis < TargetDis)
        {
            //check dis
            //float CoverDis = Vector2.Distance(closestCover.transform.position, transform.position);
            if (CoverDis > 2)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Movedir * EnemySprint, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                MoveToCover = false;
                LookingForCover = false;
                isAttacking = true;
                Debug.Log("Enemy In Cover");
             }
        }
        else
        {
            MoveToCover = false;
            LookingForCover = false;
            isAttacking = true;
        }
    }
    void Movement()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hole = Physics2D.Raycast(new Vector2(transform.position.x + (XMoveDirection * 2), transform.position.y), new Vector2(XMoveDirection, -1));

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection * EnemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (((hit.distance < 1.1f) && (hit.distance != 0)) || (hole.distance == 0))
        {

            AttackFlip();
            if (direction)//right
            {
                gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

            }
            else // left
            {
                gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            }
            direction = !direction;

        }
    }
    void Attack(RaycastHit2D Aim)
    {
        Vector3 AimAt = Aim.point;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        AimAt = Camera.main.WorldToScreenPoint(AimAt);
        AimAt.x = AimAt.x - objectPos.x;
        AimAt.y = AimAt.y - objectPos.y;
    

        float angle = Mathf.Atan2(AimAt.y, AimAt.x) * Mathf.Rad2Deg;
        if(_TimeToAim <= 0f)
        {
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // rotate gun, need to make this smooth.
            _TimeToAim = 1f / 2f/*RateofAim*/;
        }
        _TimeToAim -= Time.deltaTime;
        if (angle > 0f && angle < 80f || angle < 0f && angle > -80f)
        {
            if (direction == false)
            {
                direction = true;
                AttackFlip();
            }
        }

        if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            if (direction == true)
            {
                direction = false;
                AttackFlip();
            }
        }

        //shoot
        if (_TimeToFire <= 0f)
        {
            GameObject bulletGO = (Instantiate(bulletPre, _FirePoint.position, _FirePoint.rotation)).gameObject;
            EnemyBullet bullet = bulletGO.GetComponent<EnemyBullet>();

            if (bullet != null)
            {
                //bullet.Seek(target);
                bullet.Seek(gameObject.transform.GetChild(0).transform.GetChild(2).transform, target);
            }
            _TimeToFire = 1f / _FireRate;
        }
        _TimeToFire -= Time.deltaTime;
    }
    void Chase()
    {
        
    }
    public void SubHealth()
    {
        CurrHealth -= 50;
        if(CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void AttackFlip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            XMoveDirection = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector2 localScale = gameObject.transform.GetChild(0).transform.localScale;
        localScale.y *= -1;
        transform.GetChild(0).transform.localScale = localScale;
    }
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            XMoveDirection = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        direction = !direction;
        Vector2 localScale = gameObject.transform.GetChild(0).transform.localScale;
        localScale.x *= -1;
        transform.GetChild(0).transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("hit by enemy bullet");
            Physics2D.IgnoreCollision( collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision( collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnBecameVisible()
    {
        IsVisible = true;
    } 
}
