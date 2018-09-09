using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Dialogue dialogue;

    public Transform Player;
    public float MinPlayerDistance;

    void Update()
    {
        float PlayerDis = Vector3.Distance(Player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && PlayerDis <= MinPlayerDistance)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueMannager>().StartDialogue(dialogue);
    }
}
