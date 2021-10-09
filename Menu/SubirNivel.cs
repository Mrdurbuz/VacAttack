using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirNivel : MonoBehaviour
{

    GameManager gameManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager = FindObjectOfType<GameManager>();
        if (collision.tag == "Player")
        {
            gameManager.actualScene++;
        }
    }
}
