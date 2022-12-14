using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //public variables
    public int difficulty;

    //private variables
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty); //button listens for click event and runs method
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
