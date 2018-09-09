using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Camera cam;
   private Vector3 PrevMousePos;

    // Use this for initialization
    void Start () {
        PrevMousePos = Input.mousePosition;
        Cursor.visible = false;
        //gameObject.transform.
	}
	
	// Update is called once per frame
	void Update () {

        //gameObject.transform.position = new Vector3(Input.mousePosition.x / 100, Input.mousePosition.y / 100, Input.mousePosition.z);

        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;

        float mouseXPosDiff = mousePos.x - PrevMousePos.x;
        float mouseYPosDiff = mousePos.y - PrevMousePos.y;

        mouseXPosDiff /= 25;
        mouseYPosDiff /= 25;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + mouseXPosDiff, gameObject.transform.position.y + mouseYPosDiff, gameObject.transform.position.z);

        PrevMousePos = mousePos;

        //Debug.Log("MouseX: " + mousePos.x + "   MouseY: " + mousePos.y + "   ");
        //Debug.Log("PrevMouseX: " + PrevMousePos.x + "   PrevMouseY: " + PrevMousePos.y + "   ");
        //Debug.Log("MouseX Diff: " + mouseXPosDiff + "   MouseY Diff: " + mouseYPosDiff + "   ");
        //Debug.Log("PositionX: " + gameObject.transform.position.x);


        //if (Mathf.Abs(mouseXPosDiff) > 0 && Mathf.Abs(mouseXPosDiff) < .10)
        //{
        //    gameObject.transform.Translate((gameObject.transform.position.x + mouseXPosDiff) * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z, Space.Self);

        //}

        //if (Mathf.Abs(mouseYPosDiff) > 0 && Mathf.Abs(mouseYPosDiff) < .10)
        //{
        //    gameObject.transform.Translate(gameObject.transform.position.x, (gameObject.transform.position.y + mouseYPosDiff) * Time.deltaTime, gameObject.transform.position.z, Space.Self);

        //}

        //gameObject.transform.Translate((gameObject.transform.position.x + mouseXPosDiff) * Time.deltaTime, (gameObject.transform.position.y + mouseYPosDiff) * Time.deltaTime, gameObject.transform.position.z, Space.Self);


    }
}
