using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    private int random;

    private void Start()
    {
        HideBanner();
    }

    public void ShowBannerOrVideo()
    {
        random = Random.Range(0, 10);

        if ((random >= 0) && (random <= 2))
        {
            AdsMonetization.instance.ShowVideo();
        }
        else
        {
            AdsAdvertisement.instance.ShowBanner();
        }
    }

    public void HideBanner()
    {
        AdsAdvertisement.instance.HideBanner();
    }

    public void ShowRewardedAd()
    {
        AdsMonetization.instance.ShowRewarded();
    }
}
