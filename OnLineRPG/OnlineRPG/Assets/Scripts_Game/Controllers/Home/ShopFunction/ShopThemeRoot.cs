using EventUtil;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ShopThemeRoot : BaseThemeRoot
{
    public ShopFsmManager FsmManager => fsmManager as ShopFsmManager;
    public CoinPanel coinPanel;
    public GameObject VideoButton;
    public override void Init(HomeRoot root)
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.AddComponent<ShopFsmManager>();
            FsmManager.Init(this);
        }
        base.Init(root);
        VideoButton = transform.Find("Store/Content/VideoPanel").gameObject;
        coinPanel = transform.Find("Store/Content/CoinPanel").GetComponent<CoinPanel>();
        VideoButton.GetComponentInChildren<Button>().onClick.AddListener(ClickShopVideo);
        coinPanel.OnAwake();
    }
    public override void OnShow()
    {
        Debug.LogError("onshow");
        coinPanel.Init();
        if (BetaFramework.AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.ShopBottom))
		{
			VideoButton.transform.gameObject.SetActive(true);
			ADAnalyze.ADBtnShow("Shop");
		}
		else
		{
			VideoButton.transform.gameObject.SetActive(false);
		}
        EventDispatcher.AddEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoButton);
    }
    public override void OnHidden()
    {
        base.OnHidden();
        EventDispatcher.RemoveEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoButton);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        coinPanel.ResumeEffect();
    }
    public override void OnLeave()
    {
        base.OnLeave();
        coinPanel.PauseEffect();
    }

    private void ShowVideoButton()
    {
        VideoButton.transform.gameObject.SetActive(true);
        ADAnalyze.ADBtnShow("Shop");
    }
    public void ClickShopVideo()
    {
	    ADAnalyze.AdBtnClick("Shop");
	    DataManager.ProcessData.advideosource = RewardSource.closeShopAD;
	    BetaFramework.AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.ShopBottom);
        VideoButton.SetActive(false);
    }
}