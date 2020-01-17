using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FirePointScript : NetworkBehaviour
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
        print(vertical);
        transform.RotateAround(playeR.transform.position, transform.forward, Input.GetAxis("Mouse Y")/sensitivity);
        transform.RotateAround(playeR.transform.position, transform.forward, -Input.GetAxis("Mouse X")/sensitivity);
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
