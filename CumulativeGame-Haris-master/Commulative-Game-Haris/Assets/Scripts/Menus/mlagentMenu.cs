using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mlagentMenu : MonoBehaviour
{
    public Button startpenguin;
    public Button starthummingbird;
    public Button returntoMainMenu;
    public string penguinSceneName;
    public string hummingbirdSceneName;
    public string returnMainMenuName;

    public void PenguinGame()
    {
        SceneManager.LoadScene(penguinSceneName);
    }
    public void HummingbirdGame()
    {
        SceneManager.LoadScene(hummingbirdSceneName);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(returnMainMenuName);
    }
}



