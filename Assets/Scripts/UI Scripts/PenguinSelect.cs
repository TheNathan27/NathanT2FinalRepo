using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinSelect : MonoBehaviour
{
    public bool PenguinSelected;
   

    void Start(){
       PenguinSelected = false;
    }

    public void SelectPenguin(){
        PenguinSelected = true;
        SceneManager.LoadScene("SampleScene");
    }
}
