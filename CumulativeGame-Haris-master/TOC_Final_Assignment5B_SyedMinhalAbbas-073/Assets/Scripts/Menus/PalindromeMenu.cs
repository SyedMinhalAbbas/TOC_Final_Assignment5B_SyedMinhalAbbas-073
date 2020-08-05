using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PalindromeMenu : MonoBehaviour
{
    public Button startchooselanguage;
    public Button startpalindrome;
    public Button returntoMainMenu;
    public string chooselanguagesceneName;
    public string palindromeGameName;
    public string returnMainMenuName;
    //public Text displayText;

    public void ChooseLanguage()
    {
        SceneManager.LoadScene(chooselanguagesceneName);
    }
    public void PalindromeGame()
    {
        SceneManager.LoadScene(palindromeGameName);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(returnMainMenuName);
    }
    /*
    public void DisplayText()
    {
        displayText.text = "x , h, 6 ";
    }
     * */
}
