using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class MPplayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private string resultString;
    public GameObject sphere;
    private static int Totalscore;
    private Rigidbody rb;
    private int count;
    const char LeftParenthesis = '(';
    const char RightParenthesis = ')';


    //Update method
    void Update()
    {
        //Totalscore = PositionController.totalnumberofMP;
    }
    //Start method
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        Debug.Log("total number is " + Totalscore);


    }
    //Fixed Update
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //add force
        rb.AddForce(movement * speed);
    }

    static bool isBalancedWithStack(string str)
    {

        if (str.Length <= 1 || str.Equals(null))
            return false;

        var items = new Stack<int>(str.Length);
        int errorAt = -1;
        for (int i = 0; i < str.Length; i++)
        {

            if (str[i].Equals(LeftParenthesis))
                items.Push(i);
            else if (str[i].Equals(RightParenthesis))
            {
                if (items.Count == 0)
                {
                    errorAt = i + 1;
                    return false;
                }
                items.Pop();
            }
        }
        if (items.Count > 0)
        {
            errorAt = items.Peek() + 1;
            return false;
        }
        return true;

    }
    //On TriggerEnter 
    void OnTriggerEnter(Collider other)
    {
        Text name;
        if (other.gameObject.CompareTag("Pick Up"))
        {

            resultString = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere" + Int32.Parse(resultString));
            name = GameObject.Find("Sphere" + Int32.Parse(resultString) + "/Canvas/cubetext").GetComponent<Text>();


            string s = name.text;
            if (isBalancedWithStack(s))
            {
                if (true)
                {
                    other.gameObject.SetActive(false);
                    Debug.Log("Match Parenthesis");
                    Debug.Log(s);
                    sphere.gameObject.SetActive(false);
                    Debug.Log(other.gameObject.name);
                    count = count + 1;
                    countText.text = "Count: " + count.ToString();
                    if (count == MPpositionController.totalnumberofMP)
                    {
                        Time.timeScale = 0;
                        winText.text = "Matching Parenthesis Captured :" + MPpositionController.totalnumberofMP;

                    }
                    //SetCountText();
                }
                else
                {
                    Debug.Log("false");
                }
            }

        }

    }







    // count the collected palindrome and compare with total  
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == MPpositionController.totalnumberofMP)
        {

            winText.text =  "Matching Parenthesis Captured :" + MPpositionController.totalnumberofMP;

        }

    }
}
