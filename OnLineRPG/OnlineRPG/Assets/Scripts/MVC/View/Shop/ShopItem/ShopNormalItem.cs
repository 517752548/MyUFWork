using BetaFramework;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopNormalItem : ShopBaseItem
{
    public Text TextCoins;
    public Image ImageBg;
    public Text TextPercentMore;
    public GameObject remoteAd;

    private const string m_PercentMore = "{0}% Extra!";

    public override void Initialize()
    {
        base.Initialize();

        TextCoins.text = IapItem.ProductCoins.ToString();
        TextPercentMore.text = int.Parse(IapItem.PercentMore) == 0 ?
            "" : string.Format(m_PercentMore, IapItem.PercentMore);
        remoteAd.SetActive(AppEngine.SyncManager.Data.IsRemoveAd.Value == false && IapItem.removeAd == 1);
    }

    protected override void InitilizeSource()
    {
        IapItem.PayType = PayType.NormalType;
    }

    public override void ChangeColor(bool isChange)
    {
        ImageBg.color = isChange ? new Color(0.97f, 0.90f, 0.73f) : new Color(1f, 0.9686275f, 0.882353f);
    }
}