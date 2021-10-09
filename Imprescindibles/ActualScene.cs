using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActualScene : MonoBehaviour
{
    GameManager gameManager;

    public int numeLevel;

    /*private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        gameManager = FindObjectOfType<GameManager>();
        if (collision.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().actualScene = numeLevel;
        }
    }
}
