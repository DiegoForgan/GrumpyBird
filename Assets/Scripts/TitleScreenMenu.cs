using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour
{
    private void Start() {
        FindObjectOfType<AudioManager>().Play("TitleTheme");
    }
    public void StartGame(){
        FindObjectOfType<AudioManager>().Stop("TitleTheme");
        FindObjectOfType<AudioManager>().Play("GameplayTheme");
        SceneManager.LoadScene("Game");
    }
}
