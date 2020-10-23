using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DanrenFubenItemUI : MonoBehaviour 
{
    public Text textTitle;
    public Transform tfModelContainer;
    public Transform tfYitongguo;
    public CommonItemUI commonItemUI_left;
    public CommonItemUI commonItemUI_right;
    public Transform tfMask;
    public Transform tfItem;
    public GameUUButton btnSelect;

    public void Init()
    {
        textTitle = transform.Find("Item/Text_name").GetComponent<Text>();
        tfModelContainer = transform.Find("Item/modelContainer");
        tfYitongguo = transform.Find("Item/Image_tongguo");
        commonItemUI_left = transform.Find("Item/CommonItemUI_left").gameObject.AddComponent<CommonItemUI>();
        commonItemUI_left.Init();
        commonItemUI_right = transform.Find("Item/CommonItemUI_right").gameObject.AddComponent<CommonItemUI>();
        commonItemUI_right.Init();
        tfMask = transform.Find("Image");
        tfItem = transform.Find("Item");
        btnSelect = transform.Find("Item/Image_btn").GetComponent<GameUUButton>();
    }

}
