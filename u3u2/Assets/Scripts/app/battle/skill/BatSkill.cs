using System.Collections.Generic;
using UnityEngine;
using app.avatar;
using app.db;
using app.utils;
using app.zone;
using app.pet;

namespace app.battle
{
    public class BatSkill
    {
        public bool isAnimFinished { get; private set; }
        public bool isDestroied { get; private set; }
        public BatCharacter host { get; private set; }
        public BatRoundSkillData data { get; private set; }
        private List<BatSkillTarget> mTargets = null;
        private BatSkillPerformance mPerform = null;
        //private List<BatCharacter> mTargets = null;
        private SkillPerformTemplate mPerformTpl = null;
        private bool mIsReadyStart = false;
        private bool mIsStarted = false;
        private float mSkillStartDelay = 0f;

        public BatSkill(BatCharacter host, BatRoundSkillData data)
        {
            this.host = host;
            this.data = data;

            if (data.skillTpl != null && data.doPerform && data.skillTpl.notNeedShow == 0)
            {
                if (data.skillTpl.Id == BatSkillID.CATCH || data.skillTpl.Id == BatSkillID.ESCAPE)
                {
                    mPerform = new BatSkillPerformance(this, null);
                }
                else
                {
                    if (data.skillTpl.Id == BatSkillID.USE_ITEM || data.skillTpl.Id == BatSkillID.SUMMON)
                    {
                        mPerformTpl = SkillPerformTemplateDB.Instance.getTemplateByComposeId(host.displayModelId + BatSkillID.NORMAL_ATTACK);
                    }
                    else
                    {
                        if (data.skillEffects.Count > 0)
                        {
                            int len = data.skillEffects.Count;
                            for (int i = len - 1; i >= 0; i--)
                            {
                                mPerformTpl = SkillPerformTemplateDB.Instance.getTemplateByComposeIdAndEffectId(host.displayModelId + data.skillTpl.Id, data.skillEffects[i]);
                                if (mPerformTpl != null)
                                {
                                    break;
                                }
                            }
                            if (mPerformTpl == null)
                            {
                                mPerformTpl = SkillPerformTemplateDB.Instance.getTemplateByComposeId(host.displayModelId + data.skillTpl.Id);
                            }
                        }
                        else
                        {
                            mPerformTpl = SkillPerformTemplateDB.Instance.getTemplateByComposeId(host.displayModelId + data.skillTpl.Id);
                        }
                    }

                    if (mPerformTpl != null)
                    {
                        mPerform = new BatSkillPerformance(this, mPerformTpl);
                    }
                }
            }

            if (data.results != null)
            {
                mTargets = new List<BatSkillTarget>();
                int len = data.results.Count;
                for (int i = 0; i < len; i++)
                {
                    BatSkillTarget target = new BatSkillTarget(data.results[i]);
                    mTargets.Add(target);
                }
            }
        }

        public void Start()
        {
            mIsStarted = false;
            isDestroied = false;
            mSkillStartDelay = 0f;
            mIsReadyStart = false;

            if (mPerform == null)
            {
                int len = mTargets.Count;
                for (int i = 0; i < len; i++)
                {
                    ImpactTarget(mTargets[i], 1, 1);
                }
                Destroy();
            }
            else
            {
                /*
                mTargets = new List<BatCharacter>();
                int len = mData.results.Count;
                for (int i = 0; i < len; i++)
                {
                    mTargets.Add(mData.results[i].target);
                }
                */
                
                /*
                if (data.skillTpl.Id == BatSkillID.CATCH || 
                    data.skillTpl.Id == BatSkillID.ESCAPE || 
                    data.skillTpl.Id == BatSkillID.USE_ITEM || 
                    data.skillTpl.Id == BatSkillID.SUMMON)
                {
                    mIsReadyStart = true;
                }
                else
                {
                    LoadRes();
                }
                */
                LoadRes();
            }
        }

