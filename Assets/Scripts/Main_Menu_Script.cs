using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour
{

    public void PlayGame()
    {

        Debug.Log("Play");
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {

        Debug.Log("Game quit");
        Application.Quit();

    }

}
