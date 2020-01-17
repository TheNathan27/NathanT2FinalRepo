using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PenguinController : NetworkBehaviour
{
    private float speed;
    public float hBounds = 14.9f;
    public float vBounds = 6.9f;
    private float totalHealth  = 100.0f;
    public float currentHealth;
    private Collider BCollider;
    private bool hitBOn;
    public GameObject firePoint;
    public GameObject attack1;
    public GameObject pSprite;
    private bool cooldown1;
    public bool gameOverP1;
    public GameObject HboxP;
    public bool cooldown2;
    public GameObject attack2;
    private Animator pengAnim;
    
    void Start()
    {
        if(!isLocalPlayer)
            return;
        currentHealth = totalHealth;
        BCollider = GetComponent<BoxCollider>();
        hitBOn = true;
        cooldown1 = true;
        cooldown2 = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameOverP1 = false;
        pengAnim = pSprite.GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        SlowMode();
        Boundries();
        Attack();
        DirectionAnimation();
    }       

    void SlowMode(){
        if(Input.GetKey("left shift")){
            speed = 5.0f; 
            HboxP.gameObject.SetActive(true);
        }
        else{
            speed = 10.0f;
            HboxP.gameObject.SetActive(false);
        }
       
    }

    void Boundries(){
        if(transform.position.x < -hBounds){
            transform.position = new Vector3(-hBounds, transform.position.y, transform.position.z);
        }
        if(transform.position.x > hBounds){
            transform.position = new Vector3(hBounds, transform.position.y, transform.position.z);
        }
         if(transform.position.y < -vBounds){
            transform.position = new Vector3(transform.position.x, -vBounds, transform.position.z);
        }
        if(transform.position.y > vBounds){
            transform.position = new Vector3(transform.position.x, vBounds, transform.position.z);
        }
    }

    void DirectionAnimation(){
        if(transform.position.x < 0){
            pengAnim.SetBool("LeftofMiddle", true);
        }
        else if(transform.position.x > 0){
            pengAnim.SetBool("LeftofMiddle", false);
        }
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag != "pattack" && hitBOn == true){
            currentHealth = currentHealth - 5;
            BCollider.enabled = !BCollider.enabled;
            hitBOn = false; 
            StartCoroutine(HitInvincibility());
        }
        if(currentHealth <= 0){
            gameOverP1 = true;
            print("Player 2 Wins!");
            Destroy(gameObject);
        }
       
    }

    void Attack(){
        if(Input.GetMouseButtonDown(0) && cooldown1 == true){
            cooldown1 = false;
            StartCoroutine(Cooldown1());
            Instantiate(attack1, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, transform.position.z),
            firePoint.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1) && cooldown2 == true){
            cooldown2 = false;
            StartCoroutine(Cooldown2());
            Instantiate(attack2, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, transform.position.z),
            firePoint.transform.rotation);
        }
    }


    IEnumerator HitInvincibility(){
        yield return new WaitForSeconds(1);
        hitBOn = true;
        BCollider.enabled = !BCollider.enabled;
    }

    IEnumerator Cooldown1(){
        yield return new WaitForSeconds(0.1f);
        cooldown1 = true;
    }

    IEnumerator Cooldown2(){
        yield return new WaitForSeconds(2.0f);
        cooldown2 = true;
    }

}