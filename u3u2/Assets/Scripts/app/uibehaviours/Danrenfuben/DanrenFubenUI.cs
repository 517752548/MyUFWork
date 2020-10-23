using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DanrenFubenUI : MonoBehaviour 
{
    public Text textTitle;
    public GameUUButton btnClose;
    public GameUUButton btnLeftArrow;
    public GameUUButton btnRightArrow;
    public GameUUButton btnEnter;
    public Transform tfItemGrid;
    public TabButtonGroup tabButtonGroup;
    public List<DanrenFubenItemUI> fubenItemUIs;

    public void Init()
    {
        textTitle = transform.Find("title").GetComponent<Text>();
        btnClose = transform.Find("closeBtn").GetComponent<GameUUButton>();
        btnLeftArrow = transform.Find("btn_leftArrow").GetComponent<GameUUButton>();
        btnRightArrow = transform.Find("btn_rightArrow").GetComponent<GameUUButton>();
        btnEnter = transform.Find("Button0").GetComponent<GameUUButton>();
        tabButtonGroup = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabButtonGroup.AddToggle(transform.Find("tabGroup/zhuxianfuben").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(transform.Find("tabGroup/jingyingfuben").GetComponent<GameUUToggle>());
        tfItemGrid = transform.Find("Image/container");
        fubenItemUIs = new List<DanrenFubenItemUI>();

        DanrenFubenItemUI itemUI = null;
        for (int i = 0; i < 5; i++)
        {
            itemUI = transform.Find("Image/container/huodongItem_"+(i+1)).gameObject.AddComponent<DanrenFubenItemUI>();
            itemUI.Init();
            fubenItemUIs.Add(itemUI);
        }
      

    }
    

}
