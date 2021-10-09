using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour
{
    public Text txtButton;
    int loadLvl;

    public void InitButton(int level, bool interact)
    {
        loadLvl = level;
        txtButton.text = loadLvl.ToString();
        GetComponent<Button>().interactable = interact;
    }

    public void UseButton()
    {
        //GameManager.instance.LoadLevel(loadLvl);
    }
}
