using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PartnerUI:MonoBehaviour
{
    public GameUUButton closeBtn;
    public TabButtonGroup tabs;
    public Text title;
    public PartnerFormationUI partnerFormationUI;
    public RidePetUI ridePetUI;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        tabs = transform.Find("bg/tabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabs.AddToggle(transform.Find("bg/tabGroup/toggles/huoban").gameObject.GetComponent<GameUUToggle>());
        tabs.AddToggle(transform.Find("bg/tabGroup/toggles/qichong").gameObject.GetComponent<GameUUToggle>());

        title = transform.Find("title").GetComponent<UnityEngine.UI.Text>();
        partnerFormationUI = transform.Find("huoban").gameObject.AddComponent<PartnerFormationUI>();
        partnerFormationUI.Init();
        ridePetUI = transform.Find("RidePetUI").gameObject.AddComponent<RidePetUI>();
        ridePetUI.Init();

    }
}
