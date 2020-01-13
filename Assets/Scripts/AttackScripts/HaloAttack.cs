using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloAttack : MonoBehaviour
{
    
    public float speed;
    float timer;
    float aT;
    

    void Start()
    {
        InvokeRepeating("acceleration", 0.1f, 0.2f);
        aT = 0;
        StartCoroutine(DeathRoutine());
    }

   
    void Update()
    {   
        transform.Translate(Vector3.right * speed);    
    }

    void acceleration(){
        speed = speed + aT;
        aT = aT + 0.01f;

    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
