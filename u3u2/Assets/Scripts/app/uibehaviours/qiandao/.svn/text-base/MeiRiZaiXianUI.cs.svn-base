using UnityEngine;
using UnityEngine.UI;

public class MeiRiZaiXianUI : UIMonoBehaviour
{
    public ZaiXianItemUI ZaixinItemUI;
    public GameObject objRewardButton;
    public GameObject objRemainTime;
    public Text remainTimeText;
    public Transform tfArrowRoot;

    public override void Init()
    {
        base.Init();
        ZaixinItemUI=transform.Find("Image_bg/RewardItem").gameObject.AddComponent<ZaiXianItemUI>();
        ZaixinItemUI.Init();
        objRewardButton=transform.Find("Image_bg/Button0").gameObject;
        objRemainTime=transform.Find("Image_bg/Image_bg").gameObject;
        remainTimeText = objRemainTime.transform.Find("Text_remianTime").gameObject.GetComponent<Text>();
        tfArrowRoot = transform.Find("Image_bg/arrowRoot").GetComponent<UnityEngine.Transform>();
        objRewardButton.gameObject.SetActive(false);
    }

}
