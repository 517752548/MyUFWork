using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using Data.Request;
using EventUtil;
using Newtonsoft.Json;
using UnityEngine;

public class EmailSystem : ISystem
{
    private EmailList emailList;
    private GameObject redpoint;
    public Action<bool> newStateChangeAction;
    public override void InitSystem()
    {
        EventDispatcher.AddEventListener(GlobalEvents.LoginStatusRefresh,LoadEmailInfo);
        base.InitSystem();
    }

    public void SetEmailRedPoint(GameObject redpoint)
    {
        this.redpoint = redpoint;
        SetEmails(this.emailList);
    }

    public bool HasNewEmail() {
        return emailList != null && emailList.GetAllEmails().Find(x=>x.status == 1) != null;
    }

    public void CheckRedPoint()
    {
       
        if (emailList == null)
        {
            redpoint.SetActive(false);
            return;
        }
        List<Email> emails =emailList.GetAllEmails();
        if (emails.Find(x=>x.status == 1) != null)
        {
            redpoint.SetActive(true);
            newStateChangeAction?.Invoke(true);
        }
        else
        {
            redpoint.SetActive(false);
            newStateChangeAction?.Invoke(false);
        }
    }
    public void ClearEmails(List<Email> needDelete)
    {
        emailList.RemoveEmails(needDelete);
    }
    public void DissablePoint()
    {
        redpoint.SetActive(false);
    }
    
    public EmailList GetEmails()
    {
        return emailList;
    }

    /// <summary>
    /// 获取所有可以被领取的邮件
    /// </summary>
    /// <returns></returns>
    public List<Email> GetCanClamEmail()
    {
        List<Email> emails = emailList.GetAllEmails();
        
       return emails.FindAll(x => x.enclosure.Count > 0 && (x.status == 1 || x.status == 2));
    }
    private void SetEmails(EmailList emailList)
    {
        this.emailList = emailList;
        if (this.emailList != null && this.emailList.GetAllEmails().Count > 0 && this.emailList.GetAllEmails().Find(x=>x.status == 1) != null)
        {
            if(redpoint)
            redpoint.SetActive(true);
        }
        else
        {
            if(redpoint)
            redpoint.SetActive(false);
        }
    }
    
    public override void Shut()
    {
        base.Shut();
        EventDispatcher.RemoveEventListener(GlobalEvents.LoginStatusRefresh,LoadEmailInfo);
    }

    /// <summary>
    /// 获取用户邮件信息
    /// </summary>
    private void LoadEmailInfo()
    {
        RequestEmailInfo();
    }


    public void RequestEmailInfo()
    {
        if (!AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().fbOnline.Value && !AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().PlayerLogin)
        {
            Debug.LogError("not   login");
            return;
        }
        RequestEmail request = new RequestEmail(ServerCode.GetEmail);
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                SetEmails(null);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                EmailDataBack backdata = JsonConvert.DeserializeObject<EmailDataBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    SetEmails(null);
                }
                else
                {
                    if(backdata.data != null)
                        SetEmails(backdata.data);
                }
                
            }
        }, json,AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }

    public void ChangeEmailStatus(int group,int status,string emailid,Action<bool> callback)
    {
        ChangeEmailStatus request = new ChangeEmailStatus(ServerCode.ChangeEmail,group,status,emailid);
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback?.Invoke(false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                ChangeEmailBack backdata = JsonConvert.DeserializeObject<ChangeEmailBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    callback?.Invoke(false);
                }
                else
                {
                    if (backdata.data == "ok")
                    {
                        callback?.Invoke(true); 
                    }else if (backdata.data == "receive")
                    {
                        callback?.Invoke(false); 
                    }
                    else
                    {
                        callback?.Invoke(false);
                    }
                   
                }
                
            }
        }, json,AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
}
public class RequestEmail:BaseRequestParam
{
    public string platform;
    public string channel;
    public int ver;
    public RequestEmail(ServerCode mid)
    {
        this.mId = (int)mid;
        ver = XUtils.GetEmailVersion();
#if UNITY_IOS
        platform = "ios";
#else
        platform = "android";
#endif
        if (AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().fbOnline.Value)
        {
            channel = "fb";
        }else if (AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().PlayerLogin)
        {
            channel = "device";
        }
    }
}

public class ChangeEmailStatus:BaseRequestParam
{
    public int group;
    public int status;
    public string emailId;
    public ChangeEmailStatus(ServerCode mid,int Group,int Status,string emailId)
    {
        this.mId = (int)mid;
        this.group = Group;
        this.status = Status;
        this.emailId = emailId;
    }
}
public class ChangeEmailBack:BaseRequestParam
{
    public int group;
    public int status;
    public string data;
    public int code;
    public string emailId;
}
public class EmailDataBack : BaseResponseData<EmailList>
{
    
}
public class EmailList
{
    public List<Email> publics;
    public List<Email> my;

    public List<Email> GetAllEmails()
    {
        List<Email> emails = new List<Email>();
        if(my != null)
        emails.AddRange(my);
        if(publics != null)
        emails.AddRange(publics);
        if (emails.Count > 1)
        {
            emails = emails.OrderByDescending(x => x.stime).ToList();
        }
        return emails;
    }

    public void RemoveEmails(List<Email> needdelete)
    {
        for (int i = 0; i < needdelete.Count; i++)
        {
            if (publics != null)
            {
                Email email = publics.Find(x => x.emailId == needdelete[i].emailId);
                if (email != null)
                {
                    publics.Remove(email);
                }
            }

            if (my != null)
            {
                Email email2 = my.Find(x => x.emailId == needdelete[i].emailId);
                if (email2 != null)
                {
                    my.Remove(email2);
                } 
            }
            
        }
    }
}

public class Email
{
    public string emailId;
    public int types;
    public long stime;
    public long etime;
    public int edate;
    public string title;
    public string bodys;
    public string sender;
    public List<EmailInfo> enclosure;
    //1 未读 2 已读 3 领取 4 删除
    public int status;
    public int group;
    public int showDownLoad;
    public int showFanPage;
}

public class EmailInfo
{
    public int itemId;
    public int number;
}