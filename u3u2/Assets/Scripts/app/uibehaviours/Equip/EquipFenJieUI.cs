using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipFenJieUI : UIMonoBehaviour
{

    public List<EquipFenJieItemUI> leftItemList;

    public MoneyItemUI costMoney;
    public GameUUButton yijiantianjiaBtn;
    public Text yijiantianjiaText;
    public GameUUButton fenjieBtn;

    public EquipFenJieItemUI defaultBagItemUI;
    public ScrollRect scrollrect;
    public GridLayoutGroup itemGrid;
    
    public GameObject fenjieEffect;

    public CanvasRenderer leftPanelRenderer;
    public CanvasRenderer rightPanelRenderer;

    public override void Init()
     {
         base.Init();
        leftItemList=new List<EquipFenJieItemUI>();
        leftPanelRenderer = transform.Find("leftPanel").GetComponent<CanvasRenderer>();
        GameObject obj1 = transform.Find("leftPanel/leftEquipBgList/CommonItemUI90_90_1").gameObject;
        CommonItemUI commonUI1 = obj1.AddComponent<CommonItemUI>();
        commonUI1.Init();
        EquipFenJieItemUI fenjieItemUI1 = obj1.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI1.Init();
        leftItemList.Add(fenjieItemUI1);

        GameObject obj2 = transform.Find("leftPanel/rightEquipBgList/CommonItemUI90_90_1").gameObject;
        CommonItemUI commonUI2 = obj2.AddComponent<CommonItemUI>();
        commonUI2.Init();
        EquipFenJieItemUI fenjieItemUI2 = obj2.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI2.Init();
        leftItemList.Add(fenjieItemUI2);

        GameObject obj3 = transform.Find("leftPanel/leftEquipBgList/CommonItemUI90_90_2").gameObject;
        CommonItemUI commonUI3 = obj3.AddComponent<CommonItemUI>();
        commonUI3.Init();
        EquipFenJieItemUI fenjieItemUI3 = obj3.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI3.Init();
        leftItemList.Add(fenjieItemUI3);

        GameObject obj4 = transform.Find("leftPanel/rightEquipBgList/CommonItemUI90_90_2").gameObject;
        CommonItemUI commonUI4 = obj4.AddComponent<CommonItemUI>();
        commonUI4.Init();
        EquipFenJieItemUI fenjieItemUI4 = obj4.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI4.Init();
        leftItemList.Add(fenjieItemUI4);

        GameObject obj5 = transform.Find("leftPanel/leftEquipBgList/CommonItemUI90_90_3").gameObject;
        CommonItemUI commonUI5 = obj5.AddComponent<CommonItemUI>();
        commonUI5.Init();
        EquipFenJieItemUI fenjieItemUI5 = obj5.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI5.Init();
        leftItemList.Add(fenjieItemUI5);

        GameObject obj6 = transform.Find("leftPanel/rightEquipBgList/CommonItemUI90_90_3").gameObject;
        CommonItemUI commonUI6 = obj6.AddComponent<CommonItemUI>();
        commonUI6.Init();
        EquipFenJieItemUI fenjieItemUI6 = obj6.AddComponent<EquipFenJieItemUI>();
        fenjieItemUI6.Init();
        leftItemList.Add(fenjieItemUI6);

        costMoney=transform.Find("leftPanel/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        costMoney.Init();
        yijiantianjiaBtn=transform.Find("leftPanel/yijiantianjia").GetComponent<GameUUButton>();
        yijiantianjiaText=transform.Find("leftPanel/yijiantianjia/Text").GetComponent<Text>();
        fenjieBtn=transform.Find("leftPanel/fenjie").GetComponent<GameUUButton>();
        rightPanelRenderer = transform.Find("rightPanel").GetComponent<CanvasRenderer>();
        defaultBagItemUI=transform.Find("rightPanel/Image/scrollRect/itemGrid/CommonItemUI90_90").gameObject.AddComponent<EquipFenJieItemUI>();
        defaultBagItemUI.Init();
        scrollrect=transform.Find("rightPanel/Image/scrollRect").GetComponent<ScrollRect>();
        itemGrid=transform.Find("rightPanel/Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        fenjieEffect = transform.Find("leftPanel/UI_01").gameObject;
        fenjieEffect.gameObject.SetActive(false);
        defaultBagItemUI.gameObject.SetActive(false);
      }
}
