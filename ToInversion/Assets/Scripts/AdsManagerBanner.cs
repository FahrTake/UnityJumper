using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManagerBanner : MonoBehaviour
{

    private string googlePlayStore_id = "3131989";
    private string banner_id = "banner";
    private bool bannerAdReady = false;

    private void Start()
    {
        Advertisement.Initialize(googlePlayStore_id, true);
        StartCoroutine(WaitForBanner());

        Advertisement.Banner.Hide();
    }


    IEnumerator WaitForBanner()
    {
        while (!Advertisement.IsReady(banner_id))
        {
            yield return null;
        }

        bannerAdReady = true;
    }

    public void ShowBanner()
    {
        if(bannerAdReady)
            Advertisement.Banner.Show();
    }

}
