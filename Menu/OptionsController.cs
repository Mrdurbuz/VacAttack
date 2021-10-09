using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelReiniciar;
    bool isPaused = false;

    AudioSource audioSource;

    public AudioClip enterPause;
    public AudioClip exitPause;

    // Start is called before the first frame update
    private void Start()
    {
        panelPause.SetActive(false);
        panelReiniciar.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public bool GetIfPaused()
    {
        return isPaused;
    }

    public void SwichPause()
    {
        if (isPaused)
        {
            panelPause.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            audioSource.PlayOneShot(enterPause);
        }
        else
        {
            panelPause.SetActive(true);
            isPaused = true;
            Time.timeScale = 0.0001f;
            audioSource.PlayOneShot(exitPause);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwichPause();
        }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SwichPause();
    }

    public void Reiniciar()
    {
        panelReiniciar.SetActive(true);
        panelPause.SetActive(false);
    }

    public void Volver()
    {

        
        panelPause.SetActive(true);
        panelReiniciar.SetActive(false);
    }
       
}
