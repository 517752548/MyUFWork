using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using app.utils;

public class DoSthProgressBar : BaseUI
{
    //[Inject(ui = "DoSthProgressbarUI")]
    //public GameObject ui;

    private DoSthProgressBarUI UI;
    
    private bool m_IS_Show_Quxiao = false;
    private object data;
    private string _title;
    /// <summary>
    /// 播放时间，单位：s
    /// </summary>
    private float totalTime = 3;
    private RMetaEventHandler _callBackHandler;
    private RMetaEventHandler _callCancelHandler;
    private bool m_IsCircu = false;
    private Tweener m_tweener;

    private static DoSthProgressBar _ins;
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.PopWND);
    }
    */
    public static DoSthProgressBar Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(DoSthProgressBar)) as DoSthProgressBar;
            }
            return _ins;
        }
    }

    public DoSthProgressBar()
    {
        uiName = "DoSthProgressbarUI";
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        

        if (UI == null)
        {
            UI = ui.AddComponent<DoSthProgressBarUI>();
            UI.Init();
            UI.m_quxiaoBtn.SetClickCallBack(QuXiaoClick);
            /*
            Image fore = progressbar.transform.Find("background/foreground").GetComponent<Image>();
            RectTransform rect = fore.transform as RectTransform;
            rect.sizeDelta = new Vector2(300,36);
            */
        }
        UI.Show();
        if (null != m_tweener)
        {
            m_tweener.Kill(true);
            m_tweener = null;
        }
        UI.progressbar.forGround.rectTransform.sizeDelta = new Vector2(0, 36);
        UI.titleText.text = _title;
        if (m_IS_Show_Quxiao)
        {
            UI.m_quxiaoBtn.gameObject.SetActive(true);
            ColorUtil.DeGray(UI.m_quxiao_bg);
        }
        else
        {
            UI.m_quxiaoBtn.gameObject.SetActive(false);
            ColorUtil.Gray(UI.m_quxiao_bg);
        }
        
        //progressbar.MaxValue = 1;
        //progressbar.Value = 0;
        //progressbar.forGround.transform.localPosition = new Vector3(progressbar.zeroProgressPosition,0,0);
        //TweenUtil.MoveTo(progressbar.forGround.transform, Vector3.zero, totalTime, null, timerEnd);
        m_tweener = DOTween.To(() => UI.progressbar.forGround.rectTransform.sizeDelta, s => UI.progressbar.forGround.rectTransform.sizeDelta = s, new Vector2(300, 36), totalTime).OnComplete(timerEnd).OnKill(null);
        
    }

    public override void hide(RMetaEvent e = null)
    {
        base.hide();
        if (UI != null)
        {
            UI.Hide();
        }
        m_IsCircu = false;
        if (null != m_tweener)
        {
            m_tweener.Kill(true);
            m_tweener = null;
        }
    }

    private void timerEnd()
    {
        if (!UI.isShown)
        {
            return;
        }
        if (m_IsCircu)
        {
            show();
        }
        else
        {
            hide();
        }
        if (_callBackHandler != null)
        {
            _callBackHandler(new RMetaEvent("", data));
        }
    }

    /// <summary>
    /// 显示进度
    /// </summary>
    /// <param name="title">显示文本</param>
    /// <param name="callbackHandler">完成回掉</param>
    /// <param name="datav"></param>
    /// <param name="isshowquxiao">是否显示取消按钮</param>
    /// <param name="callCancelHandler">取消按钮回掉</param>
    /// <param name="totaltime">进度条时间</param>
    /// <param name="iscirc">是否为循环进度条</param>
    public void ShowInfo(string title, RMetaEventHandler callbackHandler, object datav = null, bool isshowquxiao = false, RMetaEventHandler callCancelHandler = null, float totaltime=3,bool iscirc = false)
    {
        if (m_IsCircu)
        {
            return;
        }

        data = datav;
        _title = title;
        _callBackHandler = callbackHandler;
        m_IS_Show_Quxiao = isshowquxiao;
        _callCancelHandler = callCancelHandler;
        totalTime = totaltime;
        m_IsCircu = iscirc;
        preLoadUI();
    }

    public void QuXiaoClick()
    {
        m_IsCircu = false;
        hide();
        if (null != _callCancelHandler)
        {
            _callCancelHandler(new RMetaEvent("", data));
        }
    }
}