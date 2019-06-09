using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyMovement : MonoBehaviour
{
    public PauseManager Pause;
    public AudioSource sound;
    public ScoreManager score;
    public Transform player;
    int multiply;


    public GameObject Text100;
    private bool candyPowerUp = false;


    private void Start()
    {
        gameObject.SetActive(true);
        ChangePosition();
    }

    private void Update()
    {
        if(player.transform.position.y > transform.position.y + 5.3f)
        {
            ChangePosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int scoresUp = 5;

            if (candyPowerUp)
                scoresUp = 100;

            score.ScoresUp(scoresUp);

            if (Pause.sound)
                sound.Play();

            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        multiply++;
        transform.position = new Vector2(Random.Range(-2.35f, 2.35f), 2.45f + (6.6f * multiply * 3));
    }

    public void CandyPowerUp()
    {
        candyPowerUp = true;
        Text100.SetActive(true);
    }

}
