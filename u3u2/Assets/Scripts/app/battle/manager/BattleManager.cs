using System;
using System.Collections;
using System.Collections.Generic;
using app.zone;
using UnityEngine;
using app.net;
using app.model;
using app.avatar;
using app.role;
using app.pet;
using app.human;
using app.state;
using minijson;

namespace app.battle
{
    public class BattleManager
    {

        public const string Enter_Battle = "Enter_Battle";  //进入战斗事件
        public const string Exit_Battle = "Exit_Battle";  //退出战斗事件

        private bool mIsBattleFinished = false;
        private bool mIsRequestingRoundData = false;
        //private PlayerModel mPlayerModel = null;
        //private float mTotalRoundStartDelay = 0;
        private float mExitStateDelay = 0;
        private bool mIsWaitingToExit = false;
        private bool mIsForceFinishByServer = false;
        /*
        private float mBattleStartEffectSecondsLeft = 0;
        private GameObject mBattleStartEffect = null;
        private bool mNeedPlayBattleStartEffect = false;
        private int mPlayBattleStartEffectDelayFramesLeft = 0;
        */
        public bool m_bIsBattle = false;
        private int mCamShakeTimes = 0;
        private static BattleManager mIns = new BattleManager();

        public static BattleManager ins
        {
            get
            {
                return mIns;
            }
        }

        public BattleManager()
        {
            if (BattleManager.ins != null)
            {
                throw new Exception("BattleManager instance already exists!");
            }

            //mPlayerModel = Singleton.getObj(typeof(PlayerModel)) as PlayerModel;
        }

        public void EnterBattleState()
        {
            m_bIsBattle = true;
            EventCore.dispathRMetaEventByParms(Enter_Battle, null);
            SceneModel.ins.InitBattleScene();

            BattleModel.ins.viewportHeight = SceneModel.ins.battleCam.GetComponent<Camera>().orthographicSize * 2;
            //BattleModel.ins.viewportWidth = BattleModel.ins.viewportHeight * Screen.width / Screen.height;
            BattleModel.ins.viewportWidth = BattleModel.ins.viewportHeight * UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight;

            //AvatarTextManager.Ins.avatarCam = SceneModel.ins.battleCam.GetComponent<Camera>();
            AvatarTextManager.Ins.SetActive(true);

            BattleModel.ins.curRoundStatus = BattleRoundStatusType.NONE;

            mIsBattleFinished = false;

            //BattleModel.ins.battleSpeed = 1f;
            //BattleModel.ins.isAutoBattle = true;

            //Time.timeScale = BattleModel.ins.battleSpeed;
            mIsWaitingToExit = false;
            mIsForceFinishByServer = false;
            /*
            BattleModel.ins.isBattleStartEffectPlaied = false;
            BattleModel.ins.isBattleStartEffectPlayFinished = false;
            BattleModel.ins.isFirstRoundIsInitRound = (BattleModel.ins.roundData[0].isInitRound);
            */
            //ZoneUI.ins.hideAll();
            //ZoneUI.ins.Init();
            List<string> list = new List<string>();
            list.Add(ZoneUI.USER_INFO);
            list.Add(ZoneUI.CHAT_INFO);

            ZoneUI.ins.Init();
            ZoneUI.ins.showPart(list);
            BattleUI.ins.Init();
            /*
            if (BattleModel.ins.isFirstRoundIsInitRound)
            {
                if (BattleUI.ins.isShown)
                {
                    BattleUI.ins.ui.SetActive(false);
                }
                CreateBattleStartEffect();
                mPlayBattleStartEffectDelayFramesLeft = 0;
                mNeedPlayBattleStartEffect = true;
            }
            else
            {
                mNeedPlayBattleStartEffect = false;
            }
            */
        }

