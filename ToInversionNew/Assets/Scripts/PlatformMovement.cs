using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public PlayerMovement player;
    public Transform positionCamera, anotherPlatform;

    public bool isPlatform;
    float x;

    public ScoreManager Score;
    bool scoreGived = false;

    public PauseManager Pause;
    public AudioSource sound;

    public SpriteRenderer sprite, spriteSecond;
    public SpriteRenderer[] colors = new SpriteRenderer[0];
    int multiply = 1, colorIndex;

    bool moving;
    float input1;
    public float speed, input;

    private void Update()
    {
        if (transform.position.y < positionCamera.transform.position.y - 5)
            TransformUp();

        if (moving)
        {
            transform.position = transform.position + (transform.right * input * speed * Time.deltaTime);

            if (isPlatform)
            {
                if (transform.rotation.eulerAngles.z < 90)
                {
                    if ((transform.position.x >= 0.6f) && (input == 1))
                    {
                        input = -1;
                    }

                    if ((transform.position.x <= -3.15f) && (input == -1))
                    {
                        input = 1;
                    }


                }
                else if (transform.rotation.eulerAngles.z > 90)
                {
                    if ((transform.position.x >= 3.15f) && (input == -1))
                    {
                        input = 1;
                    }

                    if ((transform.position.x <= -0.6f) && (input == 1))
                    {
                        input = -1;
                    }
                }
                
            }
            else
            {
                if ((transform.position.x >= 1.8f) && (input == 1))
                {
                    input = -1;
                }

                if ((transform.position.x <= -1.8f) && (input == -1))
                {
                    input = 1;
                }

            }
            
        }
    }

    private void TransformUp()
    {
        if (moving)
        {
            moving = false;
            input = 0;
        }
            

        if (isPlatform)
        {
            int rnd = Random.Range(0, 2);

            if (rnd == 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);

            if (rnd == 1)
                transform.rotation = Quaternion.Euler(0, 0, 180);

            x = 0;

        }
        else
        {
            x = Random.Range(-1.5f, 1.5f);
        }

        transform.position = new Vector2(x, anotherPlatform.transform.position.y + 6.6f);
        scoreGived = false;

        if (transform.position.y >= 2 + (6.59 * multiply * 5))
            ColorChange();


        if (isPlatform)
        {
            if(Score.score >= 14)
                moving = (Random.value > 0.5f);

            if (Score.score >= 29)
                moving = true;

        }

        if (!isPlatform)
        {
            if(Score.score >= 24)
                moving = (Random.value > 0.5f);

            if (Score.score >= 39)
                moving = true;
        }

        if (moving)
        {
            bool side = (Random.value > 0.5f);

            if(side)
                input = 1;

            if(!side)
                input = -1;
            
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        player.Loose(sprite);
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!scoreGived)
            {
                Score.ScoresUp(1);
                scoreGived = true;

                if(Pause.sound)
                    sound.Play();
            }
        }
        
    }

    public void ColorChange()
    {
        multiply++;
        colorIndex++;

        if (colorIndex == 5)
            colorIndex = 0;

        sprite.color = colors[colorIndex].color;
/*
        if (colorIndex == 0)
             sprite.color = new Color32(255, 255, 255, 255);

        if (colorIndex == 1)
            sprite.color = new Color32(232, 67, 14, 255);// 108 92 231(147). Candy: "E84393".

        if (colorIndex == 2)
            sprite.color = new Color32(25, 42, 86, 255);

        if (colorIndex == 3)
            sprite.color = new Color32(250, 225, 50, 255);

        if (colorIndex == 4)
            sprite.color = new Color32(183, 21, 64, 255); */

        if (isPlatform)
            spriteSecond.color = sprite.color;
        
    }
}
