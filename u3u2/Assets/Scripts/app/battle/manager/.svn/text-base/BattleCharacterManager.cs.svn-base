using System;
using System.Collections.Generic;
using app.chat;
using UnityEngine;
using app.pet;
using app.avatar;
using app.human;
using app.relation;

namespace app.battle
{
    public class BattleCharacterManager
    {
        public List<BatCharacter> attackers { get; private set; }
        public int attackersCount { get; private set; }
        public List<BatCharacter> defenders { get; private set; }
        public int defendersCount { get; private set; }

        public BatCharacter mainRole { get; private set; }
        public BatCharacter mainPet { get; private set; }

        private List<BatCharacter> mCharacters = new List<BatCharacter>();
        private int mCharactersCount = 0;

        //private List<BatCharacterStatusData> mReadyToCreateAtkersData = new List<BatCharacterStatusData>();
        //private List<BatCharacterStatusData> mReadyToCreateDefersData = new List<BatCharacterStatusData>();

        private BatRoundStageData mCurRoundBehavData = null;
        private int mCurRoundBehavDataIdx = -1;

        private BatRoundBehavData mCurRoundStartBehavItemData = null;
        private int mCurRoundStartBehavItemDataIdx = -1;

        private BatRoundBehavData mCurRoundExeBehavItemData = null;
        private int mCurRoundExeBehavItemDataIdx = -1;

        private BatRoundBehavData mCurRoundDefenceBehavItemData = null;
        private int mCurRoundDefenceBehavItemDataIdx = -1;

        private BatRoundBehavData mCurRoundAdjustBehavItemData = null;
        private int mCurRoundAdjustBehavItemDataIdx = -1;

        private BatRoundBehavData mCurRoundEndBehavItemData = null;
        private int mCurRoundEndBehavItemDataIdx = -1;

        private bool mIsInited = false;
        private bool mIsReadyToFight = false;
        private int mCreateCDFrameLeft = 0;

        private static BattleCharacterManager mIns = new BattleCharacterManager();

        public static BattleCharacterManager ins
        {
            get
            {
                return mIns;
            }
        }

        public BattleCharacterManager()
        {
            if (BattleCharacterManager.ins != null)
            {
                throw new Exception("BattleCharacterManager instance already exists!");
            }

            attackers = new List<BatCharacter>();
            attackersCount = 0;
            defenders = new List<BatCharacter>();
            defendersCount = 0;
            mIsReadyToFight = false;
            mIsInited = false;
        }

        public void StartRound()
        {
            mCurRoundBehavData = null;
            mCurRoundBehavDataIdx = -1;
            mCurRoundStartBehavItemData = null;
            mCurRoundStartBehavItemDataIdx = -1;
            mCurRoundExeBehavItemData = null;
            mCurRoundExeBehavItemDataIdx = -1;
            mCurRoundDefenceBehavItemData = null;
            mCurRoundDefenceBehavItemDataIdx = -1;
            mCurRoundAdjustBehavItemData = null;
            mCurRoundAdjustBehavItemDataIdx = -1;
            mCurRoundEndBehavItemData = null;
            mCurRoundEndBehavItemDataIdx = -1;

            //ClientLog.Log("StartRound");
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_INIT_START;
            if (mIsInited)
            {
                UpdateCharactersData();
                FadeInAllCharacters();
            }
            else
            {
                Init();
            }

            mainRole = GetMainRole();
            mainPet = GetMainPet();

            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_INIT_PROGRESS;
        }

