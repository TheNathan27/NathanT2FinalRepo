using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeScript : MonoBehaviour
{
    private GMScript GM;
    private AlienController AC;

    void Start(){
        GM = GameObject.Find("GameManager").GetComponent<GMScript>();
        AC = GameObject.Find("APlayer(Clone)").GetComponent<AlienController>();
    }

    void Update(){
        if(Input.GetKey("q")){
            AC.speed = 10.0f;
            GM.HideText();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Hit");
        GM.ShowText();
        AC.speed = 0;
    }
}
