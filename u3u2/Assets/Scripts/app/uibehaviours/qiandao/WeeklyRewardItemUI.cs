using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeeklyRewardItemUI : MonoBehaviour
{
    public Text textDay;
    public Text textDescrip;
    public CommonItemUINoClick leftItem;
    public CommonItemUINoClick rightItem;
    public GameUUButton leftButton;
    public GameUUButton rightButton;
    public GameUUButton recieveButton;
    public GameObject objHaveRecieve;

    public void Init()
    {
        textDay=transform.Find("Image_bg/Text_day").GetComponent<UnityEngine.UI.Text>();
        textDescrip=transform.Find("Image_bg/Text_description").GetComponent<UnityEngine.UI.Text>();
        leftItem=transform.Find("Image_bg/items/CommonItemUINoClick70_70_left").gameObject.AddComponent<CommonItemUINoClick>();
        leftItem.Init();
        rightItem=transform.Find("Image_bg/items/CommonItemUINoClick70_70_right").gameObject.AddComponent<CommonItemUINoClick>();
        rightItem.Init();
        objHaveRecieve=transform.Find("Image").gameObject;

        leftButton = transform.Find("Image_bg/items/Button_left").GetComponent<GameUUButton>();
        rightButton = transform.Find("Image_bg/items/Button_right").GetComponent<GameUUButton>();
        recieveButton = transform.Find("Button0").GetComponent<GameUUButton>();
    }

}
