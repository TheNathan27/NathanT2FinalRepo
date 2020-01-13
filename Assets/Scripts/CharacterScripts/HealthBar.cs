using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private AlienController pScript;
    private float sizeNormalized;
    void Start()
    {
        bar = transform.Find("Bar");
    }

    void Update(){
        pScript = GameObject.Find("APlayer(Clone)").GetComponent<AlienController>();
        sizeNormalized = pScript.currentHealth * .01f;
        SetSize();
    }

    public void SetSize(){
        bar.localScale = new Vector3(sizeNormalized, 1.0f);
    }

}