using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipChongZhuItemUI : MonoBehaviour {
    public Image bg;
    public Image selectedBg;
    public GameUUToggle toggle;
    public CommonItemUINoClick item;
    public Text equipName;
    public Text equipLevel;
    public Text equipType;
    public int equipTemplateId;
    public Image yijingzhuangbei;

    public void Init()
    {
        bg = transform.Find("Background").GetComponent<Image>();
        selectedBg = transform.Find("Background/Checkmark").GetComponent<Image>();
        toggle = GetComponent<GameUUToggle>();
        item = transform.Find("ZZCommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        item.Init();
        equipName = transform.Find("equipName").GetComponent<Text>();
        equipLevel = transform.Find("equipLevel").GetComponent<Text>();
        equipType = transform.Find("equipType").GetComponent<Text>();
        yijingzhuangbei = transform.Find("yizhuangbei").GetComponent<Image>();
        yijingzhuangbei.gameObject.SetActive(false);

    }

}
