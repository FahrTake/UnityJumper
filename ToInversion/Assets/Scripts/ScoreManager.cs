using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, logScoreText, logHighScoreText, logInversionText;
    public PlatformMovement[] platforms = new PlatformMovement[0];
    public Transform leftPartOne, leftPartTwo;
    public CandyMovement candy;
    private int highScore, level = 1;
    public int score, inversion;
    

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highScore = PlayerPrefs.GetInt("Highscore");

        

    }

    public void ScoresUp(int howMuch)
    {
        score += howMuch;
        scoreText.text = score.ToString();

        if (score >= (50 + (50 * level)))
            StartCoroutine(LevelUp(level));

    }

    IEnumerator LevelUp(int lvl)
    {
        level++;

        yield return new WaitForSeconds(0.6f);
        if (lvl == 1)
        {
            if (platforms[0].transform.eulerAngles.z < 90)
            {
                leftPartOne.transform.position = new Vector2(-2.5f, leftPartOne.transform.position.y);
            }
            else
            {
                leftPartOne.transform.position = new Vector2(2.5f, leftPartOne.transform.position.y);
            }

            if (platforms[1].transform.eulerAngles.z < 90)
            {
                leftPartTwo.transform.position = new Vector2(-2.5f, leftPartTwo.transform.position.y);
            }
            else
            {
                leftPartTwo.transform.position = new Vector2(2.5f, leftPartTwo.transform.position.y);
            }

        }

        if (lvl == 2)
        {
            foreach (PlatformMovement cube in platforms)
            {
                if (!cube.isPlatform)
                    cube.gameObject.transform.localScale = new Vector2(0.6f, 0.6f);
            }
        }

        if (lvl == 3)
        {
            foreach (PlatformMovement platform in platforms)
            {
                platform.speed *= 2;
            }
        }

        if(lvl == 4)
        {
            candy.CandyPowerUp();
        }

    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }

        logScoreText.text = "SCORE: " + score.ToString();
        logHighScoreText.text = "BEST SCORE: " + highScore.ToString();
        logInversionText.text = "INVERSION: " + inversion.ToString();
    }

}


/*
 
    private void LevelUp1()
    {
        if(level == 1)
        {
            if(platforms[0].transform.eulerAngles.z < 90)
            {
                leftPartOne.transform.position = new Vector2(-2.5f, leftPartOne.transform.position.y);
            }
            else
            {
                leftPartOne.transform.position = new Vector2(2.5f, leftPartOne.transform.position.y);
            }

            if (platforms[1].transform.eulerAngles.z < 90)
            {
                leftPartTwo.transform.position = new Vector2(-2.5f, leftPartTwo.transform.position.y);
            }
            else
            {
                leftPartTwo.transform.position = new Vector2(2.5f, leftPartTwo.transform.position.y);
            }
            
        }

        if(level == 2)
        {
            foreach(PlatformMovement cube in platforms)
            {
                if (!cube.isPlatform)
                    cube.gameObject.transform.localScale = new Vector2(0.6f, 0.6f);
            }
        }

        if(level == 3)
        {
            foreach (PlatformMovement platform in platforms)
            {
                platform.speed *= 2;
            }
        }

        level++;

    }


 */
