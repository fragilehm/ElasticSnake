using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SnakeMovment : MonoBehaviour
{

    public float Speed;
    public float RotationSpeed;
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = 0.5f;

    public GameObject TailPrefab;
    public Text ScoreText;
    public int score = 0;
    public AudioClip DeathSound;
    public AudioClip AteSound;
    public AudioSource audioSource;
    void Start()
    {
        tailObjects.Add(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ScoreText.text = score.ToString();

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * -1 * RotationSpeed * Time.deltaTime);
        }
    }

    public void AddTail()
    {
        score++;
        if (score == 10)
        {
            if (SceneManager.GetActiveScene().name.Equals("Level1"))
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name.Equals("Level2"))
            {
                SceneManager.LoadScene("Level3");
            }
            else
            {
                SceneManager.LoadScene("Winner");
            }
        }

        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Border"))
        {
            audioSource.PlayOneShot(DeathSound);
        }
        else if (gameObject.CompareTag("Apple"))
        {
            audioSource.PlayOneShot(AteSound);
        }
    }
}
