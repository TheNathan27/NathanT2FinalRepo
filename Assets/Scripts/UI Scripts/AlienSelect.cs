using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AlienSelect : MonoBehaviour
{

    public bool AlienSelected;

    void Start(){
        AlienSelected = false;
    }

    void Update(){

    }

    public void SelectAlien(){
        AlienSelected = true;
        SceneManager.LoadScene("SampleScene");
    }


}
