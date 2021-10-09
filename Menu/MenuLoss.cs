using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLoss : MonoBehaviour
{
    GameManager gameManager;

    private void Update()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Level" + gameManager.actualScene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
