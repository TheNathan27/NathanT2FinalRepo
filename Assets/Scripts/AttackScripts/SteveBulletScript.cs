using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveBulletScript : MonoBehaviour
{

    public float speed = 0.1f;
    public float vSpeed;


    void Start()
    {
        vSpeed = Random.Range(-0.05f, 0.05f);
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed);
        transform.Translate(Vector3.up * vSpeed);
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }


}
