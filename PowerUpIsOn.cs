using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //bool value in start
    public bool hasPowerup = false;
    private float powerupStrenght = 150.0f;
    public GameObject powerupIndicator;
    
    
    void Update()
    {
        // make it so it follows player
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        // NOT NEEDED get the indicator to rotate
        powerupIndicator.transform.Rotate(new Vector3(0, 2, 0));


    }
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
