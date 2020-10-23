using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CangkuUI:MonoBehaviour
{
    public GridLayoutGroup itemGrid;
    public CommonItemUI defaultItemUI;
    public PageTurner pageturner;


    public void Init()
    {
        itemGrid = transform.Find("Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();

        defaultItemUI = transform.Find("Image/scrollRect/itemGrid/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultItemUI.Init
        (
            defaultItemUI.transform.Find("Image").GetComponent<Image>(),
            defaultItemUI.transform.Find("Icon").GetComponent<Image>(),
            defaultItemUI.transform.Find("BianKuang").GetComponent<Image>(),
            defaultItemUI.transform.Find("Num").GetComponent<Text>(),
            null,
            null, null,null, null, null
        );

        pageturner = transform.Find("PageTurner").gameObject.AddComponent<PageTurner>();
        pageturner.Init(pageturner.transform.Find("leftButton").GetComponent<GameUUButton>()
            , pageturner.transform.Find("rightButton").GetComponent<GameUUButton>(),
        pageturner.transform.Find("Text").GetComponent<Text>());
    }
}
