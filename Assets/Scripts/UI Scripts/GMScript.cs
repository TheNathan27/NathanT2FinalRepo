using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject TextPanel;

    void Start(){

    }

    public void ShowText(){
        TextPanel.SetActive(true);

    }

    public void HideText(){
        TextPanel.SetActive(false);
    }
}
