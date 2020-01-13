using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{

    public string test;

    void Start()
    {
       
        
    }

    void Update()
    {
        test = PlayerPrefs.GetString("testing");
    }
}
