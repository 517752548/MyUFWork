﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class WorldMapUI : MonoBehaviour
{
	public GameUUButton closeBtn;
	public List<GameObject> btns = new List<GameObject>();
    public Dropdown m_NPCDropdown;
    public Dropdown m_RESDropdown;
    public RectTransform m_res_rect;
    public RectTransform m_res_show_rect;
    public Transform m_touxiang;
    public Image m_touimage;
    public List<RectTransform> btnrects = new List<RectTransform>();

    public void Init()
    {
        closeBtn = transform.Find("CloseButton").GetComponent<GameUUButton>();
        btns.Add(transform.Find("xinyue_1").gameObject);
        btns.Add(transform.Find("yingyue_2").gameObject);
        btns.Add(transform.Find("heishui_3").gameObject);
        btns.Add(transform.Find("gudao_4").gameObject);
        btns.Add(transform.Find("huangjin_5").gameObject);
        btns.Add(transform.Find("zhishui_6").gameObject);
        btns.Add(transform.Find("xichuan_7").gameObject);
        btns.Add(transform.Find("bugui_8").gameObject);
        btns.Add(transform.Find("fumo_9").gameObject);
        btns.Add(transform.Find("luoyan_10").gameObject);
        btns.Add(transform.Find("jintianhuilang_11").gameObject);
        btns.Add(transform.Find("fenshi_12").gameObject);
        btns.Add(transform.Find("lieyan_13").gameObject);
        btns.Add(transform.Find("lingchang_14").gameObject);
        btns.Add(transform.Find("zhuilongcheng_15").gameObject);
        btns.Add(transform.Find("xiaoyun_16").gameObject);
        m_NPCDropdown = transform.Find("Dropdown").GetComponent<Dropdown>();
        m_RESDropdown = transform.Find("Dropdown_res").GetComponent<Dropdown>();
        m_res_rect = m_RESDropdown.gameObject.GetComponent<RectTransform>();
        m_res_show_rect = m_RESDropdown.transform.Find("Template").GetComponent<RectTransform>();

        m_touxiang = transform.Find("touxiang");
        m_touimage = transform.Find("touxiang/ruleHeadImg").GetComponent<Image>();

        for (int i = 0; i < btns.Count; ++i)
        {
            btnrects.Add(btns[i].GetComponent<RectTransform>());
        }
    }

}
