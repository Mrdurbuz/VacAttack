using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip select;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseUpAsButton()
    {
        audioSource.PlayOneShot(select);        
    }

}
