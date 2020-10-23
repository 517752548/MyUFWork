using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZhaoCaiJinBaoUI:MonoBehaviour
{
    public Text endTime;
    public Text maxget;

    public GameObject touruGo;
    public GameObject fanhuanGo;

    public GridLayoutGroup grid;
    public Text defaultText;

    public MoneyItemUI haveMoney;
    public MoneyItemUI touruMoney;
    
    public GameUUButton chargeBtn;

    public void init()
    {
        endTime = transform.Find("endTime").GetComponent<Text>();
        maxget = transform.Find("maxget").GetComponent<Text>();
        touruGo = transform.Find("rightmodel/touru").gameObject;
        fanhuanGo = transform.Find("rightmodel/fanhuan").gameObject;
        grid = transform.Find("ScrollView/grid").GetComponent<GridLayoutGroup>();
        defaultText = transform.Find("ScrollView/grid/Text").GetComponent<Text>();

        haveMoney = transform.Find("MoneyItemhave").gameObject.AddComponent<MoneyItemUI>();
        haveMoney.Init();

        touruMoney = transform.Find("MoneyItemtouru").gameObject.AddComponent<MoneyItemUI>();
        touruMoney.Init();

        chargeBtn = transform.Find("chargeBtn").GetComponent<GameUUButton>();
    }
}