        public void Update()
        {
            UpdateCharacters(attackers, attackersCount);
            UpdateCharacters(defenders, defendersCount);

            if (!isReadyToFight)
            {
                /*
                if (--mCreateCDFrameLeft <= 0)
                {
                    int waitAtkCount = mReadyToCreateAtkersData.Count;
                    int waitDefCount = mReadyToCreateDefersData.Count;

                    while (waitAtkCount > 0)
                    {
                        CreateAttacker();
                        waitAtkCount--;
                    }

                    while (waitDefCount > 0)
                    {
                        CreateDefender();
                        waitDefCount--;
                    }

                    if (waitAtkCount == 0 && waitDefCount == 0)
                    {
                        mainRole = GetMainRole();
                        mainPet = GetMainPet();
                    }

                    mCreateCDFrameLeft = 1;
                }
                */
                return;
            }

            if (BattleModel.ins.maxModelHeight == 0)
            {
                for (int i = 0; i < attackersCount; i++)
                {
                    BattleModel.ins.maxModelHeight = Mathf.Max(BattleModel.ins.maxModelHeight, attackers[i].displayModel.totalHeight);
                }

                for (int i = 0; i < defendersCount; i++)
                {
                    BattleModel.ins.maxModelHeight = Mathf.Max(BattleModel.ins.maxModelHeight, defenders[i].displayModel.totalHeight);
                }

                for (int i = 0; i < attackersCount; i++)
                {
                    if (!attackers[i].isDestroied)
                    {
                        attackers[i].CreateAvatarName();
                        attackers[i].CreateBloodBar();
                    }
                }

                for (int i = 0; i < defendersCount; i++)
                {
                    if (!defenders[i].isDestroied)
                    {
                        defenders[i].CreateAvatarName();
                        defenders[i].CreateBloodBar();
                    }
                }
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_INIT_PROGRESS)
            {
                if (isReadyToFight)
                {
                    BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_INIT_FINISH;
                }
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_INIT_FINISH)
            {
                //ClientLog.Log("StartRoundStart");
                StartRoundStart();
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_START_PROGRESS)
            {
                if (isRoundStartFinish)
                {
                    //ClientLog.Log("FinishRoundStart");
                    BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_START_FINISH;
                }
                else
                {
                    //ClientLog.Log("ProcessRoundStart");
                    ProcessRoundStart();
                }
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_START_FINISH)
            {
                //ClientLog.Log("StartRoundProgress");
                StartRoundProgress();
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_PROGRESS_PROGRESS)
            {
                if (isRoundProgressFinish)
                {
                    //ClientLog.Log("FinishRoundProgress");
                    BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_PROGRESS_FINISH;
                }
                else
                {
                    //ClientLog.Log("ProcessRoundProgress");
                    ProcessRoundProgress();
                }
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_PROGRESS_FINISH)
            {
                //ClientLog.Log("StartRoundEnd");
                StartRoundEnd();
            }

            if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_PROGRESS)
            {
                if (isRoundEndFinish)
                {
                    //ClientLog.Log("FinishRoundEnd");
                    BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_END_FINISH;
                    if (!BattleModel.ins.curRoundData.isFinalRound)
                    {
                        BattleModel.ins.curRoundWaitTimeLeft = BattleDef.MANUAL_ROUND_CD_SECONDS;
                    }

                    for (int i = 0; i < attackersCount; i++)
                    {
                        if (attackers[i].curAnimName == AvatarBase.ANIM_NAME_DEFENSE)
                        {
                            attackers[i].PlayAnimation(AvatarBase.ANIM_NAME_IDLE);
                        }
                    }

                    for (int i = 0; i < defendersCount; i++)
                    {
                        if (defenders[i].curAnimName == AvatarBase.ANIM_NAME_DEFENSE)
                        {
                            defenders[i].PlayAnimation(AvatarBase.ANIM_NAME_IDLE);
                        }
                    }

                    /*
                    if (BattleUI.ins.isShown)
                    {
                        if (mainPet == null || (mainPet.isAlive && mainPet.isActive))
                        {
                            BattleUI.ins.ShowPetSkillBtns();
                        }
                        else
                        {
                            BattleUI.ins.HidePetSkillBtns();
                        }
                    }
                    */
                }
                else
                {
                    //ClientLog.Log("ProcessRoundEnd");
                    ProcessRoundEnd();
                }
            }
        }

        private void StartRoundStart()
        {
            ClientLog.Log("--------------------DO ROUND_START--------------------");
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_START_START;
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_START_PROGRESS;
            mCurRoundBehavDataIdx = -1;
        }

