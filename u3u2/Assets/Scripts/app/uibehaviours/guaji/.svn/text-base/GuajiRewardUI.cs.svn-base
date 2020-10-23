using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuajiRewardUI : MonoBehaviour 
{
    public GameUUButton closeBtn;
    public Transform tfItemGrid;
    public GuajiRewardItemUI defaultItemUI;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        tfItemGrid = transform.Find("Image_mask/itemGrid");
        defaultItemUI = tfItemGrid.Find("RewardItem").gameObject.AddComponent<GuajiRewardItemUI>();
        defaultItemUI.Init();
    }


}
