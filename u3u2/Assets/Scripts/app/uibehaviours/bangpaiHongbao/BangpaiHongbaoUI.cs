using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangpaiHongbaoUI : MonoBehaviour 
{
    public GameUUButton btn_close;
    public HongbaoItemUI[] itemUIs = new HongbaoItemUI[6];
    public GameUUButton btn_leftArrow;
    public GameUUButton btn_rightArrow;
    public GameUUButton btn_shuoming;
    public GameUUButton btn_fafanghongbao;
    public Text text_lijin;
    public FahongbaoUI faHongbaoUI;
    public LingHongbaoUI lingHongbaoUI;
    public HongbaoXiangqingUI hongbaoXiangqingUI;

    public void Init()
    {
        btn_close = transform.Find("closeBtn").GetComponent<GameUUButton>();
        for (int i = 1; i <= 6; i++)
        {
            itemUIs[i - 1] = transform.Find("hongbaoItem_" + i).gameObject.AddComponent<HongbaoItemUI>();
            itemUIs[i - 1].Init();
        }
        btn_leftArrow = transform.Find("btn_leftArrow").GetComponent<GameUUButton>();
        btn_rightArrow = transform.Find("btn_rightArrow").GetComponent<GameUUButton>();
        btn_shuoming = transform.Find("btn_shuoming").GetComponent<GameUUButton>();
        btn_fafanghongbao = transform.Find("btn_fahongbao").GetComponent<GameUUButton>();
        text_lijin = transform.Find("MoneyItem/Text").GetComponent<Text>();
        faHongbaoUI = transform.Find("FahongbaoGo").gameObject.AddComponent<FahongbaoUI>();
        faHongbaoUI.Init();
        lingHongbaoUI = transform.Find("QianghongbaoGo").gameObject.AddComponent<LingHongbaoUI>();
        lingHongbaoUI.Init();
        hongbaoXiangqingUI = transform.Find("LibaoXiangqing").gameObject.AddComponent<HongbaoXiangqingUI>();
        hongbaoXiangqingUI.Init();
    }
}
