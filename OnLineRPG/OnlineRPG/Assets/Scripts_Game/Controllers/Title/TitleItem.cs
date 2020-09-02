using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleItem : MonoBehaviour
{
    public Image titleImg;
    public TextMeshProUGUI lv;
    public int id;
    Dictionary<int, TitleReceiveData> dic;
    void Start()
    {
        dic = TitleData.titleDic;
        id = -1;        
    }
    /// <summary>
    /// 当前展示的称号ID
    /// </summary>
    public void SetShowId(int itemId)
    {
        id = itemId;
    }

    /// <summary>
    /// 展示称号
    /// </summary>
    public void Show()
    {
        var titleList = TitleData.configList;
        if (id != -1)
        {
            TitleReceiveData data = TitleData.GetReceiveData(id);
            CommUtil.LoadTittleOrCache(data.resources, op =>
            {
                if (op != null)
                {
                    titleImg.sprite = op;
                    if (data.next > -1)
                    {
                        lv.gameObject.SetActive(true);                   
                        lv.text = data.title;
                    }
                    else
                    {
                        lv.gameObject.SetActive(false);
                    }                 
                }
            });
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
