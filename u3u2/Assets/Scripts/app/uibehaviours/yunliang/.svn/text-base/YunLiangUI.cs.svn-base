using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class YunLiangUI:MonoBehaviour
{
    public GameUUButton closeBtn;
    public GameObject renwuItemGrid;
    public List<YunLiangItemUI> renwuList;
    public GameUUButton shuomingBtn;
    public Text leftTimes;
    public GameUUButton addTimesBtn;
    public GameUUButton shuaxinBtn;
    public MoneyItemUI shuaxinCost;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        renwuItemGrid = transform.Find("itemList").gameObject;
        shuomingBtn = transform.Find("cishuobj/Button").GetComponent<GameUUButton>();
        leftTimes = transform.Find("cishuobj/ContentText_22").GetComponent<Text>();
        addTimesBtn = transform.Find("addTimesBtn").GetComponent<GameUUButton>();
        shuaxinBtn = transform.Find("shuaxinBtn").GetComponent<GameUUButton>();
        shuaxinCost = transform.Find("shuaxinBtn/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        shuaxinCost.Init
        (
            shuaxinCost.transform.Find("Image").GetComponent<Image>(),
            shuaxinCost.transform.Find("Text").GetComponent<Text>(),
            null
        );

        renwuList = new List<YunLiangItemUI>();
        YunLiangItemUI itemUI1 = transform.Find("itemList/FirstItem").gameObject.AddComponent<YunLiangItemUI>();
        itemUI1.Init();
        YunLiangItemUI itemUI2 = transform.Find("itemList/FirstItem (1)").gameObject.AddComponent<YunLiangItemUI>();
        itemUI2.Init();
        YunLiangItemUI itemUI3 = transform.Find("itemList/FirstItem (2)").gameObject.AddComponent<YunLiangItemUI>();
        itemUI3.Init();
        renwuList.Add(itemUI1);
        renwuList.Add(itemUI2);
        renwuList.Add(itemUI3);

    }
}