using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleShowItem : MonoBehaviour
{
    ShowTitleDialog showTitleDialog;
    TitleReceiveData titleReceiveData;
    public int id;
    public bool islock;
    bool isShowTime;
    long title_time;

    //public TextMeshProUGUI theme;   主题text  暂时没有
    public TextMeshProUGUI _name;
    public Text des;
    public Text next_level;
    public TextMeshProUGUI remaining_time;
    public GameObject seceted;
    public GameObject lockObj;
    public TitleItem titleObj;

    public void SetData(TitleReceiveData titleReceiveData , bool islock)
    {
        var owendTitleDic = TitleData.title_time;
        var titleList = TitleData.configList;
        this.titleReceiveData = titleReceiveData;
        this.islock = islock;

        lockObj?.SetActive(islock);
        remaining_time.SetParentActive(false);
        next_level.SetActive(false);
        if (titleReceiveData!=null)
        {
            id = titleReceiveData.id;
            titleObj.SetShowId(id);
            titleObj.Show();
            //theme.text = titleReceiveData.theme;
            _name.text = titleReceiveData.name;
            des.text = titleReceiveData.introduce;
            
            if (owendTitleDic.ContainsKey(titleReceiveData.id) && owendTitleDic[titleReceiveData.id] != "-1")
            {
                title_time = long.Parse(owendTitleDic[titleReceiveData.id]); 
                remaining_time.SetParentActive(true);
                isShowTime = true;
                
            }
            else if (titleReceiveData.next > 0)
            {
                next_level.SetActive(true);
                string s = "";
                foreach (var item in titleList)
                {
                    if (item.id == titleReceiveData.next)
                    {
                        s = item.title;
                    }
                }
                next_level.text = s;
            }
        }
    }

    private void Update()
    {
        if (isShowTime)
            ShowTitleTime();
        
    }

    private void ShowTitleTime()
    {
        long remain_time = title_time - DateTime.Now.Second;
        if (remain_time < 0)
        {
            isShowTime = false;
            TitleData.DeleteTitle(id,(ok) =>
            {
                if (ok)
                {
                    Debug.Log("删除成功");
                }
            });
        }
        string s = XUtils.GetFormatTime(remain_time);
        remaining_time.text = s;
    }

    public void BindListener(ShowTitleDialog showTitleDialog)
    {
        this.showTitleDialog = showTitleDialog;
    }


    public void SetButtonStatus()
    {
        if (TitleData.currentTitleId == id)
        {
            seceted.gameObject.SetActive(true);
        }
        else
        {
            seceted.gameObject.SetActive(false);
        }
        lockObj?.SetActive(islock);
        
    }
    public void selectPet()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_EquipPet);
        TitleData.currentTitleId = id;
        TitleData.showTime = titleReceiveData.limit;
        TitleData.UploadConfig(UploadTitleType.Refresh,(ok) => {
            if (ok)
            {
                showTitleDialog.callBackTitleStatus();
            }
        });  
    }
    public void Close()
    {
        showTitleDialog.CloseWindow();
    }
}
