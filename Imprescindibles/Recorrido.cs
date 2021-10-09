using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorrido : MonoBehaviour
{

    public Slider recorridoSlider;
    public float distancia;
    public float maxValue;
    
    public GameObject player;
    public GameObject final;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        maxValue = transform.position.x - player.transform.position.x;
        recorridoSlider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //recorridoSlider.maxValue = 337;
        distancia = (player.transform.position.x - final.transform.position.x);
        recorridoSlider.value = -distancia;
    }
}
