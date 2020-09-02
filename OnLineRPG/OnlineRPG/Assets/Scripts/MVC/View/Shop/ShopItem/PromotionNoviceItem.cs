using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BetaFramework;
using Scripts.MVC.View.Shop.View;

//新手促销项
public class PromotionNoviceItem : ShopBaseItem, IEffectable
{
    public Text TextCoins;
    public Text TextClock;

    private const string m_RemainTime = "LIMITED  TIME:      {0}";

    public bool IsShop;

    public override void Initialize()
    {
        base.Initialize();
        foreach (Transform item in transform)
        {
            if (Regex.IsMatch(item.name, "[pP]ar$"))
            {
                par = item.gameObject;
                break;
            }
        }
        if (TextCoins != null)
        {
            TextCoins.text = IapItem.ProductCoins.ToString();
        }

        if (TextClock != null)
        {
            UpdateClock();
            TimersManager.SetLoopableTimer(1, UpdateClock);
        }
    }

    private void UpdateClock()
    {
        if (DataManager.GiftData == null)
            return;

        int remainSeconds = Mathf.Clamp(DataManager.GiftData.Time, 0, int.MaxValue);
        TimeSpan t = TimeSpan.FromSeconds(remainSeconds);
        string text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
        TextClock.text = string.Format(m_RemainTime, text);
    }

    protected override void OnDisable()
    {
        TimersManager.ClearTimer(UpdateClock);
        base.OnDisable();
    }

    protected override void InitilizeSource()
    {
        if (IsShop)
        {
            IapItem.PayType = PayType.ShopgreenhandType;
        }
        else
        {
            IapItem.PayType = PayType.DialogGreenhandType;
        }
    }

    [SerializeField] private GameObject par;
    public void PauseEffect()
    {
        par.SetActive(false);
    }

    public void ResumeEffect()
    {
        par.SetActive(true);
    }
}