using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class PositionControlle : MonoBehaviour
{
    public GameObject theCube;
    public GameObject theSphere;
    public float maxPos= 0f;
    public float minPos = 30f;
    private string createdRandomString;
    public int thestringlength;
    private static int palindromeLength;
    private Vector3 theNewPos;
    public void spawn()
    {
        List<int> palindromeIndexes = new List<int>();
        int palindromeIndex;

        Text randomString;
        for (int i = 0; i < palindromeLength; i++)
        {
            palindromeIndex = Random.Range(0, 9);
            if (!palindromeIndexes.Contains(palindromeIndex) || palindromeIndexes.Count == 0)
            {
                palindromeIndexes.Add(palindromeIndex);
            }
            else
            {
                palindromeLength = palindromeLength + 1;
            }
        }

        int cubeNumber = 0;
        while (cubeNumber<10)
        {
            createdRandomString = "";
            float theXPosition = Random.Range(minPos, maxPos);
            float theZPosition = Random.Range(minPos, maxPos);
            theNewPos= new Vector3 (theXPosition,0.5f,theZPosition);
            if (Physics.CheckSphere(theNewPos, 0.36f))
            {
                continue;
            }
            else
            {
                GameObject sphere = Instantiate(theSphere);
                GameObject cube = Instantiate(theCube);
                sphere.name = "Sphere" + cubeNumber;
                cube.name = "Cube" + cubeNumber;
                sphere.transform.position = new Vector3(theXPosition,1.1f,theZPosition);
                cube.transform.position = theNewPos;
                randomString = GameObject.Find("Sphere"+cubeNumber+"/Canvas/Text").GetComponent<Text>();
                string[] characters = new string[] { "x", "m", "3"};
                thestringlength = Random.Range(9, 15);
                if (palindromeIndexes.Contains(cubeNumber))
                {
                    for (int j = 0; j < thestringlength/2; j++) 
                    {
                        createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)]; 
                    }
                    createdRandomString = createdRandomString + new string(createdRandomString.Reverse().ToArray());
                }
                else
                {
                    for (int j = 0; j < thestringlength; j++) 
                    {
                        createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)]; 
                    }   
                }

                randomString.text = createdRandomString;
                cubeNumber++;
            }
        }
    }
    
    public static int _totalPalindromes;
    public static int totalPalindromes
    {
        get
        {
            return _totalPalindromes;
        }
        set
        {
            _totalPalindromes = value;
        }

    }
    
    void Start()
    {
        palindromeLength = Random.Range(3, 10);
        PositionControlle.totalPalindromes = palindromeLength;
        spawn();
    }
}