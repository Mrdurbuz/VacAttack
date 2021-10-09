using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvas : MonoBehaviour
{
    public Text info;
    public GameObject hud;
    public string message;

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            hud.SetActive(true);
            info.text = message;
        }    
    }
}
