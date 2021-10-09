using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsArentAllright : MonoBehaviour
{
    public bool kid1OK;
    public bool kid2OK;
    public bool kid3OK;

    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (kid1OK)
            {
                player.GetComponent<Collection>().kid1OK = true;
                player.GetComponent<Player>().AddPoints(10);
            }
            if (kid2OK)
            {
                player.GetComponent<Collection>().kid2OK = true;
                player.GetComponent<Player>().AddPoints(20);
            }
            if (kid3OK)
            {
                player.GetComponent<Collection>().kid3OK = true;
                player.GetComponent<Player>().AddPoints(30);
            }

            Destroy(this.gameObject);
        }
    }
}
