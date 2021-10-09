using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : MonoBehaviour
{
    public ParticleSystem stars;

    private void OnTriggerEnter2D(Collider2D col)
    {
  
        
        if (col.tag == "Enemie")
        {
           
            print("GolpeoVaca");
            stars.Play();
        }
    }
}