        /*
        public GameObject CreateBattleStartEffect()
        {
            if (mBattleStartEffect == null)
            {
                mBattleStartEffect = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath("common_kaishizhandou"));
            }

            if (SceneModel.ins.battleContainer != null && mBattleStartEffect.transform.parent != SceneModel.ins.battleContainer.transform)
            {
                mBattleStartEffect.transform.SetParent(SceneModel.ins.battleContainer.transform);
                mBattleStartEffect.transform.localPosition = new Vector3(0, 2, 0);
                if (mBattleStartEffect.layer != SceneModel.ins.battleModelContainer.layer)
                {
                    GameObjectUtil.SetLayer(mBattleStartEffect, SceneModel.ins.battleModelContainer.layer);
                }

                if (SceneModel.ins.battleCam != null)
                {
                    mBattleStartEffect.transform.localEulerAngles = SceneModel.ins.battleCam.transform.localEulerAngles;
                }
            }
            mBattleStartEffect.SetActive(false);
            return mBattleStartEffect;
        }

        private void PlayBattleStartEffect()
        {
            mBattleStartEffectSecondsLeft = 1.5f;
            mBattleStartEffect.SetActive(true);
            BattleModel.ins.isPlayingBattleStartEffect = true;
            BattleModel.ins.isBattleStartEffectPlaied = true;
        }
        */

        public void ExitBattleState()
        {
            Time.timeScale = 1.0f;
            m_bIsBattle = false;
            EventCore.dispathRMetaEventByParms(Exit_Battle, null);
            BattleCharacterManager.ins.DestroyCharacters();
            if (BattleModel.ins.canUpdate)
            {
                BattleModel.ins.roundData.Clear();
            }
            BattleUI.ins.hide();
            //ZoneUI.ins.showAll();
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.NONE;
            BattleModel.ins.SetAllResDisposable(true);
            //MemCache.DestroyFreePools();
            mIsWaitingToExit = false;
            mIsForceFinishByServer = false;
            /*
            if (mBattleStartEffect != null)
            {
                mBattleStartEffect.transform.SetParent(GameClient.ins.cachedDisplayModels.transform);
                mBattleStartEffect.SetActive(false);
            }
            BattleModel.ins.isPlayingBattleStartEffect = false;
            */
            BattleModel.ins.deadPetIds.Clear();
        }