        private void ProcessRoundStart()
        {
            ProcessRoundBehav(BattleModel.ins.curRoundData.startDatas);
        }

        private bool isRoundStartFinish
        {
            get
            {
                return BattleModel.ins.curRoundData.isStartDone;
            }
        }

        private void StartRoundProgress()
        {
            ClientLog.Log("--------------------DO ROUND_PROGRESS--------------------");
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_PROGRESS_START;
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_PROGRESS_PROGRESS;
            mCurRoundBehavDataIdx = -1;
        }

        private void ProcessRoundProgress()
        {
            ProcessRoundBehav(BattleModel.ins.curRoundData.progressDatas);
        }

        private bool isRoundProgressFinish
        {
            get
            {
                return BattleModel.ins.curRoundData.isProgressDone;
            }
        }

        private void StartRoundEnd()
        {
            ClientLog.Log("--------------------DO ROUND_END--------------------");
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_END_START;
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_END_PROGRESS;
            mCurRoundBehavDataIdx = -1;
        }

        private void ProcessRoundEnd()
        {
            ProcessRoundBehav(BattleModel.ins.curRoundData.endDatas);
        }

        private bool isRoundEndFinish
        {
            get
            {
                return BattleModel.ins.curRoundData.isEndDone;
            }
        }

        private void ProcessRoundBehav(List<BatRoundStageData> behavDatas)
        {
            if (mCurRoundBehavData == null || mCurRoundBehavData.isDone)
            {
                if (mCurRoundBehavDataIdx + 1 < behavDatas.Count)
                {
                    mCurRoundBehavDataIdx = mCurRoundBehavDataIdx + 1;
                    mCurRoundBehavData = behavDatas[mCurRoundBehavDataIdx];
                }
                else
                {
                    mCurRoundBehavData = null;
                    mCurRoundBehavDataIdx = -1;
                }

                mCurRoundStartBehavItemData = null;
                mCurRoundStartBehavItemDataIdx = -1;
                mCurRoundExeBehavItemData = null;
                mCurRoundExeBehavItemDataIdx = -1;
                mCurRoundDefenceBehavItemData = null;
                mCurRoundDefenceBehavItemDataIdx = -1;
                mCurRoundAdjustBehavItemData = null;
                mCurRoundAdjustBehavItemDataIdx = -1;
                mCurRoundEndBehavItemData = null;
                mCurRoundEndBehavItemDataIdx = -1;
            }

            if (mCurRoundBehavData != null)
            {
                if (!mCurRoundBehavData.isStartDone)
                {
                    if (mCurRoundStartBehavItemData == null || mCurRoundStartBehavItemData.isDone)
                    {
                        if (mCurRoundStartBehavItemDataIdx + 1 < mCurRoundBehavData.startItems.Count)
                        {
                            mCurRoundStartBehavItemDataIdx++;
                            mCurRoundStartBehavItemData = mCurRoundBehavData.startItems[mCurRoundStartBehavItemDataIdx];
                            DoBehav(mCurRoundStartBehavItemData);
                        }
                    }
                }
                else if (!mCurRoundBehavData.isExecuteDone)
                {
                    if (mCurRoundExeBehavItemData == null || mCurRoundExeBehavItemData.isDone)
                    {
                        if (mCurRoundExeBehavItemDataIdx + 1 < mCurRoundBehavData.exeItems.Count)
                        {
                            mCurRoundExeBehavItemDataIdx++;
                            mCurRoundExeBehavItemData = mCurRoundBehavData.exeItems[mCurRoundExeBehavItemDataIdx];
                            DoBehav(mCurRoundExeBehavItemData);
                        }
                    }
                }
                else if (!mCurRoundBehavData.isDefenceDone)
                {
                    if (mCurRoundDefenceBehavItemData == null || mCurRoundDefenceBehavItemData.isDone)
                    {
                        if (mCurRoundDefenceBehavItemDataIdx + 1 < mCurRoundBehavData.defItems.Count)
                        {
                            mCurRoundDefenceBehavItemDataIdx++;
                            mCurRoundDefenceBehavItemData = mCurRoundBehavData.defItems[mCurRoundDefenceBehavItemDataIdx];
                            DoBehav(mCurRoundDefenceBehavItemData);
                        }
                    }
                }
                else if (!mCurRoundBehavData.isAdjustDone)
                {
                    if (mCurRoundAdjustBehavItemData == null || mCurRoundAdjustBehavItemData.isDone)
                    {
                        if (mCurRoundAdjustBehavItemDataIdx + 1 < mCurRoundBehavData.adjustItems.Count)
                        {
                            mCurRoundAdjustBehavItemDataIdx++;
                            mCurRoundAdjustBehavItemData = mCurRoundBehavData.adjustItems[mCurRoundAdjustBehavItemDataIdx];
                            DoBehav(mCurRoundAdjustBehavItemData);
                        }
                    }
                }
                else if (!mCurRoundBehavData.isEndDone)
                {
                    if (mCurRoundEndBehavItemData == null || mCurRoundEndBehavItemData.isDone)
                    {
                        if (mCurRoundEndBehavItemDataIdx + 1 < mCurRoundBehavData.endItems.Count)
                        {
                            mCurRoundEndBehavItemDataIdx++;
                            mCurRoundEndBehavItemData = mCurRoundBehavData.endItems[mCurRoundEndBehavItemDataIdx];
                            DoBehav(mCurRoundEndBehavItemData);
                        }
                    }
                }
            }
        }