        private void LoadRes()
        {
            List<string> resPathes = new List<string>();
            if (mPerformTpl != null)
            {
                string path = null;
                List<SkillPerformEffectItemTemplate> effectItemList = mPerformTpl.effectItemList;
                int len = effectItemList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (PropertyUtil.IsLegalID(effectItemList[i].effectId))
                    {
                        path = PathUtil.Ins.GetEffectPath(effectItemList[i].effectId);
                        if (!resPathes.Contains(path))
                        {
                            resPathes.Add(path);
                        }
                    }
                }

                if (PropertyUtil.IsLegalID(mPerformTpl.blowEffectId))
                {
                    path = PathUtil.Ins.GetEffectPath(mPerformTpl.blowEffectId);
                    if (!resPathes.Contains(path))
                    {
                        resPathes.Add(path);
                    }
                }  
            }

            int resCount = resPathes.Count;

            if (resCount > 0)
            {
                List<object[]> loadList = new List<object[]>();
                for (int i = 0; i < resCount; i++)
                {
                    loadList.Add(new object[]{resPathes[i], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
                }
                SourceLoader.Ins.loadList(loadList, OnAllResLoaded, OnOneResLoaded);
            }
            else
            {
                OnAllResLoaded(null);
            }
        }

        private void OnOneResLoaded(RMetaEvent e)
        {
            if (SourceLoader.Ins.IsLoadSuccess(e))
            {
                LoadInfo info = (LoadInfo)((e.data as List<object>)[2]);
                string path = info.urlPath;
                BattleModel.ins.SetResUndisposable(path);
            }
        }

        private void OnAllResLoaded(RMetaEvent e)
        {
            mIsReadyStart = true;
            //DoStart();
        }

        private void DoStart()
        {
            mIsStarted = true;
            mSkillStartDelay = 0f;

            if (mPerform == null)
            {
                Destroy();
            }
            else
            {
                mPerform.Start(host, mTargets);

                int len = this.data.results.Count;
                for (int i = 0; i < len; i++)
                {
                    BatRoundSkillResultData data = this.data.results[i];

                    if (data.target.HasBuffTplID(BatBuffID.DEFENSE))
                    {
                        if (data.target.isAlive)
                        {
                            data.target.DoDefense();
                        }
                    }
                    
                    if (!string.IsNullOrEmpty(data.errorMsg))
                    {
                        if (host.data.type == PetType.LEADER)
                        {
                            if (host.data.uuidL == PetModel.Ins.getLeader().Id)
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg(data.errorMsg);
                            }
                        }
                        else if (host.data.type == PetType.PET)
                        {
                            Pet myFightPet = PetModel.Ins.getChongWu();
                            if (myFightPet != null && host.data.uuidL == myFightPet.Id)
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg(data.errorMsg);
                            }
                        }
                        
                    }
                }
            }
        }

        public void Update()
        {
            if (mIsStarted)
            {
                if (!isDestroied)
                {
                    mPerform.Update();
                    if (mPerform.isAnimFinished)
                    {
                        isAnimFinished = true;
                    }
                    else
                    {
                        isAnimFinished = false;
                    }

                    if (mPerform.isSkillAnimFinished)
                    {
                        int len = this.data.results.Count;
                        for (int i = 0; i < len; i++)
                        {
                            BatRoundSkillResultData data = this.data.results[i];

                            if (data.target.HasBuffTplID(BatBuffID.DEFENSE) && data.target.curAnimName == AvatarBase.ANIM_NAME_DEFENSE)
                            {
                                if (data.target.isAlive)
                                {
                                    data.target.Idle();
                                }
                            }
                        }
                    }

                    if (isAnimFinished)
                    {
                        int len = this.data.results.Count;
                        for (int i = 0; i < len; i++)
                        {
                            BatRoundSkillResultData data = this.data.results[i];
                            if (data.counterattack != null)
                            {
                                data.counterattack.host.Counterattack(data.counterattack);
                            }
                        }

                        if (mPerform.isCanDestroy)
                        {
                            Destroy();
                        }
                    }
                }
            }
            else
            {
                if (mSkillStartDelay >= BattleDef.SKILL_START_DELAY)
                {
                    if (mIsReadyStart)
                    {
                        DoStart();
                    }
                }
                else
                {
                    mSkillStartDelay += Time.deltaTime;
                }
            }
        }

