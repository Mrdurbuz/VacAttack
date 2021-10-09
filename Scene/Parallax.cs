using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]

public class Parallax : MonoBehaviour
{
    private float length;
    private float startpos;
    public float efectoParallax;

    public float difParal;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        //posicion incial de la imagen
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //variable que indica el movimiento segun el largo de la imagen
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponentInParent<Transform>().position = player.transform.position + new Vector3(0, difParal, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float temp = Camera.main.transform.position.x * (1 - efectoParallax);
        float dist = Camera.main.transform.position.x * efectoParallax;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }else if( temp < startpos - length)
        {
            startpos -= length;
        }

    }
}
