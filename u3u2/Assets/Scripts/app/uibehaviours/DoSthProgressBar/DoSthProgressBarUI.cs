﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoSthProgressBarUI : UIMonoBehaviour {

    public Text titleText;
    public ProgressBar progressbar;
    public GameUUButton m_quxiaoBtn;
    public Image m_quxiao_bg;
    public Text m_quxiao_text;

    public override void Init()
    {
        base.Init();

        titleText = transform.Find("loadingTipsLabel").gameObject.GetComponent<Text>();
        progressbar = transform.Find("progressbar").gameObject.AddComponent<ProgressBar>();

        progressbar.Init
        (
            progressbar.transform.Find("background").GetComponent<Image>(),
            progressbar.transform.Find("background/foreground").GetComponent<Image>(),
            progressbar.transform.Find("Text").GetComponent<Text>(), 290
        );

        m_quxiaoBtn = transform.Find("CancelBtn").gameObject.GetComponent<GameUUButton>();
        m_quxiao_bg = transform.Find("CancelBtn").gameObject.GetComponent<Image>();
        m_quxiao_text = transform.Find("CancelBtn/Text").gameObject.GetComponent<Text>();
    }
}