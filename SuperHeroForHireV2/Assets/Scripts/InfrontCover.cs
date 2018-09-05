using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrontCover : MonoBehaviour {
    public Transform Player;
    public float MinPlayerDistance;
    private bool cover = false;
    // Use this for initialization


        //????????not sure if this kind of cover is needed??????????
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float PlayerDis = Vector3.Distance(Player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && PlayerDis <= MinPlayerDistance)
        {
            cover = !cover;
            //move player to edge of surface stop movement (maybe just a sprite and hide real player)
            Player.GetComponent<Player_Movement>().SetCoverCrouch(cover);
            Debug.Log("Player in cover");
        }
    }
}
