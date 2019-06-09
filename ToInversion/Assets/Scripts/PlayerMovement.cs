using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject willActiveObjects, willDisActiveObjects, info;
    public Transform cameraPos, rightPoint, leftPoint;
    public Rigidbody2D player;
    public float force;
    float maxY = -4;
    public bool dead = false;

    public ScoreManager score;
    public SpriteRenderer sprite;
    public ColorManager colorManager;

    public PauseManager Pause;
    public AudioSource sound;
    public AudioClip fall;

    public SpriteRenderer myImage;
    public AdsManagerBanner bannerManager;
    public AdsManager adsManager;
    int rnd = 0;

    private void Start()
    {
        rnd = Random.Range(0, 10);
        if (rnd == 5)
            adsManager.PrepareVideoAd();
    }

    private void Update()
    {
        if (transform.position.y > maxY)
            maxY = transform.position.y;

        cameraPos.transform.position = new Vector3(0, maxY, -10);

        if(transform.position.y < cameraPos.transform.position.y - 5.2)
        {
            sprite.gameObject.SetActive(false);
            Loose(myImage);
        }
    }

    public void Jump(string side)
    {
        if (player.isKinematic)
        {
            info.SetActive(false);
            player.isKinematic = false;

            if (PlayerPrefs.HasKey("Reward"))
            {
                int reward = PlayerPrefs.GetInt("Reward");

                if (reward == 1)
                {
                    colorManager.Inversion();
                    PlayerPrefs.SetInt("Reward", 0);
                }
            }

        }

        Vector3 direction = new Vector3(0, 0, 0);

        if (side == "Left")
           direction = leftPoint.transform.position - transform.position;

        if (side == "Right")
            direction = rightPoint.transform.position - transform.position;

        if ((!dead) && (Time.timeScale == 1))
        {
            if (Pause.sound)
                sound.Play();

            player.velocity = new Vector2(0, 0);
            player.AddForce(direction * force, ForceMode2D.Impulse);
        }

    }

    public void Loose(SpriteRenderer blockImage)
    {
        if (!dead)
        {
            dead = true;
            sound.clip = fall;

            if (Pause.sound)
                sound.Play();

            myImage.color = blockImage.color;
            StartCoroutine(ObjectsSetActive());


            bannerManager.ShowBanner();
            if (rnd == 5)
                adsManager.ShowVideo();

        }
    }

    IEnumerator ObjectsSetActive()
    {
        yield return new WaitForSeconds(1);
        score.GameOver();
        willActiveObjects.SetActive(true);
        willDisActiveObjects.SetActive(false);
        player.gameObject.SetActive(false);
    }
}
