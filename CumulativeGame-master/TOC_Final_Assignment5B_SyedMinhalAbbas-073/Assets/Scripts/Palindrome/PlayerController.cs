using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public Text countText;
    public Text winText;
    private string resultString;
    public GameObject sphere;
    private static int Totalscore;
    private Rigidbody rb;
    private int count;

    //Update method
    void Update(){
        Totalscore = PositionController.totalnumberofpalindrom;
    }
    //Start method
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        
        
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
    //On TriggerEnter 
    void OnTriggerEnter(Collider other)
    {
        Text name;
        if (other.gameObject.CompareTag("Pick Up"))
        {
            
            resultString = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere"+Int32.Parse(resultString));            name = GameObject.Find("Sphere"+Int32.Parse(resultString)+"/Canvas/cubetext").GetComponent<Text>();            
            //Palindrome checking using Reverse() Method one 
            /*
            var reversed = new string(name.text.Reverse().ToArray());
            var original = new string(name.text.ToArray());            Debug.Log(name.text == reversed);            var palindrom = original == reversed;            if (palindrom == true) // Checking whether string is palindrome or not
            {
                other.gameObject.SetActive(false);
                Debug.Log("Palindrome  detected");
                sphere.gameObject.SetActive(false);
                Debug.Log(other.gameObject.name);
                count = count + 1;
                SetCountText();
            }
            */

            //Palindrome checking using Looping Method two 
            string s, revs = "";
            s = name.text;
            for (int i = s.Length - 1; i >= 0; i--) //String Reverse  
            {
                revs += s[i].ToString();
            }
            if (revs == s) // Checking whether string is palindrome or not  
            {
                other.gameObject.SetActive(false);
                Debug.Log("Palindrome  detected");
                sphere.gameObject.SetActive(false);
                Debug.Log(other.gameObject.name);
                count = count + 1;
                SetCountText();
            }
            else
            {
                Debug.Log("false");
            }
        }
    }
    // count the collected palindrome and compare with total  
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == Totalscore)
        {
            winText.text = "Great!" +"Palindrome Captured :" + Totalscore;
        }
    }
} 


       