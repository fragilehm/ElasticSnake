using UnityEngine;
using UnityEngine.SceneManagement;


using System.Collections;

public class LevelManager : MonoBehaviour {
    
	// Use this for initialization
	public void Play() {
        SceneManager.LoadScene("Play");
	}
	public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
	// Update is called once per frame
	public void Quit () {
        Application.Quit();
	}
}
