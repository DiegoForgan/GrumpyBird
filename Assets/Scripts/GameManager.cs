using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    private int highScore;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject GameOverPanel;
    private static GameManager instance;
    private bool gameIsOver;

    public static GameManager Instance{

        get{
           if(instance == null) instance = FindObjectOfType<GameManager>();
           return instance; 
        }
    }
    
    private void Awake() {
        if (instance == null) instance = this;
        else {
          Destroy(gameObject);
          return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
        gameIsOver = false;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0) && gameIsOver){
            RestartGame();
        }
    }

    private void RestartGame(){
        gameIsOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NotifyPlayerDied(){
        gameIsOver = true;
        Time.timeScale = 0f;
        ShowGameOverScreen();
    }

    public void ShowGameOverScreen(){
        GameOverPanel.SetActive(true);
    }
    
    public void AddOneToScore(){
        score++;
        UpdateScoreUI();
    }
    private void UpdateScoreUI(){
        scoreText.SetText("Score: "+ score);
    }

    private void UpdateHighScoreUI(){
        highScoreText.SetText("HighScore: "+ highScore);
    }
}
