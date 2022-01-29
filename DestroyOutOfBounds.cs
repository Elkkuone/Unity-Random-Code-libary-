using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftLimit = -40;
    private float bottomLimit = -5;

    // Update is called once per frame
    private void Start()
    {
            }
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.z < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
