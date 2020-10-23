using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelRewardUI : UIMonoBehaviour
{
    public LevelRewardItemUI itemUI;
    public GameUUMask gameMask;
    public GridLayoutGroup grid;

    public override void Init()
    {
        base.Init();
        itemUI=transform.Find("Image_mask/scrollRect /itemGrid/RewardItem").gameObject.AddComponent<LevelRewardItemUI>();
        itemUI.Init();
        grid=transform.Find("Image_mask/scrollRect /itemGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        gameMask = transform.Find("Image_mask").GetComponent<GameUUMask>();

    }

}
