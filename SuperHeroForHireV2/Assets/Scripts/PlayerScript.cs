using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Transform pBody;

    private Rigidbody2D pRigid;

    public bool _Direction;

    public ArmRotation _Arm;

    private bool _Grounded;

    [SerializeField]  private LayerMask whatIsGround;

    [SerializeField]  private Transform[] groundPoints;

    private bool _Jump;

    public float jumpHight;

    public float _Speed;

    public float _Horizontal;

    void Awake ()

    {
        pBody = transform.Find("Body");

        pRigid = gameObject.GetComponent<Rigidbody2D>();

        _Direction = true;

    }

	void Start ()

    {
	
        

	}
	

    void FixedUpdate ()

    {

        float _Horizontal = Input.GetAxis("Horizontal");

        float _Vertical = Input.GetAxis("Vertical");

        Movements(_Horizontal);

      
    }

	void Update ()

    {
	
	}

    void Movements (float _Horizontal)

    {

            pRigid.AddForce(new Vector2(_Speed*_Horizontal, pRigid.velocity.y));


    }

  

    public void Flipp ()

    {

        
            _Direction = !_Direction;

            Vector3 theScale = pBody.localScale;

            theScale.x *= -1f;

            pBody.localScale = theScale;
        

    }
}
