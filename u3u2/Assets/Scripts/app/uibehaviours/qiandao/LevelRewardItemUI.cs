using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelRewardItemUI : MonoBehaviour
{

    public Text textTarget;
    public List<CommonItemUINoClick> commonUIs;
    public List<GameUUButton> gameButtons;
    public GameUUButton buttonReceive;
    public GameObject objHaveReveive;

    public void Init()
    {
        textTarget=transform.Find("Image_bg/Text_title").GetComponent<UnityEngine.UI.Text>();
        commonUIs=new List<CommonItemUINoClick>();
        CommonItemUINoClick c1 = transform.Find("Image_bg/items/CommonItemUINoClick70_70_1").gameObject.AddComponent<CommonItemUINoClick>();
        c1.Init();
        commonUIs.Add(c1);
        CommonItemUINoClick c2 = transform.Find("Image_bg/items/CommonItemUINoClick70_70_2").gameObject.AddComponent<CommonItemUINoClick>();
        c2.Init();
        commonUIs.Add(c2);
        CommonItemUINoClick c3 = transform.Find("Image_bg/items/CommonItemUINoClick70_70_3").gameObject.AddComponent<CommonItemUINoClick>();
        c3.Init();
        commonUIs.Add(c3);
        CommonItemUINoClick c4 = transform.Find("Image_bg/items/CommonItemUINoClick70_70_4").gameObject.AddComponent<CommonItemUINoClick>();
        c4.Init();
        commonUIs.Add(c4);
        CommonItemUINoClick c5 = transform.Find("Image_bg/items/CommonItemUINoClick70_70_5").gameObject.AddComponent<CommonItemUINoClick>();
        c5.Init();
        commonUIs.Add(c5);

        gameButtons=new List<GameUUButton>(5);

        gameButtons.Add(transform.Find("Image_bg/items/Button_1").GetComponent<GameUUButton>());

        gameButtons.Add(transform.Find("Image_bg/items/Button_2").GetComponent<GameUUButton>());

        gameButtons.Add(transform.Find("Image_bg/items/Button_3").GetComponent<GameUUButton>());

        gameButtons.Add(transform.Find("Image_bg/items/Button_4").GetComponent<GameUUButton>());

        gameButtons.Add(transform.Find("Image_bg/items/Button_5").GetComponent<GameUUButton>());

        objHaveReveive=transform.Find("Image").gameObject;

        buttonReceive = transform.Find("Button0").GetComponent<GameUUButton>();

    }

}
