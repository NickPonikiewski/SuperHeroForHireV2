using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour
{
    public Transform hitPoint;
    public Transform Crosshair;
    public bool direction;
    public Camera cam;
    public int posOffset;
    public GameObject parent;

    void Start()
    {
        direction = true;
    }

    void Update()
    {
        //rotation
        //Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos = Crosshair.position;
        mousePos = cam.WorldToScreenPoint(mousePos);
        mousePos.z = 5f;

        Vector3 objectPos = cam.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (direction == true)
        {
            posOffset = 0;
        }

        if (direction == false)
        {
            posOffset = 0;
        }

        //if (!(angle > 80f && angle < 120f))
        //{
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset)); //Rotating!
        //}

        //if (angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        //{
        //    if (direction == false)
        //    {
        //        direction = true;

        //        Flip();
        //    }
        //}

        //if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)

        //    if (direction == true)
        //    {
        //        direction = false;

        //        Flip();
        //    }


        if (angle > 0f && angle < 80f || angle < 0f && angle > -80f)
        {
            if (direction == false)
            {
                direction = true;

                Flip();
            }
        }

        if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)

            if (direction == true)
            {
                direction = false;

                Flip();
            }
    }

    void Flip()
    {

        //Vector2 localScale2 = gameObject.transform.parent.localScale;
        //localScale2.x *= -1;
        //transform.parent.localScale = localScale2;

        if (gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX == true)
        {
            gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX == false)
        {
            gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
        }



        //if (gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipY == true)
        //{
        //    gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipY = false;
        //}
        //else if (gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipY == false)
        //{
        //    gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipY = true;
        //}

        Vector2 localScale = gameObject.transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }

}