        private void DoBehav(BatRoundBehavData data)
        {
            data.host = this.GetCharacter(data.hostUUID);
            data.host.DoBatRoundBehav(data);
        }

        public void FixedUpdate()
        {
            FixedUpdateCharacters(attackers, attackersCount);
            FixedUpdateCharacters(defenders, defendersCount);
        }

        private void Init()
        {
            //ClientLog.Log("Init");
            //#if !UNITY_ANDROID
            CreateAttackers(BattleModel.ins.curRoundData.attackerStatus);
            CreateDefenders(BattleModel.ins.curRoundData.defenderStatus);
            //#endif
            mIsInited = true;
        }

        private void CreateAttackers(List<BatCharacterStatusData> datas)
        {
            int len = datas.Count;
            for (int i = 0; i < len; i++)
            {
                CreateAttacker(datas[i]);
            }
        }

        private BatCharacter CreateAttacker(BatCharacterStatusData data)
        {
            BatCharacter cha = CreateBatCharacter(data, BatCharacterSiteType.ATTACKER);
            attackers.Add(cha);
            attackersCount++;
            mCharacters.Add(cha);
            mCharactersCount++;
            return cha;
        }


        private void CreateDefenders(List<BatCharacterStatusData> datas)
        {
            int len = datas.Count;
            for (int i = 0; i < len; i++)
            {
                CreateDefender(datas[i]);
            }
        }


        private BatCharacter CreateDefender(BatCharacterStatusData data)
        {
            BatCharacter cha = CreateBatCharacter(data, BatCharacterSiteType.DEFENDER);
            defenders.Add(cha);
            defendersCount++;
            mCharacters.Add(cha);
            mCharactersCount++;
            return cha;
        }

        private BatCharacter CreateBatCharacter(BatCharacterStatusData data, BatCharacterSiteType siteType)
        {
            BatCharacter cha = new BatCharacter();
            cha.Init(data, siteType);
            return cha;
        }

        private void UpdateCharactersData()
        {
            //ClientLog.Log("UpdateCharactersData");
            UpdateAttackersData();
            UpdateDefendersData();
        }

