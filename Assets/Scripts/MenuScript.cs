using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    //loads the various scenes. based on what you are doing and ways to go to different scenes too
    public void MainMenuA()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_1");
    }
    public void WinGame()
    {
        SceneManager.LoadScene("_Scene_2");
    }
    public void FailGame()
    {
        SceneManager.LoadScene("_Scene_3");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