        public void Update()
        {
            if (!BattleModel.ins.canUpdate)
            {
                return;
            }
            /*
            if (mNeedPlayBattleStartEffect)
            {

                if (mPlayBattleStartEffectDelayFramesLeft > 0)
                {
                    mPlayBattleStartEffectDelayFramesLeft--;
                    return;
                }

                PlayBattleStartEffect();
                mNeedPlayBattleStartEffect = false;
            }

            if (mBattleStartEffectSecondsLeft > 0)
            {
                mBattleStartEffectSecondsLeft -= Time.deltaTime;

                if (mBattleStartEffectSecondsLeft <= 0)
                {
                    if (mBattleStartEffect != null)
                    {
                        mBattleStartEffect.SetActive(false);
                        // GameObject.DestroyImmediate(mBattleStartEffect, true);
                    }

                    BattleModel.ins.isPlayingBattleStartEffect = false;
                    BattleModel.ins.isBattleStartEffectPlayFinished = true;
                    
                    //if (BattleUI.ins.ui != null)
                    //{
                    //    BattleUI.ins.ui.SetActive(true);
                    //}
                }

                return;
            }
            */
            BattleCharacterManager.ins.Update();

            if (!mIsBattleFinished)
            {
                BattleUI.ins.Update();

                if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.NONE || 
                    BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH || 
                    BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_REQUESTING)
                {
                    /*
                    if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH)
                    {
                        if (BattleModel.ins.isFirstRoundIsInitRound)
                        {
                            if (!BattleModel.ins.isPlayingBattleStartEffect && !BattleModel.ins.isBattleStartEffectPlaied)
                            {
                                ShowBattleStartEffect();
                                BattleModel.ins.isBattleStartEffectPlaied = true;
                            }
                        }
                    }
                    */
                    /*
                    if (BattleModel.ins.isPlayingBattleStartEffect)
                    {
                        return;
                    }
                    */

                    if (BattleModel.ins.curRoundWaitTimeLeft == BattleDef.MANUAL_ROUND_CD_SECONDS)
                    {
                        BattleUI.ins.UpdateJiaSuBtnStatus();
                        BattleCharacterManager.ins.ShowAllPrepareSign();
                        Time.timeScale = 1.0f;
                        if ((BattleModel.ins.battleType == BattleType.PVP || BattleModel.ins.battleType == BattleType.TEAM_PVP) && BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH)
                        {
                            //BattleModel.ins.battleSpeed = 1.0f;
                            BattleModel.ins.curRoundData.pvpRoundFinishClientTime = Time.unscaledTime;
                        }
                    }

                    if (BattleModel.ins.curRoundWaitTimeLeft == BattleDef.MANUAL_ROUND_CD_SECONDS)
                    {
                        //pve和team_pve 第一回合开始 每个怪物说话
                        if (BattleModel.ins.battleType == BattleType.PVE || BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                        {
                            if (BattleModel.ins.curRoundData.isInitRound)
                            {
                                int cout = BattleCharacterManager.ins.defenders.Count;
                                for (int i = 0; i < cout; i++)
                                {
                                    BattleCharacterManager.ins.defenders[i].TryShowMonsterChat();
                                }
                            }
                        }
                    }

                    TryStartNextRound();
                }


                if (BattleModel.ins.roundData.Count == 0)
                {
                    if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.NONE)
                    {
                        RequestNextRound();
                    }
                    else if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH)
                    {
                        if (BattleModel.ins.curRoundData.isFinalRound)
                        {
                            BattleFinish(false);
                        }
                        else
                        {
                            if (BattleModel.ins.curRoundData.isStatusRound)
                            {
                                BattleModel.ins.curRoundNum = BattleModel.ins.curRoundData.roundNum;
                            }
                            else
                            {
                                BattleModel.ins.curRoundNum = BattleModel.ins.curRoundData.roundNum + 1;
                            }

                            if (BattleModel.ins.battleSubType != BattleSubType.MANUAL)
                            {
                                if (BattleModel.ins.curRoundWaitTimeLeft < (BattleDef.MANUAL_ROUND_CD_SECONDS - BattleDef.AUTO_ROUND_CD_SECONDS))
                                {
                                    RequestNextRound();
                                }
                                else
                                {
                                    BattleModel.ins.curRoundWaitTimeLeft -= Time.deltaTime;
                                }
                            }
                            else
                            {
                                if (BattleModel.ins.curRoundWaitTimeLeft <= 0)
                                {
                                    RequestNextRound();
                                }
                                else
                                {
                                    BattleModel.ins.curRoundWaitTimeLeft -= Time.deltaTime;
                                }
                            }

                            if (BattleModel.ins.curRoundWaitTimeLeft < 0)
                            {
                                BattleModel.ins.curRoundWaitTimeLeft = 0;
                            }
                        }
                    }
                }

                /*
                BatCharacter mainRole = BattleCharacterManager.ins.mainRole;
                BatCharacter mainPet = BattleCharacterManager.ins.mainPet;

                if (mainRole != null)
                {
                    ZoneUI.ins.UpdateRoleInfo((float)mainRole.curHP / (float)mainRole.data.maxHp, 
                        (float)mainRole.curMP / (float)mainRole.data.maxMp,
                        (float)mainRole.curSP / (float)mainRole.data.maxSp);
                }

                if (mainPet != null)
                {
                    ZoneUI.ins.UpdatePetInfo((float)mainPet.curHP / (float)mainPet.data.maxHp, 
                        (float)mainPet.curMP / (float)mainPet.data.maxMp,
                        (float)mainPet.curSP / (float)mainPet.data.maxSp);
                }
                */
                BattleModel.ins.battleTime += Time.deltaTime;
            }
            else
            {
                mExitStateDelay -= Time.deltaTime;
                if (mExitStateDelay <= 0 && !mIsWaitingToExit)
                {
                    Time.timeScale = 1f;
                    mIsWaitingToExit = true;
                    if (mIsForceFinishByServer)
                    {
                        StateManager.Ins.changeState(StateDef.zoneState);
                    }
                    else
                    {
                        BattleCGHandler.sendCGBattleReadReportEnd();
                        /**
                         * 退出战斗从客户端主动退改成服务器推送是因为当最后一轮战报收到，但动画还没播完的时候服务器有可能发起一个切磋，导致这场战斗动画还没播完就跳到下场战斗。
                         * 又改成客户端发送退出战斗的消息后不需要等待服务器返回就可以主动退。
                         */
                        StateManager.Ins.changeState(StateDef.zoneState);
                    }
                }
            }

