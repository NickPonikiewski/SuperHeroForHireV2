using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Transform target;

    private float speed = 30f;

    Vector3 OldDir;

    public void Seek (Transform _target) //can be used for spawn effect, set speed, dam amount
    {
        target = _target;
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
    }
    // Update is called once per frame
    void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
            //return;
        }

        transform.Translate(OldDir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        PlayerScript health = target.gameObject.GetComponent<PlayerScript>();
        health.SubHealth();
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (target.gameObject != null)
                {
                    GameObject temp = target.gameObject;
                    PlayerScript health = temp.GetComponent<PlayerScript>();
                    if (health != null)
                    {
                        health.SubHealth();
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
}
