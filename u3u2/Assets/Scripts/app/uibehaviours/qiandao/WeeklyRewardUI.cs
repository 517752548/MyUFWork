using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeeklyRewardUI : UIMonoBehaviour
{
    public GameUUMask mask;
    public GridLayoutGroup grid;
    public WeeklyRewardItemUI itemUI;

    public override void Init()
    {
        base.Init();
        grid=transform.Find("Image_mask/scrollRect/itemGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        itemUI=transform.Find("Image_mask/scrollRect/itemGrid/RewardItem").gameObject.AddComponent<WeeklyRewardItemUI>();
        itemUI.Init();
        mask = transform.Find("Image_mask").GetComponent<GameUUMask>();

    }

}
