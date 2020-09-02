using System.Net.Mime;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class HeadUI : BaseHomeUI
{
    public TextMeshProUGUI cupTxt;
    public GameObject Title;
    private TitleItem titleItem;
    public override void Init(HomeRoot root)
    {
        Title = transform.Find("Title").gameObject;
        var st = Title.AddComponent<TitleItem>();
        st.titleImg = Title.transform.Find("Img_bg").GetComponent<Image>();
        st.lv = Title.transform.Find("Text_Level").GetComponent<TextMeshProUGUI>();
        titleItem = st;
        cupTxt = transform.Find("Cup/Text_Num").GetComponent<TextMeshProUGUI>();
        base.Init(root);
    }

    public override void OnShow()
    {
        cupTxt.text = AppEngine.SyncManager.Data.Cup.Value.ToString();
        if (TitleData.currentTitleId > 0)
        {
            titleItem.SetShowId(TitleData.currentTitleId);
            titleItem.Show();
        } else {
            titleItem.gameObject.SetActive(false);
        }
    }
    public override void OnEnter()
    {
        cupTxt.text = AppEngine.SyncManager.Data.Cup.Value.ToString();
    }
}