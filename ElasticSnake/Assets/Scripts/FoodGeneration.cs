using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FoodGeneration : MonoBehaviour {

	public float XSize = 8.8f;
	public float ZSize = 8.8f;
	public GameObject foodPrefab;
	public Vector3 curPos;
	public GameObject curFood;
    public Text Level;
    
	void AddNewFood()
	{
	    RandomPos();

       
            curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
        
	}
	void RandomPos()
	{

        // if ((Level.text).CompareTo("1") == 0)
        // {
        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            curPos = new Vector3(Random.Range(-XSize, XSize), 0.25f, Random.Range(-ZSize, ZSize));
        }
        else if(SceneManager.GetActiveScene().name.Equals("Level2"))
        { 
       
            float X = Random.Range(-XSize, XSize);
            curPos = new Vector3(X, 0.25f, validZ(X));
           
        }
        else
        {
            float X = Random.Range(-XSize, XSize);
            curPos = new Vector3(X, 0.25f, validZ(X));
        }
	}

	void Update()
	{

        if (!curFood)
		{
			AddNewFood();
		}
		else
		{
			return;
		}
	}
    float validZ(float x)
    {
       /* float leftButtomX1 = -3.2f;
        float leftButtomX2 = -6.8f;
        float leftButtomZ1 = -5.4f;
        float leftButtomZ2 = -6.6f;

        float RightButtomX1 = 3.2f;
        float RightButtomX2 = 6.8f;
        float RightButtomZ1 = -5.4f;
        float RightButtomZ2 = -6.6f;

        float leftTopX1 = -3.2f;
        float leftTopX2 = -6.8f;
        float leftTopZ1 = 5.4f;
        float leftTopZ2 = 6.6f;

        float RightTopX1 = 3.2f;
        float RightTopX2 = 6.8f;
        float RightTopZ1 = 5.4f;
        float RightTopZ2 = 6.6f;*/

        float res = 0;
        if (SceneManager.GetActiveScene().name.Equals("Level2"))
        {
            while (check(-3.2f, -6.8f, -5.4f, -6.6f, x, res))
            {
                res = Random.Range(-XSize, XSize);
            }
        }
        else
        {
            while (check(-3.2f, -6.8f, -5.4f, -6.6f, x, res) || check1(-5.4f, -6.6f, 1.8f, -1.8f, x, res))
            {
                res = Random.Range(-XSize, XSize);
            }
        }


        return res;


    }
    bool check(float x1, float x2, float z1, float z2, float x, float z)
    {
        if (x < x1 && x > x2 && z < z1 && z > z2)
        {
            return true;
        }
        if (x < -x2 && x > -x1 && z < z1 && z > z2)
        {
            return true;
        }
        if (x < x2 && x > x1 && z > z1 && z < z2)
        {
            return true;
        }
        if (x < -x2 && x > -x1 && z > z1 && z < z2)
        {
            return true;
        }
         return false;
    }
    bool check1(float x1, float x2, float z1, float z2, float x, float z)
    {
        if (x < x1 && x > x2 && z < z1 && z > z2)
        {
            return true;
        }
        if (x < -x2 && x > -x1 && z < z1 && z > z2)
        {
            return true;
        }
        return false;
    }
}
