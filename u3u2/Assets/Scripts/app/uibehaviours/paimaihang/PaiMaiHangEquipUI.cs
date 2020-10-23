﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PaiMaiHangEquipUI : MonoBehaviour
{

    public GameUUButton closeBtn;
    public CommonItemUI commonItemUI;
    public Text itemName;
    public Text equipLevel;
    public Text equipType;
    public Text pingfenText;
    public UGUISwitchButton pingfenBtn;

    public Text zhiyeRequire;
    public Text propAText;
	public GameObject propBContainer;
	public List<Text> propBList = new List<Text>();
    public Text dazaoText;

    public Text naijiuText;
    public GameObject shangjiaFeiyong;
    public MoneyItemUI shangjiaCost;
    public GameObject shangjiazhong;
    public Text chushouzhongText;
    public InputTextUI chushoujiage;

    public GameUUButton quxiaoBtn;
    public GameUUButton shangjiaBtn;
    public GameUUButton xiajiaBtn;

    public void Init()
     {
        closeBtn=transform.Find("bg/UpContent/closeBtn").GetComponent<GameUUButton>();
        commonItemUI=transform.Find("bg/UpContent/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        commonItemUI.Init();
        itemName=transform.Find("bg/UpContent/equipName").GetComponent<UnityEngine.UI.Text>();
        equipLevel=transform.Find("bg/UpContent/equipLevel").GetComponent<UnityEngine.UI.Text>();
        equipType=transform.Find("bg/UpContent/equipTypeName").GetComponent<UnityEngine.UI.Text>();
        pingfenText=transform.Find("bg/UpContent/equipPingFen").GetComponent<UnityEngine.UI.Text>();
        
        //pingfenBtn 
        
        zhiyeRequire=transform.Find("bg/MidContent/scroll/content/propA/zhiyeyaoqiu").GetComponent<UnityEngine.UI.Text>();
        propAText=transform.Find("bg/MidContent/scroll/content/propA/PropAText").GetComponent<UnityEngine.UI.Text>();
        propBContainer=transform.Find("bg/MidContent/scroll/content/PropBList").gameObject;
        propBList = new List<Text>();
        Text t1 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText").GetComponent<Text>();
        Text t2 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText 1").GetComponent<Text>();
        Text t3 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText 2").GetComponent<Text>();
        Text t4 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText 3").GetComponent<Text>();
        Text t5 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText 4").GetComponent<Text>();
        Text t6 = transform.Find("bg/MidContent/scroll/content/PropBList/PropBText 5").GetComponent<Text>();
        propBList.Add(t1);
        propBList.Add(t2);
        propBList.Add(t3);
        propBList.Add(t4);
        propBList.Add(t5);
        propBList.Add(t6);

        naijiuText=transform.Find("bg/MidContent/scroll/content/propA/naijiudu").GetComponent<UnityEngine.UI.Text>();
        shangjiaFeiyong=transform.Find("bg/MidContent/shangjiafeiyong").gameObject;
        shangjiaCost=transform.Find("bg/MidContent/shangjiafeiyong/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        shangjiaCost.Init();
        shangjiazhong=transform.Find("bg/MidContent/chushouzhong").gameObject;
        chushouzhongText = shangjiazhong.transform.Find("Text").GetComponent<Text>();
        chushoujiage=transform.Find("bg/MidContent/chushoujiage/InputTextUI").gameObject.AddComponent<InputTextUI>();
        MoneyItemUI m1 = chushoujiage.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m1.Init();
        chushoujiage.Init
        (
            chushoujiage.transform.Find("jianBtn").GetComponent<GameUUButton>(),
            chushoujiage.transform.Find("jiaBtn").GetComponent<GameUUButton>(),
            chushoujiage.transform.Find("MoneyItem/Text").GetComponent<Text>(),
            m1.moneyIcon, m1.inputBg
        );
        quxiaoBtn=transform.Find("bg/DownContent/quxiao").GetComponent<GameUUButton>();
        shangjiaBtn=transform.Find("bg/DownContent/shangjia").GetComponent<GameUUButton>();
        xiajiaBtn=transform.Find("bg/DownContent/xiajia").GetComponent<GameUUButton>();

        }

}
