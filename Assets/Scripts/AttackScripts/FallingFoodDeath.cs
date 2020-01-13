using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFoodDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -13){
            Destroy(gameObject);
        }
    }
}
