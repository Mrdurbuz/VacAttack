using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    Transform player;

    Vector2 startPosition;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        startPosition = player.position - transform.position;
    }

    void Update()
    {

        transform.Translate(startPosition * speed * Time.deltaTime);
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerHealth>().LossTry();
            Destroy(this.gameObject);
        }
        
    }
}
