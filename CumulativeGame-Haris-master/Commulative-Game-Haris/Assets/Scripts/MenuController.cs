using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public Button startMlagents;
    public Button startComputationalModels;
    public Button linktowebsite;
    public Button listofitems;
    public Button Quit;


    public string mlagentSceneName;
    public string computationalmodelSceneName;
    public string listSceneName;

    public void MlagentMenu()
    {
        SceneManager.LoadScene(mlagentSceneName);
    }
    public void ComputationalModelMenu()
    {
        SceneManager.LoadScene(computationalmodelSceneName);
    }
    public void lists()
    {
        SceneManager.LoadScene(listSceneName);
    }
    public void websitelink()
    {
        Application.OpenURL("http://www.niazilab.com");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
 
    
}
