using UnityEngine;
using UnityEngine.UI;

public class QiRiMuBiaoItemUI : MonoBehaviour
{
    public Text textDescrip;
    public CommonItemUI rightItem;
    public GameUUButton rightButton;
    public GameUUButton recieveButton;
    public GameObject objHaveRecieve;

    public void Init()
    {
        textDescrip=transform.Find("Image_bg/Text_description").GetComponent<UnityEngine.UI.Text>();
        rightItem=transform.Find("Image_bg/items/CommonItemUINoClick70_70_right").gameObject.AddComponent<CommonItemUI>();
        rightItem.Init();
        objHaveRecieve = transform.Find("yilingqu").gameObject;

        rightButton = transform.Find("Image_bg/items/Button_right").GetComponent<GameUUButton>();
        recieveButton = transform.Find("Button0").GetComponent<GameUUButton>();
    }

}