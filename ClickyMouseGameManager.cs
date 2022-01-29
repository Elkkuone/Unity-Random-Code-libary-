using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float maxRate = 0.9f;

    public Button RestartButton;
    //TMPro
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    public GameObject titleScreen;

    private int score;


    void Start()
    {
       
    }

    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(maxRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        RestartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void StartGame(int difficulty)
    {
        
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        // ingore collision with each other
        Physics.IgnoreLayerCollision(3, 3);
        // to start spawning
        StartCoroutine(SpawnTarget());
        //TMPro
        UpdateScore(0);
        maxRate /= difficulty;
    }
}
