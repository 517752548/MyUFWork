using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChengHaoUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    //public GameUUButton yincangBtn;
    public GameUUButton confirmBtn;
    public GridLayoutGroup chenghaoGrid;
    public ChengHaoToggleUI defaultitem;
    public TabButtonGroup chenghaoTBG;
    //称号属性
    public GridLayoutGroup propGrid;
    public List<Text> propList;

    public Text huodeText;
    public Text guoqiTimeText;
    public Text descText;

    public void Init()
    {
        closeBtn = transform.Find("CloseButton").GetComponent<GameUUButton>();
     //   yincangBtn=transform.Find("list/yincangBtn").GetComponent<GameUUButton>();
        confirmBtn = transform.Find("confirmBtn").GetComponent<GameUUButton>();

        chenghaoGrid=transform.Find("list/ScrollView/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultitem=transform.Find("list/ScrollView/grid/Toggle").gameObject.AddComponent<ChengHaoToggleUI>();
        defaultitem.Init();
        chenghaoTBG=transform.Find("list/ScrollView/grid").gameObject.AddComponent<TabButtonGroup>();
        chenghaoTBG.Init();
        propGrid=transform.Find("contentList/ScrollView/vertical/shuxingGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        propList = new List<Text>() { 
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (1)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (2)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (3)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (4)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (5)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (6)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (7)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (8)").GetComponent<UnityEngine.UI.Text>(),
            transform.Find("contentList/ScrollView/vertical/shuxingGrid/Text (9)").GetComponent<UnityEngine.UI.Text>()
        };

        huodeText=transform.Find("contentList/ScrollView/vertical/huodefangfaText").GetComponent<UnityEngine.UI.Text>();
        guoqiTimeText=transform.Find("contentList/ScrollView/vertical/guoqishijian").GetComponent<UnityEngine.UI.Text>();
        descText=transform.Find("contentList/ScrollView/vertical/chengweiText").GetComponent<UnityEngine.UI.Text>();

    }

}
