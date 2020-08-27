using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class EmailGiftDialog : UIWindowBase
{
    public Text tittle;
    public Text des;
    public Text name;
    public Text time;
    public GameObject[] rewardItems;

    public GameObject[] lockobj;
    public GameObject[] unlockobj;
    
    public GameObject[] reward1;
    public GameObject[] reward2;
    public GameObject[] reward3;

    public Image[] reward1image;
    public Image[] reward2image;
    public Image[] reward3image;
    
    public TextMeshProUGUI[] reward1text;
    public TextMeshProUGUI[] reward2text;
    public TextMeshProUGUI[] reward3text;
    public GameObject DownLoad;
    public GameObject FanPage;
    public GameObject GiftObj;

    public TextMeshProUGUI[] buttonText;
    private Email _email;
    private bool calm;
    private EmailItem emailItem;
    public override void OnOpen()
    {
        base.OnOpen();
        _email = objs[0] as Email;
        emailItem = objs[1] as EmailItem;
        SetUI();
        SetButtonStatus();
        AppEngine.SSystemManager.GetSystem<EmailSystem>().CheckRedPoint();
    }

    private void SetUI()
    {
        tittle.text = _email.title;
        des.text = _email.bodys;
        name.text = string.Format("Sender:{0}", _email.sender);
        time.text = XUtils.GetEmailTimeDesAgo(_email.stime);
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

        if (_email.status == 1 || _email.status == 2)
        {
            for (int i = 0; i < lockobj.Length; i++)
            {
                unlockobj[i].SetActive(true);
            }
            for (int i = 0; i < lockobj.Length; i++)
            {
                lockobj[i].SetActive(false);
            }
        }
        if (_email.status == 3 || _email.status == 4)
        {
            Debug.LogError("yilingqu ");
            for (int i = 0; i < lockobj.Length; i++)
            {
                unlockobj[i].SetActive(false);
            }
            for (int i = 0; i < lockobj.Length; i++)
            {
                lockobj[i].SetActive(true);
            }
        }

        if (_email.enclosure.Count == 0)
        {
            GiftObj.SetActive(false);
        }
        if (_email.enclosure.Count >= 1)
        {
            BagItems_Data _data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(_email.enclosure[0].itemId.ToString());
            LoadItemReward(_data,_email.enclosure[0].number,reward1image,reward1text);
        }
        if (_email.enclosure.Count >= 2)
        {
            BagItems_Data _data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(_email.enclosure[1].itemId.ToString());
            LoadItemReward(_data,_email.enclosure[1].number,reward2image,reward2text);
        }
        if (_email.enclosure.Count >= 3)
        {
            BagItems_Data _data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(_email.enclosure[2].itemId.ToString());
            LoadItemReward(_data,_email.enclosure[2].number,reward3image,reward3text);
        }

        if (_email.showDownLoad == 1)
        {
            DownLoad.SetActive(true);
        }

        if (_email.showFanPage == 1)
        {
            FanPage.SetActive(true);
        }
    }

    private void SetButtonStatus()
    {
        Debug.LogError(_email.status);
        if ((_email.status == 1 || _email.status == 2) && _email.enclosure.Count > 0)
        {
            for (int i = 0; i < buttonText.Length; i++)
            {
                buttonText[i].text = "CLAIM";
            }

            calm = true;
        }
        else
        {
            for (int i = 0; i < buttonText.Length; i++)
            {
                buttonText[i].text = "OK";
            }

            calm = false;
        }
        // if (_email.status == 3 || _email.status == 4)
        // {
        //     for (int i = 0; i < buttonText.Length; i++)
        //     {
        //         buttonText[i].text = "OK";
        //     }
        //
        //     calm = false;
        // }
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

    private bool canclick = true;
    public void ClickButton()
    {
        if (canclick == false)
        {
            return;
        }

        canclick = false;
        TimersManager.SetTimer(0.8f, () =>
        {
            canclick = true;
        });
        if (calm)
        {
            UIManager.ShowLoading();
            AppEngine.SSystemManager.GetSystem<EmailSystem>().ChangeEmailStatus(_email.group,3,_email.emailId, (ok) =>
            {
                UIManager.CloseLoading();
                //canclick = true;
                if (ok)
                {
                    _email.status = 3;
                    CommonRewardData _commonRewardData = new CommonRewardData();
                    _commonRewardData.Tittle = _email.title;
                    _commonRewardData.boxType = RewardBoxType.None;
                    _commonRewardData.RewardSource = RewardSource.email;
                    for (int i = 0; i < _email.enclosure.Count; i++)
                    {
                        if (_email.enclosure[i].itemId == (int)BatItem.Coin)
                        {
                            _commonRewardData.coin = _email.enclosure[i].number;
                        }else if (_email.enclosure[i].itemId == (int)BatItem.Hint1)
                        {
                            _commonRewardData.hint1 = _email.enclosure[i].number;
                        }else if (_email.enclosure[i].itemId == (int)BatItem.Hint2)
                        {
                            _commonRewardData.hint2 = _email.enclosure[i].number;
                        }else if (_email.enclosure[i].itemId == (int)BatItem.Hint3)
                        {
                            _commonRewardData.hint3 = _email.enclosure[i].number;
                        }else if (_email.enclosure[i].itemId == (int)BatItem.Hint4)
                        {
                            _commonRewardData.hint4 = _email.enclosure[i].number;
                        }
                    }
                    emailItem.Refresh();
                    UIManager.CloseUIWindow(this); 
                    UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog,OpenType.Stack,null,_commonRewardData);
                    AppEngine.SSystemManager.GetSystem<EmailSystem>().CheckRedPoint();
                }
                else
                {
                    canclick = true;
                    UIManager.ShowMessage("No internet connection");
                }
                
            });
           
        }
        else
        {
            UIManager.CloseUIWindow(this); 
        }
        
    }

    public void ClickDownLoad()
    {
#if UNITY_ANDROID
        PlatformAndroid.OpenWithGooglePlay();
        return;
#endif
        Application.OpenURL(Const.APPSTORE_URL);
    }

    public void ClickFanPage()
    {
        Application.OpenURL(Const.FanPage_URL);
    }


}
