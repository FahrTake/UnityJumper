using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsAdvertisement : MonoBehaviour
{
    
    public static AdsAdvertisement instance = null; // Экземпляр объекта

    private string store_id = "3131989";
    private string banner = "banner";
    private bool bannerReady = false;

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
        /* TODO: Здесь мы будем проводить инициализацию   */
        Advertisement.Initialize(store_id, false);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(banner))
        {
            yield return new WaitForSeconds(0.5f);
        }
        bannerReady = true;
    }

    public void ShowBanner()
    {
        if (bannerReady)
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(banner);
        }
    }

    public void HideBanner()
    {
        if(bannerReady)
            Advertisement.Banner.Hide();

    } 

}

