using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TitleItem : MonoBehaviour
{
    public TitleReceiveData itemData;
    public Image bg;
    public TextMeshProUGUI level;
    public GameObject selected;
    public GameObject lockObj;
    public bool islock;

    public void SetData(TitleReceiveData data , bool islock)
    {
        itemData = data;
        this.islock = islock;
        Debug.LogError("id: " +data.id +"--name: "+data.name +"--sprite: "+data.resources + "--level: "+data.introduce);
    }

    public void ShowItem()
    {
        CommUtil.LoadTittleOrCache(itemData.resources,op =>
        {
            if (op != null)
            {
                bg.sprite = op;
                level.text = itemData.introduce;
                currentUseTitleStatus();
                lockObj?.SetActive(islock);
            }
        });
        
    }

    public void currentUseTitleStatus()
    {
        selected.SetActive(false);
        if (AppEngine.SyncManager.Data.Titles.Value.currentTitleId.Equals(itemData.id))
        {
            selected.SetActive(true);
        }
    }

    public void ClickTitleItem()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_ShowTitleDialog, null, itemData);
    }
}
