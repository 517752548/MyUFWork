﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncData
{
    public int dataVersion;
    public PlayerSyncData syncData;
}

public class PlayerSyncData
{
    public string playerTag;
    
    public int coin;
    public int hint1;
    public int hint2;
    public int hint3;
    public int hint4;
    public bool hint1unlock;
    public bool hint2unlock;
    public bool hint3unlock;
    public bool hint4unlock;
    public int bee;
    public string todayKey;
    public string monKey;
    public bool toadyFinished;
    public PetData pets;
    public TitleData titles;
    //public KnowledgeCardData cards;

    public int fansNumber;
    public int videoShowTimes;
    public bool isRemoveAd;

    public string lastRateRewardTime;

    public int stars;

    public int classicLevel;

    public int signTimes;
    public string lastSignDate;

    public string oneWordLastCompleteID;
    public string oneWordLastCompleteExID;
    public string oneWordExLevelStartID;
    public string oneWordCurExID;

    public bool guideFirstWord;
    public bool guideWelcome;
    public bool guideHint1Unlock;
    public bool guideHint2Unlock;
    public bool guideHint3Unlock;
    public bool guideHint4Unlock;
    public bool guideBlogEnter;
    public bool guideBlogCard;
    public bool guideDailyEnter;
    public bool guideDailyReward;
    public bool guideRateReward;
    public bool guideBeeReward;
    public bool guideBeeUse;
    public bool guideThemeWord;
    public EliteData elidate;
    public int cup;
    public int eliteTicket;
}

public class BaseSyncHandData
{
    private Action onChange;
    
    public void SetChangeListener(Action onChange)
    {
        this.onChange = onChange;
    }
    
    protected void OnDataChange()
    {
        onChange?.Invoke();
    }

    public virtual BaseSyncHandData Clone()
    {
        return this;
    }

    public virtual bool IsEqual(BaseSyncHandData other)
    {
        return Equals(other);
    }
}
