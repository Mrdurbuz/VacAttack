using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    //public GameObject startButton;
    //public GameObject optionsButton;
    //public GameObject exitButton;
    //public GameObject languajeButton;
    //public GameObject soundButton;
    

    public GameObject optionsPanel;

    public bool showOptions = false;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
    }

    public void SwitchOptionsPanel()
    {
        if (showOptions)
        {
            showOptions = false;
            optionsPanel.SetActive(false);
        }
        else
        {
            showOptions = true;
            optionsPanel.SetActive(true);
        }
    }

    public void Languaje()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SatartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void VolverOpciones()
    {
        optionsPanel.SetActive(false);

    }
}
