using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    private bool toss;
    private float speed = 10.0f;
    private float rSpeed = 100.0f;
    private float hBound = 24.0f;
    private float vBound = 11.3f;
    void Start()
    {
        toss = true;
    }

   
    void Update()
    {
        if(toss == true){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            StartCoroutine(MoveRoutine());
        }
        else{
            transform.Rotate(Vector3.forward, rSpeed * Time.deltaTime);
            StartCoroutine(DeathRoutine());
        }

        if(transform.position.x < -hBound){
            toss = false;
        }
        if(transform.position.x > hBound){
            toss = false;
        }
        if(transform.position.y < -vBound){
            toss = false;
        }
        if(transform.position.y > vBound){
            toss = false;
        }
    }

    IEnumerator MoveRoutine(){
        yield return new WaitForSeconds(1.5f);
        toss = false;
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
