using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsManager : MonoBehaviour
{

    private string googlePlayStore_id = "3131989";

    private string video_id = "video";
    private string rewardedVideo_id = "rewardedVideo";

    ShowAdPlacementContent rewardedAd = null;
    private bool rewardedAdReady = false;

    ShowAdPlacementContent videoAd = null;
    private bool videoAdReady = false;

    private void Start()
    {
        Monetization.Initialize(googlePlayStore_id, false);
        PrepareRewardedAd();
    }

    public void PrepareVideoAd()
    {
        StartCoroutine(WaitForVideoAd());
    }

    public void PrepareRewardedAd()
    {
        StartCoroutine(WaitForRewardedAd());
    }


    IEnumerator WaitForRewardedAd()
    {
        while (!Monetization.IsReady(rewardedVideo_id))
        {
            yield return null;
        }

        rewardedAdReady = true;
        ShowRewardVideo();
    }

    public void ShowRewardVideo()
    {
        rewardedAd = Monetization.GetPlacementContent(rewardedVideo_id) as ShowAdPlacementContent;

        if((rewardedAd != null) && (rewardedAdReady))
        {
            rewardedAd.Show(RewardedAdFinished);
        }
    }

    void RewardedAdFinished(ShowResult result)
    {
        if(result == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Reward", 1);
        }
    }


    IEnumerator WaitForVideoAd()
    {
        while (!Monetization.IsReady(video_id))
        {
            yield return null;
        }

        videoAdReady = true;
    }

    public void ShowVideo()
    {
        videoAd = Monetization.GetPlacementContent(video_id) as ShowAdPlacementContent;

        if((videoAd != null) && (videoAdReady))
        {
            videoAd.Show();
        }
    }
    
}