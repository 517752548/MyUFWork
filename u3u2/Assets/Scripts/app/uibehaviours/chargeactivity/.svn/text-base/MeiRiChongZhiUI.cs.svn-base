using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeiRiChongZhiUI:MonoBehaviour
{
    public Text endTime;
    public Text ruleText;
    public GridLayoutGroup grid;
    public MeiRiChongItemUI defaultDayItem;

    public Text jindu;
    public GameUUButton chargeBtn;

    public void init()
    {
        endTime = transform.Find("endTime").GetComponent<Text>();
        ruleText = transform.Find("rolecontent").GetComponent<Text>();
        grid = transform.Find("Image_mask/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        Transform tf = transform.Find("Image_mask/scrollRect/itemGrid/dayItem");
        defaultDayItem = tf.gameObject.AddComponent<MeiRiChongItemUI>();
        defaultDayItem.init();
        jindu = transform.Find("jindu").GetComponent<Text>();
        chargeBtn = transform.Find("chargeBtn").GetComponent<GameUUButton>();
    }
}

public class MeiRiChongItemUI : MonoBehaviour
{
    public Text dayText;
    public List<CommonItemUI> commonItemList;
    public GameUUButton lingquBtn;
    public Text lingquBtnText;
    public Image yilingquImg;

    public void init()
    {
        dayText = transform.Find("Text_day").GetComponent<Text>();
        CommonItemUI item1 = transform.Find("items/CommonItemUI (1)").gameObject.AddComponent<CommonItemUI>();
        item1.Init();
        CommonItemUI item2 = transform.Find("items/CommonItemUI (2)").gameObject.AddComponent<CommonItemUI>();
        item2.Init();
        CommonItemUI item3 = transform.Find("items/CommonItemUI (3)").gameObject.AddComponent<CommonItemUI>();
        item3.Init();
        commonItemList = new List<CommonItemUI>();
        commonItemList.Add(item1);
        commonItemList.Add(item2);
        commonItemList.Add(item3);
        lingquBtn = transform.Find("lingquBtn").GetComponent<GameUUButton>();
        lingquBtnText = transform.Find("lingquBtn/name").GetComponent<Text>();
        yilingquImg = transform.Find("yilingqu").GetComponent<Image>();

    }
}