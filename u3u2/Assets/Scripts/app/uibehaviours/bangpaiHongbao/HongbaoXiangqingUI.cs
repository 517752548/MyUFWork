using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HongbaoXiangqingUI : MonoBehaviour {
    public GameUUButton btnClose;
    public Text textNum;
    public Text textName;
    public Text textZhufu;
    public Transform tfMask;
    public Transform tfYilingwan;
    public Transform tfYilingwanDes;
    public Transform tfGrid;
    public HongbaoXiangqingItemUI xiangqingItemUI;


    public void Init()
    {
        btnClose = transform.Find("btn_close").GetComponent<GameUUButton>();
        textNum = transform.Find("MoneyItem/Text").GetComponent<Text>();
        textName = transform.Find("Text_name").GetComponent<Text>();
        textZhufu = transform.Find("Text_zhufu").GetComponent<Text>();
        tfMask = transform.Find("Image_mask");
        tfYilingwan = transform.Find("Image_yilingwan");
        tfYilingwanDes = transform.Find("Text_yilingwan");
        tfGrid = transform.Find("scroll/ItemList/");
        xiangqingItemUI = transform.Find("scroll/ItemList/hongbaoItem").gameObject.AddComponent<HongbaoXiangqingItemUI>();
        xiangqingItemUI.Init();
    }
}
