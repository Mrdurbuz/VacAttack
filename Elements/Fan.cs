using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    public float force;
    private bool firsttime;

    GameObject player;

    AudioSource audioSource;

    public AudioClip wind;
    public AudioClip fan;

    bool canSound;
    bool canFanSound;

    private void Start()
    {
        firsttime = true;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        canFanSound = true;
        canSound = true;
    }

    private void Update()
    {

        if (canFanSound)
        {
            StartCoroutine(FanSound());
        }
        
        if (player.GetComponent<Player>().isGrounded) firsttime = true;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player" && firsttime)
        {
            col.GetComponent<Rigidbody2D>().AddForce(-col.GetComponent<Rigidbody2D>().velocity);
            firsttime = false;
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (canSound)
            {
                StartCoroutine(Sound());
            }
            col.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(0, 
            this.transform.position.y * -force * Time.fixedDeltaTime), 
            this.transform.position + new Vector3(10,0,0));
        }
    }

    IEnumerator Sound()
    {
        canSound = false;
        audioSource.PlayOneShot(wind);
        yield return new WaitForSeconds(3.5f);
        canSound = true;
    }

    IEnumerator FanSound()
    {
        canFanSound = false;
        audioSource.PlayOneShot(fan);
        yield return new WaitForSeconds(3.5f);
        canFanSound = true;
    }
}
