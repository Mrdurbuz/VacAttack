using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    float xMove;
    public float speed;
    public float masSpeed;

    Rigidbody2D rb;

    public Transform refPie;

    public bool isGrounded;

    Animator anim;

    public AudioClip jumpSound;
    public AudioClip shootSound;
    public AudioClip meleAttack;

    AudioSource audioSource;

    public ParticleSystem jumpDust;
    public ParticleSystem runDust;

    GhostEffect ghost;

    public GameObject [] bullets;
    public Transform mira;
    public int select;

    public bool canHit;
    public float wait;

    public float cadenciaDisp;
    public bool canShoot;

    public bool hasPaper;
    public bool hasDuck;
    public bool hasPhone;

    public int howManyPaper;
    public int howManyDuck;
    public int howManyPhone;

    public int getPoints;

    void Start()
    {
        //Damos el valor a rb, para acceder directamente al rigidbody
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        ghost = GetComponent<GhostEffect>();
        ghost.enabled = false;

        canShoot = true;

        canHit = true; 

        select = 0;

        hasPaper = true;
        hasPhone = false;
        hasDuck = false;

        howManyDuck = 0;
        howManyPaper = 5;
        howManyPhone = 0;

        wait = 1;
    }

    void Update()
    {
        //Para saber si el player esta cerca del suelo.
        isGrounded = Physics2D.OverlapCircle(refPie.position, 2f, 1 << 8);
        if (isGrounded) anim.SetBool ("OnTheGround",true);  else anim.SetBool("OnTheGround", false);

        //Movimiento del personaje a izquierda y derecha
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (transform.localScale.x < 0)
            {
            
                transform.Translate(xMove * speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector3(transform.localScale.x * -Input.GetAxisRaw("Horizontal"), transform.localScale.y, transform.localScale.z);

            }else if(transform.localScale.x > 0)
            {
                
                transform.Translate(xMove * speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector3(transform.localScale.x * Input.GetAxisRaw("Horizontal"), transform.localScale.y, transform.localScale.z);
            }
            anim.SetFloat("Run", 1);
            if (isGrounded) RunDust(15, 10);
        }

        else
        {
            anim.SetFloat("Run", 0);
            runDust.Stop();
        }

        //Salto del personaje, hecho por fuerzas, si se pulsan las teclas y esta en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //***
            JumpDust();
            //aplicamos una fuerza en la posicion Y del vector2 del rigidbody
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
            anim.SetTrigger("Jump");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true)
        {
            speed = moveSpeed + masSpeed;
            anim.speed = 1.2f;
            RunDust(15, 20);

            ghost.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = moveSpeed;
            anim.speed = 0.8f;
            RunDust(15, 10);
            ghost.enabled = false;
        }

        MeleAttack();
        Guns();
    }


    void JumpDust()
    {
        jumpDust.Play();
    }

    void RunDust(int max, int min)
    {
        //Esto es para cambiar el numero de emision segun velocidad, pero no sé implementarlo
        //runDust.emission.rateOverTime.constantMax = max;
        //runDust.emission.rateOverTime.constantMin = min;
        runDust.Play();
    }

    public void MeleAttack()
    {
        if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.K)) && canHit == true)
        {
            audioSource.PlayOneShot(meleAttack);
            GetComponent<MeleeAttack>().BatAttack();
            anim.SetTrigger("Attacking");

            ghost.enabled = true;
            StartCoroutine(CanHitAgain());
        }
        else if (Input.GetKeyUp(KeyCode.C)|| Input.GetKeyUp(KeyCode.K))
        {
            ghost.enabled = false;
        }
    }

    public void Guns()
    {
        if ((Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.L)) && canShoot == true && (hasPaper || hasDuck || hasPhone))
        {
            audioSource.PlayOneShot(shootSound);
            anim.SetTrigger("Throwing");
            StartCoroutine(Shoot());

            if(select == 0)
            {
                howManyPaper--;
            }
            if(select == 1)
            {
                howManyDuck--;
            }
            if(select == 2)
            {
                howManyPhone--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && hasPaper && howManyPaper > 0)
        {
            select = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasDuck && howManyDuck > 0)
        {
            select = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasPhone && howManyPhone > 0)
        {
            select = 2;
        }

        if(howManyPaper <= 0)
        {
            hasPaper = false;
            //howManyPaper = 0;
            if(select == 0 && hasDuck)
            {
                select = 1;
            }else if(select == 0 && hasPhone)
            {
                select = 2;
            }
        }
        if(howManyDuck <= 0)
        {
            hasDuck = false;
            //howManyDuck = 0;
            if(select == 1 && hasPhone)
            {
                select = 2;
            }
            else if (select == 1 && hasPaper)
            {
                select = 0;
            }
        }
        if (howManyPhone <= 0)
        {
            hasPhone = false;
            //howManyPhone = 0;
            if (select == 2 && hasPaper)
            {
                select = 0;
            }
            else if (select == 2 && hasDuck)
            {
                select = 1;
            }
        }
    }

    public int AmmoPaper()
    {
        return howManyPaper;
        
    }

    public int AmmoDuck()
    {
        return howManyDuck;
    }

    public int AmmoPhone()
    {
        return howManyPhone;
    }

    public void morePaper(int quantity)
    {
        howManyPaper += quantity;
    }

    public void moreDuck(int quantity)
    {
        howManyDuck += quantity;
    }

    public void morePhone(int quantity)
    {
        howManyPhone += quantity;
    }

    IEnumerator CanHitAgain()
    {
        canHit = false;
        yield return new WaitForSeconds(wait);
        canHit = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (transform.localScale.x < 0)
        {
            mira.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.localScale.x > 0)
        {
            mira.rotation = Quaternion.Euler(0, 180, 0);
        }
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullets[select], mira.position, mira.rotation);
        yield return new WaitForSeconds(cadenciaDisp);
        canShoot = true;
    }

    public void AddPoints(int suma)
    {
        getPoints += suma;

    }

    public int HowMuchPoints()
    {
        return getPoints;
    }
}