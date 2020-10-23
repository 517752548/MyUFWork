using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FubenJiangliUI : UIMonoBehaviour 
{
    public TabButtonGroup tabButtonGroup;
    public Transform tfGrid;
    public QiRiMuBiaoItemUI defaultItemUI;

    public override void Init()
    {
        base.Init();
        tabButtonGroup = transform.Find("grid").gameObject.AddComponent<TabButtonGroup>();
        tabButtonGroup.AddToggle(transform.Find("grid/Toggle (1)").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(transform.Find("grid/Toggle (2)").GetComponent<GameUUToggle>());
        tfGrid = transform.Find("Image_mask/scrollRect/itemGrid");
        defaultItemUI = transform.Find("Image_mask/scrollRect/itemGrid/RewardItem").gameObject.AddComponent<QiRiMuBiaoItemUI>();
        defaultItemUI.Init();
    }


}
