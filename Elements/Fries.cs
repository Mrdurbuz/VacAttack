using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    float iniY;

    public float quantity;

    GameObject player;

    void Start()
    {
        iniY = transform.position.y;
        player = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        float posiY = Mathf.PingPong(Time.time, 1f);
        transform.position = new Vector3(transform.position.x, iniY + posiY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().Fries();
            Destroy(this.gameObject);
        }
    }
}
