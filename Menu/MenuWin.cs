using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    GameManager gameManager;

    private void Update()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + gameManager.actualScene);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //public void NextLevel

    public void ExitButton()
    {
        Application.Quit();
    }
}
