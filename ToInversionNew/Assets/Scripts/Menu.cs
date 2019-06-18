using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public bool isMenu = false;
    int highScore = 0;

    private void Start()
    {
        if (isMenu)
        {
            if (PlayerPrefs.HasKey("Highscore"))
                highScore = PlayerPrefs.GetInt("Highscore");
                
        }
        
        highScoreText.text = "BEST SCORE: " + highScore.ToString();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
