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

        #if UNITY_STANDALONE || UNITY_WEBPLAYER
         

        #else

        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    horizontal = x > 0 ? 1 : -1;
                else
                    vertical = y > 0 ? 1 : -1;
            }
           
        }

#endif
    }
    
}
