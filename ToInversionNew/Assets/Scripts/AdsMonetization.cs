using System.Collections;
using UnityEngine;
//using UnityEngine.Monetization;

public class AdsMonetization : MonoBehaviour
{

    /*
    public static AdsMonetization instance = null; // Экземпляр объекта

    private string store_id = "3131989";

    private string video = "video";
    private string rewardedVideo = "rewardedVideo";


    ShowAdPlacementContent videoAd = null;
    ShowAdPlacementContent rewardedAd = null;
    private bool videoReady = false, rewardedReady = false;

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
        /* TODO: Здесь мы будем проводить инициализацию * /

        Monetization.Initialize(store_id, false);
        StartCoroutine(ShowAdWhenReady());
        StartCoroutine(WaitForAd());

    }
    
    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(video))
        {
            yield return new WaitForSeconds(0.25f);
        }
        
        videoAd = Monetization.GetPlacementContent(video) as ShowAdPlacementContent;
        videoReady = true;
    }

    public void ShowVideo()
    {
        if ((videoAd != null) && (videoReady))
        {
           videoAd.Show();
        }
    }

    IEnumerator WaitForAd()
    {
        while (!Monetization.IsReady(rewardedVideo))
        {
            yield return null;
        }
        
        rewardedAd = Monetization.GetPlacementContent(rewardedVideo) as ShowAdPlacementContent;
        rewardedReady = true;
        
    }

    public void ShowRewarded()
    {
        if ((rewardedAd != null) && (rewardedReady))
        {
            rewardedAd.Show(AdFinished);
        }
    }

    void AdFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Reward the player
            PlayerPrefs.SetInt("Reward", 1);
            Debug.Log("Reward Finish");
        }
    } */


}
