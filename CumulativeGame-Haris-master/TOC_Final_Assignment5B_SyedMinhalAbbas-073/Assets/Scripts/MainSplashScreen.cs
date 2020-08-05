using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSplashScreen : MonoBehaviour
{
    public static int SceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        //check if current scene number is zero then run the function
        if (SceneNumber == 0)
        {
            StartCoroutine(ToMenuScene());
        }
    }

    IEnumerator ToMenuScene()
    {
        //wait for some seconds
        yield return new WaitForSeconds(3);
        SceneNumber = 1;
        //load next scene
        SceneManager.LoadScene(1);
    }

}
