using System.Collections.Generic;
using app.config;
using app.utils;
using UnityEngine;
using UnityEngine.UI;

public class SystemNotice : BaseUI
{
    private static SystemNotice mIns;
    public static SystemNotice ins
    {
        get
        {
            if (mIns == null) { mIns = Singleton.GetObj(typeof(SystemNotice)) as SystemNotice; }
            return mIns;
        }
    }

    //[Inject(ui = "systemNoticeUI")]
    //public GameObject ui;

    public SystemNoticeUI UI;
    //private UGUIRichText richText;
    private GameObject richText;
    private RectTransform richTextRT;
    private Text richTextText;
    private ContentSizeFitter textSizeFitter;
    private List<string> noticeList = new List<string>();
    //private bool isShowing;
    private int ypos = -22;
    private int bgwidth = 567;
    /// <summary>
    /// 播放速度
    /// </summary>
    private float speed = 50;

    private int fontsize = 20;
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.BUBBLES);
    }
    */

    public SystemNotice()
    {
        uiName = "systemNoticeUI";
    }

    public override void initUI()
    {
        base.initUI();
        UI = ui.AddComponent<SystemNoticeUI>();
        UI.Init();
        if (richText == null)
        {
            //richText = new UGUIRichText();
            richText = new GameObject();
            richText.transform.SetParent(UI.bg.transform);
            richText.layer = UI.gameObject.layer;
            richTextRT = richText.AddComponent<RectTransform>();
            richText.AddComponent<CanvasRenderer>();
            richText.AddComponent<Canvas>();
            richTextRT.anchorMin = new Vector2(0, 0.5f);
            richTextRT.anchorMax = new Vector2(0, 0.5f);
            richTextRT.pivot = new Vector2(0f, 0.5f);
            richTextRT.localScale = Vector3.one;
            richTextText = richText.AddComponent<Text>();
            richTextText.font = SourceManager.Ins.defaultFont;
            richTextText.fontSize = fontsize;
            richTextText.color = Color.green;
            richTextText.supportRichText = true;
            textSizeFitter = richText.AddComponent<ContentSizeFitter>();
            textSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            textSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        if (noticeList == null)
        {
            noticeList = new List<string>();
        }
        //初始化后先隐藏
        //hide();
    }

    /*
    public override void Update()
    {
        if (!isShowing && noticeList.Count>0)
        {
            Init();

            isShowing = true;
            richText.gameObject.SetActive(true);
            List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
            Dictionary<string, string> textDict = new Dictionary<string, string>();
            textDict.Add("type", "text");
            textDict.Add("text", ColorUtil.getColorText(ColorUtil.GREEN,noticeList[0]));
            content.Add(textDict);
            richText.SetContent(content, SourceManager.Ins.defaultFont, fontsize, true);
            noticeList.RemoveAt(0);
            richText.gameObject.transform.localPosition = new Vector3(bgwidth / 2 + richText.width/2, ypos, 0);
            TweenUtil.MoveTo(richText.gameObject.transform, 
                new Vector3(-bgwidth / 2 - richText.width / 2, ypos, 0),
                (bgwidth+richText.width)/speed, null, moveEnd);
        }
    }
    */

    private void moveEnd()
    {
        /*
        richText.gameObject.SetActive(false);
        List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
        Dictionary<string, string> textDict = new Dictionary<string, string>();
        textDict.Add("type", "text");
        textDict.Add("text", ColorUtil.getColorText(ColorUtil.GREEN,""));
        content.Add(textDict);
        richText.SetContent(content, SourceManager.Ins.defaultFont, fontsize, false);
        richText.gameObject.transform.localPosition = new Vector3(bgwidth / 2, ypos, 0);
        isShowing = false;
        */
        if (noticeList.Count == 0)
        {
            hide();
        }
        else
        {
            ShowNextNotice();
        }
    }

    public void ShowNotice(string str)
    {
        if (!ServerConfig.instance.IsPassedCheck)
        {
            return;
        }
        noticeList.Add(str);
        if (!isShown)
        {
            preLoadUI();
        }
    }

    private void ShowNextNotice()
    {
        //List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
        //Dictionary<string, string> textDict = new Dictionary<string, string>();
        //textDict.Add("type", "text");
        //textDict.Add("text", ColorUtil.getColorText(ColorUtil.GREEN, noticeList[0]));
        //content.Add(textDict);
        //richText.SetContent(content, SourceManager.Ins.defaultFont, fontsize, true);
        richTextText.text = noticeList[0];
        textSizeFitter.SetLayoutHorizontal();
        float width = richTextRT.sizeDelta.x;
        noticeList.RemoveAt(0);
        /*
        richText.gameObject.transform.localPosition = new Vector3(bgwidth / 2 + width / 2, ypos, 0);
        TweenUtil.MoveTo(richText.gameObject.transform,
            new Vector3(-bgwidth / 2 - width / 2, ypos, 0),
            (bgwidth + width) / speed, null, moveEnd);
        */
        richText.gameObject.transform.localPosition = new Vector3(bgwidth / 2, ypos, 0);
        TweenUtil.MoveTo(richText.gameObject.transform,
            new Vector3(-bgwidth / 2 - width, ypos, 0),
            (bgwidth + width) / speed, null, moveEnd);
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        //this.setAsFirstSibling(UI.gameObject);
        if (noticeList.Count > 0)
        {
            ShowNextNotice();
        }
        else
        {
            hide(null);
        }
    }

    /*
    public void Init()
    {
        if (base.ui != null)
        {
            base.ui.SetActive(true);
        }
        else
        {
            preLoadUI();
        }
    }

    public override void hide(RMetaEvent e = null)
    {
        base.hide(e);
    }
    */

}
