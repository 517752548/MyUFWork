using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GuajiRewardItemUI : MonoBehaviour 
{
    public Text textTitle;
    public Transform tfRewardItemRoot;
    public CommonItemUI defaultItemUI_1;
    public CommonItemUI defaultItemUI_2;
    public CommonItemUI defaultItemUI_3;
    public CommonItemUI defaultItemUI_4;
    public CommonItemUI defaultItemUI_5;
    public CommonItemUI defaultItemUI_6;
    public List<CommonItemUI> itemUIs = new List<CommonItemUI>();
    

    public void Init()
    {
        textTitle = transform.Find("Text_day").GetComponent<Text>();
        tfRewardItemRoot = transform.Find("items");
        defaultItemUI_1 = tfRewardItemRoot.Find("CommonItemUI70_70_1").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_1.Init();
        defaultItemUI_2 = tfRewardItemRoot.Find("CommonItemUI70_70_2").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_2.Init();
        defaultItemUI_3 = tfRewardItemRoot.Find("CommonItemUI70_70_3").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_3.Init();
        defaultItemUI_4 = tfRewardItemRoot.Find("CommonItemUI70_70_4").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_4.Init();
        defaultItemUI_5 = tfRewardItemRoot.Find("CommonItemUI70_70_5").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_5.Init();
        defaultItemUI_6 = tfRewardItemRoot.Find("CommonItemUI70_70_6").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI_6.Init();
        itemUIs.Add(defaultItemUI_1);
        itemUIs.Add(defaultItemUI_2);
        itemUIs.Add(defaultItemUI_3);
        itemUIs.Add(defaultItemUI_4);
        itemUIs.Add(defaultItemUI_5);
        itemUIs.Add(defaultItemUI_6);

    }


}
