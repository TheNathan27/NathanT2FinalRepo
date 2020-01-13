using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : MonoBehaviour
{
    private float speed;
    public float hBounds = 24.0f;
    public float vBounds = 11.3f;
    private float totalHealth  = 100.0f;
    public float currentHealth;
    private Collider BCollider;
    private bool hitBOn;
    public GameObject firePoint;
    public GameObject attack1;
    private bool cooldown1;
    public bool gameOverP1;
    public GameObject Hbox;
    public bool cooldown2;
    public GameObject attack2;
    public bool shoot;
    private GameObject CTree;
 
    void Start()
    {
        currentHealth = totalHealth;
        BCollider = GetComponent<BoxCollider>();
        hitBOn = true;
        cooldown1 = true;
        cooldown2 = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameOverP1 = false;
        shoot = false;
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
    }       

    void SlowMode(){
        if(Input.GetKey("left shift")){
            speed = 5.0f; 
            Hbox.gameObject.SetActive(true);
        }
        else{
            speed = 10.0f;
            Hbox.gameObject.SetActive(false);
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

    public void OnCollisionEnter(Collision collision){
        if(hitBOn == true){
            currentHealth = currentHealth - 5;
            BCollider.enabled = !BCollider.enabled;
            hitBOn = false; 
            StartCoroutine(HitInvincibility());
            print(currentHealth);
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
            Instantiate(attack1, new Vector3(firePoint.transform.position.x, 
            firePoint.transform.position.y, transform.position.z), firePoint.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1) && cooldown2 == true){
            cooldown2 = false;
            StartCoroutine(Cooldown2());
        }
    }

    IEnumerator HitInvincibility(){
        yield return new WaitForSeconds(1);
        hitBOn = true;
        BCollider.enabled = !BCollider.enabled;
    }

    IEnumerator Cooldown1(){
        yield return new WaitForSeconds(0.3f);
        cooldown1 = true;
    }

    IEnumerator Cooldown2(){
        yield return new WaitForSeconds(8.0f);
        cooldown2 = true;
        shoot = false;
    }
}