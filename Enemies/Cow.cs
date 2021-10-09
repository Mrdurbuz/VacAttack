using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float speed;
    public float detectDist;
    public float gDetectRadio = 0.2f;

    Rigidbody2D rigi;

    Transform player;
    public float playerForce;

    public AudioClip atackk;

    AudioSource audioSource;

    public GameObject efectoEnemy;
    public ParticleSystem runDust;
    public bool isGrounded;
    public Transform refPie;

    public GameObject fries;

    Animator _an;

    private void Start()
    { 

        rigi = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponent<AudioSource>();

        _an = GetComponent<Animator>();
    }

    private void Update()
    {
        DetectPlayer();
        isGrounded = Physics2D.OverlapCircle(refPie.position, 2f, 1 << 8);
    }

    void DetectPlayer()
    {
        float distToPlayer = Vector2.Distance(player.position, this.transform.position);
        if (distToPlayer < detectDist)
        {
            Chase();
            _an.SetBool("Chasing", true);
            runDust.Play();
        }
        else{
            _an.SetBool("Chasing", false);
            return;
        }
    }

    public void Chase()
    {
        Vector2 pp = player.position - this.transform.position;
        if (pp.x < -0.1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World); 
        }
        else if (pp.x > 0.1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }

        else { this.transform.localScale = new Vector3(1, 1, 1); }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Toes" )
        {
            DestroyEffectInJump();
        }
        if(col.gameObject.tag == "Bat")
        {
            DestroyEffectInShoot();
            
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().LossTry();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectDist);
    }

    private void DestroyEffectInJump()
    {
        DropFries();
        GameObject efecto2 = Instantiate(efectoEnemy, this.transform.position, this.transform.rotation);
        Destroy(efecto2, 3);
       
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerForce));

        player.GetComponent<Player>().AddPoints(10);

        Destroy(this.gameObject);
    }

    public void DestroyEffectInShoot()
    {
        DropFries();
        GameObject efecto2 = Instantiate(efectoEnemy, this.transform.position, this.transform.rotation);

        player.GetComponent<Player>().AddPoints(10);

        Destroy(efecto2, 3);
        Destroy(this.gameObject);
    }

    private void DropFries()
    {
        float randomNumber = Random.Range(1, 100);
        if (randomNumber > 70) Instantiate(fries, this.transform.position + new Vector3(0,1,0), this.transform.rotation);
    }
}


