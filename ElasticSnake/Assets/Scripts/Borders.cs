using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Borders : MonoBehaviour {
    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
	{
		
		if(other.CompareTag("SnakeMain"))
		{
            audio.Play();
            SceneManager.LoadScene("GameOver");
            
				//Application.LoadLevel(Application.loadedLevel);
		}

	}
}
