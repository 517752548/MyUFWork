using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivityTipsUI : MonoBehaviour
{
    public Image icon;
    public Text activityname;
    public Text cishu;
    public Text timeText;
    public Text typeText;
    public Text huoyueduText;
    public Text xianzhiText;
    public Text descText;
    public GridLayoutGroup rewardGrid;
    public CommonItemUI defaultRewardItem;

    public void Init()
    {
        icon=transform.Find("content/UpContent/Icon").GetComponent<Image>();
        activityname=transform.Find("content/UpContent/itemName").GetComponent<UnityEngine.UI.Text>();
        cishu=transform.Find("content/UpContent/cishu").GetComponent<UnityEngine.UI.Text>();
        timeText=transform.Find("content/content/MidContent/shijian/text").GetComponent<UnityEngine.UI.Text>();
        typeText=transform.Find("content/content/MidContent/renwuxingshi/text").GetComponent<UnityEngine.UI.Text>();
        huoyueduText=transform.Find("content/content/MidContent/huoyuedu/text").GetComponent<UnityEngine.UI.Text>();
        xianzhiText=transform.Find("content/content/MidContent/dengjixianzhi/text").GetComponent<UnityEngine.UI.Text>();
        descText=transform.Find("content/content/MidContent/desc").GetComponent<UnityEngine.UI.Text>();
        rewardGrid=transform.Find("content/content/MidContent/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultRewardItem=transform.Find("content/content/MidContent/grid/CommonItemUI80_80").gameObject.AddComponent<CommonItemUI>();
        defaultRewardItem.Init();

    }

}
