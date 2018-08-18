using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

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
            HitTarget();
            return;
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
            HitTarget();
            return;
        }

        transform.Translate(OldDir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
