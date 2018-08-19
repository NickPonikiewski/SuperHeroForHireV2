using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    private Stat health;

    private Vector2 touchOrigin = -Vector2.one;

    private void Awake()
    {
        health.Initialize();
    }

    void Start ()
    { 

	}
	
	void Update ()
    {
       
        //changes the players health
        if (Input.GetKeyDown(KeyCode.J))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            health.CurrentVal += 10;
        }



    }
    
}
