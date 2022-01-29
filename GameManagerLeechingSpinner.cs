using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    public int pointValue;

    public ParticleSystem explosionEffect;



    private GameManager gameManager;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    void Update()
    {

    }

    private void OnMouseDown() {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce() => Vector3.up * Random.Range(minSpeed, maxSpeed);

    float RandomTorque() => Random.Range(-maxTorque, maxTorque);

    Vector3 RandomSpawnPos => new Vector3 (Random.Range(-xRange, xRange), -ySpawnPos);

    
}