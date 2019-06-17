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

    /*
     * 
     * 
    public Rigidbody2D cube;

    public void MenuCubeJump(int side)
    {
        cube.isKinematic = false;
        Vector2 direction = new Vector2(side, 4.5f);

        if(cube.velocity.y == 0)
            cube.AddForce(direction * 1.4f, ForceMode2D.Impulse);

        StartCoroutine(ToPlayOrToQuit());
    }

    IEnumerator ToPlayOrToQuit()
    {
        yield return new WaitForSeconds(1f);
        if (cube.transform.position.x > 0)
            Play();

        if (cube.transform.position.x < 0)
            Quit();
        
    } */

}