            if (mCamShakeTimes > 0)
            {
                float x = UnityEngine.Random.Range(-0.12f, 0.12f);
                float z = UnityEngine.Random.Range(-0.12f, 0.12f);
                SceneModel.ins.battleCam.transform.localPosition = new Vector3(x, 1, z);
                mCamShakeTimes--;
            }
            else
            {
                if (SceneModel.ins.battleCam)
                {
                    SceneModel.ins.battleCam.transform.localPosition = new Vector3(0, 1, 0);
                }
            }
        }

        public void FixedUpdate()
        {
            if (!BattleModel.ins.canUpdate)
            {
                return;
            }
            /*
            if (mNeedPlayBattleStartEffect)
            {
                return;
            }

            if (mBattleStartEffectSecondsLeft > 0)
            {
                return;
            }
            */
            if (!mIsBattleFinished)
            {
                BattleModel.ins.battleFixedTime += Time.fixedDeltaTime / Time.timeScale;
                BattleCharacterManager.ins.FixedUpdate();
                BattleUI.ins.FixedUpdate();
            }
        }

        public void RequestNextRound()
        {
            //if (!mIsRequestingRoundData && !BattleUI.ins.UI.tempContainer.activeSelf)
            if (!mIsRequestingRoundData)
            {
                //ClientLog.Log("requestNextRound");
                mIsRequestingRoundData = true;
                int isAuto = (BattleModel.ins.battleSubType == BattleSubType.MANUAL ? 0 : 1);
                int roleSkillId = BattleModel.ins.mainRoleManualOptItem.skillId;
                int roleTargetPos = BattleModel.ins.mainRoleManualOptItem.targetPos;
                int roleItemTplId = BattleModel.ins.mainRoleManualOptItem.itemTplId;
                long summonPetUUID = BattleModel.ins.mainRoleManualOptItem.summonPetUUID;
                int petSkillId = BattleModel.ins.mainPetManualOptItem.skillId;
                int petTargetPos = BattleModel.ins.mainPetManualOptItem.targetPos;
                int petItemTplId = BattleModel.ins.mainPetManualOptItem.itemTplId;

                string logStr = "isAuto:" + isAuto + " roleSkillId:" + roleSkillId + " roleTargetPos:" + roleTargetPos + " roleItemTplId:" + roleItemTplId + " petSkillId:" + petSkillId + " petTargetPos:" + petTargetPos + " petItemTplId:" + petItemTplId + " SummonPetUUID:" + summonPetUUID;

                if (BattleModel.ins.battleType == BattleType.PVE)
                {
                    ClientLog.Log(">>>Request PVE BattleRound    " + logStr);
                    BattleCGHandler.sendCGBattleNextRound(isAuto, roleSkillId, roleTargetPos, roleItemTplId, petSkillId, petTargetPos, petItemTplId, summonPetUUID);
                }
                else if (BattleModel.ins.battleType == BattleType.PVP)
                {
                    ClientLog.Log(">>>Request PVP BattleRound    " + logStr);
                    BattleCGHandler.sendCGBattleNextRoundPvp(isAuto, roleSkillId, roleTargetPos, roleItemTplId, petSkillId, petTargetPos, petItemTplId, summonPetUUID);
                }
                else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                {
                    ClientLog.Log(">>>Request TEAM BattleRound    " + logStr);
                    BattleCGHandler.sendCGBattleNextRoundTeam(isAuto, roleSkillId, roleTargetPos, roleItemTplId, petSkillId, petTargetPos, petItemTplId, summonPetUUID);
                }

                BattleModel.ins.curRoundWaitTimeLeft = 0;
                if (BattleCharacterManager.ins.mainRole != null)
                {
                    BattleCharacterManager.ins.mainRole.SetPrepareSignActive(false);
                }
                if (BattleCharacterManager.ins.mainPet != null)
                {
                    BattleCharacterManager.ins.mainPet.SetPrepareSignActive(false);
                }
                BattleModel.ins.curRoundStatus = BattleRoundStatusType.ROUND_REQUESTING;
                //mTotalRoundStartDelay = 0;
                BattleUI.ins.UpdateJiaSuBtnStatus();
            }
        }

        public void TryStartNextRound()
        {
            BatRoundData roundData = PopRoundData();
            if (roundData != null)
            {
                BattleModel.ins.lastRoundData = BattleModel.ins.curRoundData;
                BattleModel.ins.curRoundData = roundData;
                mIsRequestingRoundData = false;
                BattleModel.ins.curRoundWaitTimeLeft = 0;
                BattleModel.ins.curRoundNum = roundData.roundNum;
                float speed = 1.0f;

                if (BattleModel.ins.battleType == BattleType.PVP)
                {
                    if (roundData.pvpRoundIsAutoBattle)
                    {
                        BattleUI.ins.AutoBattle(true);
                    }
                    else
                    {
                        BattleUI.ins.ManualBattle(true);
                    }
                    float secondsCost = roundData.secondsCost;
                    float delay = (roundData.pvpRoundBroadcastServerTime - roundData.pvpRoundCreateServerTime) / 1000.0f;
                    if (BattleModel.ins.lastRoundData != null)
                    {
                        if (roundData.pvpRoundCreateClientTime < BattleModel.ins.lastRoundData.pvpRoundFinishClientTime)
                        {
                            delay += BattleModel.ins.lastRoundData.pvpRoundFinishClientTime - (roundData.pvpRoundCreateClientTime + delay);
                        }
                    }
                    //mTotalRoundStartDelay += delay;
                    ClientLog.LogWarning("轮数：" + BattleModel.ins.curRoundNum + "    本轮战报延迟：" + (roundData.pvpRoundBroadcastServerTime - roundData.pvpRoundCreateServerTime) / 1000.0f + "    战报播放总延迟：" + delay);
                    //if (mTotalRoundStartDelay > 1.0f)
                    if (delay > 0.0f)
                    {
                        //战报延迟超过一秒，加速播动画。
                        //float secondsLeft = secondsCost - mTotalRoundStartDelay;
                        float secondsLeft = secondsCost - delay;
                        speed = secondsCost / secondsLeft;
                        if (speed == 0)
                        {
                            speed = 1;
                        }
                        else if (speed < 0 || speed > 20)
                        {
                            speed = 20;
                        }
                        ClientLog.LogWarning("总延迟超过0秒，加速播动画。播放速度：" + speed);
                        //BattleModel.ins.battleSpeed = speed;
                    }
                    else
                    {
                        ClientLog.LogWarning("总延迟不超过0秒，正常播放动画。");
                        //BattleModel.ins.battleSpeed = 1.0f;
                    }

                    //Time.timeScale = BattleModel.ins.battleSpeed;
                    //mTotalRoundStartDelay += (secondsCost / BattleModel.ins.battleSpeed);
                    //BattleCharacterManager.ins.StartRound();
                }
                else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                {
                    if (roundData.teamRoundIsAutoBattle)
                    {
                        ClientLog.LogWarning("TryStartNextRound AutoBattle");
                        BattleUI.ins.AutoBattle(true);
                    }
                    else
                    {
                        BattleUI.ins.ManualBattle(true);
                    }
                    float secondsCost = roundData.secondsCost;
                    float delay = (roundData.teamRoundBroadcastServerTime - roundData.teamRoundCreateServerTime) / 1000.0f;
                    if (BattleModel.ins.lastRoundData != null)
                    {
                        if (roundData.teamRoundCreateClientTime < BattleModel.ins.lastRoundData.teamRoundFinishClientTime)
                        {
                            delay += BattleModel.ins.lastRoundData.teamRoundFinishClientTime - (roundData.teamRoundCreateClientTime + delay);
                        }
                    }
                    //mTotalRoundStartDelay += delay;
                    ClientLog.LogWarning("轮数：" + BattleModel.ins.curRoundNum + "    本轮战报延迟：" + (roundData.teamRoundBroadcastServerTime - roundData.teamRoundCreateServerTime) / 1000.0f + "    战报播放总延迟：" + delay);
                    //if (mTotalRoundStartDelay > 1.0f)
                    if (delay > 0.0f)
                    {
                        //战报延迟超过一秒，加速播动画。
                        //float secondsLeft = secondsCost - mTotalRoundStartDelay;
                        float secondsLeft = secondsCost - delay;
                        speed = secondsCost / secondsLeft;
                        if (speed == 0)
                        {
                            speed = 1;
                        }
                        else if (speed < 0 || speed > 20)
                        {
                            speed = 20;
                        }
                        ClientLog.LogWarning("总延迟超过0秒，加速播动画。播放速度：" + speed);
                        //BattleModel.ins.battleSpeed = speed;
                    }
                    else
                    {
                        ClientLog.LogWarning("总延迟不超过0秒，正常播放动画。");
                        //BattleModel.ins.battleSpeed = 1.0f;
                    }

                    //Time.timeScale = BattleModel.ins.battleSpeed;
                    //mTotalRoundStartDelay += (secondsCost / BattleModel.ins.battleSpeed);
                    //BattleCharacterManager.ins.StartRound();
                }
                /*
                else
                {
                    BattleCharacterManager.ins.StartRound();
                }
                */
                Time.timeScale = speed * roundData.roundPlaySpeed;
                BattleCharacterManager.ins.StartRound();
                BattleUI.ins.BattleRoundStarted();
                BattleUI.ins.UpdateJiaSuBtnStatus();
                //BattleCharacterManager.ins.HideAllPrepareSign();
            }
            else
            {
                if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                {
                    BattleFinish(true);
                }
            }
        }

        public void BattleFinish(bool isForceByServer)
        {
            mIsBattleFinished = true;
            mIsForceFinishByServer = isForceByServer;
            //mTotalRoundStartDelay = 0;
            BattleModel.ins.curRoundData = null;
            BattleModel.ins.curRoundNum = 0;
            BattleModel.ins.curRoundStatus = BattleRoundStatusType.NONE;
            BattleModel.ins.curRoundWaitTimeLeft = 0;
            BattleModel.ins.roundData.Clear();
            BattleModel.ins.battleSubType = BattleSubType.NONE;
            
            mIsWaitingToExit = false;
            mExitStateDelay = 0.2f;
            if (isForceByServer)
            {
                StateManager.Ins.changeState(StateDef.zoneState);
            }
        }

        public void ParseWholeBattleReportData(string dataPack)
        {
            ClientLog.Log(dataPack);
            IList datas = (IList)(Json.Deserialize(dataPack));
            int len = datas.Count;
            for (int i = 0; i < len; i++)
            {
                IDictionary data = (IDictionary)(Json.Deserialize((string)datas[i]));
                BatRoundData roundData = new BatRoundData();
                roundData.Parse(data);
                PushRoundData(roundData);
            }
        }

        /// <summary>
        /// 解析一条服务器传来的回合数据。
        /// </summary>
        /// <param name="dataPack">Data pack.</param>
        public BatRoundData ParseRoundData(string dataPack)
        {
            IDictionary data = (IDictionary)(Json.Deserialize(dataPack));
            BatRoundData roundData = new BatRoundData();
            roundData.Parse(data);
            PushRoundData(roundData);
            
            ClientLog.Log("=========== ROUND " + roundData.roundNum + " ===========");
            ClientLog.Log(dataPack);

            //Logger.Ins.WriteLogToFile(Logger.Ins.getLogDir() + "/battleReport.txt", "BATTLE ROUND " + roundData.roundNum + "=>" + dataPack);

            return roundData;
        }

        public void ParseBattleRewardData(string dataPack)
        {
            /*
            if (dataPack != null && dataPack.Length > 0)
            {
                ClientLog.Log("========== BATTLE RESULT==========");
                ClientLog.Log(dataPack);
                
                IDictionary data = (IDictionary)(Json.Deserialize(dataPack));

                RewardData rewardData = new RewardData();
                rewardData.ParseBattle(data);
                mPlayerModel.rewardDatas.Add(rewardData);
                //Logger.Ins.WriteLogToFile(Logger.Ins.getLogDir() + "/battleReport.txt", "BATTLE RESULT=>" + dataPack);
            }
            */
        }

        private void PushRoundData(BatRoundData roundData)
        {
            //ClientLog.Log("PushRoundData");
            BattleModel.ins.roundData.Add(roundData);
            
            BattleModel.ins.BattleResult = roundData.battleResult;
            if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
            {
                BattleModel.ins.useItemTimeLeft = JsonHelper.GetIntData(BattleReportDef.BATTLE_LEFT_USEDRUGS_NUM.ToString(), roundData.attakerStatusAdd);
            }
            else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
            {
                BattleModel.ins.useItemTimeLeft = JsonHelper.GetIntData(BattleReportDef.BATTLE_LEFT_USEDRUGS_NUM.ToString(), roundData.defenderStatusAdd);
            }
        }

        private BatRoundData PopRoundData()
        {
            if (BattleModel.ins.roundData.Count > 0)
            {
                BatRoundData data = BattleModel.ins.roundData[0];
                BattleModel.ins.roundData.RemoveAt(0);
                return data;
            }
            return null;
        }

        public void UpdateMainRoleInfo(BatCharacter mainRole)
        {
            ZoneUI.ins.UpdateRoleInfo((float)mainRole.curHP / (float)mainRole.data.maxHp,
                        (float)mainRole.curMP / (float)mainRole.data.maxMp,
                        (float)mainRole.curSP / (float)mainRole.data.maxSp);

            if (BattleModel.ins.roleInfoView != null)
            {
                BattleModel.ins.roleInfoView.UpdateRoleInfoInBattle();
            }
            
        }

        public void UpdateMainPetInfo(BatCharacter mainPet)
        {
            if (mainPet == null)
            {
                ClientLog.LogError("mainPet is null");
                return;
            }
            if (Human.Instance.PetModel.getChongWu() == null || Human.Instance.PetModel.getChongWu().Id != mainPet.data.uuidL)
            {
                Human.Instance.PetModel.UpdatePetFightState(mainPet.data.uuidL, 1);
            }
            else
            {
                ZoneUI.ins.UpdatePetInfo((float)mainPet.curHP / (float)mainPet.data.maxHp,
                            (float)mainPet.curMP / (float)mainPet.data.maxMp,
                            (float)mainPet.curSP / (float)mainPet.data.maxSp);
            }
        }

        public void PlayBattleReport(string pack)
        {
            BattleModel.ins.battleType = BattleType.PLAY_BATTLE_REPORT;
            BattleModel.ins.selfSiteType = BatCharacterSiteType.NONE;
            BattleManager.ins.ParseWholeBattleReportData(pack);
           // BattleModel.ins.battleToBackType = msg.getToBackType();
            if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            {
                StateManager.Ins.changeState(StateDef.battleState);
            }
        }

        public void ShakeCamera()
        {
            mCamShakeTimes = 8;
        }
    }
}