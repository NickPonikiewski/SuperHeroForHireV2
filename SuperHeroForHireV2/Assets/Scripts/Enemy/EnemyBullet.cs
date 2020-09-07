using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Transform target;
    private Transform player;
    private float speed = 50f;

    RaycastHit2D hit;

    Vector3 targetDir;
    Vector3 OldDir;

    public void Seek (Transform _target, Transform _player) //can be used for spawn effect, set speed, dam amount
    {
        target = _target;
        player = _player;
    }
    private void Start()
    {
        if (target == null)
        {
            
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
            //return;
        }
        OldDir = dir;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        targetDir = player.position - transform.position;
        hit = Physics2D.Raycast(transform.position, targetDir, Mathf.Infinity, ~ LayerMask.GetMask("Ignore Raycast"));
    }
    
    // Update is called once per frame
    void Update () {
        targetDir = player.position - transform.position;
        hit = Physics2D.Raycast(transform.position, targetDir, Mathf.Infinity, ~ LayerMask.GetMask("Ignore Raycast"));
        Debug.Log(hit.distance);
        if(hit.distance <= 0)
        {
            Debug.Log("HIT");
            HitTarget();
        }
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        float distanceThisFrame = speed * Time.deltaTime;
       /* Vector3 dir = target.position - transform.position;
        

        if(dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
            //return;
        }
*/
        transform.Translate(OldDir.normalized * distanceThisFrame, Space.World); 
	}

    void HitTarget()
    {
        PlayerScript health = player.gameObject.GetComponent<PlayerScript>();
        health.SubHealth();
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision( collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if (collision.gameObject != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("player!");
                if (player.gameObject != null)
                {
                    GameObject temp = player.gameObject;
                    PlayerScript health = temp.GetComponent<PlayerScript>();
                    if (health != null)
                    {
                        health.SubHealth();
                    }
                }
            }
            
        }
        Destroy(this.gameObject);
    }
}
