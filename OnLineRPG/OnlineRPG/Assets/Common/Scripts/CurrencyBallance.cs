using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrencyBallance : MonoBehaviour
{
    public Transform coinPos;

    //本次动画不播放了
    public bool ignoreAnim = false;
    //是否忽略本次的加金币动画
    public bool _skipAnim = false;
    
    public static List<CurrencyBallance> _CurrencyBallances = new List<CurrencyBallance>();
    private void Start()
    {
        _CurrencyBallances.Add(this);
        EventUtil.EventDispatcher.AddEventListener(GlobalEvents.SkipBalanceAni, OnSkipAni);
        EventUtil.EventDispatcher.AddEventListener(GlobalEvents.SkipBalanceUpdate, OnSkipUpdate);
        UpdateBalance(AppEngine.SyncManager.Data.Coin.Value,false, RubyAniType.None);
        AppEngine.SyncManager.Data.Coin.DataUpdateEvent += OnBalanceChanged;
    }

    private void OnSkipAni()
    {
        _skipAnim = true;
    }
    
    private void OnSkipUpdate()
    {
        ignoreAnim = true;
    }

    void CoinGetBack(int count)
    {
        UpdateBalance(count,false,RubyAniType.None);
    }
    private void UpdateBalance(int coin,bool showAnim,RubyAniType type)
    {
        //gameObject.SetText(balance.ToString());
        if (showAnim)
        {
            //AdsOnSaleIconCtrl.instance.TriggerRubyAni(type);
            Text text = gameObject.GetComponent<Text>();
            if (text != null)
            {
                int oldBalance = int.Parse(text.text);
                if (coin > oldBalance)
                    gameObject.GetComponentInParent<AdsOnSaleIconCtrl>()?.TriggerRubyAni(type);
                DOTween.To(() => oldBalance, x => oldBalance = x, coin, 1f).OnUpdate(() =>
                {
                    text.text = oldBalance.ToString();
                });
                
            }
        }
        else
        {
            gameObject.SetText(coin.ToString());
        }
    }

    private void OnBalanceChanged()
    {
        if (ignoreAnim)
        {
            ignoreAnim = false;
            return;
        }
        if (_skipAnim)
        {
            _skipAnim = false;
            UpdateBalance(AppEngine.SyncManager.Data.Coin.Value, false, RubyAniType.SingleCoin);
        }
        else
        {
            UpdateBalance(AppEngine.SyncManager.Data.Coin.Value, true, RubyAniType.SingleCoin);
        }
    }
    private void FadeUpdateBalance(int coin,RubyAniType type)
    {
        //gameObject.SetText(balance.ToString());
        //AdsOnSaleIconCtrl.instance.TriggerRubyAni(type);
        Text text = gameObject.GetComponent<Text>();
        if (text != null)
        {
            int oldBalance = int.Parse(text.text);
            if (coin > oldBalance)
                gameObject.GetComponentInParent<AdsOnSaleIconCtrl>()?.TriggerRubyAni(type);
            DOTween.To(() => oldBalance, x => oldBalance = x, coin, 1f).OnUpdate(() =>
            {
                text.text = oldBalance.ToString();
            });
            
        }
    }
    /// <summary>
    /// 播放假的加金币动画
    /// </summary>
    public void DoFadeAnim(int coin)
    {
        if(coin == 0)
            return;
        int currentCoin = AppEngine.SyncManager.Data.Coin.Value;
        int lastCoin = currentCoin - coin;
        if (lastCoin < 0)
        {
            lastCoin = 0;
        }
        gameObject.SetText(lastCoin.ToString());
        TimersManager.SetTimer(1f, () =>
        {
            FadeUpdateBalance(currentCoin,RubyAniType.MoreCoin);
        });
    }
    private void OnDestroy()
    {
        _CurrencyBallances.Remove(this);
        AppEngine.SyncManager.Data.Coin.DataUpdateEvent -= OnBalanceChanged;
        EventUtil.EventDispatcher.RemoveEventListener(GlobalEvents.SkipBalanceAni, OnSkipAni);
        EventUtil.EventDispatcher.RemoveEventListener(GlobalEvents.SkipBalanceUpdate, OnSkipUpdate);
    }
}