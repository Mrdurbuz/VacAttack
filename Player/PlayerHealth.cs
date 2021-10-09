using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool isWin;

    public bool godMode = false;

    public int tries;

    public AudioClip getDamage;

    AudioSource audioSource;

    Animator anim;

    public float fries;

    GameObject prefabCamera;
    Animator camAnim;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        isWin = false;

        tries = 3;

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        fries = 0;

        prefabCamera = GameObject.Find("PrefabCamera");
        camAnim = prefabCamera.GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tries <= 0)
        {
            print("Dead");
            gameManager.GetComponent<GameManager>().Dead();
        }

        //variable para probar que la victoria del jugador va a la pantalla de victoria.
        if (isWin == true)
        {
            SceneManager.LoadScene("Level2");
        }

        if (godMode)
        {
            Color mycolor = Color.white;
            mycolor = new Color(1, 1, 1, Mathf.PingPong(Time.time * 3, 1));
            GetComponent<SpriteRenderer>().color = mycolor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void Fries()
    {
        fries++;
        if(fries >= 2)
        {
            fries = 0;
            GainTry();
        }
    }

    public void GainTry()
    {
        if (tries <= 5)
        {
            tries += 1;
        }else if(tries >= 5)
        {
            GetComponent<Player>().AddPoints(15);
        }
    }

    public void LossTry()
    {
        if (!godMode)
        {
            if (tries > 0)
            {
                anim.SetTrigger("Damage");
                tries -= 1;
                audioSource.PlayOneShot(getDamage);
                FindObjectOfType<GameManager>().tries = tries;
                camAnim.SetTrigger("shake");
                StartCoroutine(ActiveGodMode(3));
            }
        }

    }

    IEnumerator ActiveGodMode(float time)
    {
        if (!godMode)
        {
            godMode = true;
            yield return new WaitForSeconds(time);
            godMode = false;
        }
    }

    public int GetTries()
    {
        return tries;
    }
}
