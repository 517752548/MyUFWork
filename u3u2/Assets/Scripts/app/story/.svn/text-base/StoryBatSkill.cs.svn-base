using System.Collections.Generic;
using app.battle;
using UnityEngine;
using app.db;
using app.utils;

namespace app.story
{
    public class StoryBatSkill
    {
        //攻击方
        public StoryBattleAvatar host { get; private set; }
        //剧情模板
        public StoryBattleTemplate storyTpl { get; private set; }
        //技能模板
        public SkillTemplate skillTpl { get; private set; }
        //技能表现模板
        private SkillPerformTemplate mPerformTpl = null;
        //目标列表
        private List<StoryBattleAvatar> mTargets = null;
        //当前技能执行状态
        private StoryBatSkillStatus status = StoryBatSkillStatus.none;

        private Vector3 mEffectOffset = Vector3.zero;//new Vector3(-0.25f, 0, -0.25f);

        private List<EffectConfig> mEffectConfigs = new List<EffectConfig>();
        private List<BatEffectBase> mEffects= new List<BatEffectBase>();
        private List<SoundConfig> mSoundConfigs = new List<SoundConfig>();
        //已经经过的时间
        private float mFixedTimePassed;
        private bool hasShouji = false;
        private bool hasPlayEffect = false;
        private bool hasPlaySound = false;

        public StoryBatSkill(StoryBattleAvatar host,StoryBattleTemplate storyTpl)
        {
            this.host = host;
            this.storyTpl = storyTpl;
            skillTpl = SkillTemplateDB.Instance.getTemplate(storyTpl.skillId);
            if (skillTpl != null && skillTpl.notNeedShow == 0)
            {
                mPerformTpl = SkillPerformTemplateDB.Instance.getTemplateByComposeId(host.displayModelId + storyTpl.skillId);
            }
            InitEffectCfgs();
            InitSoundCfgs();
            mTargets = new List<StoryBattleAvatar>();
            if (storyTpl.skillTargets.Contains(","))
            {//多体目标
                string[] strarr = storyTpl.skillTargets.Split(',');
                foreach (string s in strarr)
                {
                    StoryBattleAvatar sba = StoryManager.ins.GetBattleAvatar(s);
                    if (sba!=null)
                    {
                        mTargets.Add(sba);
                    }
                }
            }
            else
            {//单体目标
                StoryBattleAvatar sba = StoryManager.ins.GetBattleAvatar(storyTpl.skillTargets);
                if (sba != null)
                {
                    mTargets.Add(sba);
                }
            }
            status = StoryBatSkillStatus.none;
        }

        private void InitEffectCfgs()
        {
            mEffectConfigs.Clear();
            int len = mPerformTpl.effectItemList.Count;
            for (int i = 0; i < len; i++)
            {
                SkillPerformEffectItemTemplate effectItemTpl = mPerformTpl.effectItemList[i];
                if (PropertyUtil.IsLegalID(effectItemTpl.effectId) &&
                    PropertyUtil.IsLegalID(effectItemTpl.effectShowTargetType) &&
                    PropertyUtil.IsLegalID(effectItemTpl.effectImpactTargetType))
                {
                    EffectConfig effectCfg = new EffectConfig();
                    effectCfg.effectId = effectItemTpl.effectId;
                    effectCfg.type = (SkillEffectType)effectItemTpl.effectType;
                    effectCfg.target = (SkillEffectShowTarget)effectItemTpl.effectShowTargetType;
                    effectCfg.pos = (SkillEffectPosType)effectItemTpl.effectShowPosType;
                    effectCfg.impactTargetType = (SkillEffectImpactTargetType)effectItemTpl.effectImpactTargetType;
                    effectCfg.showTime = effectItemTpl.effectShowTime;
                    effectCfg.isShown = false;
                    mEffectConfigs.Add(effectCfg);
                }
            }
        }

