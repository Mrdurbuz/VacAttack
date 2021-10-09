using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfo : MonoBehaviour
{
    public List<GameObject> triesImages = new List<GameObject>();

    public GameObject canvasPaper;
    public GameObject canvasDuck;
    public GameObject canvasPhone;

    public GameObject canvasPaperActive;
    public GameObject canvasDuckActive;
    public GameObject canvasPhoneActive;

    public GameObject[] gunActive;
    public int whatGun;

    public Text municion;
    public Text clock;

    public Slider friesSlider;
    public float fries;

    GameObject player;

    public GameObject kid1;
    public GameObject kid2;
    public GameObject kid3;

    public Text points;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;

        canvasPaperActive.SetActive(false);
        canvasDuckActive.SetActive(false);
        canvasPhoneActive.SetActive(false);
    }

    void Update()
    {
        LifeCanvas();
        GunsCanvas();
        Count();
        Kids();
        CountPoints();
    }

    public void Kids()
    {
        if(player.GetComponent<Collection>().kid1OK == true)
        {
            kid1.SetActive(true);
        }
        if (player.GetComponent<Collection>().kid2OK == true)
        {
            kid2.SetActive(true);
        }
        if (player.GetComponent<Collection>().kid3OK == true)
        {
            kid3.SetActive(true);
        }
    }

    public void CountPoints()
    {
        points.text = player.GetComponent<Player>().HowMuchPoints().ToString();
    }

    public void Count()
    {        
        clock.text = GetComponent<Clock>().WhatTime().ToString();
    }

    public void LifeCanvas()
    {
        int numetries = player.GetComponent<PlayerHealth>().GetTries();
        for (int i = 0; i < triesImages.Count; i++)
        {
            if (numetries > i)
            {
                triesImages[i].SetActive(true);
            }
            else
            {
                triesImages[i].SetActive(false);
            }
        }

        fries = player.GetComponent<PlayerHealth>().fries;
        friesSlider.maxValue = 2;
        friesSlider.value = fries;

    }

    public void GunsCanvas()
    {
        if (player.GetComponent<Player>().hasPaper == true)
        {
            canvasPaper.SetActive(true);
        }
        else if(player.GetComponent<Player>().hasPaper == false)
        {
            canvasPaper.SetActive(false);
        }

        if (player.GetComponent<Player>().hasDuck == true)
        {
            canvasDuck.SetActive(true);
        }
        else if(player.GetComponent<Player>().hasDuck == false)
        {
            canvasDuck.SetActive(false);
        }

        if (player.GetComponent<Player>().hasPhone == true)
        {
            canvasPhone.SetActive(true);
        }
        else if (player.GetComponent<Player>().hasPhone == false)
        {
            canvasPhone.SetActive(false);
        }

        whatGun = player.GetComponent<Player>().select;

        if (whatGun == 0)
        {
            municion.text = player.GetComponent<Player>().AmmoPaper().ToString();
            if (player.GetComponent<Player>().hasPaper == true)
            {
                canvasPaperActive.SetActive(true);
                canvasDuckActive.SetActive(false);
                canvasPhoneActive.SetActive(false);
            }

        }

        if (whatGun == 1)
        {
            municion.text = player.GetComponent<Player>().AmmoDuck().ToString();
            if (player.GetComponent<Player>().hasDuck == true)
            {
                canvasDuckActive.SetActive(true);
                canvasPhoneActive.SetActive(false);
                canvasPaperActive.SetActive(false);

            }

        }

        if (whatGun == 2)
        {
            municion.text = player.GetComponent<Player>().AmmoPhone().ToString();
            if (player.GetComponent<Player>().hasPhone == true)
            {
                canvasPhoneActive.SetActive(true);
                canvasDuckActive.SetActive(false);
                canvasPaperActive.SetActive(false);
            }

        }
    }
}
