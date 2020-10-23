using UnityEngine;
using System.Collections;

public class ZaiXianItemUI : MonoBehaviour
{
    public GameUUButton button;
    public CommonItemUINoClick commonItem;

    public void Init()
    {
        commonItem=transform.Find("RewardItem").gameObject.AddComponent<CommonItemUINoClick>();
        commonItem.Init();
        commonItem.icon.gameObject.SetActive(false);
        button = transform.Find("Button").GetComponent<GameUUButton>();
    }

}