        private void InitSoundCfgs()
        {
            mSoundConfigs.Clear();
            int len = mPerformTpl.soundItemList.Count;
            for (int i = 0; i < len; i++)
            {
                SkillPerformSoundItemTemplate soundItemTpl = mPerformTpl.soundItemList[i];
                if (PropertyUtil.IsLegalID(soundItemTpl.soundId) && soundItemTpl.soundStartTime >= 0f)
                {
                    SoundConfig soundCfg = new SoundConfig();
                    soundCfg.soundId = soundItemTpl.soundId;
                    soundCfg.startTime = soundItemTpl.soundStartTime;
                    soundCfg.isLoop = (soundItemTpl.isLoop == 0 ? false : true);
                    soundCfg.isPlayed = false;
                    mSoundConfigs.Add(soundCfg);
                }
            }
        }

        public void Start()
        {
            LoadRes();
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
                status = StoryBatSkillStatus.loadingRes;
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
            status = StoryBatSkillStatus.loadResEnd;
            if (mPerformTpl.isNearAttack == 1)
            {
                host.LookAt(mTargets[0].globalPosition);
                RunToEnemy();
            }
            else
            {
                ArrivedEnemy();
            }
        }

        private void RunToEnemy()
        {
            host.PlayAnimation(StoryBattleAvatar.ANIM_NAME_MOVE);
            Vector3 pos = mTargets[0].localPosition;
            pos += mTargets[0].forward * (host.displayModel.radiusFront + mTargets[0].displayModel.radiusFront + 0.35f);
            //mHost.LookAt(pos);
            float dist = Vector3.Distance(host.localPosition, pos);
            float time = dist / BattleDef.CHARACTER_MOVE_SPEED;
            //ClientLog.Log("RunToEnemy dist:" + dist + " time:" + time);
            //mAnim = mHost.PlayAnimation(CharacterBase.ANIM_NAME_MOVE);
            TweenUtil.MoveTo(host.displayModelContainer.transform, pos, time, null, ArrivedEnemy);
            status= StoryBatSkillStatus.isMovingToTarget;
        }

        private void ArrivedEnemy()
        {
            status = StoryBatSkillStatus.arrivedTarget;
            DoPerform();
        }

        private void DoPerform()
        {
            mFixedTimePassed = 0;
            hasShouji = false;
            hasPlayEffect = false;
            hasPlaySound = false;

            status = StoryBatSkillStatus.isStartAttack;
            host.PlayAnimation(mPerformTpl.actionId);

            if (skillTpl != null && skillTpl.needShowOnRelease == 1 && !string.IsNullOrEmpty(skillTpl.bubble))
            {
                host.ShowSkillName(skillTpl.bubble, PathUtil.Ins.skillNameAtlasPath);
            }
        }

