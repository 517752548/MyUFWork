﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Bag;
using BetaFramework;
using Data.Request;
 using Newtonsoft.Json;
using SimpleJson;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSyncManager : IModule
{
    public SyncDataAccesser Data { get; private set; }

    private float time = 0f;
    private bool isNetEnable;
    private bool isDuringSync = false;

    public bool IsDuringSync => isDuringSync;
    
    public override void Init()
    {
        Data = new SyncDataAccesser();
        Data.Init();

        isNetEnable = IsNetReachable();
        base.Init();
    }

    private bool IsNetReachable()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }

    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);
        time += deltaTime;
        if (time > 1)
        {
            time = 0;
            bool isNet = IsNetReachable();
            //LoggerHelper.Error("数据同步 当前网络 " + isNet + " | " + isNetEnable);
            if (isNetEnable != isNet && isNet && Data.IsChanged)
            {
                //LoggerHelper.Error("数据同步 网络恢复重新上传");
                DoSync(null, false, true);
            }

            isNetEnable = isNet;
        }
    }
    
    
    public override void Shut()
    {
        base.Shut();
    }

    public override void Pause(bool pause)
    {
        base.Pause(pause);
    }

    public void OnUserChanged(Action back = null)
    {
        Data.Reset();
        //Data.ClassicLevel.Value = 1;
        //Data.ClassicLevel.ResetLastValue();
        Record.DeleteKey(PrefKeys.ClassicLevelProgress);
        Record.DeleteKey(PrefKeys.DailyLevelProgress);
        Record.DeleteKey(PrefKeys.OneWordLevelProgress);
        DataManager.ProcessData.NotShowWorldUnlock = true;
        DoSync((result, coverLocal) =>
        {
            Debug.LogError(result + "-" + coverLocal);
            if (result && !coverLocal)
            {
                ChangeScene();
            }
            TimersManager.SetTimer(0.5f, () =>
            {
                back?.Invoke();
            });
            
        }, true, true);
    }
   
    public void DoSync(Action<bool, bool> resultCallback, bool uploadAll = false, bool forceExecute = false)
    {
#if UNITY_EDITOR
        //return;
#endif
        if (isDuringSync && !forceExecute)
            return;
        isDuringSync = true;
        Data._ignoreChange = uploadAll;
        string json = Data.GetDataJson();
        Debug.Log("数据同步参数: " + json);
        WebRequestPostUtility.Instance.PostJson(Const.AsyncServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                LoggerHelper.Error("数据同步请求失败 " + back.error);
                resultCallback?.Invoke(false, false);
            }
            else
            {
                Debug.Log("数据同步结果: " + back.downloadHandler.text);
                SyncResponse response = JsonConvert.DeserializeObject<SyncResponse>(back.downloadHandler.text);
                if (response.code != 200)
                {
                    LoggerHelper.Error("数据同步请求失败 code=" + response.code);
                    resultCallback?.Invoke(false, false);
                }
                else
                {
                    Data.UpdateByWeb(response.data);
                    resultCallback?.Invoke(true, response.data.syncData != null);
                    if (response.data.syncData != null)
                    {
                        if (Data.ClassicLevel.Value == 0)
                        {
                            Data.ClassicLevel.Value = 1;
                            Data.ClassicLevel.ResetLastValue();
                        }
                        Record.DeleteKey(PrefKeys.ClassicLevelProgress);
                        Record.DeleteKey(PrefKeys.DailyLevelProgress);
                        Record.DeleteKey(PrefKeys.OneWordLevelProgress);
                        DataManager.ProcessData.NotShowWorldUnlock = true;
                        ChangeScene();
                    }
                }
            }
            isDuringSync = false;
        }, json, AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == WordScene.Main)
        {
            UIManager.CloseAll();
            AppEngine.SyncManager.Data.fansNumber.ResetLastValue();
            SceneManager.LoadSceneAsync(WordScene.Load, LoadSceneMode.Single);
        }
        else
        {
            DataManager.ProcessData.cancelFirstGoToGameScene = true;
        }
        
        // if (SceneManager.GetActiveScene().name == WordScene.Main)
        // {
        //     LoggerHelper.Error("数据同步刷新UI");
        //     UIManager.CloseAll();
        //     UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
        //     {
        //         SceneManager.LoadScene(WordScene.Main);
        //         MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
        //         {
        //             Timer.Schedule(AppThreadController.instance, 0.2f, () =>
        //             {
        //                 UIManager.CloseUIWindow(
        //                     UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
        //                 UIManager.CloseAll();
        //             });
        //         });
        //                         
        //     });
        //     //SceneManager.LoadSceneAsync($"{WordScene.MainScene}", LoadSceneMode.Single);
        // }
        // else
        // {
        //     DataManager.ProcessData.cancelFirstGoToGameScene = true;
        // }
    }
}

