using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay = new List<string>();
    private float TimeToNextText;
  

    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Rotator();

        TimeToNextText += Time.deltaTime;
        
        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 5.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 1;


                Text.text = TextToDisplay[CurrentText];
            }
        }
    }

    void Rotator()
    {
        new Vector3 (0, 0, 4);
    }
}