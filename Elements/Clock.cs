using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    int time;
    bool canCount;

    private void Start()
    {
        time = 0;
        canCount = true;
    }

    private void Update()
    {
        if (canCount == true)
            StartCoroutine(Count());
    }

    public int WhatTime()
    {
        return time; 
    }

    IEnumerator Count()
    {
        canCount = false;
        yield return new WaitForSeconds(1);
        time++;
        canCount = true;
    }
}
