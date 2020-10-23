using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JingJiChangRewardItemUI : MonoBehaviour
{
    public Text paimingText;
    public CommonItemUINoClick[] rewardList;

    public void Init()
    {
        rewardList = new CommonItemUINoClick[4];

        Transform transform1 = transform.Find("rewarditems/ZZMoneyItem (1)");
        CommonItemUINoClick c1 =  transform1.gameObject.AddComponent<CommonItemUINoClick>();
        c1.Init();
        rewardList[0] = c1;

        CommonItemUINoClick c2 = transform.Find("rewarditems/ZZMoneyItem (2)").gameObject.AddComponent<CommonItemUINoClick>();
        c2.Init();
        rewardList[1] = c2;

        CommonItemUINoClick c3 = transform.Find("rewarditems/ZZMoneyItem (3)").gameObject.AddComponent<CommonItemUINoClick>();
        c3.Init();
        rewardList[2] = c3;

        CommonItemUINoClick c4 = transform.Find("rewarditems/ZZMoneyItem (4)").gameObject.AddComponent<CommonItemUINoClick>();
        c4.Init();
        rewardList[3] = c4;

        Transform tfPaiming = transform.Find("paiming");
        if (tfPaiming)
        {
            paimingText = tfPaiming.GetComponent<Text>();
        }
    }

}
