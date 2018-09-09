using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour {
    public int health;
    public int armor;
    public bool hasDied;
    public bool isDead;
	// Use this for initialization
	void Start () {
        hasDied = false;
        isDead = false;
        health = 100;
        armor = 100;
	}
	
	// Update is called once per frame
	void Update () {
        Die();
	}

    void Die()
    {
        if ((gameObject.transform.position.y < -7 || health < 0) && isDead == false)
        {
            hasDied = true;
        }
        if (hasDied == true && isDead == false)
        {
            //isDead = true;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
