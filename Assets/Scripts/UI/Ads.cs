using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour
{
    public Button AdsButton;
    void Start()
    {
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize("3544384", false);
        }
    }
    public void UnityAds()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show();
            StaticParams.TotalScore += StaticParams.MelonCounter;
            AdsButton.interactable = false;
        }
    }
}
