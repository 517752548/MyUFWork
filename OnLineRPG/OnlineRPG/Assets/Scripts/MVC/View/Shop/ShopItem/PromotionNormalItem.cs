using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Subscript {
    none = -1,
    POPULAR = 0,
    BEST = 1,
    SALE = 2
}

//常规促销类
public class PromotionNormalItem : ShopBaseItem
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
		moreText = transform.Find("Img_Bg/More/Text/Text_100").GetComponent<TextMeshProUGUI>();
        base.Initialize();

        if (TextCoins != null && IapItem.ProductCoins > 0)
        {
            TextCoins.text = IapItem.ProductCoins.ToString();
        }else
        {
            TextCoins.transform.parent.gameObject.SetActive(false);
        }

        if (TextHint1 != null && IapItem.ProductHint1 > 0)
        {
            TextHint1.text = IapItem.ProductHint1.ToString();
        }else
        {
            TextHint1.transform.parent.gameObject.SetActive(false);
        }

        if (TextHint2 != null && IapItem.ProductHint2 > 0)
        {
            TextHint2.text = IapItem.ProductHint2.ToString();
        }else
        {
            TextHint2.transform.parent.gameObject.SetActive(false);
        }

        if (TextHint3 != null && IapItem.ProductHint3 > 0)
        {
            TextHint3.text = IapItem.ProductHint3.ToString();
        }
        else
        {
            TextHint3.transform.parent.gameObject.SetActive(false);
        }

		if (TextHint4 != null && IapItem.ProductHint4 > 0) {
			TextHint4.text = IapItem.ProductHint4.ToString();
		} else {
			TextHint4.transform.parent.gameObject.SetActive(false);
		}
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
			moreText.text = string.Format("{0}%", IapItem.PercentMore);
		}

		if (TextTitle != null)
        {
            TextTitle.text = IapItem.TitleName.ToUpper();
        }

        if (IapItem.ImageType < 0 || IapItem.ImageType >= ImgParent.childCount)
        {
            IapItem.ImageType = 0;
        }

        ImgParent.GetChild(IapItem.ImageType - 1).gameObject.SetActive(true);

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