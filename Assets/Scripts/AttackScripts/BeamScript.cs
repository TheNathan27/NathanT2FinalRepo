using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    public float speed = 0.2f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed);
        StartCoroutine(DeathRoutine());
        
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }


}
