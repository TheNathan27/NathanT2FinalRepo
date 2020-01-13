using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GScript : MonoBehaviour
{

    public GameObject[] foodPrefabs;
    float speed = 0.2f;
    
    void Start()
    {
        InvokeRepeating("FallingFood", 1.0f, Random.Range(0.2f, 1.0f));
        StartCoroutine(DeathRoutine());
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed);
    }

    void FallingFood(){
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[foodIndex], new Vector3(transform.position.x, transform.position.y,
        transform.position.z), foodPrefabs[foodIndex].transform.rotation);
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
