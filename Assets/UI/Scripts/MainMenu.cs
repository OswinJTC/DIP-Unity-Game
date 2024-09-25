using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OnContinueButton()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void OnControlsButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }

}
