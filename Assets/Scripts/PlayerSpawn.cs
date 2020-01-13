using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    
    private LoadData spawnData;
    public GameObject APlayer;
    public GameObject PPlayer;
    private bool playerSpawned;
    public GameObject p1;

    void Start()
    {
        spawnData = gameObject.GetComponent<LoadData>();
        playerSpawned = false;
    }

    
    void Update()
    {
        
        if(spawnData.test == "Alien" && playerSpawned != true){
            p1 = Instantiate(APlayer, new Vector3(-20, 0, 1), transform.rotation);
            playerSpawned = true;
        }
        else if(spawnData.test == "pEnGuIn" && playerSpawned != true){
            p1 = Instantiate(PPlayer, new Vector3(20, 0, 1), transform.rotation);
            playerSpawned = true;
        }
        p1.tag = "player 1";
    }
}
