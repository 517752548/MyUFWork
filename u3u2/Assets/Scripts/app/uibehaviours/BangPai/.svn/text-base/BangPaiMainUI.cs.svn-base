using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiMainUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public Text panelTitle;
    public TabButtonGroup mainTBG;

    public GameObject xinxiGo;
    public GameObject chengyuanGo;
    public GameObject jiansheGo;
    public GameObject fuliGo;
    public GameObject huodongGo;
    
    
    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        panelTitle = transform.Find("title").GetComponent<Text>();
        mainTBG = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        mainTBG.AddToggle(transform.Find("tabGroup/xinxi").GetComponent<GameUUToggle>());
        mainTBG.AddToggle(transform.Find("tabGroup/chengyuan").GetComponent<GameUUToggle>());
        mainTBG.AddToggle(transform.Find("tabGroup/jianshe").GetComponent<GameUUToggle>());
        mainTBG.AddToggle(transform.Find("tabGroup/fuli").GetComponent<GameUUToggle>());
        mainTBG.AddToggle(transform.Find("tabGroup/huodong").GetComponent<GameUUToggle>());

        /*
        chengyuanTBG = transform.Find("chengyuanGo/btngrid").gameObject.AddComponent<TabButtonGroup>();
        chengyuanTBG.AddToggle(transform.Find("chengyuanGo/btngrid/chengyuanLiebiao").GetComponent<GameUUToggle>());
        chengyuanTBG.AddToggle(transform.Find("chengyuanGo/btngrid/shenqingLiebiao").GetComponent<GameUUToggle>());
        chengyuanTBG.AddToggle(transform.Find("chengyuanGo/btngrid/bangpaiShijian").GetComponent<GameUUToggle>());
        
        xinxiUI = transform.Find("xinxiGo").gameObject.AddComponent<BangPaiXinXiUI>();
        xinxiUI.Init();
        
        chengyuanGo = transform.Find("chengyuanGo").gameObject;
        
       

        jiansheUI = transform.Find("jiansheGo").gameObject.AddComponent<BangPaiJianSheUI>();
        jiansheUI.Init();

        fuliUI = transform.Find("bangpaifuli").gameObject.AddComponent<BangPaiFuLiUI>();
        fuliUI.Init();
         */
    }
}
