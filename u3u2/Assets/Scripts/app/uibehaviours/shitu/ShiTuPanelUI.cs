using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShiTuPanelUI : MonoBehaviour
{
    public GameUUButton closeBtn;

    public TabButtonGroup panelTBG;
    
    public Image tudiIcon;
    public Text tudiName;
    public Text tudiLevel;
    public Text tudiJob;
    public Text tudiFightPower;

    public GridLayoutGroup listgrid;
    public ShiTuChengJiuItemUI defaultItem;

    public void Init()
    {
        closeBtn = transform.Find("close").GetComponent<GameUUButton>();
        panelTBG = transform.Find("toggleGroup").gameObject.AddComponent<TabButtonGroup>();
        panelTBG.Init();

        GameUUToggle toggle = transform.Find("toggleGroup/chengjiu").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle);

        tudiIcon = transform.Find("CommonItemUINoClick80_80/Icon").GetComponent<Image>();
        GameObject biankuang = transform.Find("CommonItemUINoClick80_80/BianKuang").gameObject;
        biankuang.SetActive(false);

        tudiName = transform.Find("tudiName").GetComponent<Text>();
        tudiLevel = transform.Find("tudiLevel").GetComponent<Text>();
        tudiJob = transform.Find("tudiJob").GetComponent<Text>();
        tudiFightPower = transform.Find("zhandouli/Text").GetComponent<Text>();
        listgrid = transform.Find("ScrollViewVertical/grid").GetComponent<GridLayoutGroup>();
        defaultItem = transform.Find("ScrollViewVertical/grid/item").gameObject.AddComponent<ShiTuChengJiuItemUI>();
        defaultItem.Init();

    }
}
