using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class YunLiangItemUI : MonoBehaviour {
    public Text title;
    public MoneyItemUI yajin;
    public Text content;
    public GameObject modelParent;
    public GameUUButton renwuBtn;
    public Text renwuBtnText;
    public GameObject yifangqiTip;
    public MoneyItemUI jiangli;

    public void Init()
    {
        title = transform.Find("titletext").GetComponent<Text>();
        yajin = transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        yajin.Init
        (
            yajin.transform.Find("Image").GetComponent<Image>(),
            yajin.transform.Find("Text").GetComponent<Text>(),
            null
        );
        jiangli = transform.Find("jiangliMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        jiangli.Init
        (
            jiangli.transform.Find("Image").GetComponent<Image>(),
            jiangli.transform.Find("Text").GetComponent<Text>(),
            null
        );
        content = transform.Find("renwuContent").GetComponent<Text>();
        modelParent = transform.Find("Image 1").gameObject;
        renwuBtn = transform.Find("applyBtn").GetComponent<GameUUButton>();
        renwuBtnText = transform.Find("applyBtn/Text").GetComponent<Text>();
        yifangqiTip = transform.Find("rejectedTips").gameObject;
    }

}