public class SyncDataAccesser
{
    public RecordExtra.IntPrefData DataVersion { get; private set; }
    public RecordExtra.IntPrefData ModuleVersion { get; private set; }
    public StringSyncField UserTag { get; private set; }
    public IntSyncField ClassicLevel { get; private set; }
    public IntSyncField SignTimes { get; private set; }
    public StrDateSyncField LastSignDate { get; private set; }
    public IntSyncField Coin { get; private set; }
    public IntSyncField Hint1 { get; private set; }
    public BoolSyncField Hint1Unlock { get; private set; }
    public IntSyncField Hint2 { get; private set; }
    public BoolSyncField Hint2Unlock { get; private set; }
    public IntSyncField Hint3 { get; private set; }
    public BoolSyncField Hint3Unlock { get; private set; }
    public IntSyncField Hint4 { get; private set; }
    public BoolSyncField Hint4Unlock { get; private set; }
    public IntSyncField Bee { get; private set; }
    
    public StringSyncField TodayKey { get; private set; }
    
    public IntSyncField Stars { get; private set; }
    public ObjSyncField<PetData> Pets { get; private set; }
    public ObjSyncField<TitleData> Titles { get; private set; }
    //public ObjSyncField<KnowledgeCardData> KnowledgeCards { get; private set; }
    
    public BoolSyncField ToadyFinished { get; private set; }
    
    public IntSyncField fansNumber { get; private set; }
    
    public StringSyncField lastRateRewardTime { get; private set; }
    
    public StringSyncField MonKey { get; private set; }
    
    public IntSyncField VideoShowTimes { get; private set; }
    
    public BoolSyncField IsRemoveAd { get; private set; }
    
    public StringSyncField OneWordLastCompleteID { get; private set; }
    public StringSyncField OneWordLastCompleteExID { get; private set; }
    public StringSyncField OneWordExLevelStartID { get; private set; }
    public StringSyncField OneWordCurExID { get; private set; }
    
    public BoolSyncField GuideFirstWord { get; private set; }
    public BoolSyncField GuideWelcome { get; private set; }
    public BoolSyncField GuideHint1Unlock { get; private set; }
    public BoolSyncField GuideHint2Unlock { get; private set; }
    public BoolSyncField GuideHint3Unlock { get; private set; }
    public BoolSyncField GuideHint4Unlock { get; private set; }
    public BoolSyncField GuideBlogEnter { get; private set; }
    public BoolSyncField GuideBlogCard { get; private set; }
    public BoolSyncField GuideDailyEnter { get; private set; }
    public BoolSyncField GuideDailyReward { get; private set; }
    public BoolSyncField GuideRateReward { get; private set; }
    public BoolSyncField GuideBeeReward { get; private set; }
    public BoolSyncField GuideBeeUse { get; private set; }
    public BoolSyncField GuideThemeWord { get; private set; }
    
    public ObjCompressSyncField<EliteData> Elitedata { get; private set; }
    public IntSyncField Cup { get; private set; }
    public IntSyncField EliteTicket { get; private set; }
    
