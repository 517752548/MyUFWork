using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class BangPaiFuLiUI : MonoBehaviour 
{
    public GridLayoutGroup grid;
    public BangPaiFuLiItemUI fuliItemUI;
    public BangPaiFuLiItemUI fuliJinengUI;
    public BangPaiFuLiItemUI xiulianJinengUI;
    public BangPaiFuLiItemUI bangpaiHongBaoUI;
        
    public void Init()
    {
        grid = transform.Find("scrollRect/Image_mask/itemGrid").GetComponent<GridLayoutGroup>();
        fuliItemUI = transform.Find("scrollRect/Image_mask/itemGrid/RewardItem").gameObject.AddComponent<BangPaiFuLiItemUI>();
        fuliItemUI.Init();
        fuliJinengUI = transform.Find("scrollRect/Image_mask/itemGrid/RewardItem_1").gameObject.AddComponent<BangPaiFuLiItemUI>();
        fuliJinengUI.Init();
        xiulianJinengUI = transform.Find("scrollRect/Image_mask/itemGrid/RewardItem_2").gameObject.AddComponent<BangPaiFuLiItemUI>();
        xiulianJinengUI.Init();
        bangpaiHongBaoUI = transform.Find("scrollRect/Image_mask/itemGrid/RewardItem_3").gameObject.AddComponent<BangPaiFuLiItemUI>();
        bangpaiHongBaoUI.Init();
        bangpaiHongBaoUI.textContent.text = "博手气，得金子，打开红包即可获得";
    }
}

