using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class JieChuTuDiUI:MonoBehaviour
{
    public Text jiechuHuaFei;
    public List<CommonItemUI> tudiList;
    public GameUUButton sureBtn;
    public GameUUButton cancelBtn;
    public TabButtonGroup xuanzeTBG;

    public void Init()
    {
        jiechuHuaFei=transform.Find("Image/title").GetComponent<Text>();
        sureBtn=transform.Find("Image/btns/ZZButton0").GetComponent<GameUUButton>();
        cancelBtn=transform.Find("Image/btns/ZZButton1").GetComponent<GameUUButton>();
        xuanzeTBG=transform.Find("Image/GameObject").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle toggle1 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80/Toggle").GetComponent<GameUUToggle>();
        xuanzeTBG.AddToggle(toggle1);
        GameUUToggle toggle2 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80 (1)/Toggle").GetComponent<GameUUToggle>();
        xuanzeTBG.AddToggle(toggle2);
        GameUUToggle toggle3 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80 (2)/Toggle").GetComponent<GameUUToggle>();
        xuanzeTBG.AddToggle(toggle3);

        tudiList = new List<CommonItemUI>();
        CommonItemUI ui1 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80").gameObject.AddComponent<CommonItemUI>();
        ui1.Init();
        tudiList.Add(ui1);
        CommonItemUI ui2 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80 (1)").gameObject.AddComponent<CommonItemUI>();
        ui2.Init();
        tudiList.Add(ui2);
        CommonItemUI ui3 = transform.Find("Image/GameObject/CommonItemUIWithToggle80_80 (2)").gameObject.AddComponent<CommonItemUI>();
        ui3.Init();
        tudiList.Add(ui3);

    }
}
