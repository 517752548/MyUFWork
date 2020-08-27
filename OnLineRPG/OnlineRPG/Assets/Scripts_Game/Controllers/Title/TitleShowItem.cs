using BetaFramework;
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
    //TextMeshProUGUI

    public Text _name;
    public Text des;
    public Text remaining_time;
    public GameObject seceted;
    public GameObject lockObj;

    public void SetData(TitleReceiveData titleReceiveData , bool islock)
    {
        this.titleReceiveData = titleReceiveData;
        this.islock = islock;
        lockObj?.SetActive(islock);
        if (titleReceiveData!=null)
        {
            id = titleReceiveData.id;
            _name.text = titleReceiveData.name;
            des.text = titleReceiveData.introduce;
        }
    }

    public void BindListener(ShowTitleDialog showTitleDialog)
    {
        this.showTitleDialog = showTitleDialog;
    }


    public void SetButtonStatus()
    {
        if (AppEngine.SyncManager.Data.Titles.Value.currentTitleId == id)
        {
            seceted.gameObject.SetActive(true);
        }
        else
        {
            seceted.gameObject.SetActive(false);
        }
        lockObj?.SetActive(islock);
    }


}
