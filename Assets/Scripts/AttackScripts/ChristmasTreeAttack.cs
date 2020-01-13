using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeAttack : MonoBehaviour
{
    private GameObject AlienPlayer;
    private float rSpeed = 5.0f;
    private float fSpeed = 20.0f;
    private bool rotating;
    private AlienController alienscript;

    void Start()
    {
        AlienPlayer = GameObject.Find("APlayer(Clone)");
        rotating = true;
        alienscript = AlienPlayer.GetComponent<AlienController>();
    }
    
    void Update()
    {
        if(rotating == true){
            transform.RotateAround(AlienPlayer.transform.position, transform.forward, rSpeed);
            StartCoroutine(RotationRoutine());
        }
        if(alienscript.shoot == true){
            transform.Translate(Vector3.right * fSpeed * Time.deltaTime);
            StartCoroutine(DeathRoutine());
            rotating = false;
            transform.parent = null;
        }
        
    }

    IEnumerator RotationRoutine(){
        yield return new WaitForSeconds(3);
        rotating = false;
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        alienscript.shoot = false;
    }

}
