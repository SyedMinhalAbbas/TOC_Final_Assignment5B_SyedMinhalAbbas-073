using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ComputationalMenu : MonoBehaviour
{
    public Button startpalindrome;
    public Button startmatchingParenthesis;
    public Button returntoMainMenu;
    public string PalindromeMenuName;
    public string MatchingParenthesisMenuName;
    public string returnMainMenuName;

    public void PalindromeMenuGame()
    {
        SceneManager.LoadScene(PalindromeMenuName);
    }
    public void MatchingParenthesisMenu()
    {
        SceneManager.LoadScene(MatchingParenthesisMenuName);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(returnMainMenuName);
    }
}
