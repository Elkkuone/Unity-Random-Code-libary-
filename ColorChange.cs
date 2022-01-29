using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private start()
    {
        Material material = Renderer.material; //Reference to the Material
        material.color = Random.ColorHSV(); //Switch Color every Time when hits Play

    }
    private Update()
    {
        transform.Rotate(11.0f * Time.deltaTime, 0.2f, 0.1f);
        switchcolorF = switchcolorF += 1.0f * Time.deltaTime; //Increase switchcolorF by 1 every Second.

        Material material = Renderer.material;
        if (switchcolorF >= 10.0f) //If switchcolorF reaches 10 or is above, switch the color and reset switchcolorF
        {
            material.color = Random.ColorHSV();
            switchcolorF = 1.0f;
        }
    }
}