        public void FixedUpdate()
        {
            if (mIsStarted && !isDestroied)
            {
                mPerform.FixedUpdate();
            }
        }

        /// <summary>
        /// 技能目标受击后数值变化。
        /// </summary>
        /// <param name="target">Target.</param>
        /// <param name="impactTime">Impact time.</param>
        /// <param name="totalImpactTime">Total impact time.</param>
        public void ImpactTarget(BatSkillTarget target, int impactTime, int totalImpactTime)
        {
            if (data.skillTpl.Id == BatSkillID.SUMMON)
            {
                //召唤
                ClientLog.Log("Summon host:" + host.data.uuidS + " target:" + target.targetUUID);
                if (target.isSummonSuccess)
                {
                    BatCharacter summonTarget = BattleCharacterManager.ins.GetCharacter(target.summonResultStatusData.uuidS);
                    if (summonTarget == null)
                    {
                        //召唤前没有宠物。
                        if (host.siteType == BatCharacterSiteType.ATTACKER)
                        {
                            BattleCharacterManager.ins.InsertNewAttacker(target.summonResultStatusData);
                        }
                        else if (host.siteType == BatCharacterSiteType.DEFENDER)
                        {
                            BattleCharacterManager.ins.InsertNewDefender(target.summonResultStatusData);
                        }
                    }
                    else
                    {
                        //召唤前有宠物，需要将之前的宠物替换。
                        summonTarget.Init(target.summonResultStatusData, target.character.siteType);
                        summonTarget.UpdateAvatarName();
                    }
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("召唤宠物失败");
                }

                return;
            }

            ClientLog.Log("ImpactTarget host:" + host.data.uuidS + " target:" + target.character.data.uuidS);

            if (data.skillTpl.Id == BatSkillID.ESCAPE)
            {
                target.character.DoEscape(target.isEscaped);
                return;
            }

            int hpDiff = target.hpDiff;
            int mpDiff = target.mpDiff;
            int spDiff = target.spDiff;

            if (totalImpactTime > 1)
            {
                if (impactTime == totalImpactTime)
                {
                    hpDiff = hpDiff - (int)(hpDiff / totalImpactTime) * (totalImpactTime - 1);
                    mpDiff = mpDiff - (int)(mpDiff / totalImpactTime) * (totalImpactTime - 1);
                    spDiff = spDiff - (int)(spDiff / totalImpactTime) * (totalImpactTime - 1);
                }
                else
                {
                    hpDiff = (int)(hpDiff / totalImpactTime);
                    mpDiff = (int)(mpDiff / totalImpactTime);
                    spDiff = (int)(spDiff / totalImpactTime);
                }
            }

            if (impactTime == totalImpactTime)
            {
                target.character.ImpactedBySkill(hpDiff, mpDiff, spDiff, target.buffData, target.isCrit, target.isDodgy, target.isDefense, target.isDeadFly, host.data.attackType, target.isNoBubble);
                if (target.chivalricStatusChanged)
                {
                    target.character.UpdateChivalric(target.hasChivalric, target.chivalricId);
                }
            }
            else
            {
                target.character.ImpactedBySkill(hpDiff, mpDiff, spDiff, null, target.isCrit, target.isDodgy, target.isDefense, false, host.data.attackType, target.isNoBubble);
            }
        }

        public void Destroy()
        {
            if (!isDestroied)
            {
                isDestroied = true;

                this.data.isDone = true;

                if (mPerform != null)
                {
                    mPerform.Destroy();
                    mPerform = null;
                }

                this.data = null;
            }
        }
    }
}