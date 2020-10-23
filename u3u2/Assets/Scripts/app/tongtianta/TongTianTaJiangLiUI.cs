using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TongTianTaJiangLiUI : MonoBehaviour 
{
    public GameUUButton closeBtn;
    public Transform tfRewardItemRoot;
    public GameObject objRewardItem;

    public GameObject objBigBg;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        tfRewardItemRoot = transform.Find("Image_mask/itemGrid");
        objRewardItem = tfRewardItemRoot.Find("RewardItem").gameObject;
        objBigBg = transform.Find("Image_bigBg").gameObject;
    }

}
