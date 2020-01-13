using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar2 : MonoBehaviour
{
    private Transform bar;
    private PenguinController pScript;
    private float sizeNormalized;
    void Start()
    {
        bar = transform.Find("Bar2");
        pScript = GameObject.Find("PPlayer").GetComponent<PenguinController>();
    }

    void Update(){
        sizeNormalized = pScript.currentHealth * .01f;
        SetSize();
    }

    public void SetSize(){
        bar.localScale = new Vector3(sizeNormalized, 1.0f);
    }
}
