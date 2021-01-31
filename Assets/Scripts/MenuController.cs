using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Main_Scene");
    }

    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        Debug.Log("Main");
        SceneManager.LoadScene("TitleScene");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
