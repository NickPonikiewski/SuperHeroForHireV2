using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    IEnumerator Wait(float sec, string newGameLevel)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(newGameLevel);
    }

	public void NewGameButton (string newGameLevel)
    {
        StartCoroutine(Wait(1, newGameLevel));
       
    }
	
    public void StoryPage (string Story)
    {
        SceneManager.LoadScene(Story);
    }

    public void HowtoplayButton (string Instructions)
    {
        SceneManager.LoadScene(Instructions);
    }

    public void Return (string Menu)
    {
        SceneManager.LoadScene(Menu);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

}