    private SyncData _syncData;
    private List<SyncBaseField> allFields;
    public bool _ignoreChange;
    
    public void Init()
    {
        DataVersion = new RecordExtra.IntPrefData("sync_data_version", 0);
        ModuleVersion = new RecordExtra.IntPrefData("sync_module_version", 0);
        if (DataVersion.Value > 0 && ModuleVersion.Value < 1)
        {
            DataVersion.Value = 0;
            ModuleVersion.Value = 1;
        }
        allFields = new List<SyncBaseField>();
        _syncData = new SyncData
        {
            dataVersion = DataVersion.Value, 
            syncData = new PlayerSyncData()
        };
        
        UserTag = InitStringField(x => x.playerTag,"");
        ClassicLevel = InitIntField(x => x.classicLevel, 0, PrefKeys.ClassicGameLevelIndex);
        SignTimes = InitIntField(x => x.signTimes, 0, "player_sign_times");
        LastSignDate = InitStrDateField(x => x.lastSignDate, DateTime.MinValue, "player_last_sign_date");
        
        Bee = InitIntField(x => x.bee, 0);
        Coin = InitIntField(x => x.coin, 0);
        Hint1 = InitIntField(x => x.hint1, 0);
        Hint1Unlock = InitBoolField(x => x.hint1unlock, false);
        Hint2 = InitIntField(x => x.hint2, 0);
        Hint2Unlock = InitBoolField(x => x.hint2unlock, false);
        Hint3 = InitIntField(x => x.hint3, 0);
        Hint3Unlock = InitBoolField(x => x.hint3unlock, false);
        Hint4 = InitIntField(x => x.hint4, 0);
        Hint4Unlock = InitBoolField(x => x.hint4unlock, false);
        TodayKey = InitStringField(x => x.todayKey, "",PrefKeys.DailyDay);
        MonKey = InitStringField(x => x.monKey, "",PrefKeys.DailyMon);
        Pets = InitObjField(x => x.pets, new PetData());
        Titles = InitObjField(x => x.titles, new TitleData());
        
        ToadyFinished = InitBoolField(x => x.toadyFinished, false,PrefKeys.DailyFinished);
        Stars = InitIntField(x => x.stars, 0, PrefKeys.DailyStars);
        
        //KnowledgeCards = InitObjField(x => x.cards, new KnowledgeCardData());

        fansNumber = InitIntField(x => x.fansNumber, 0, "fansNumber");

        IsRemoveAd = InitBoolField(x => x.isRemoveAd, false, PrefKeys.Remove_Ads);
        VideoShowTimes = InitIntField(x => x.videoShowTimes, 0, PrefKeys.RewardVideo_ShowTimes);
        lastRateRewardTime = InitStringField(x => x.lastRateRewardTime, "1970xx", "RateQuestionTime");
        
        GuideFirstWord = InitBoolField(x => x.guideFirstWord, false, "guide_shown_first_word");
        GuideWelcome = InitBoolField(x => x.guideWelcome, false, "guide_shown_welcome");
        GuideHint1Unlock = InitBoolField(x => x.guideHint1Unlock, false, "guide_shown_hint1unlock");
        GuideHint2Unlock = InitBoolField(x => x.guideHint2Unlock, false, "guide_shown_hint2unlock");
        GuideHint3Unlock = InitBoolField(x => x.guideHint3Unlock, false, "guide_shown_hint3unlock");
        GuideHint4Unlock = InitBoolField(x => x.guideHint4Unlock, false, "guide_shown_hint4unlock");
        GuideBlogEnter = InitBoolField(x => x.guideBlogEnter, false, "guide_shown_blog_enter");
        GuideBlogCard = InitBoolField(x => x.guideBlogCard, false, "guide_shown_blog_card");
        GuideDailyEnter = InitBoolField(x => x.guideDailyEnter, false, "guide_shown_daily_enter");
        GuideDailyReward = InitBoolField(x => x.guideDailyReward, false, "guide_shown_daily_reward");
        GuideRateReward = InitBoolField(x => x.guideRateReward, false, "guide_shown_rate_reward");
        GuideBeeReward = InitBoolField(x => x.guideBeeReward, false, "guide_shown_bee_reward");
        GuideBeeUse = InitBoolField(x => x.guideBeeUse, false, "guide_shown_bee_use");
        GuideThemeWord = InitBoolField(x => x.guideThemeWord, false, "guide_shown_theme_word");
        
        OneWordLastCompleteID = InitStringField(x => x.oneWordLastCompleteID, "", "oneword_last_ID");
        OneWordLastCompleteExID = InitStringField(x => x.oneWordLastCompleteExID, "", "oneword_last_ex_id");
        OneWordExLevelStartID = InitStringField(x => x.oneWordExLevelStartID, "", "oneword_ex_start_ID");
        OneWordCurExID = InitStringField(x => x.oneWordCurExID, "", "oneword_ex_level_ID");
        Elitedata = InitCompressObjField(x => x.elidate, new EliteData(), "elidate");
        
        Cup = InitIntField(x => x.cup, -1);
        EliteTicket = InitIntField(x => x.eliteTicket, 0);
        MoveOldData();
    }

