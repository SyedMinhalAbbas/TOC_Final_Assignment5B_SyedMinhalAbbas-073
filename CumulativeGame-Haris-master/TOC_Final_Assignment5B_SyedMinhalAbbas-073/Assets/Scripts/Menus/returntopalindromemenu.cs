using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returntopalindromemenu : MonoBehaviour
{
    public Button PalindromeMenu;

    public string PalindromeMenuSceneName;

    public void ReturntoPalindromeMenu()
    {
        SceneManager.LoadScene(PalindromeMenuSceneName);
    }
}
