using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // gets player input
    public float horizontal;
    // makes the movement and amount
    public float speed = 70.0f;
    // x variable for both
    public float xRange = 10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player moves too much in any direction, then
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        { 
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // gets player input a,d
        horizontal = Input.GetAxis("Horizontal");
        // makes the movement happen a,d
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
