using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public bool paper;
    public bool duck;
    public bool phone;

    GameObject player;

    public int quantity;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (paper == true)
            {
                player.GetComponent<Player>().hasPaper = true;
                player.GetComponent<Player>().morePaper(quantity);
            }
            if(duck == true)
            {
                player.GetComponent<Player>().hasDuck = true;
                player.GetComponent<Player>().moreDuck(quantity);
            }
            if(phone == true)
            {
                player.GetComponent<Player>().hasPhone = true;
                player.GetComponent<Player>().morePhone(quantity);
            }
            Destroy(this.gameObject);
        }       
    }
}
