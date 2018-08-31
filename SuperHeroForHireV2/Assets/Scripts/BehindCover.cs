using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCover : MonoBehaviour {

    public Transform Player;
    public float MinPlayerDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float PlayerDis = Vector3.Distance(Player.position, transform.position);

		if(Input.GetKeyDown(KeyCode.E) && PlayerDis <= MinPlayerDistance)
        {
            //move player to edge of surface stop movement (maybe just a sprite and hide real player)
            Debug.Log("Player in cover");

        }
	}
}
