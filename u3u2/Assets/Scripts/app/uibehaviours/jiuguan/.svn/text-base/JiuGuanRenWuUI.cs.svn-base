using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JiuGuanRenWuUI : MonoBehaviour
{

    public GameUUButton closeBtn;
    public GameObject renwuItemGrid;
    public List<JiuGuanRenWuItemUI> renwuList;
    public GameUUButton shuomingBtn;
    public Text leftTimes;
    public GameUUButton addTimes;
    public Text jiuguanLevel;
    public ProgressBar jiuguanExp;
    public GameUUButton shuaxinBtn;
    public MoneyItemUI shuaxinCost;
    public GameUUButton manxingBtn;
    public MoneyItemUI manxingCost;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        renwuItemGrid=transform.Find("itemList").gameObject;
        renwuList = new List<JiuGuanRenWuItemUI>();
        JiuGuanRenWuItemUI j1 = transform.Find("itemList/FirstItem").gameObject.AddComponent<JiuGuanRenWuItemUI>();
        j1.Init();
        JiuGuanRenWuItemUI j2 = transform.Find("itemList/FirstItem 1").gameObject.AddComponent<JiuGuanRenWuItemUI>();
        j2.Init();
        JiuGuanRenWuItemUI j3 = transform.Find("itemList/FirstItem 2").gameObject.AddComponent<JiuGuanRenWuItemUI>();
        j3.Init();
        renwuList.Add(j1);
        renwuList.Add(j2);
        renwuList.Add(j3);
        shuomingBtn = transform.Find("cishuobj/Button").GetComponent<GameUUButton>();
        leftTimes=transform.Find("cishuobj/ContentText_22").GetComponent<UnityEngine.UI.Text>();
        addTimes = transform.Find("addTimesBtn").GetComponent<GameUUButton>();
        addTimes.gameObject.SetActive(false);
        jiuguanLevel=transform.Find("jiuguanLV/GameObject/ContentText_22").GetComponent<UnityEngine.UI.Text>();
        jiuguanExp=transform.Find("jiuguanLV/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        jiuguanExp.Init
        (
            jiuguanExp.transform.Find("background").GetComponent<Image>(), 
            jiuguanExp.transform.Find("background/foreground").GetComponent<Image>(),
            jiuguanExp.transform.Find("Text").GetComponent<Text>(), 228
        );
        shuaxinBtn = transform.Find("shuaxinBtn").gameObject.GetComponent<GameUUButton>();
        shuaxinCost=transform.Find("shuaxinBtn/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        shuaxinCost.Init();
        manxingBtn = transform.Find("manxingBtn").gameObject.GetComponent<GameUUButton>();
        manxingCost = transform.Find("manxingBtn/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        manxingCost.Init();
    }
}