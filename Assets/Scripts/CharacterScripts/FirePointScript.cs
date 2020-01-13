using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointScript : MonoBehaviour
{
    public GameObject playeR;
    private float sensitivity;

    void Start()
    {
        
    }


    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Mouse X");
        transform.RotateAround(playeR.transform.position, transform.forward, vertical/sensitivity);
        transform.RotateAround(playeR.transform.position, transform.forward, -horizontal/sensitivity);
        SlowAim();
    }

    void SlowAim(){
        if(Input.GetKey("left shift")){
            sensitivity = 0.5f;
        }
        else{
            sensitivity = 0.2f;
        }
    }
}
