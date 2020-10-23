using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaiFuJiJinUI:MonoBehaviour
{
    public Text endTime;
    public List<JiJinItemUI> jijinList;
    public Text ruleText ;
    public void init()
    {
        endTime = transform.Find("endTime").GetComponent<Text>();
        ruleText = transform.Find("ruleText").GetComponent<Text>();
        
        jijinList =new List<JiJinItemUI>();
        for (int i=0;i<3;i++)
        {
            JiJinItemUI item = transform.Find("item ("+(i+1)+")").gameObject.AddComponent<JiJinItemUI>();
            item.init();
            jijinList.Add(item);
        }
    }

}

public class JiJinItemUI : MonoBehaviour
{
    public Text shouyi;
    public Text jiage;
    public GameUUButton buyBtn;
    public Text btnText;

    public void init()
    {
        shouyi = transform.Find("shouyi").GetComponent<Text>();
        jiage = transform.Find("jiage").GetComponent<Text>();
        buyBtn = transform.Find("chargeBtn").GetComponent<GameUUButton>();
        btnText = transform.Find("chargeBtn/Text").GetComponent<Text>();
    }

}

