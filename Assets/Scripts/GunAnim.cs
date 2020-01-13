using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour
{
    private Animator Gun;
    void Start()
    {
        Gun = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Gun.SetBool("TriggerDown", true);
        }
        else{
            Gun.SetBool("TriggerDown", false);
        }
    }
}
