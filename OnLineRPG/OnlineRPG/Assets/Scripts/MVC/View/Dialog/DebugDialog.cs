using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using BetaFramework;

public class DebugDialog : UIWindowBase
{
    public Button CloseButton;
    public Button UnlockLevelBtn;
    public Button AddCurrencyBtn;
    public Button SwitchGroupABBtn;

    public InputField TextCurrency;
    public InputField TextUnlockLevel;

    public InputField hint1;
    public InputField hint2;
    public InputField hint3;

    public InputField petId;
    public InputField petNumber;

    public Text TextKey;
    public Text TextValue;
    public GameObject LineObject;

    public Transform ContentTrans;
    public Toggle m_purchaseSandboxDispatchEventToggle;

    private Dictionary<string, string> m_Content;
    public Text ShowAnswerText;

    public override void OnOpen()
    {
        base.OnOpen();

        m_purchaseSandboxDispatchEventToggle = GameObject.Find("PurchaseSandboxDispatchEvent/Toggle").GetComponent<Toggle>();

        CloseButton.onClick.AddListener(Close);
        UnlockLevelBtn.onClick.AddListener(OnUnlockLevelBtnClick);
        AddCurrencyBtn.onClick.AddListener(OnAddCurrencyBtnClick);

        m_Content = new Dictionary<string, string>();

        AddToDictionary();
        ShowDictionary();
        Debug.Log("baichen - idfa:" + PlatformUtil.GetDeviceId());
        ShowAnswerText.text = "显示答案:" + GameSetting.ShowText;

        m_purchaseSandboxDispatchEventToggle.isOn = GameSetting.IsAllowDebugSandBoxDispatchEvent;
        m_purchaseSandboxDispatchEventToggle.onValueChanged.AddListener(PurchaseSandboxDispatchEventToggleValueChange);
        Debug.Log("baichen - idfa:" + PlatformUtil.GetDeviceId());

        SwitchGroupABBtn.onClick.AddListener(OnSwitchBtnClick);
        
    }

    private void OnAddCurrencyBtnClick()
    {
        if (IsInt(TextCurrency.text))
        {
            int currency = Convert.ToInt32(TextCurrency.text);
            AppEngine.SyncManager.Data.Coin.Value += currency;
            Close();
        }
    }

    public void AddHint()
    {
        int hint1c = 0;
        int hint2c = 0;
        int hint3c = 0;
        int.TryParse(hint1.text, out hint1c);
        int.TryParse(hint2.text, out hint2c);
        int.TryParse(hint3.text, out hint3c);
//        DataManager.SkillData.AddMultiHintCount(hint3c);
//        DataManager.SkillData.AddSpecificHintCount(hint2c);
//        DataManager.SkillData.AddNormalHintCount(hint3c);
        CommandBinder.DispatchBinding(GameEvent.AppRestart);
    }

    public void UnlockPet()
    {

    }

    private void OnUnlockLevelBtnClick()
    {

        if (!IsInt(TextUnlockLevel.text))
        {
            return;
        }
        int unlocklevel = Convert.ToInt32(TextUnlockLevel.text);
        AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value = unlocklevel < 1?1:unlocklevel;

        CommandBinder.DispatchBinding(GameEvent.AppRestart);
    }

    public void GetRandomPet()
    {
        
        //UIManager.ShowMessage("所有宠物都获得一个碎片"  );
    }
    
    private void AddToDictionary()
    {
        m_Content.Add("用户id：", DataManager.DeviceData.DeviceId);
        m_Content.Add("当前分层：", DataManager.BusinessData.PlayerTag);
        m_Content.Add("广告数据：", JsonConvert.SerializeObject(DataManager.AdsData, Formatting.Indented));
        m_Content.Add("礼包数据：", JsonConvert.SerializeObject(DataManager.GiftData, Formatting.Indented));
        m_Content.Add("充值内容：", JsonConvert.SerializeObject(DataManager.ShopData.PurchasedItems, Formatting.Indented));
        m_Content.Add("Normal窗口个数：", UIManager.GetNormalUICount().ToString());
        m_Content.Add("DDL配置：", Record.GetString(PrefKeys.DDL_OnlineConfig) + "-" + JsonConvert.SerializeObject(HandleDdlMsg.localdata));

        if (HandleDdlMsg.localdata != null)
        {
            m_Content.Add("DDL配置turn：", HandleDdlMsg.localdata.ShowInfo());
            m_Content.Add("DDL配置map：", Record.GetString(PrefKeys.DDL_LevelMap));
        }
    }

    private void ShowDictionary()
    {
        foreach (string key in m_Content.Keys)
        {
            Text keyObj = Instantiate<Text>(TextKey, ContentTrans);
            Text valueObj = Instantiate<Text>(TextValue, ContentTrans);
            Instantiate<GameObject>(LineObject, ContentTrans);

            keyObj.text = key;
            valueObj.text = m_Content[key];
        }

        TextKey.gameObject.SetActive(false);
        TextValue.gameObject.SetActive(false);
        LineObject.gameObject.SetActive(false);
    }

    public override void OnClose()
    {
        base.OnClose();

        CloseButton.onClick.RemoveListener(Close);
        UnlockLevelBtn.onClick.RemoveListener(OnUnlockLevelBtnClick);
        AddCurrencyBtn.onClick.RemoveListener(OnAddCurrencyBtnClick);
    }

    public bool IsInt(string value)
    {
        Regex r = new Regex(@"^[+-]?\d*(,\d{3})*(\.\d+)?$");
        bool isMatch = r.IsMatch(value);
        return isMatch;
    }

    public void ShowAnswer()
    {
        GameSetting.ShowText = !GameSetting.ShowText;
        ShowAnswerText.text = "显示答案:" + GameSetting.ShowText;
    }

    public void PurchaseSandboxDispatchEventToggleValueChange(bool on)
    {
        Debug.LogError("on " + on);

        GameSetting.IsAllowDebugSandBoxDispatchEvent = on;
    }

    private void OnSwitchBtnClick()
    {

        CommandBinder.DispatchBinding(GameEvent.AppRestart);
    }
}