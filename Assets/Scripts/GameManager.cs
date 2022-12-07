using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public variables
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText; //score text assigned to text mesh pro
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;

    //private variables
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        //while condition true, run loop continuously
        while (isGameActive)
        {
            //suspends coroutine for specified time
            yield return new WaitForSeconds(spawnRate);
            //random index from zero to size of list
            int index = Random.Range(0, targets.Count);
            //spawn random target
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; //score increases everytime UpdateScore argument is run
        scoreText.text = "Score: " + score; //will update text ingame as score variable changes
    }
    
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); //activates restart button
        gameOverText.gameObject.SetActive(true); //activates gameover text
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //scene manager will reload the current active scene
    }
}
