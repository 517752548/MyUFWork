using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EmailSliderDialog : UIWindowBase
{

    public Transform emailContent;
    public GameObject loading;
    public GameObject noMessage;
    //public GameObject calmall;
    //public GameObject deleteall;
    private Dictionary<string,EmailItem> emailItem = new Dictionary<string, EmailItem>();
    private GameObject emailItemGameObject;
    public override void OnOpen()
    {
        base.OnOpen();
        GameAnalyze.SettingReport("Home","Email","1");
        LoadItem();
    }

    private async void LoadItem()
    {
        emailItemGameObject = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_EmailItem).Task;
        SetEmails();
    }

    private void SetEmails()
    {
        EmailList emailList =  AppEngine.SSystemManager.GetSystem<EmailSystem>().GetEmails();
        if (emailList == null)
        {
            DeleteAllEmail();
            noMessage.SetActive(true);
            //calmall.SetActive(false);
            //deleteall.SetActive(false);
        }
        else
        {
            GameObject item = null;
            List<Email> emails = emailList.GetAllEmails();
            if (emails.Count == 0)
            {
                noMessage.SetActive(true);
                //calmall.SetActive(false);
                //deleteall.SetActive(false);
            }
            else
            {
                noMessage.SetActive(false);
                //calmall.SetActive(true);
                //deleteall.SetActive(true);
            }
            for (int i = 0; i < emails.Count; i++)
            {
                item = Instantiate(emailItemGameObject, emailContent, false);
                EmailItem _item = item.GetComponent<EmailItem>();
                _item.SetEmailData(emails[i],this);
                emailItem.Add(emails[i].emailId,_item);
            }
        }
    }

    public void ChangeEmailStatus(int group,int status,string emailid,Action<bool> callback)
    {
        loading.SetActive(true);
        AppEngine.SSystemManager.GetSystem<EmailSystem>().ChangeEmailStatus(group,status,emailid, (ok)=>
        {
            loading.SetActive(false);
            callback?.Invoke(ok);
        });
    }
    
    public void ClearEmails(List<Email> needDelete)
    {

        foreach (string emailItemKey in emailItem.Keys)
        {
            if (needDelete.Find(x=>x.emailId == emailItemKey) != null)
            {
                Destroy(emailItem[emailItemKey].gameObject);
            }
        }
        //emailItem.Clear();
        //deleteall.SetActive(false);
        //calmall.SetActive(false);
        
        if (emailContent.childCount == 0)
        {
            AppEngine.SSystemManager.GetSystem<EmailSystem>().DissablePoint(); 
            noMessage.SetActive(true);
        }
        
        AppEngine.SSystemManager.GetSystem<EmailSystem>().ClearEmails(needDelete);
    }

    private void DeleteAllEmail()
    {
        foreach (string emailItemKey in emailItem.Keys)
        {
            Destroy(emailItem[emailItemKey].gameObject);
        }
        AppEngine.SSystemManager.GetSystem<EmailSystem>().DissablePoint();
    }

    private void RefreshUI()
    {
        foreach (string itemKey in emailItem.Keys)
        {
            emailItem[itemKey].Refresh();
        }
    }
    public void ClamAll()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        Debug.LogError("calmall");
       List<Email> emails = AppEngine.SSystemManager.GetSystem<EmailSystem>().GetCanClamEmail();
       if (emails.Count > 0)
       {
           loading.SetActive(true);

           ClamAllClass calmallclass =  new ClamAllClass();
           calmallclass.CalmAll(emails, (data) =>
           {
               Debug.LogError("ok");
               RefreshUI();
               loading.SetActive(false);
               AppEngine.SSystemManager.GetSystem<EmailSystem>().CheckRedPoint();
               UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog,OpenType.Stack,null,data);
           });
       }
       else
       {
           UIManager.ShowMessage(" No claimable rewards");
          
       }
    }

    private bool deleteall = true;
    public void DeleteAll()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        List<Email> emails = AppEngine.SSystemManager.GetSystem<EmailSystem>().GetEmails().GetAllEmails();
        List<Email> needDelete = new List<Email>();
        for (int i = 0; i < emails.Count; i++)
        {
            if ((emails[i].status == 2 && emails[i].enclosure.Count == 0)   || emails[i].status == 3)
            {
                needDelete.Add(emails[i]); 
            }
        }

        if (needDelete.Count == 0)
        {
            return;
        }
        
        if (deleteall == false)
        {
            return;
        }

        deleteall = false;
        
        TimersManager.SetTimer(0.5f, () => { deleteall = true; });
        ConstDelegate.PlayerSelect select = DeleteAll;
        UIManager.OpenUIAsync(ViewConst.prefab_EmailDeleteMessageDialog,OpenType.Stack,null,select);
    }

    private void DeleteAll(bool ok)
    {
        if (ok)
        {
            List<Email> emails = AppEngine.SSystemManager.GetSystem<EmailSystem>().GetEmails().GetAllEmails();
            List<Email> needDelete = new List<Email>();
            for (int i = 0; i < emails.Count; i++)
            {
                if ((emails[i].status == 2 && emails[i].enclosure.Count == 0)   || emails[i].status == 3)
                {
                    needDelete.Add(emails[i]); 
                }
            }
            if (needDelete.Count > 0)
            {
                loading.SetActive(true);

                DeleteAllClass calmallclass =  new DeleteAllClass();
                calmallclass.DeleteAll(needDelete, () =>
                {
                    ClearEmails(needDelete);
                    loading.SetActive(false);
                    UIManager.ShowMessage("All read messages deleted successfully");
                });
            }
            else
            {
                UIManager.ShowMessage("All read messages deleted successfully");
            }
        }
    }
}

