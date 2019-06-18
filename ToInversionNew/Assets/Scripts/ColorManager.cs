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
    
}
