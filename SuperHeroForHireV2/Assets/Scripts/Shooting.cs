using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public float _FireRate;

    public ArmRotation a_Script;

    public Camera cam;

    public float _Damage;

    public Transform bulletPre;

    public LayerMask hitWhat;

    private float _TimeToFire = 0f;

    public Transform _FirePoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()

    {
      

        if (_FireRate == 0)

        {
            if (Input.GetButtonDown("Fire1"))

            {
                Shoot();
            }
        }

        else

        {
            if (Input.GetButton("Fire1") && Time.deltaTime > _TimeToFire)

             {
                _TimeToFire = Time.time + 1/_FireRate;

                Shoot();
             }

         }

        }

    

    void Shoot()
    {

        Vector2 mousePosition = new Vector2 (cam.ScreenToWorldPoint ( Input.mousePosition).x,cam.ScreenToWorldPoint(Input.mousePosition).y);

        CreateBullet();

        Vector2 firePP = new Vector2(_FirePoint.position.x, _FirePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePP, mousePosition,100,hitWhat);

    }

    void CreateBullet()

    { Instantiate(bulletPre, _FirePoint.position, _FirePoint.rotation); }
} 

