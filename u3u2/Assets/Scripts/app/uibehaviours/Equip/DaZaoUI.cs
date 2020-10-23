using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DaZaoUI: UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public TabButtonGroup tabBtn;
    public Text panelTitle;

    public GameObject dazaoUIObj;
    public GameObject shengxingUIObj;
    public GameObject shengxingUIObjL;
    public GameObject shengxingUIObjR;
    public GameObject baoshiObj;
    public GameObject hechengUIObj;

    public EquipDaZaoUI dazaoUI;
    public EquipShengXingUI shengxingUI;
    public EquipBaoshiUI baoshiUI;
    public HeChengUI hechengUI;
    
    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        tabBtn = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabBtn.AddToggle(transform.Find("tabGroup/toggles/dazao").GetComponent<GameUUToggle>());
        tabBtn.AddToggle(transform.Find("tabGroup/toggles/shengxing").GetComponent<GameUUToggle>());
        tabBtn.AddToggle(transform.Find("tabGroup/toggles/baoshi").GetComponent<GameUUToggle>());
        tabBtn.AddToggle(transform.Find("tabGroup/toggles/hecheng").GetComponent<GameUUToggle>());
        
        panelTitle = transform.Find("title").GetComponent<Text>();
        
        //dazaoUI = transform.Find("dazao").gameObject.AddComponent<EquipDaZaoUI>();
        //dazaoUI.Init();
        
        //shengxingUI = transform.Find("shengxing").gameObject.AddComponent<EquipShengXingUI>();
        //shengxingUI.Init();
        
        //xiangqianUI = transform.Find("xiangqian").gameObject.AddComponent<XiangQianUI>();
        //xiangqianUI.Init();

        //hechengUI = transform.Find("hecheng").gameObject.AddComponent<HeChengUI>();
        //hechengUI.Init();
    }
}
