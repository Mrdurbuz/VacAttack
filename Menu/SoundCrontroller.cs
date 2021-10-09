using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCrontroller : MonoBehaviour
{
    public void changeVolume(float value)
    {
        AudioSource[] aSources = FindObjectsOfType<AudioSource>();
        if (aSources.Length > 0)
        {
            foreach (AudioSource ac in aSources)
            {
                ac.volume = value;
            }
        }
    }
}
