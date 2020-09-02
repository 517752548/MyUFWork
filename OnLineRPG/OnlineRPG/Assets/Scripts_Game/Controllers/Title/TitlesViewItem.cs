using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TitlesViewItem : MonoBehaviour
{
    public TitleReceiveData itemData;
    public Image titleImg;
    public TextMeshProUGUI des;
    public GameObject selected;
    public GameObject lockObj;
    public bool islock;

    public void SetData(TitleReceiveData data , bool islock)
    {
        itemData = data;
        this.islock = islock;
        ShowItem();
    }

    public void ShowItem()
    {
        CommUtil.LoadTittleOrCache(itemData.resources,op =>
        {
            if (op != null)
            {
                titleImg.sprite = op;
                if (itemData.title.Equals(""))
                    des.SetActive(false);
                else
                    des.text = itemData.title;
                
                currentUseTitleStatus();
                lockObj?.SetActive(islock);
            }
        });
        
    }

    public void currentUseTitleStatus()
    {
        selected.SetActive(false);
        if (TitleData.currentTitleId.Equals(itemData.id)) 
        {
            selected.SetActive(true);
        }
    }

    public void ClickTitleItem()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_ShowTitleDialog, null, itemData);
    }
}
