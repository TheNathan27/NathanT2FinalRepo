using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirBlastScript : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(FRoutine());
    }

    IEnumerator FRoutine(){
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
