using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainUIButtonUI : MonoBehaviour {

    public GameObject mainButtons;
    public GameObject downBtns;
    public GameObject rightBtns;
    public GameObject topBtns;
    public GameObject leftBtns;
    public List<MainButtonUI> downBtnGrid;
    public List<MainButtonUI> rightBtnGrid;
    public List<MainButtonUI> topBtnGrid;
    public List<MainButtonUI> leftBtnGrid;
    public GameObject bagua;

    public TiShengUI tishengUI;
    //public GameObject showBtnsBtn;
    //public GameObject hideBtnsBtn;
    
    public void Init(){
        mainButtons =this.gameObject;
        downBtns = transform.Find("downImage/downBtns").gameObject;
        rightBtns = transform.Find("rightImage/rightBtns").gameObject;
        topBtns = transform.parent.Find("topBtns").gameObject;
        leftBtns = transform.parent.Find("leftBtns").gameObject;
        
        downBtnGrid = new List<MainButtonUI>();
        MainButtonUI m1 = transform.Find("downImage/downBtns/huobanBtnContainer/huoban").gameObject.AddComponent<MainButtonUI>();
        m1.Init();
        MainButtonUI m2 = transform.Find("downImage/downBtns/jinengBtnContainer/jineng").gameObject.AddComponent<MainButtonUI>();
        m2.Init();
        MainButtonUI m3 = transform.Find("downImage/downBtns/bangpaiBtnContainer/bangpai").gameObject.AddComponent<MainButtonUI>();
        m3.Init();
        MainButtonUI m4 = transform.Find("downImage/downBtns/qianghuaBtnContainer/qianghua").gameObject.AddComponent<MainButtonUI>();
        m4.Init();
        MainButtonUI m5 = transform.Find("downImage/downBtns/dazaoBtnContainer/dazao").gameObject.AddComponent<MainButtonUI>();
        m5.Init();
        MainButtonUI m6 = transform.Find("downImage/downBtns/xitongBtnContainer/xitong").gameObject.AddComponent<MainButtonUI>();
        m6.Init();
        downBtnGrid.Add(m1);
        downBtnGrid.Add(m2);
        downBtnGrid.Add(m3);
        downBtnGrid.Add(m4);
        downBtnGrid.Add(m5);
        downBtnGrid.Add(m6);
        
        rightBtnGrid = new List<MainButtonUI>();
        MainButtonUI r1 = transform.Find("rightImage/rightBtns/beibaoBtnContainer/beibao").gameObject.AddComponent<MainButtonUI>();
        r1.Init();
        rightBtnGrid.Add(r1);
        
        topBtnGrid = new List<MainButtonUI>();
        MainButtonUI t1 = transform.parent.Find("topBtns/huodongBtnContainer/huodong").gameObject.AddComponent<MainButtonUI>();
        t1.Init();
         MainButtonUI t2 = transform.parent.Find("topBtns/guajiBtnContainer/guaji").gameObject.AddComponent<MainButtonUI>();
        t2.Init();
         MainButtonUI t4 = transform.parent.Find("topBtns/paihangBtnContainer/paihang").gameObject.AddComponent<MainButtonUI>();
        t4.Init();
         MainButtonUI t5 = transform.parent.Find("topBtns/tishengBtnContainer/tisheng").gameObject.AddComponent<MainButtonUI>();
        t5.Init();
        topBtnGrid.Add(t1);
        topBtnGrid.Add(t2);
        topBtnGrid.Add(t4);
        topBtnGrid.Add(t5);

        tishengUI = transform.parent.Find("topBtns/tishengBtnContainer/tishengPanel").gameObject.AddComponent<TiShengUI>();
        tishengUI.Init();
        
        
        leftBtnGrid = new List<MainButtonUI>();
        MainButtonUI l1 = transform.parent.Find("leftBtns/jiangliBtnContainer/jiangli").gameObject.AddComponent<MainButtonUI>();
        l1.Init();
         MainButtonUI l2 = transform.parent.Find("leftBtns/shangchengBtnContainer/shangcheng").gameObject.AddComponent<MainButtonUI>();
        l2.Init();
        MainButtonUI l3 = transform.parent.Find("leftBtns/vipBtnContainer/vip").gameObject.AddComponent<MainButtonUI>();
        l3.Init();
        leftBtnGrid.Add(l1);
        leftBtnGrid.Add(l2);
        leftBtnGrid.Add(l3);
        
        
        bagua = transform.Find("bagua").gameObject;
        //showBtnsBtn = transform.Find("bagua/hei").gameObject;
        //hideBtnsBtn = transform.Find("bagua/bai").gameObject;    
        
    }
}
