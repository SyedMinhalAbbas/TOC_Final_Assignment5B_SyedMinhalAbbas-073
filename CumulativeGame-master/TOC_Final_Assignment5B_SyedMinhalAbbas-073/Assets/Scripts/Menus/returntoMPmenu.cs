using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returntoMPmenu : MonoBehaviour
{
    public Button MPMenu;

    public string MPMenuSceneName;

    public void ReturntoMPMenu()
    {
        SceneManager.LoadScene(MPMenuSceneName);
    }
}
