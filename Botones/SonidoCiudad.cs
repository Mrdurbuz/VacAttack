using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCiudad : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip ciudad;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ciudad);
    }

}
