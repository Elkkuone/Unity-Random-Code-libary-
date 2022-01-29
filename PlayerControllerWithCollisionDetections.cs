using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{       // new value for rigidbody component
    private Rigidbody playerRB;
    public float speed = 5.0f;
    // new gameobject 
    private GameObject focalpoint;
    //bool value in start
    public bool hasPowerup = false;
    private float powerupStrenght = 15000.0f;
    public GameObject powerupIndicator;
    

    void Start()
    {

        // get regidbody component and set it to our player object 
        playerRB = GetComponent<Rigidbody>();
        // get the vocalpoint in game to our object
        focalpoint = GameObject.FindWithTag("MainCamera");
       
    }
    
    void Update()
    {
        
        // float value that makes moving up and down possible
        float fowardInput = Input.GetAxis("Vertical");
        // make the player move with the vocalpoint 
        playerRB.AddForce(focalpoint.transform.forward * fowardInput * speed);
        // make it so it follows player
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        // get the indicator to rotate
        powerupIndicator.transform.Rotate(new Vector3(0, 2, 0));


    }
    // when something hits this happens
    private void OnTriggerEnter(Collider other)
    {
        powerupIndicator.gameObject.SetActive(true);

        if (other.CompareTag("Powerup"))
        {
            // set powerup on
            hasPowerup = true;
            // destroy powerup 
            Destroy(other.gameObject);
            // when powerup Destroyed, this happens
            StartCoroutine(PowerupCountdownTimer());
        }
        IEnumerator PowerupCountdownTimer()

        {
            // wait 7 sec, after powerup = false
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // if something with powerup hits Enemy tagged GameObject && <-- Cheks if its on
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Other way form player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            // log for if it hits
            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
            // this keeps counting down even id it hits something
            powerupIndicator.gameObject.SetActive(true);
        }



    }
}
