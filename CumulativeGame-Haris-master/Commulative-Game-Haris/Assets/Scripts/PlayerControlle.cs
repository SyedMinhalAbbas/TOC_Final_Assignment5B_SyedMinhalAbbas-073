using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlle : PositionControlle
{// In this class of Player controller, there is used regular expression for which pallindrome requirement satisfied . The requirement is the autogeneration pallindrome string at different positions and the The string is attached with cubes using UI text compared with the given requirement that the first alphabet is x, the second one is m that one belong to first alphabet of my name and a last alphabet  that a numeric represent the last digit of registration number of institution.If the string not full filled the palindrome requirement never pickup or destroy 
    private Rigidbody _rigidbody;
    public int speed;
    private string theCubeIndex;
    public GameObject sphere;
    private int palindromeCount = 0;
    private static int totalPalindromes;
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        //In start method Component is actually an instance of a class so the first step is to get a reference to the Component instance you want to work with This is done with the GetComponent function you want to assign the Component object to a variable,you can set the values of its properties much as you would in the Inspector:
    }

    private void Update()
        //Returns the value of the virtual axis identified by Horizontal to local variable moveHorizontal. Similarly,Returns the value of the virtual axis identified by Vertical to local variable moveVertical
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.2f,moveVertical);
        //Control the speed of movement with the moveVertical parameter.Calculate a position between the points specified by current and target, moving no farther than the distance specified by move vertical value.
        _rigidbody.AddForce(movement * speed); 
        //The force applied used for controling the speed of ball as Force can only be applied to an active Rigidbody. If a GameObject is inactive, AddForce has no effect. Also, the Rigidbody cannot be kinematic.
    }
    void OnTriggerEnter(Collider other)//OnTriggerEnter method contain paramter named other, In this method first of all check the tag is collectables then match regex 
    {
        Text checkIsPalindrome,collectedPalindrome;
        if (other.gameObject.CompareTag ("Collectables"))
        {

            // Indicates whether the regular expression finds a match in the input string. that include two characters and one is numeric value, sphere varbale contain the finding gameobject using parameter thecubeindex. checkIsPalindrome basically check the string that generated having pallindrome or not using UI text.Using for loop for decrement that reverse the string of pallindrome and check the condition which randomly genearted pallindrome if the sequence according the pallindrome the set active variable change the false othervise not.
            //if the palindromeCount is equal to the totalPalindromes then using UItext display the message the collected pallindrome 
            theCubeIndex = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex));
            checkIsPalindrome = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex)+"/Canvas/Text").GetComponent<Text>();
            //var reversed = new string(checkIsPalindrome.text.Reverse().ToArray());
            string revs = "";
            for (int i = checkIsPalindrome.text.Length - 1; i >= 0; i--)  
            {
                revs += checkIsPalindrome.text[i].ToString();
            }
            if (revs == checkIsPalindrome.text)
            {
                other.gameObject.SetActive(false);
                sphere.gameObject.SetActive(false);
                palindromeCount += 1;
                if (palindromeCount == PositionControlle.totalPalindromes)
                {
                    collectedPalindrome = GameObject.Find("Canva/Tex").GetComponent<Text>();
                    collectedPalindrome.text = "Huurrraaahhh.... You collect " + palindromeCount + " Palindromes";
                }
            }
            
        }
    }
}
