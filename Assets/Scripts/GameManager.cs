using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject explanationPanel;
    private int highScore = 0;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject GameOverPanel;
    private static GameManager instance;
    private bool gameIsOver;
    private bool tutorialOnScreen;

    public static GameManager Instance{ get{ return instance; } }
    
    private void Awake() {
        if (instance == null) instance = this;
        else {
          Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        UpdateScoreUI();
        UpdateHighScoreUI();
        gameIsOver = false;
        ShowTutorial(true);
        FindObjectOfType<AudioManager>().Play("GameplayTheme");
    }

    private void ShowTutorial(bool state){
        tutorialOnScreen = state;
        explanationPanel.SetActive(state);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0) && gameIsOver){
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && tutorialOnScreen){
            ShowTutorial(false);
        }
    }
    private void RestartGame(){
        gameIsOver = false;
        Time.timeScale = 1f;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NotifyPlayerDied(){
        gameIsOver = true;
        Time.timeScale = 0f;
        if(score > highScore){ 
            PlayerPrefs.SetInt("HighScore",score);
            PlayerPrefs.Save();
        }
        ShowGameOverScreen();
    }

    public void ShowGameOverScreen(){
        GameOverPanel.SetActive(true);
    }
    
    public void AddOneToScore(){
        score++;
        UpdateScoreUI();
        FindObjectOfType<AudioManager>().Play("point");
    }
    private void UpdateScoreUI(){
        scoreText.SetText("Score: "+ score);
    }

    private void UpdateHighScoreUI(){
        highScoreText.SetText("HighScore: "+ highScore);
    }

    public bool IsTutorialOnScreen(){
        return tutorialOnScreen;
    }
}
