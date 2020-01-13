using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingStrings : MonoBehaviour
{
    string testing;
    private AlienSelect aSelect;
    private PenguinSelect pSelect;

    void Start()
    {
        pSelect = GameObject.Find("PenguinBoi").GetComponent<PenguinSelect>();
        aSelect= GameObject.Find("UFOBoi").GetComponent<AlienSelect>();
    }

    void Update()
    {
        if(aSelect.AlienSelected == true){
            PlayerPrefs.SetString("testing", "Alien");
        }
        else if(pSelect.PenguinSelected == true){
            PlayerPrefs.SetString("testing", "pEnGuIn");
        }
        else{
            PlayerPrefs.SetString("testing", "Deh");
        }
    }
}
