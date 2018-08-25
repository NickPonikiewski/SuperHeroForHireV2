using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        int horizontal = 0;
        int vertical = 0;
       
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

<<<<<<< HEAD

=======
>>>>>>> b376560cffca10708bb269019e0f87726f0a7345
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
         

        #else

        

#endif
<<<<<<< HEAD

=======
>>>>>>> b376560cffca10708bb269019e0f87726f0a7345
    public void SubHealth()
    {
        health.CurrentVal -= 5;
        if(health.CurrentVal <= 0)
        {
            //add death screen
            SceneManager.LoadScene("Game Over");
            Debug.Log("died");
        }
<<<<<<< HEAD

=======
>>>>>>> b376560cffca10708bb269019e0f87726f0a7345
    }
}
