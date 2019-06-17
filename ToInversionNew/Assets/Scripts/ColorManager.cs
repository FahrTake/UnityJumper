using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Camera cam; //0ABDE3
    public SpriteRenderer[] candyAndPlayer = new SpriteRenderer[0];
    public SpriteRenderer[] platformSprite = new SpriteRenderer[0];
    Color32[] oldColor = new Color32[7]; // Ind: 0, 1, 2, 3, 4 - Цвета платформ, Ind: 5 - Конфета и Игрок, Ind: 6 - Фон Камеры.

    public Transform player;
    private int multiply = 1;
    public ScoreManager scoreManager;

    private void Start()
    {
        SaveColor();
    }

    private void Update()
    {
        if(player.transform.position.y >= (multiply * 170))
        {
           Inversion();
        }
    }

    public void Inversion()
    {
        Debug.Log("Now");
        Color32 saveColor = oldColor[6];

        for (int i = 6; i > 0; i--)
        {
            oldColor[i] = oldColor[i - 1];

            if (i == 6)
                cam.backgroundColor = new Color32(oldColor[i].r, oldColor[i].g, oldColor[i].b, 0);

            if (i == 5)
            {
                foreach (SpriteRenderer sprite in candyAndPlayer)
                {
                    sprite.color = oldColor[i];
                }
            }

            if (i <= 4)
                platformSprite[i].color = oldColor[i];
        }

        oldColor[0] = new Color32(saveColor.r, saveColor.g, saveColor.b, 255);
        platformSprite[0].color = oldColor[0];

        multiply++;
        scoreManager.inversion++;
        SaveColor();
    }


    private void SaveColor()
    {
        for (int j = 0; j < oldColor.Length; j++)
        {
            if (j <= 4)
            {
                oldColor[j] = platformSprite[j].color;
            }

            if (j == 5)
                oldColor[j] = candyAndPlayer[0].color;

            if (j == 6)
                oldColor[j] = cam.backgroundColor;
        }
    }


    /*

    if(index == 1)
        {
            Color32 saveColor = cam.backgroundColor;

            cam.backgroundColor = platformSprite[2].color;
            platformSprite[2].color = new Color32(saveColor.r, saveColor.g, saveColor.b, 255);

            saveColor = candyAndPlayer[0].color;
            foreach(SpriteRenderer sprite in candyAndPlayer)
            {
                sprite.color = platformSprite[0].color;
            }

            platformSprite[0].color = saveColor;

        }

        if(index == 2)
        {
            Color32 saveColor = cam.backgroundColor;

            cam.backgroundColor = platformSprite[4].color;
            platformSprite[4].color = new Color32(saveColor.r, saveColor.g, saveColor.b, 255);

            saveColor = candyAndPlayer[0].color;
            foreach (SpriteRenderer sprite in candyAndPlayer)
            {
                sprite.color = platformSprite[3].color;
            }

            platformSprite[3].color = saveColor;
        }

    */




    /*
    if(index == 1)
        {

            cam.backgroundColor = new Color32(oldColor[2].r, oldColor[2].g, oldColor[2].b, 0);// oldColor[2] 2
            //platformSprite[4].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255); // oldColor[6]  6

            platformSprite[2].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255);
            //platformSprite[4].color = oldColor[0];

            foreach (SpriteRenderer sprite in candyAndPlayer)
            {
                sprite.color = oldColor[4]; // 1
            }

            platformSprite[4].color = oldColor[5]; // 1, 5

            
            /*
            cam.backgroundColor = new Color32(oldColor[4].r, oldColor[4].g, oldColor[4].b, 0);// oldColor[4] 4
            //platformSprite[4].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255); // oldColor[6]  6

            platformSprite[0].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255);
            platformSprite[4].color = oldColor[0];

            foreach (SpriteRenderer sprite in candyAndPlayer)
            {
                sprite.color = oldColor[1]; // 1
            }

            platformSprite[1].color = oldColor[5]; // 1, 5 // /*
}

        if(index == 2)
        {
            cam.backgroundColor = new Color32(oldColor[2].r, oldColor[2].g, oldColor[2].b, 0);// oldColor[2] 2
                                                                                              //platformSprite[4].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255); // oldColor[6]  6

platformSprite[2].color = new Color32(oldColor[6].r, oldColor[6].g, oldColor[6].b, 255);
            //platformSprite[4].color = oldColor[0];

            foreach (SpriteRenderer sprite in candyAndPlayer)
            {
                sprite.color = oldColor[4]; // 1
            }

            platformSprite[4].color = oldColor[5]; // 1, 5
        }

    */

    /* 

    Color32[] newColor = new Color32[7];
    bool inversionBlink = false;
    public float blinkSpeed, blinkTimes;
    float x, y, blinkInterval;

    private void Start()
    {
        SaveColor("Old");
    }

    private void Update()
    {
        if (inversionBlink)
        {
            y = Mathf.Sin(x);

            x += (Time.deltaTime * Mathf.PI * blinkInterval);
            blinkInterval *= 2 * Time.deltaTime;

            if(y >= 0)
            {
                for(int i = 0; i < platformSprite.Length; i++)
                {
                    platformSprite[i].color = newColor[i];
                }

                foreach(SpriteRenderer sprite in candyAndPlayer)
                {
                    sprite.color = newColor[5];
                }

                cam.backgroundColor = newColor[6];

            }
            else if(y <= 0)
            {
                for (int i = 0; i < platformSprite.Length; i++)
                {
                    platformSprite[i].color = oldColor[i];
                }

                foreach (SpriteRenderer sprite in candyAndPlayer)
                {
                    sprite.color = oldColor[5];
                }

                cam.backgroundColor = oldColor[6];
            }

            if (x >= Mathf.PI * blinkTimes)
            {
                inversionBlink = false;
            }

        }
    }

    private void ChangeColor()
    {

    }

    public void Inversion()
    {
        cam.backgroundColor = oldColor[4];
        platformSprite[4].color = oldColor[6];

        foreach(SpriteRenderer sprite in candyAndPlayer)
        {
            sprite.color = oldColor[1];
        }

        platformSprite[1].color = oldColor[5];

        SaveColor("New");

        inversionBlink = true;
        blinkInterval = blinkSpeed;
        x = 0;
        y = 0;

    }

    private void SaveColor(string whichOne)
    {
        if(whichOne == "Old")
        {
            for (int j = 0; j < oldColor.Length; j++)
            {
                if (j <= 4)
                {
                    oldColor[j] = platformSprite[j].color;
                }

                if (j == 5)
                    oldColor[j] = candyAndPlayer[0].color;

                if (j == 6)
                    oldColor[j] = cam.backgroundColor;
            }

           foreach(Color32 color in oldColor)
            {
                Debug.Log(color);
            }

            Debug.Log("__________________");
        }


        if(whichOne == "New")
        {
            for (int j = 0; j < newColor.Length; j++)
            {
                if (j <= 4)
                {
                    newColor[j] = platformSprite[j].color;
                }

                if (j == 5)
                    newColor[j] = candyAndPlayer[0].color;

                if (j == 6)
                    newColor[j] = cam.backgroundColor;
            }

            foreach (Color32 color in newColor)
            {
                Debug.Log(color);
            }
        }
        
    }

     */

}