        private void UpdateAttackersData()
        {
            int len = BattleModel.ins.curRoundData.attackerStatus.Count;

            for (int i = 0; i < len; i++)
            {
                BatCharacterStatusData data = BattleModel.ins.curRoundData.attackerStatus[i];
                BatCharacter cha = GetAttacker(data.uuidS);
                if (cha != null && cha.data.uuidL == data.uuidL)
                {
                    cha.UpdateData(data);
                }
                else
                {
                    InsertNewAttacker(data);
                }
            }

            List<BatCharacter> noUseAttackers = new List<BatCharacter>();
            for (int i = 0; i < attackersCount; i++)
            {
                if (!BattleModel.ins.curRoundData.hasAttacker(attackers[i].data.uuidS, attackers[i].data.uuidL))
                {
                    noUseAttackers.Add(attackers[i]);
                }
            }

            len = noUseAttackers.Count;
            for (int i = 0; i < len; i++)
            {
                attackers.Remove(noUseAttackers[i]);
                attackersCount--;
                mCharacters.Remove(noUseAttackers[i]);
                mCharactersCount--;
                noUseAttackers[i].Destroy();
            }
            noUseAttackers.Clear();
        }

        public void InsertNewAttacker(BatCharacterStatusData data)
        {
            BatCharacter atker = CreateAttacker(data);
            atker.CreateAvatarName();
            atker.CreateBloodBar();
            mainRole = GetMainRole();
            mainPet = GetMainPet();
            
            if (mainRole != null)
            {
                BattleManager.ins.UpdateMainRoleInfo(mainRole);
            }
            
            if (mainPet != null)
            {
                BattleManager.ins.UpdateMainPetInfo(mainPet);
            }
        }

        private void UpdateDefendersData()
        {
            int len = BattleModel.ins.curRoundData.defenderStatus.Count;

            for (int i = 0; i < len; i++)
            {
                BatCharacterStatusData data = BattleModel.ins.curRoundData.defenderStatus[i];
                BatCharacter cha = GetDefender(data.uuidS);
                if (cha != null && cha.data.uuidL == data.uuidL)
                {
                    cha.UpdateData(data);
                }
                else
                {
                    InsertNewDefender(data);
                }
            }

            List<BatCharacter> noUseDefenders = new List<BatCharacter>();
            for (int i = 0; i < defendersCount; i++)
            {
                if (!BattleModel.ins.curRoundData.hasDefender(defenders[i].data.uuidS, defenders[i].data.uuidL))
                {
                    noUseDefenders.Add(defenders[i]);
                }
            }

            len = noUseDefenders.Count;
            for (int i = 0; i < len; i++)
            {
                defenders.Remove(noUseDefenders[i]);
                defendersCount--;
                mCharacters.Remove(noUseDefenders[i]);
                mCharactersCount--;
                noUseDefenders[i].Destroy();
            }
            noUseDefenders.Clear();
        }

        public void InsertNewDefender(BatCharacterStatusData data)
        {
            BatCharacter defer = CreateDefender(data);
            defer.CreateAvatarName();
            defer.CreateBloodBar();
            mainRole = GetMainRole();
            mainPet = GetMainPet();
            
            if (mainRole != null)
            {
                BattleManager.ins.UpdateMainRoleInfo(mainRole);
            }
            
            if (mainPet != null)
            {
                BattleManager.ins.UpdateMainPetInfo(mainPet);
            }
        }

        public bool isReadyToFight
        {
            get
            {
                if (mIsReadyToFight)
                {
                    return true;
                }

                mIsReadyToFight = mIsInited && BattleUI.ins.ui != null && isAllAttackersInited && isAllDefendersInited;
                return mIsReadyToFight;
            }
        }

