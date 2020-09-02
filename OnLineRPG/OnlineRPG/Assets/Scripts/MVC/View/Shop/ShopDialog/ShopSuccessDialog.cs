using System.Collections.Generic;
using EventUtil;
using UnityEngine;
using UnityEngine.UI;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;

public class ShopSuccessDialog : UIWindowBase
{
    public TextMeshProUGUI TextTitle;
    public Text TextCoin;
    public Text TextHint1;
    public Text TextHint2;
    public Text TextHint3;
	public Text TextHint4;

	public GameObject GoCoin;
    public GameObject GoHint1;
    public GameObject GoHint2;
    public GameObject GoHint3;
	public GameObject GoHint4;

    public override void OnOpen()
    {
		Debug.Log("OnOpen");
        base.OnOpen();
        GetComponentInChildren<Button>().onClick.AddListener(Claim);

        var item = objs[0] as IapProductConfig_Data;
        if (item == null) return;
        InitData(item);
        string campaign = DataManager.BusinessData.PlayerTag;
    }

    public override void OnClose()
    {
        GetComponentInChildren<Button>().onClick.RemoveListener(Claim);
        base.OnClose();
    }

	public void Claim()
	{
		var item = objs[0] as IapProductConfig_Data;
		if (item != null) {
			var rewards = new List<RewardInventory>
			{
				new RewardInventory() {type = InventoryType.Hint1, count = item.ProductHint1},
				new RewardInventory() {type = InventoryType.Hint2, count = item.ProductHint2},
				new RewardInventory() {type = InventoryType.Hint3, count = item.ProductHint3},
				new RewardInventory() {type = InventoryType.Hint4, count = item.ProductHint4},
				new RewardInventory() {type = InventoryType.Bee, count = item.ProductHint5}
			};
			RewardMgr.RewardInventory(rewards, RewardSource.shop, item.ProductID, item.ProductDollarPrice, item.IapType.ToString());
		}
		Close();
	}

    private void InitData(IapProductConfig_Data item)
    {
		Debug.Log("title " + item.TitleName);
		TextTitle.text = item.TitleName;
		SetProductInfo(item.ProductCoins, TextCoin, GoCoin);
        SetProductInfo(item.ProductHint1, TextHint1, GoHint1);
        SetProductInfo(item.ProductHint2, TextHint2, GoHint2);
        SetProductInfo(item.ProductHint3, TextHint3, GoHint3);
		SetProductInfo(item.ProductHint4, TextHint4, GoHint4);
    }

    private void SetProductInfo(int value, Text text, GameObject go)
    {
        if (value > 0)
        {
            text.text = value.ToString();
        }
        else
        {
            go.SetActive(false);
        }
    }
}