using UnityEngine;
using UnityEngine.UI;

public class BattleItemDetailInfoUIBehav : MonoBehaviour
{
    public CommonItemUINoClick commonItem;
    public Text type;
    public Text level;
    public Text desc;

    public void Init()
    {
        commonItem = transform.Find("CommonItemUINoClick80_80").gameObject.AddComponent<CommonItemUINoClick>();
        commonItem.Init();
        type = transform.Find("CommonItemUINoClick80_80/type").GetComponent<Text>();
        level = transform.Find("CommonItemUINoClick80_80/level").GetComponent<Text>();
        desc = transform.Find("desc").GetComponent<Text>();
    }
}
