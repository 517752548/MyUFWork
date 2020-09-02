using EventUtil;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopBaseDialog : UIWindowBase
{
    public Button CloseButton;

    public override void OnOpen()
    {
        base.OnOpen();
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseInitSuccessful, OnPurchaseInitSucceed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseInitFailer, OnPurchaseInitFailed);
        EventDispatcher.AddEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseFailed, OnPurchaserFailed);
        CloseButton.onClick.AddListener(Close);

        Init();
    }

    public override void OnClose()
    {
        base.OnClose();
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseInitSuccessful, OnPurchaseInitSucceed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseInitFailer, OnPurchaseInitFailed);
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseFailed, OnPurchaserFailed);
        CloseButton.onClick.RemoveListener(Close);
    }

    protected virtual void Init()
    {
    }

    public virtual void StartLoading()
    {
    }

    public virtual void StopLoading()
    {
    }

    public virtual void CloseInteractable()
    {
        if (CloseButton != null)
        {
            CloseButton.interactable = false;
            StartCoroutine(OpenInteractable());
        }
    }

    private IEnumerator OpenInteractable()
    {
        yield return new WaitForSeconds(5);
        if (CloseButton != null)
        {
            CloseButton.interactable = true;
        }
    }

    public void SetCloseButtonCanClick()
    {
        if (CloseButton != null)
        {
            CloseButton.interactable = true;
        }
    }

    #region Listener

    protected void OnPurchaseInitSucceed()
    {
        StopLoading();
    }

    protected void OnPurchaseInitFailed()
    {
        StopLoading();
    }

    protected void OnPurchaserFailed()
    {
        StopLoading();
        SetCloseButtonCanClick();
    }

    protected void OnPurchaseSucceed(IapProductConfig_Data item)
    {
        StopLoading();
        SetCloseButtonCanClick();
    }

    #endregion Listener
}