    public bool IsChanged
    {
        get
        {
            bool change = false;
            allFields.ForEach(f => { change |= f.IsSyncDataChanged; });
            return change;
        }
    }

    private void MoveOldData()
    {
        var key = typeof(Bag.Coin).FullName;
        if (Record.HasKey(key))
        {
             var d = Record.GetObject<Bag.Coin>(key, null);
             _syncData.syncData.coin = d.Count;
             Record.DeleteKey(key);
             Coin.UpdateSave();
        }
        key = typeof(Bag.Hint1).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.Hint1>(key, null);
            _syncData.syncData.hint1 = oldData.Count;
            _syncData.syncData.hint1unlock = oldData.IsUnlocked;
            Record.DeleteKey(key);
            Hint1.UpdateSave();
            Hint1Unlock.UpdateSave();
        }
        key = typeof(Bag.Hint2).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.Hint2>(key, null);
            _syncData.syncData.hint2 = oldData.Count;
            _syncData.syncData.hint2unlock = oldData.IsUnlocked;
            Record.DeleteKey(key);
            Hint2.UpdateSave();
            Hint2Unlock.UpdateSave();
        }
        key = typeof(Bag.Hint3).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.Hint3>(key, null);
            _syncData.syncData.hint3 = oldData.Count;
            _syncData.syncData.hint3unlock = oldData.IsUnlocked;
            Record.DeleteKey(key);
            Hint3.UpdateSave();
            Hint3Unlock.UpdateSave();
        }
        key = typeof(Bag.Hint4).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.Hint4>(key, null);
            _syncData.syncData.hint4 = oldData.Count;
            _syncData.syncData.hint4unlock = oldData.IsUnlocked;
            Record.DeleteKey(key);
            Hint4.UpdateSave();
            Hint4Unlock.UpdateSave();
        }
        key = typeof(Bag.PetItem).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.PetItem>(key, null);
            _syncData.syncData.pets = new PetData
            {
                currentPetId = oldData.currentPetId, 
                petItems = oldData.petItems, 
                hasNewPet = oldData.hasNewPet
            };
            Record.DeleteKey(key);
            Pets.UpdateSave();
        }
        key = typeof(Bag.KnowledgeCardItem).FullName;
        if (Record.HasKey(key))
        {
            var oldData = Record.GetObject<Bag.KnowledgeCardItem>(key, null);
            //_syncData.syncData.cards = new KnowledgeCardData();
            int level = 1;
            foreach (var c in oldData.LocalKnowledgeCards.Values)
            {
                //_syncData.syncData.cards.allCards.Add(new KnowledgeCard()
                DataManager.PlayerData.KnowledgeCards.Value.allCards.Add(new KnowledgeCard()
                {
                    level = level++,
                    count = c.count,
                    cardID = c.cardID,
                    creatTime = c.creatTime,
                    isNew = c.isNew,
                    isClickHeart = c.isClickHeart,
                    praise = c.Praise_points,
                    needSync = true
                });
            }
            Record.DeleteKey(key);
            //KnowledgeCards.UpdateSave();
            DataManager.PlayerData.KnowledgeCards.ResetLastValue();
            DataManager.PlayerData.KnowledgeCards.Save();
        }

        if (Cup.Value < 0)
        {
            _syncData.syncData.cup = fansNumber.Value;
            Cup.UpdateSave();
        }
    }

    public string GetDataJson()
    {
        _syncData.dataVersion = DataVersion.Value;
        string json = JsonConvert.SerializeObject(new SyncRequest(ServerCode.DataSync, _syncData));
        if (_ignoreChange || _syncData.dataVersion <= 0) 
            return json;
        
        var json_param = SimpleJson.SimpleJson.DeserializeObject<JsonObject>(json);
        json_param.TryGetValue("data", out var data);
        ((JsonObject)data).TryGetValue("syncData", out var syncData);
        var json_syncData = (JsonObject)syncData;
        allFields.ForEach(field =>
        {
            if (!field.IsSyncDataChanged && ClassicLevel != field)
                json_syncData.Remove(field.FieldName);
        });
        // if (KnowledgeCards.IsSyncDataChanged)
        // {
        //     json_syncData.TryGetValue(KnowledgeCards.FieldName, out var cards);
        //     ((JsonObject)cards).TryGetValue("allCards", out var allCards);
        //     var json_allCards = (JsonArray) allCards;
        //     for (int i = json_allCards.Count - 1; i >= 0; i--)
        //     {
        //         ((JsonObject) json_allCards[i]).TryGetValue("needSync", out var newFlag);
        //         if ((bool) newFlag)
        //         {
        //             ((JsonObject) json_allCards[i]).Remove("needSync");
        //         }
        //         else
        //         {
        //             json_allCards.RemoveAt(i);
        //         }
        //     }
        // }
        json = json_param.ToString();
    
        return json;
    }

    public void UpdateByWeb(SyncData data)
    {
        DataVersion.Value = data.dataVersion;
        if (data.syncData == null)
        {
            _syncData.dataVersion = data.dataVersion;
            //KnowledgeCards.Value?.allCards.ForEach(c => c.needSync = false);
            allFields.ForEach(field => field.ResetSyncChangeState());
        }
        else
        {
            _syncData.syncData = data.syncData;
            //KnowledgeCards.Value?.allCards.ForEach(c => c.needSync = false);
            allFields.ForEach(field => field.UpdateSave());
        }
    }

    public void Reset()
    {
        DataVersion.Value = 0;
        //当天版本是1.1.7 五个版本后打开就可以了，有问题是程江的锅
        //allFields.ForEach(f => f.Reset());
    }
    
    private StringSyncField InitStringField(Expression<Func<PlayerSyncData, string>> memberAccess, 
        string defVal, string key=null)
    {
        var f = new StringSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private BoolSyncField InitBoolField(Expression<Func<PlayerSyncData, bool>> memberAccess, 
        bool defVal, string key=null)
    {
        var f = new BoolSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private IntSyncField InitIntField(Expression<Func<PlayerSyncData, int>> memberAccess, 
        int defVal, string key=null)
    {
        var f = new IntSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private FloatSyncField InitFloatField(Expression<Func<PlayerSyncData, float>> memberAccess, 
        float defVal, string key=null)
    {
        var f = new FloatSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private ObjSyncField<T> InitObjField<T>(Expression<Func<PlayerSyncData, object>> memberAccess, 
        T defVal, string key=null) where T : BaseSyncHandData, new()
    {
        var f = new ObjSyncField<T>(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    private ObjCompressSyncField<T> InitCompressObjField<T>(Expression<Func<PlayerSyncData, object>> memberAccess, 
        T defVal, string key=null) where T : BaseSyncHandData, new()
    {
        var f = new ObjCompressSyncField<T>(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    private StrDateSyncField InitStrDateField(Expression<Func<PlayerSyncData, string>> memberAccess, 
        DateTime defVal, string key=null)
    {
        var f = new StrDateSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private DateSyncField InitDateField(Expression<Func<PlayerSyncData, DateTime>> memberAccess, 
        DateTime defVal, string key=null)
    {
        var f = new DateSyncField(ref _syncData, GetFieldName(memberAccess), key, defVal);
        f.Init();
        allFields.Add(f);
        return f;
    }
    
    private static string GetFieldName<T1, T2>(Expression<Func<T1, T2>> memberAccess)
    {
        return ((MemberExpression)memberAccess.Body).Member.Name;
    }

}

public class SyncBaseField
{
    public bool IsSyncDataChanged { get; protected set; }
    
    public virtual void UpdateSave()
    {
        IsSyncDataChanged = false;
    }
    
    public virtual void UpdateRead()
    {
    }

    public virtual void ResetSyncChangeState()
    {
        IsSyncDataChanged = false;
    }

    public virtual void Reset()
    {
        
    }

    public virtual string FieldName { get; }

    public virtual object GetValObj()
    {
        return null;
    }
}

public abstract class SyncField<T> : SyncBaseField
{
    public T Delta { get; protected set; }
    protected T lastData;
    private readonly SyncData _syncData;
    private readonly string _key, _name;
    private readonly FieldInfo _syncDataField;
    private readonly T _defValue;
    private event Action changeListener;

    protected SyncField(ref SyncData syncData, string name, string key, T defVal)
    {
        _syncData = syncData;
        this._name = name;
        this._key = string.IsNullOrEmpty(key) ? "sync_data_" + name : key;
        _defValue = defVal;
        _syncDataField = syncData.syncData.GetType().GetField(name);
        IsSyncDataChanged = RecordChangeState;
        //Delta = default(T);
    }

    public virtual void Init()
    {
        _syncDataField.SetValue(_syncData.syncData, GetRecord(this._key, _defValue));
        ResetLastValue();
    }

    public string Key => _key;

    public override string FieldName => _name;

    public T Value
    {
        get => (T)(_syncDataField.GetValue(_syncData.syncData));
        set
        {
            Delta = value;
            OnDataChanged((T)(_syncDataField.GetValue(_syncData.syncData)), value);
            _syncDataField.SetValue(_syncData.syncData, value); 
            SaveRecord(_key, value);
        }
    }

    public T LastValue => lastData;

    //set => lastData = value;
    public virtual void ResetLastValue()
    {
        lastData = Value;
    }

    public virtual bool IsChanged => !lastData.Equals(Value);

    public override object GetValObj()
    {
        return Value;
    }

    protected virtual void OnDataChanged(T oldData, T newData)
    {
        IsSyncDataChanged = IsSyncDataChanged || !IsEquals(oldData, newData);
        RecordChangeState = IsSyncDataChanged;
        //changeListener?.Invoke();
        TimersManager.SetTimer(0.05f, () => changeListener?.Invoke());
    }

    protected virtual bool IsEquals(T v1, T v2)
    {
        return false;
    }

    protected abstract T GetRecord(string key, T defVal);

    protected abstract void SaveRecord(string key, T val);

    public override void UpdateSave()
    {
        base.UpdateSave();
        RecordChangeState = false;
        if (!IsValidValue())
        {
            _syncDataField.SetValue(_syncData.syncData, _defValue);
        }
        ResetLastValue();
        SaveRecord(_key, Value);
        TimersManager.SetTimer(0.05f, () => changeListener?.Invoke());
    }

    protected virtual bool IsValidValue()
    {
        return true;
    }

    public override void UpdateRead()
    {
        base.UpdateRead();
        _syncDataField.SetValue(_syncData.syncData, GetRecord(_key, Value));
    }

    public override void ResetSyncChangeState()
    {
        if (!IsSyncDataChanged)
            return;
        base.ResetSyncChangeState();
        RecordChangeState = false;
    }

    public override void Reset()
    {
        base.Reset();
        Record.DeleteKey(_key);
        _syncDataField.SetValue(_syncData.syncData, _defValue);
        RecordChangeState = false;
        IsSyncDataChanged = false;
        Delta = _defValue;
    }

    private bool RecordChangeState
    {
        get => Record.GetBool(_key + "_change", true);
        set => Record.SetBool(_key + "_change", value);
    }
    
    public event Action DataUpdateEvent
    {
        add
        {
            if (changeListener == null ||
                !changeListener.GetInvocationList().Contains(value))
            {
                changeListener += value;
            }
        }
        remove
        {
            if (changeListener != null &&
                changeListener.GetInvocationList().Contains(value))
            {
                changeListener -= value;
            }
        }
    }
}

public class StringSyncField : SyncField<string>
{
    public StringSyncField(ref SyncData syncData, string name, string key, string defVal) 
        : base(ref syncData, name, key, defVal)
    {
    }

    protected override string GetRecord(string key, string defVal)
    {
        return Record.GetString(key, defVal);
    }

    protected override void SaveRecord(string key, string val)
    {
        Record.SetString(key, val);
    }

    protected override bool IsEquals(string v1, string v2)
    {
        return v1 == null ? (v2 == null) : (v2 != null && (v1.Equals(v2)));
    }

    protected override bool IsValidValue()
    {
        return !string.IsNullOrEmpty(Value);
    }
}

public class BoolSyncField : SyncField<bool>
{
    public BoolSyncField(ref SyncData syncData, string name, string key, bool defVal) 
        : base(ref syncData, name, key, defVal)
    {
    }

    protected override bool GetRecord(string key, bool defVal)
    {
        return Record.GetBool(key, defVal);
    }

    protected override void SaveRecord(string key, bool val)
    {
        Record.SetBool(key, val);
    }

    protected override bool IsEquals(bool v1, bool v2)
    {
        return v1 == v2;
    }
}
 
public class IntSyncField : SyncField<int>
 {
     public IntSyncField(ref SyncData syncData, string name, string key, int defVal) 
         : base(ref syncData, name, key, defVal)
     {
         Delta = 0;
     }
 
     protected override void OnDataChanged(int oldData, int newData)
     {
         Delta += (newData - oldData);
         base.OnDataChanged(oldData, newData);
     }
 
     protected override int GetRecord(string key, int defVal)
     {
         return Record.GetInt(key, defVal);
     }
 
     protected override void SaveRecord(string key, int val)
     {
         Record.SetInt(key, val);
     }

     public override void Reset()
     {
         base.Reset();
         Delta = 0;
     }
     
     protected override bool IsEquals(int v1, int v2)
     {
         return v1 == v2;
     }
 }

public class FloatSyncField : SyncField<float>
{
    public FloatSyncField(ref SyncData syncData, string name, string key, float defVal) 
        : base(ref syncData, name, key, defVal)
    {
        Delta = 0;
    }

    protected override void OnDataChanged(float oldData, float newData)
    {
        Delta += (newData - oldData);
        base.OnDataChanged(oldData, newData);
    }

    protected override float GetRecord(string key, float defVal)
    {
        return Record.GetFloat(key, defVal);
    }

    protected override void SaveRecord(string key, float val)
    {
        Record.SetFloat(key, val);
    }
    
    public override void Reset()
    {
        base.Reset();
        Delta = 0;
    }
    
    protected override bool IsEquals(float v1, float v2)
    {
        return Math.Abs(v1 - v2) < 0.0001;
    }
}

public class ObjSyncField<T> : SyncField<T> where T : BaseSyncHandData, new()
{
    public ObjSyncField(ref SyncData syncData, string name, string key, T defVal) 
        : base(ref syncData, name, key, defVal)
    {
        
    }

    public override void Init()
    {
        base.Init();
        Value.SetChangeListener(OnObjDataChanged);
    }

    private void OnObjDataChanged()
    {
        OnDataChanged(null, Value);
        SaveRecord(Key, Value);
    }

    public override void ResetLastValue()
    {
        lastData = (T)Value.Clone();
    }

    public override bool IsChanged => !lastData.IsEqual(Value);

    protected override T GetRecord(string key, T defVal)
    {
        return Record.GetObject(key, defVal);
    }

    protected override void SaveRecord(string key, T val)
    {
        Record.SetObject(key, val);
    }

    public void UpdateValue(Func<T, T> op)
    {
        Value = op(Value);
    }

    protected override bool IsEquals(T v1, T v2)
    {
        return false;
        //return v1 == null ? (v2 == null) : (v2 != null && (v1.Equals(v2)));
    }

    protected override bool IsValidValue()
    {
        return Value != null;
    }
}

 /// <summary>
 /// 压缩字符串
 /// </summary>
 /// <typeparam name="T"></typeparam>
 public class ObjCompressSyncField<T> : SyncField<T> where T : BaseSyncHandData, new()
 {
     public ObjCompressSyncField(ref SyncData syncData, string name, string key, T defVal) 
         : base(ref syncData, name, key, defVal)
     {
        
     }

     public override void Init()
     {
         base.Init();
         Value.SetChangeListener(OnObjDataChanged);
     }

     private void OnObjDataChanged()
     {
         OnDataChanged(null, Value);
         SaveRecord(Key, Value);
     }

     public override void ResetLastValue()
     {
         lastData = (T)Value.Clone();
     }

     public override bool IsChanged => !lastData.IsEqual(Value);

     protected override T GetRecord(string key, T defVal)
     {
         string compressedstr = Record.GetString(key, "");
         if (string.IsNullOrEmpty(compressedstr))
         {
             return defVal;
         }
         string decompressedstr = StringCompressUtils.DecompressString(compressedstr);
         return JsonConvert.DeserializeObject<T>(decompressedstr);
     }

     protected override void SaveRecord(string key, T val)
     {
         string compressValue = StringCompressUtils.CompressString(JsonConvert.SerializeObject(val));
         Record.SetString(key, compressValue);
     }

     public void UpdateValue(Func<T, T> op)
     {
         Value = op(Value);
     }

     protected override bool IsEquals(T v1, T v2)
     {
         return false;
         //return v1 == null ? (v2 == null) : (v2 != null && (v1.Equals(v2)));
     }

     protected override bool IsValidValue()
     {
         return Value != null;
     }
 }
 
public class DateSyncField : SyncField<DateTime>
{
    public DateSyncField(ref SyncData syncData, string name, string key, DateTime defVal) 
        : base(ref syncData, name, key, defVal)
    {
    }

    protected override DateTime GetRecord(string key, DateTime defVal)
    {
        return Record.GetDate(key, defVal);
    }

    protected override void SaveRecord(string key, DateTime val)
    {
        Record.SetDate(key, val);
    }

    protected override bool IsEquals(DateTime v1, DateTime v2)
    {
        return v1.Equals(v2);
    }
}

public class StrDateSyncField : StringSyncField
{
    public StrDateSyncField(ref SyncData syncData, string name, string key, DateTime defVal) 
        : base(ref syncData, name, key, DateToStr(defVal))
    {
    }

    private static string DateToStr(DateTime dt)
    {
        return dt.ToString();
    }

    private static DateTime StrToDate(string str)
    {
        return XUtils.ConvertTime(str, DateTime.MinValue);
    }

    public DateTime Date
    {
        get => StrToDate(Value);
        set => Value = DateToStr(value);
    }
}
