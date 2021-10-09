using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCow : MonoBehaviour
{
    public GameObject[] references;

    public int minValor;
    public int maxValor;

    public bool canMove;
    public bool canShoot;

    public float speed;
    public float cadence;
    public float detectDist;

    int random;

    public GameObject bullet;
    public Transform mira;

    Transform player;

    public GameObject fries;
    public GameObject efectoEnemy;

    public float playerForce;



    bool canSound;

    // Start is called before the first frame update
    void Start()
    {
        canSound = true;
        canShoot = true;
        canMove = true;
        random = Random.Range(minValor, maxValor);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();

        if (canSound)
        {
            StartCoroutine(Sound());
        }

        if (canMove == true)
        {
            FlyMoveEnemy();
        }

        Vector2 pp = player.position - this.transform.position;
        if (pp.x < -0.1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (pp.x > 0.1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        else { this.transform.localScale = new Vector3(1, 1, 1); }
    }

    void DetectPlayer()
    {
        float disToPlayer = Vector3.Distance(this.gameObject.transform.position, player.position);
        if (disToPlayer < detectDist)
        {
            if (canShoot)
            {
                StartCoroutine(CanIShoot());
            }
        }
    }

    public void FlyMoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, references[random].transform.position, speed * Time.deltaTime);
        if (transform.position == references[random].transform.position)
        {
            StartCoroutine(CanIMove());
        }
    }

    IEnumerator CanIMove()
    {
        canMove = false;
        yield return new WaitForSeconds(1);
        random = Random.Range(minValor, maxValor);
        canMove = true;
    }

    IEnumerator Sound()
    {
        canSound = false;
        yield return new WaitForSeconds(4);

        canMove = true;
    }

    IEnumerator CanIShoot()
    {
        canShoot = false;
        Instantiate(bullet, mira.position, Quaternion.identity);
        yield return new WaitForSeconds(cadence);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Toes")
        {
            DestroyEffectInJump();
        }
        if (col.gameObject.tag == "Bat")
        {
            DestroyEffectInShoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().LossTry();
        }
    }

    private void DestroyEffectInJump()
    {
        DropFries();
        GameObject efecto2 = Instantiate(efectoEnemy, this.transform.position, this.transform.rotation);
        Destroy(efecto2, 3);

        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerForce));

        player.GetComponent<Player>().AddPoints(30);

        Destroy(this.gameObject);
    }

    public void DestroyEffectInShoot()
    {
        DropFries();
        GameObject efecto2 = Instantiate(efectoEnemy, this.transform.position, this.transform.rotation);

        player.GetComponent<Player>().AddPoints(30);

        Destroy(efecto2, 3);
        Destroy(this.gameObject);
    }

    private void DropFries()
    {
        float randomNumber = Random.Range(1, 100);
        if (randomNumber > 70) Instantiate(fries, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectDist);
    }
}
