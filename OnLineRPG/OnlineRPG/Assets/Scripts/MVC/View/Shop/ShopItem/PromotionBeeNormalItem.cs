using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



//常规促销类
public class PromotionBeeNormalItem : ShopBaseItem
{
    public Text TextCoins;
    public Text TextHint1;
    public Text TextHint2;
    public Text TextHint3;
	public Text TextHint4;
    public Text TextHint5;
	public Text TextOriginalPrice;
    public TextMeshProUGUI TextTitle;
	public TextMeshProUGUI moreText;
    public TextMeshProUGUI SubScriptText;
    public GameObject moreObj;

    public Transform ImgParent;
    public GameObject removeAdObj;

    public override void Initialize()
    {
        base.Initialize();
        
        if (TextHint5 != null && IapItem.ProductHint5 > 0) {
            TextHint5.text = IapItem.ProductHint5.ToString();
        } else {
            TextHint5.transform.parent.gameObject.SetActive(false);
        }

        if (TextOriginalPrice != null)
        {
            var data = DataManager.IapData;
            TextOriginalPrice.text = data.GetOriginPrice(IapItem);
        }
		if (moreText != null) {
            if (IapItem.PercentMore == "0")
            {
                moreText.text = "";
            }
            else
            {
                moreText.text = string.Format("{0}% Extra!", IapItem.PercentMore); 
            }
			
		}

		if (TextTitle != null)
        {
            TextTitle.text = IapItem.TitleName.ToUpper();
        }

        // if (IapItem.ImageType < 0 || IapItem.ImageType >= ImgParent.childCount)
        // {
        //     IapItem.ImageType = 0;
        // }

        //ImgParent.GetChild(IapItem.ImageType - 1).gameObject.SetActive(true);

        if (SubScriptText != null) {
            if (IapItem.Subscript != (int)Subscript.none)
            {
                moreObj.SetActive(true);
                SubScriptText.text = ((Subscript)IapItem.Subscript).ToString();
            }
            else {
                moreObj.SetActive(false);
            }
        }

        removeAdObj.SetActive(AppEngine.SyncManager.Data.IsRemoveAd.Value == false && IapItem.removeAd == 1);
    }

    protected override void InitilizeSource()
    {
        IapItem.PayType = PayType.ResidentType;
    }
}