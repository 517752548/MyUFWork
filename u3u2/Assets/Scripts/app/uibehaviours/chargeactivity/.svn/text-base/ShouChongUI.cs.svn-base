using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShouChongUI:MonoBehaviour
{
    public GridLayoutGroup grid;
    public List<CommonItemUI> commonItemList;

    public GameUUButton chargeBtn;
    public Text chargeBtnText;

    public void init()
    {
        grid = transform.Find("Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        commonItemList = new List<CommonItemUI>();
        for (int i=0;i<6;i++)
        {
            CommonItemUI item1 =
                transform.Find("Image/scrollRect/itemGrid/CommonItemUI ("+(i+1)+")").gameObject.AddComponent<CommonItemUI>();
            item1.Init();
            commonItemList.Add(item1);
        }
        chargeBtn = transform.Find("chargeBtn").GetComponent<GameUUButton>();
        chargeBtnText = transform.Find("chargeBtn/Text").GetComponent<Text>();
    }
}

public class YiYuanGouUI : MonoBehaviour
{
    public GridLayoutGroup grid;
    public List<CommonItemUI> commonItemList;
    public Text ruleContent;
    public GameUUButton chargeBtn;
    public Text chargeBtnText;

    public void init()
    {
        grid = transform.Find("Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        commonItemList = new List<CommonItemUI>();
        for (int i = 0; i < 6; i++)
        {
            CommonItemUI item1 =
                transform.Find("Image/scrollRect/itemGrid/CommonItemUI (" + (i + 1) + ")").gameObject.AddComponent<CommonItemUI>();
            item1.Init();
            commonItemList.Add(item1);
        }
        chargeBtn = transform.Find("chargeBtn").GetComponent<GameUUButton>();
        chargeBtnText = transform.Find("chargeBtn/Text").GetComponent<Text>();
        ruleContent = transform.Find("rulecontent").GetComponent<Text>();
    }
}