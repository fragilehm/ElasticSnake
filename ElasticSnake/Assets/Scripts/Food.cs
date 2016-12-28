using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
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
            other.GetComponent<SnakeMovment>().AddTail();
			Destroy(gameObject);
		}
	}

}
