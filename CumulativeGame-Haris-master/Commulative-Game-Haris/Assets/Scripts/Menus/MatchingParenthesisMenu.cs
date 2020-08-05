using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchingParenthesisMenu : MonoBehaviour
{
    public Button startchooselanguage;
    public Button startmatchingparenthesis;
    public Button returntoMainMenu;
    public string chooselanguagesceneName;
    public string matchingparenthesisGameName;
    public string returnMainMenuName;
    public Text displayText;

    public void ChooseLanguage()
    {
        SceneManager.LoadScene(chooselanguagesceneName);
    }
    public void matchingParenthesisGame()
    {
        SceneManager.LoadScene(matchingparenthesisGameName);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(returnMainMenuName);
    }
 
    public void DisplayText()
    {
        displayText.text = "x , h, 6 , ( , )";
    }

}
