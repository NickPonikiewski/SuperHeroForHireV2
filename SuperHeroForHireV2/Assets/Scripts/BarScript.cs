using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }

    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            //updates health
            content.fillAmount = fillAmount;
        }
        
    }

    private float Map(float value, float inMin, float inMax, float outMax, float outMin)
    {
        // sclaes the player's Health and health bar
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

    }
}
