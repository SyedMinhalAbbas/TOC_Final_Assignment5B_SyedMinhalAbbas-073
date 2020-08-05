using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class returnfromlist : MonoBehaviour
{

    public Button MainMenu;
   
    public string MainMenuSceneName;
   
    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
   
}
