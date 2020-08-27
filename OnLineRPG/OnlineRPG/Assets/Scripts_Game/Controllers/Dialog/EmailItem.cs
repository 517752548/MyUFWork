using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class EmailItem : MonoBehaviour
{
    public TextMeshProUGUI[] _tittleText;
    public GameObject newPoint;
    public GameObject unlock;
    public GameObject locked;
    public GameObject[] reward1;
    public GameObject[] reward2;
    public GameObject[] reward3;

    public Image[] reward1image;
    public Image[] reward2image;
    public Image[] reward3image;
    
    public TextMeshProUGUI[] reward1text;
    public TextMeshProUGUI[] reward2text;
    public TextMeshProUGUI[] reward3text;

    public Text[] timeText;
    
    private Email _email;
    private EmailSliderDialog emailSliderDialog;
    public void SetEmailData(Email _email,EmailSliderDialog emailSliderDialog)
    {
        this._email = _email;
        this.emailSliderDialog = emailSliderDialog;
        for (int i = 0; i < _tittleText.Length; i++)
        {
            _tittleText[i].text = string.Format("{0}", _email.title);
        }

        string timestr = XUtils.GetEmailTimeDesExpers(_email.etime);
        for (int i = 0; i < timeText.Length; i++)
        {
            timeText[i].text = timestr;
        }
        SetStatus();

        SetItems();
    }

    public void Refresh()
    {
        SetStatus();
    }
    private void SetStatus()
    {
        //未读
        if (_email.status == 1)
        {
            newPoint.SetActive(true);
            unlock.SetActive(true);
            locked.SetActive(false);
        }

        if (_email.status == 2)
        {
            if (_email.enclosure == null || _email.enclosure.Count == 0)
            {
                newPoint.SetActive(false);
                unlock.SetActive(false);
                locked.SetActive(true);
            }
            else
            {
                newPoint.SetActive(false);
                unlock.SetActive(true);
                locked.SetActive(false);  
            }
            
        }

        if (_email.status == 3)
        {
            newPoint.SetActive(false);
            unlock.SetActive(false);
            locked.SetActive(true);
        }
    }

    private bool canclick = true;
    public void ClickEmail()
    {
        if (canclick == false)
        {
            return;
        }
        
        
        if (_email.status == 1)
        {//未读变已读
            Debug.LogError("未读");
            canclick = false;
            emailSliderDialog.ChangeEmailStatus(_email.group,2,_email.emailId,ChangeBack);
        }else if (_email.status == 2)
        {//已读
            Debug.LogError("已读");
            canclick = false;
            TimersManager.SetTimer(0.5f, () => { canclick = true; });
            UIManager.OpenUIAsync(ViewConst.prefab_EmailGiftDialog,OpenType.Stack,null,_email,this);
        }else if (_email.status == 3)
        {//已领取
            UIManager.OpenUIAsync(ViewConst.prefab_EmailGiftDialog,OpenType.Stack,null,_email,this);
        }else if (_email.status == 4)
        {//已删除
            UIManager.OpenUIAsync(ViewConst.prefab_EmailGiftDialog,OpenType.Stack,null,_email,this);
        }
        
    }

    private void ChangeBack(bool ok)
    {
        canclick = true;
        Debug.LogError("back" + ok);
        if (ok)
        {
            this._email.status = 2;
            SetStatus();
            UIManager.OpenUIAsync(ViewConst.prefab_EmailGiftDialog,OpenType.Stack,null,_email,this);
        }
        else
        {
            UIManager.ShowMessage("No internet connection");
        }
        
    }
    
    private void SetItems()
    {
            for (int i = 0; i < reward1.Length; i++)
            {
                reward1[i].SetActive(_email.enclosure.Count >= 1);
            }
            for (int i = 0; i < reward2.Length; i++)
            {
                reward2[i].SetActive(_email.enclosure.Count >= 2);
            }
            for (int i = 0; i < reward3.Length; i++)
            {
                reward3[i].SetActive(_email.enclosure.Count >= 3);
            }

            if (_email.enclosure.Count >= 1)
            {
               BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(_email.enclosure[0].itemId.ToString());
               LoadItemReward(data,_email.enclosure[0].number,reward1image,reward1text);
            }
            if (_email.enclosure.Count >= 2)
            {
                BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(_email.enclosure[1].itemId.ToString());
                LoadItemReward(data,_email.enclosure[1].number,reward2image,reward2text);
            }
            if (_email.enclosure.Count >= 3)
            {
                BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(_email.enclosure[2].itemId.ToString());
                LoadItemReward(data,_email.enclosure[2].number,reward3image,reward3text);
            }
    }

    private async void LoadItemReward(BagItems_Data data,int number,Image[] images,TextMeshProUGUI[] text)
    {
        if (data == null)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = "0";
            }
            return;
        }
       Sprite image = await Addressables.LoadAssetAsync<Sprite>(data.Sprite + ".png").Task;
       images[0].sprite = image;
       Sprite gimage = await Addressables.LoadAssetAsync<Sprite>(data.Gsprite + ".png").Task;
       images[1].sprite = gimage;

       for (int i = 0; i < text.Length; i++)
       {
           text[i].text = String.Format("{0}",number);
       }
    }
}
