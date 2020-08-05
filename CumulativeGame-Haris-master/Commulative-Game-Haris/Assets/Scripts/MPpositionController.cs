using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class MPpositionController : MonoBehaviour
{
    public GameObject theObject;
    public GameObject theSphere;
    public float maximumPosition = 10f;
    public float minimumPosition = -10f;
    private string randString;
    private int thestringlength;
    public static int totalnumberofMP;




    private Vector3 theNewPos;
    private int parenthesisIndex;
    public void spawn()
    {
        List<int> MPindexes = new List<int>();

        setMatchingParenthesisIndexes(MPindexes);
        GenerateCollectibles(MPindexes);
    }

    private void setMatchingParenthesisIndexes(List<int> MPindexes)
    {
        int MPindex;
        int i = 0;
        while (i < totalnumberofMP)
        {
            MPindex = Random.Range(0, 45);
            if (!MPindexes.Contains(MPindex) || MPindexes.Count == 0)
            {
                MPindexes.Add(MPindex);
                i++;
            }
        }
        // Debug.Log("Number of parenthesis indexes" + MPindex);
        Debug.Log("Total Number of parenthesis indexes" + totalnumberofMP);

    }



    private void GenerateCollectibles(List<int> MPindexes)
    {
        Text randomString;
        int cubeNumber = 0;
        List<int> parenthesisIndexes = new List<int>();

        while (cubeNumber < 46)
        {
            randString = "";
            float theXPosition = Random.Range(minimumPosition, maximumPosition);
            float theZPosition = Random.Range(minimumPosition, maximumPosition);
            theNewPos = new Vector3(theXPosition, 0.5f, theZPosition);
            if (Physics.CheckSphere(theNewPos, 0.36f))
            {
                continue;
            }
            else
            {
                GameObject sphere = Instantiate(theSphere);
                GameObject cube = Instantiate(theObject);
                sphere.name = "Sphere" + cubeNumber;
                cube.name = "Cube" + cubeNumber;
                sphere.transform.position = new Vector3(theXPosition, 1.1f, theZPosition);
                cube.transform.position = theNewPos;
                randomString = GameObject.Find("Sphere" + cubeNumber + "/Canvas/cubetext").GetComponent<Text>();
                string[] characters = new string[] { "x", "h", "6", "(", ")" };
                thestringlength = Random.Range(9, 15);

                if (MPindexes.Contains(cubeNumber))
                {
                    /***************************/
                    Debug.Log(cubeNumber);
                    int value = 0;
                    int openingBracket = 0;
                    while (value < thestringlength)
                    {

                        int randomSelect = Random.Range(0, 5);
                        if (randomSelect == 3)
                        {
                            if (value == (thestringlength - 1))
                            {

                            }
                            else
                            {
                                if (openingBracket == (thestringlength - value))
                                {
                                    Debug.Log(openingBracket == (thestringlength - value));
                                    for (int i = 0; i < openingBracket; i++)
                                    {
                                        randString = randString + characters[4];
                                        openingBracket--;
                                        value++;
                                    }
                                }
                                else
                                {
                                    randString = randString + characters[3];
                                    openingBracket++;
                                    value++;
                                    if (openingBracket > (thestringlength - value))
                                    {
                                        randString = randString.Remove(randString.Length - 1, 1);
                                        value--;
                                        openingBracket--;
                                        for (int i = 0; i < openingBracket; i++)
                                        {
                                            randString = randString + characters[4];
                                            openingBracket--;
                                            value++;
                                        }
                                    }
                                }
                            }
                        }
                        else if (randomSelect == 4)
                        {
                            if (openingBracket > 0)
                            {
                                if (openingBracket == (thestringlength - value))
                                {
                                    Debug.Log(openingBracket == (thestringlength - value));
                                    for (int i = 0; i < openingBracket; i++)
                                    {
                                        randString = randString + characters[4];
                                        openingBracket--;
                                        value++;
                                    }
                                }
                                else
                                {
                                    randString = randString + characters[4];
                                    openingBracket--;
                                    value++;
                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (openingBracket == (thestringlength - value))
                            {
                                for (int i = 0; i < openingBracket; i++)
                                {
                                    randString = randString + characters[4];
                                    openingBracket--;
                                    value++;
                                }
                            }
                            else
                            {
                                randString = randString + characters[randomSelect];
                                value++;
                                if (openingBracket > (thestringlength - value))
                                {
                                    randString = randString.Remove(randString.Length - 1, 1);
                                    value--;
                                    for (int i = 0; i < openingBracket; i++)
                                    {
                                        randString = randString + characters[4];
                                        openingBracket--;
                                        value++;
                                    }
                                }
                            }
                        }
                    }

                    /*****************************/

                }
                else
                {
                    for (int j = 0; j < thestringlength; j++)
                    {
                        randString = randString + characters[Random.Range(0, characters.Length)];
                    }
                }
                randomString.text = randString;
                cubeNumber++;
            }
        }
    }

    public static int _totalMP;
    public static int totalMP
    {
        get
        {
            return _totalMP;
        }
        set
        {
            _totalMP = value;
        }

    }

    void Start()
    {
        totalnumberofMP = 46 / 3;
        MPpositionController.totalMP = totalnumberofMP;
        spawn();
    }
}


