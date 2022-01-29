using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position);
        enemyRB.AddForce(moveDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
       
    }



}