        public bool isAllAttackersInited
        {
            get
            {
                /*
                if (mReadyToCreateAtkersData.Count > 0)
                {
                    return false;
                }
                */
                if (attackersCount == 0)
                {
                    return false;
                }

                for (int i = 0; i < attackersCount; i++)
                {
                    if (attackers[i].isInited == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool isAllDefendersInited
        {
            get
            {
                /*
                if (mReadyToCreateDefersData.Count > 0)
                {
                    return false;
                }
                */

                if (defendersCount == 0)
                {
                    return false;
                }

                for (int i = 0; i < defendersCount; i++)
                {
                    if (defenders[i].isInited == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void UpdateCharacters(List<BatCharacter> chas, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!chas[i].isDestroied)
                {
                    chas[i].Update();
                }
            }
        }

        private void FixedUpdateCharacters(List<BatCharacter> chas, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!chas[i].isDestroied)
                {
                    chas[i].FixedUpdate();
                }
            }
        }

        public BatCharacter GetCharacter(string uuid)
        {
            if (IsAttacker(uuid))
            {
                return GetAttacker(uuid);
            }
            return GetDefender(uuid);
        }

        public BatCharacter GetCharacter(long uuid)
        {
            for (int i = 0; i < attackersCount; i++)
            {
                if (attackers[i].data.uuidL == uuid)
                {
                    return attackers[i];
                }
            }

            for (int i = 0; i < defendersCount; i++)
            {
                if (defenders[i].data.uuidL == uuid)
                {
                    return defenders[i];
                }
            }

            return null;
        }

        public BatCharacter GetAttacker(string uuid)
        {
            for (int i = 0; i < attackersCount; i++)
            {
                if (attackers[i].data.uuidS == uuid)
                {
                    return attackers[i];
                }
            }

            return null;
        }

        public BatCharacter GetDefender(string uuid)
        {
            for (int i = 0; i < defendersCount; i++)
            {
                if (defenders[i].data.uuidS == uuid)
                {
                    return defenders[i];
                }
            }

            return null;
        }


        private BatCharacter GetMainRole()
        {
            if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
            {
                return GetAttackerMainRole();
            }
            else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
            {
                return GetDefenderMainRole();
            }
            return null;
        }

        private BatCharacter GetAttackerMainRole()
        {
            for (int i = 0; i < attackersCount; i++)
            {
                if (attackers[i].data.type == PetType.LEADER && attackers[i].data.ownerUUID == Human.Instance.Id)
                {
                    return attackers[i];
                }
            }
            return null;
        }

        private BatCharacter GetDefenderMainRole()
        {
            for (int i = 0; i < defendersCount; i++)
            {
                if (defenders[i].data.type == PetType.LEADER && defenders[i].data.ownerUUID == Human.Instance.Id)
                {
                    return defenders[i];
                }
            }
            return null;
        }

        private BatCharacter GetMainPet()
        {
            if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
            {
                return GetAttackerMainPet();
            }
            else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
            {
                return GetDefenderMainPet();
            }
            return null;
        }

        private BatCharacter GetAttackerMainPet()
        {
            for (int i = 0; i < attackersCount; i++)
            {
                if (attackers[i].data.type == PetType.PET && attackers[i].data.ownerUUID == Human.Instance.Id)
                {
                    return attackers[i];
                }
            }
            return null;
        }

        private BatCharacter GetDefenderMainPet()
        {
            for (int i = 0; i < defendersCount; i++)
            {
                if (defenders[i].data.type == PetType.PET && defenders[i].data.ownerUUID == Human.Instance.Id)
                {
                    return defenders[i];
                }
            }
            return null;
        }

        public bool IsAttacker(string id)
        {
            return id.ToCharArray()[0] == 'a';
        }

        public void FadeInAllCharacters(List<BatCharacter> ignoreList = null)
        {
            for (int i = 0; i < mCharactersCount; i++)
            {
                if (ignoreList == null || !ignoreList.Contains(mCharacters[i]))
                {
                    mCharacters[i].FadeIn();
                }
            }
        }

        public void FadeOutAllCharacters(List<BatCharacter> ignoreList = null)
        {
            for (int i = 0; i < mCharactersCount; i++)
            {
                if (ignoreList == null || !ignoreList.Contains(mCharacters[i]))
                {
                    mCharacters[i].FadeOut();
                }
            }
        }

        public void DestroyCharacters()
        {
            /*
            mReadyToCreateAtkersData.Clear();
            mReadyToCreateDefersData.Clear();
            */
            //DestroyCharacters(attackers);
            attackers.Clear();
            attackersCount = 0;
            //DestroyCharacters(defenders);
            defenders.Clear();
            defendersCount = 0;
            DestroyCharacters(mCharacters);
            mCharacters.Clear();
            mCharactersCount = 0;
            mCurRoundBehavData = null;
            mCurRoundBehavDataIdx = -1;
            mCurRoundStartBehavItemData = null;
            mCurRoundStartBehavItemDataIdx = -1;
            mCurRoundExeBehavItemData = null;
            mCurRoundExeBehavItemDataIdx = -1;
            mCurRoundDefenceBehavItemData = null;
            mCurRoundDefenceBehavItemDataIdx = -1;
            mCurRoundAdjustBehavItemData = null;
            mCurRoundAdjustBehavItemDataIdx = -1;
            mCurRoundEndBehavItemData = null;
            mCurRoundEndBehavItemDataIdx = -1;
            mIsInited = false;
            mIsReadyToFight = false;
            BattleModel.ins.maxModelHeight = 0;
        }

        private void DestroyCharacters(List<BatCharacter> characters)
        {
            int len = characters.Count;

            for (int i = 0; i < len; i++)
            {
                characters[i].Destroy();
            }

            characters.Clear();
        }

        public void ShowAllPrepareSign()
        {
            if (BattleModel.ins.battleType == BattleType.PVE)
            {
                if (mainRole != null && mainRole.isCanDoSkill)
                {
                    if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(mainRole.data.uuidL))
                    {
                        mainRole.SetPrepareSignActive(true);
                    }
                }

                if (mainPet != null && mainPet.isCanDoSkill)
                {
                    if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(mainPet.data.uuidL))
                    {
                        mainPet.SetPrepareSignActive(true);
                    }
                }
            }
            else if (BattleModel.ins.battleType == BattleType.PVP)
            {
                for (int i = 0; i < attackersCount; i++)
                {
                    if ((attackers[i].data.type == PetType.LEADER || attackers[i].data.type == PetType.PET) && attackers[i].isCanDoSkill)
                    {
                        if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(attackers[i].data.uuidL))
                        {
                            attackers[i].SetPrepareSignActive(true);
                        }
                    }
                }

                for (int i = 0; i < defendersCount; i++)
                {
                    if ((defenders[i].data.type == PetType.LEADER || defenders[i].data.type == PetType.PET) && defenders[i].isCanDoSkill)
                    {
                        if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(defenders[i].data.uuidL))
                        {
                            defenders[i].SetPrepareSignActive(true);
                        }
                    }
                }
            }
            else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
            {
                for (int i = 0; i < attackersCount; i++)
                {
                    if ((attackers[i].data.type == PetType.LEADER || attackers[i].data.type == PetType.PET) && attackers[i].isCanDoSkill)
                    {
                        if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(attackers[i].data.uuidL))
                        {
                            attackers[i].SetPrepareSignActive(true);
                        }
                    }
                }
                
                for (int i = 0; i < defendersCount; i++)
                {
                    if ((defenders[i].data.type == PetType.LEADER || defenders[i].data.type == PetType.PET) && defenders[i].isCanDoSkill)
                    {
                        if (!BattleModel.ins.charactersNeedHidePrepareSign.Contains(defenders[i].data.uuidL))
                        {
                            defenders[i].SetPrepareSignActive(true);
                        }
                    }
                }
            }

            BattleModel.ins.charactersNeedHidePrepareSign.Clear();
        }

        public void HideAllPrepareSign()
        {
            for (int i = 0; i < attackersCount; i++)
            {
                attackers[i].SetPrepareSignActive(false);
            }

            for (int i = 0; i < defendersCount; i++)
            {
                defenders[i].SetPrepareSignActive(false);
            }
        }

        public void showChatBubble(ChatMsgData msg)
        {
            for (int i = 0; mCharacters != null && i < mCharacters.Count; i++)
            {
                BatCharacter batcha = mCharacters[i];
                if (batcha.data.type == PetType.LEADER && batcha.data.ownerUUID.ToString() == msg.getFromRoleUUID())
                {
                    batcha.ShowChatBubble(RelationChatItemScript.getContentText(msg),true);
                    break;
                }
            }
        }
    }
}