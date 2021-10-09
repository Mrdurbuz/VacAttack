using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int tries;

    GameObject player;

    public int actualScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        tries = 3;

        player = FindObjectOfType<Player>().gameObject;
    }

    public int GetTry()
    {
        return tries;
    }

    //variable para probar que la muerte del jugador va a la pantalla de derrota.
    public void Dead()
    {
        SceneManager.LoadScene("Loss");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Level" + actualScene);
        GetComponent<OptionsController>().SwichPause();
        GetComponent<OptionsController>().panelReiniciar.SetActive(false);
    }
     
    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + (actualScene + 1));
    }

    public void VueltaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}



