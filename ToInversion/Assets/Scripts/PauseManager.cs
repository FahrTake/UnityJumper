using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseThings;
    public Sprite soundOnSprite, soundOffSprite, musicOnSprite, musicOffSprite;
    public Button soundButton, musicButton;
    private bool pause;
    public bool sound, music;

    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        if (PlayerPrefs.HasKey("Sound"))
        {
            int OnOrOff = PlayerPrefs.GetInt("Sound");

            if (OnOrOff == 0)
            {
                sound = false;
                soundButton.image.sprite = soundOffSprite;
            }
        }

        if (PlayerPrefs.HasKey("Music"))
        {
            int OnOrOffMusic = PlayerPrefs.GetInt("Music");

            if(OnOrOffMusic == 0)
            {
                music = false;
                musicButton.image.sprite = musicOffSprite;
            }
        }

    }

    public void TurnPause()
    {
        if (!pause)
        {
            pause = true;
            pauseThings.SetActive(true);
            Time.timeScale = 0;

        }
        else if(pause)
        {
            pause = false;
            pauseThings.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void TurnSound()
    {
        if (sound)
        {
            PlayerPrefs.SetInt("Sound", 0);
            sound = false;
            soundButton.image.sprite = soundOffSprite;
        }
        else if(!sound)
        {
            PlayerPrefs.SetInt("Sound", 1);
            sound = true;
            soundButton.image.sprite = soundOnSprite;
        }

    }

    public void TurnMusic()
    {

        if (music)
        {
            PlayerPrefs.SetInt("Music", 0);
            music = false;
            musicButton.image.sprite = musicOffSprite;
        }else if (!music)
        {
            PlayerPrefs.SetInt("Music", 1);
            music = true;
            musicButton.image.sprite = musicOnSprite;
        }

    }
    
}
