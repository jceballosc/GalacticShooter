using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{

#if UNITY_ANDROID
    string gameID = "4922432";
    string RewardAdID = "Rewarded_Android";
    string InterstitialAdID = "Interstitial_Android";
    string BannerAdID = "Banner_Android";
#elif UNITY_IPHONE
string gameID = "4922433";
    string RewardAdID = "Rewarded_iOS";
    string InterstitialAdID = "Interstitial_iOS";
    string BannerAdID = "Banner_iOS";
#endif

    public void OnInitializationComplete()
    {
        Debug.Log("Init Compplete");
        Advertisement.Load(RewardAdID, this);
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                break;  
        }
        Debug.Log(showCompletionState);
    }


    void Start()
    {
        Advertisement.Initialize(gameID, true, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