        private void CheckEffectShow()
        {
            int effectsLen = mEffectConfigs.Count;
            for (int i = 0; i < effectsLen; i++)
            {
                EffectConfig cfg = mEffectConfigs[i];
                if (!cfg.isShown)
                {
                    if (cfg.target == SkillEffectShowTarget.SELF)
                    {
                        BatEffectBase effect = ShowEffect(cfg, host);
                    }
                    else if (cfg.target == SkillEffectShowTarget.ENEMY_SKILL_TARGET)
                    {
                        if (cfg.impactTargetType == SkillEffectImpactTargetType.ALL && mTargets != null && mTargets.Count>0)
                        {
                            BatEffectBase effect = ShowEffect(cfg, mTargets[0]);
                        }
                        else if (cfg.impactTargetType == SkillEffectImpactTargetType.EACH)
                        {
                            int len = mTargets != null?mTargets.Count:0;
                            for (int j = 0; j < len; j++)
                            {
                                StoryBattleAvatar target = mTargets[j];
                                BatEffectBase effect = ShowEffect(cfg, target);
                            }
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.SELF_SKILL_TARGET)
                    {
                        if (cfg.impactTargetType == SkillEffectImpactTargetType.ALL && mTargets != null && mTargets.Count > 0)
                        {
                            BatEffectBase effect = ShowEffect(cfg, mTargets[0]);
                        }
                        else if (cfg.impactTargetType == SkillEffectImpactTargetType.EACH)
                        {
                            int len = mTargets != null ? mTargets.Count : 0;
                            for (int j = 0; j < len; j++)
                            {
                                StoryBattleAvatar target = mTargets[j];
                                BatEffectBase effect = ShowEffect(cfg, target);
                            }
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.FULL_SCREEN && mTargets != null && mTargets.Count > 0)
                    {
                        BatEffectBase effect = ShowEffect(cfg, mTargets[0]);
                    }
                    else if (cfg.target == SkillEffectShowTarget.ALL_TARGETS)
                    {
                    }
                }
            }
        }

        private BatEffectBase ShowEffect(EffectConfig cfg, StoryBattleAvatar effectShowTarget)
        {
            BatEffectBase effect = null;
            effect = BatEffectHelper.CreateBatEffectBase(cfg.effectId);
            effect.SetLayer(LayerConfig.Layer_StoryModel);
            mEffects.Add(effect);

            if (effect != null)
            {
                effect.SetActive(false);
            }
            if (effectShowTarget == null)
            {
                GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);

                if (cfg.target == SkillEffectShowTarget.SELF_SKILL_TARGET)
                {
                    if (host.CurData.posX == 1)
                    {
                        effect.displayModel.transform.localPosition = mEffectOffset;//StoryDef.atkPosList[3] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                    }
                    else
                    {
                        effect.displayModel.transform.localPosition = mEffectOffset;//StoryDef.defPosList[3] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                    }
                }
                else if (cfg.target == SkillEffectShowTarget.ENEMY_SKILL_TARGET)
                {
                    if (host.CurData.posX == 1)
                    {
                        effect.displayModel.transform.localPosition = mEffectOffset;//StoryDef.defPosList[3] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                    }
                    else
                    {
                        effect.displayModel.transform.localPosition = mEffectOffset;//StoryDef.atkPosList[3] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                    }
                }
                else if (cfg.target == SkillEffectShowTarget.FULL_SCREEN)
                {

                }
            }
            else
            {
                switch (cfg.pos)
                {
                    case SkillEffectPosType.GROUND:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        effect.displayModel.transform.localPosition = mEffectOffset;//effectShowTarget.localPosition + mEffectOffset;
                        if (effectShowTarget.CurData.posX == 1)
                        {
                            effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                        }
                        else
                        {
                            effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                        }
                        break;
                    case SkillEffectPosType.BODY:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        effect.displayModel.transform.localPosition += mEffectOffset;
                        break;
                    case SkillEffectPosType.HEAD_TOP:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        Vector3 localPos = effect.displayModel.transform.localPosition;
                        localPos.y = effectShowTarget.displayModel.totalHeight;
                        effect.displayModel.transform.localPosition = localPos;
                        break;
                    case SkillEffectPosType.LEFT_HAND:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        break;
                    case SkillEffectPosType.RIGHT_HAND:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        break;
                    case SkillEffectPosType.FIRE_ROOT:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.displayModelContainer.transform, true, true);
                        break;
                    default:
                        GameObjectUtil.Bind(effect.displayModel.transform, host.transform, true, true);
                        break;
                }
            }

            effect.displayModel.transform.localPosition += effect.orgPos;
            effect.displayModel.transform.localEulerAngles += effect.orgAngle;
            cfg.isShown = true;

            if (effect != null)
            {
                effect.SetActive(true);
            }
            return effect;
        }

        private void CheckSoundPlay()
        {
            int soundsLen = mSoundConfigs.Count;
            for (int i = 0; i < soundsLen; i++)
            {
                SoundConfig cfg = mSoundConfigs[i];
                if (!cfg.isPlayed)
                {
                    PlaySound(cfg);
                }
            }
        }

        private void PlaySound(SoundConfig cfg)
        {
            AudioManager.Ins.PlayAudio(cfg.soundId, AudioEnumType.Skill);
            cfg.isPlayed = true;
        }
        
        public void FixedUpdate()
        {
            if (status >= StoryBatSkillStatus.isStartAttack && status < StoryBatSkillStatus.skillEnd)
            {
                mFixedTimePassed += Time.fixedDeltaTime;
                if (!hasShouji&&status >= StoryBatSkillStatus.isStartAttack && status < StoryBatSkillStatus.skillEnd && mFixedTimePassed > mPerformTpl.impactStartTime)
                {
                    //执行技能效果，目标受击动作和受击特效
                    int len = mTargets.Count;
                    for (int i = 0; i < len; i++)
                    {
                        int hpDiff = storyTpl.hp;
                        mTargets[i].XPChanged(hpDiff, false, false, false, BatCharacterAttackType.STRENGTH, false);
                    }
                    status = StoryBatSkillStatus.skillStartImpact;
                    hasShouji = true;
                }
                if (!hasPlayEffect && status >= StoryBatSkillStatus.isStartAttack && status < StoryBatSkillStatus.skillEnd && mFixedTimePassed > mPerformTpl.effectItemList[0].effectShowTime)
                {
                    //播放 技能特效
                    CheckEffectShow();
                    hasPlayEffect = true;
                }
                if (!hasPlaySound && status >= StoryBatSkillStatus.isStartAttack && status < StoryBatSkillStatus.skillEnd && mFixedTimePassed > mPerformTpl.soundItemList[0].soundStartTime)
                {
                    //播放 声音
                    CheckSoundPlay();
                    hasPlaySound = true;
                }
                if (status >= StoryBatSkillStatus.skillStartImpact && mFixedTimePassed >
                    (mPerformTpl.impactStartTime + mPerformTpl.effectStopDelayTime))
                {
                    skillEnd();
                }
            }
        }

        public void skillEnd()
        {
            if (mPerformTpl.isNearAttack == 1)
            {//还原位置
                host.InitPosition();
            }
            status = StoryBatSkillStatus.skillEnd;
        }

        public void Destroy()
        {
            status = StoryBatSkillStatus.hasDestoried;
            hasShouji = false;
            hasPlayEffect = false;
            hasPlaySound = false;
            host = null;
            if(mTargets!=null)mTargets.Clear();
            mTargets = null;
            if(mEffectConfigs!=null)mEffectConfigs.Clear();
            if (mEffects != null)
            {
                for (int i = 0; i < mEffects.Count; i++)
                {
                    mEffects[i].Destroy();
                }
                mEffects.Clear();
            }
            if(mSoundConfigs!=null)mSoundConfigs.Clear();
        }

        private enum StoryBatSkillStatus
        {
            none,
            loadingRes,
            loadResEnd,
            isMovingToTarget,
            arrivedTarget,
            //开始播放攻击动作
            isStartAttack,
            //经过技能影响的时间，目标开始播放受击动作和受击特效
            skillStartImpact,
            //技能完成，此时需要把特效和音效都停止
            skillEnd,
            hasDestoried
        }

        private class EffectConfig
        {
            public string effectId = null;
            public SkillEffectType type = SkillEffectType.NONE;
            public SkillEffectShowTarget target = SkillEffectShowTarget.NONE;
            public SkillEffectPosType pos = SkillEffectPosType.NONE;
            public SkillEffectImpactTargetType impactTargetType = SkillEffectImpactTargetType.NONE;
            public float showTime = 0f;
            public bool isShown = false;
        }

        private class SoundConfig
        {
            public string soundId = null;
            public float startTime = 0f;
            public bool isLoop = false;
            public bool isPlayed = false;
        }
    }
}