public class ClamAllClass
{
    private int max;
    private int current;
    List<Email> okemail = new List<Email>();
    private CommonRewardData _commonRewardData;
    public Action<CommonRewardData> callback;

    public ClamAllClass()
    {
        _commonRewardData = new CommonRewardData();
        _commonRewardData.Tittle = "Email Rewards";
        _commonRewardData.boxType = RewardBoxType.None;
        _commonRewardData.RewardSource = RewardSource.email;
    }
    private void Request(Email email)
    {
        AppEngine.SSystemManager.GetSystem<EmailSystem>().ChangeEmailStatus(email.group, 3, email.emailId, (ok) =>
        {
            current++;
            if (ok)
            {
                email.status = 3;
                okemail.Add(email);
                for (int k = 0; k < email.enclosure.Count; k++)
                {
                    if (email.enclosure[k].itemId == (int) BatItem.Coin)
                    {
                        _commonRewardData.coin += email.enclosure[k].number;
                    }
                    else if (email.enclosure[k].itemId == (int) BatItem.Hint1)
                    {
                        _commonRewardData.hint1 += email.enclosure[k].number;
                    }
                    else if (email.enclosure[k].itemId == (int) BatItem.Hint2)
                    {
                        _commonRewardData.hint2 += email.enclosure[k].number;
                    }
                    else if (email.enclosure[k].itemId == (int) BatItem.Hint3)
                    {
                        _commonRewardData.hint3 += email.enclosure[k].number;
                    }
                    else if (email.enclosure[k].itemId == (int) BatItem.Hint4)
                    {
                        _commonRewardData.hint4 += email.enclosure[k].number;
                    }
                }
            }
            if (current == max)
            {
                callback.Invoke(_commonRewardData);
            }
        });
        
        
    }

    public void CalmAll(List<Email> emails, Action<CommonRewardData> callback)
    {
        this.callback = callback;
        if (emails.Count > 0)
        {
            max = emails.Count;
            for (int i = 0; i < emails.Count; i++)
            {
                Request(emails[i]);
            }
        }
    }
}

public class DeleteAllClass
{
    private int max;
    private int current;
    List<Email> okemail = new List<Email>();
    private CommonRewardData _commonRewardData;
    public Action callback;

    public DeleteAllClass()
    {

    }
    private void Request(Email email)
    {
        AppEngine.SSystemManager.GetSystem<EmailSystem>().ChangeEmailStatus(email.group, 4, email.emailId, (ok) =>
        {
            current++;
            if (ok)
            {
                email.status = 4;
                okemail.Add(email);
            }
            if (current == max)
            {
                callback.Invoke();
            }
        });
        
        
    }

    public void DeleteAll(List<Email> emails, Action callback)
    {
        this.callback = callback;
        max = emails.Count;
        if (emails.Count > 0)
        {

            for (int i = 0; i < emails.Count; i++)
            {
                Request(emails[i]);
            }
        }
    }
}