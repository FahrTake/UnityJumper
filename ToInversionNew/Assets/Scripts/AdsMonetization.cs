using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsMonetization : MonoBehaviour
{
    public static AdsMonetization instance = null; // Экземпляр объекта

    private string video = "video";
    private string rewardedVideo = "rewardedVideo";

    // Метод, выполняемый при старте игры
    void Start()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        InitializeManager();

    }

    // Метод инициализации менеджера
    private void InitializeManager()
    {
        /* TODO: Здесь мы будем проводить инициализацию */

    }


}
