using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class PositionController : MonoBehaviour
{
    public GameObject theObject;
    public GameObject theSphere;
    public float maximumPosition = 10f;
    public float minimumPosition = -10f;
    private string randString;
    private int thestringlength;
    //public Vector3[] theCubepositions;
    public static int totalnumberofpalindrom;

    //Spawn Method
    public void spawn()
    {
        //create list 
        List<int> list = new List<int>();
        int randomNumber;
        //number of palindrom from 3 to 10
        int palindromeLength = Random.Range(3, 10);
        Text name;
        //whateven length generate means total number of palindromes is in game
        totalnumberofpalindrom = palindromeLength;
        //testing
        Debug.Log("Palindrome Length: " + palindromeLength);

        //condition to set number of palindromes
        //loop upto palindrome length
        for (int i = 0; i < palindromeLength; i++)
        {
            //using random.range define range and store in random number
            randomNumber = Random.Range(0, 9);
            //check if not in list then add
            if (!list.Contains(randomNumber) || list.Count == 0)
            {
                list.Add(randomNumber);
            }
            else
            {
                palindromeLength = palindromeLength + 1;
            }
        }
        int k = 0;
        while (k < 10)
        {
            randString = "";
            float radius = 0.3f;
            //positioning of cubes randomly
            float theXPosition = Random.Range(minimumPosition, maximumPosition);
            float theZPosition = Random.Range(minimumPosition, maximumPosition);

            var theNewPos = new Vector3(theXPosition, 0.5f, theZPosition);
            if (Physics.CheckSphere(theNewPos, 0.36f))
            {
                Debug.Log(k + " Colliding");
            }
            else
            {
                GameObject sphere = Instantiate(theSphere);
                GameObject cube = Instantiate(theObject);
                sphere.name = "Sphere" + k;
                cube.name = "Cube" + k;

                //Another method for randomizing position // Assign vector3 array of position 
                //choose random position in vector3 array of position

                //int cuberandomNumber = Random.Range(0, theCubepositions.Length);
                //cube.transform.position = theCubepositions[cuberandomNumber];
                //sphere.transform.position = cube.transform.position;
                sphere.transform.position = new Vector3(theXPosition, 1.0f, theZPosition);
                cube.transform.position = theNewPos;

                name = GameObject.Find("Sphere" + k + "/Canvas/cubetext").GetComponent<Text>();
                //characters string will include following characters
                string[] characters = new string[] { "x", "h", "6" };
                //initlize range for length of string
                thestringlength = Random.Range(9, 15);
                if (list.Contains(k))
                {
                    for (int j = 0; j <= thestringlength / 2; j++)
                    {
                        randString = randString + characters[Random.Range(0, characters.Length)];
                    }
                    randString = randString + new string(randString.Reverse().ToArray());
                }
                else
                {
                    for (int j = 0; j < thestringlength; j++)
                    {
                        randString = randString + characters[Random.Range(0, characters.Length)];
                    }
                }
                name.text = randString;
                k++;
            }
        }
    }

    // Update is called once per frame
    void Start()
    {
        spawn();
    }
}