using System.Collections.Generic;
using app.db;
using UnityEngine;
using app.utils;
using app.model;

namespace app.battle
{
    public class BatSkillPerformance
    {
        private SkillPerformTemplate mTpl = null;

        private float mTimePassed = 0f;
        private float mFixedTimePassed = 0f;

        //private float mStartTime = 0f;

        private BatSkill mSkill = null;
        private AnimationState mSkillAnim = null;

        private BatCharacter mHost = null;
        private List<BatSkillTarget> mTargets = null;

        private List<EffectConfig> mEffectConfigs = new List<EffectConfig>();
        private List<BatEffectBase> mEffects = new List<BatEffectBase>();
        private List<BatSkillBulletEffect> mBullets = new List<BatSkillBulletEffect>();
        private List<BatSkillImpactEffect> mImpactEffects = new List<BatSkillImpactEffect>();

        private List<SoundConfig> mSoundConfigs = new List<SoundConfig>();

        private SkillImpactEffectPosType mImpactEffectPos = SkillImpactEffectPosType.NONE;

        private int mImpactTimes = 0;

        private SkillActionType mActionType = SkillActionType.NONE;

        private bool mIsArrivedBattlePos = false;
        private bool mIsRunningBack = false;
        private bool mIsSkillAnimStarted = false;
        private bool mIsSkillAnimFinished = false;

        private Vector3 mEffectOffset = new Vector3(-0.25f, 0, -0.25f);


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

        public BatSkillPerformance(BatSkill skill, SkillPerformTemplate tpl)
        {
            mSkill = skill;
            mTpl = tpl;
            if (mTpl != null)
            {
                mActionType = (SkillActionType)tpl.actionType;
                mImpactEffectPos = (SkillImpactEffectPosType)tpl.blowEffectPosId;
                InitEffectCfgs();
                InitSoundCfgs();
            }
        }

        public void Start(BatCharacter host, List<BatSkillTarget> targets)
        {
            mHost = host;
            mTargets = targets;
            mIsSkillAnimStarted = false;
            mIsSkillAnimFinished = false;
            mTimePassed = 0f;
            mFixedTimePassed = 0f;

            if (mSkill.data.skillTpl.Id == BatSkillID.CATCH)
            {
                RunToEnemy();
            }
            else if (mSkill.data.skillTpl.Id == BatSkillID.ESCAPE)
            {
                mIsArrivedBattlePos = true;
                DoTeamEscape();
            }
            else if (mTpl != null)
            {
                if (mSkill.data.skillTpl.Id != BatSkillID.USE_ITEM && mSkill.data.skillTpl.Id != BatSkillID.SUMMON && mTpl.isNearAttack == 1)
                {
					RunToEnemy();
                }
                else
                {
                    mHost.InitPosition();
                    mIsArrivedBattlePos = true;
                    DoPerform();
                }
            }

            mIsRunningBack = false;
        }

        private void DoTeamEscape()
        {
            int len = mTargets.Count;
            for (int i = 0; i < len; i++)
            {
                mSkill.ImpactTarget(mTargets[i], 1, 1);
            }
            mIsSkillAnimFinished = true;
        }

        private void RunToEnemy()
        {
            mHost.PlayAnimation(BatCharacter.ANIM_NAME_MOVE);
            Vector3 pos = mTargets[0].character.localPosition;
            pos += mTargets[0].character.forward * (mHost.displayModel.radiusFront + mTargets[0].character.displayModel.radiusFront + 0.35f);
            //mHost.LookAt(pos);
            float dist = Vector3.Distance(mHost.localPosition, pos);
            float time = dist / BattleDef.CHARACTER_MOVE_SPEED;
            //ClientLog.Log("RunToEnemy dist:" + dist + " time:" + time);
            //mAnim = mHost.PlayAnimation(CharacterBase.ANIM_NAME_MOVE);
            TweenUtil.MoveTo(mHost.displayModelContainer.transform, pos, time, null, ArrivedEnemy);
            mIsArrivedBattlePos = false;
        }

        private void ArrivedEnemy()
        {
            if (mSkill.data.skillTpl.Id == BatSkillID.CATCH)
            {
                RunBack();
            }
            else
            {
                DoPerform();
            }
        }

        private void RunBack()
        {
            mHost.PlayAnimation(BatCharacter.ANIM_NAME_MOVE);
            //mHost.LookAt(mHost.worldBattlePos);
            //float dist = Vector3.Distance(mHost.localPosition, mHost.localBattlePos);
            //float time = dist / BattleDef.CHARACTER_MOVE_SPEED;
            if (mSkill.data.skillTpl.Id == BatSkillID.CATCH)
            {
                //mHost.LookAt(mHost.globalBattlePos);
                //time *= 6;

                int len = mTargets.Count;
                bool hasPetCaught = false;
                for (int i = 0; i < len; i++)
                {
                    mTargets[i].character.DoBeCaughtMove(mHost, mTargets[i].isBeCaught);
                    if (mTargets[i].isBeCaught)
                    {
                        hasPetCaught = true;
                    }
                    /*
                    Vector3 pos = mHost.localBattlePos;
                    if (mHost.sitePoses == BattleDef.ATTACKER_POSES)
                    {
                        pos -= mHost.forward * (mHost.radiusZ + mTargets[i].character.radiusZ);
                    }
                    else
                    {
                        pos += mHost.forward * (mHost.radiusZ + mTargets[i].character.radiusZ);
                    }
                    if (mTargets[i].character.data.status == BatCharacterStatus.BE_CAUGHT)
                    {
                        TweenUtil.MoveTo(mTargets[i].character.displayModelContainer.transform, pos, time);
                        hasPetCaught = true;
                    }
                    else
                    {
                        TweenUtil.MoveTo(mTargets[i].character.displayModelContainer.transform, pos * 0.65f, time * 0.65f, null, delegate(){
                            TweenUtil.MoveTo(mTargets[i].character.displayModelContainer.transform, mTargets[i].character.localBattlePos, time * 0.65f, null, delegate(){
                                mTargets[i].character.InitPosition();
                            });
                        });
                    }
                    */
                }

                /*
                if (hasPetCaught)
                {
                    TweenUtil.MoveTo(mHost.displayModelContainer.transform, mHost.localBattlePos, time, null, ArrivedBattlePos);
                }
                else
                {
                    TweenUtil.MoveTo(mHost.displayModelContainer.transform, mHost.localBattlePos, time, null, ArrivedBattlePos);
                }
                */
                mHost.DoCatchMoveBack(hasPetCaught, ArrivedBattlePos);
            }
            else
            {
                float dist = Vector3.Distance(mHost.localPosition, mHost.localBattlePos);
                float time = dist / BattleDef.CHARACTER_MOVE_SPEED;
                mHost.LookAt(mHost.globalBattlePos);
                TweenUtil.MoveTo(mHost.displayModelContainer.transform, mHost.localBattlePos, time, null, ArrivedBattlePos);
            }
            //ClientLog.Log("RunBack dist:" + dist + " time:" + time);
            //mAnim = mHost.PlayAnimation(CharacterBase.ANIM_NAME_MOVE);
            mIsRunningBack = true;
        }

        private void ArrivedBattlePos()
        {
            mHost.Idle();
            mHost.InitPosition();
            //mAnim = mHost.PlayAnimation(CharacterBase.ANIM_NAME_IDLE, 1f);
            mIsArrivedBattlePos = true;
            mIsRunningBack = false;

            if (mSkill.data.skillTpl.Id == BatSkillID.CATCH)
            {
                //是捕捉技能。
                int len = mTargets.Count;
                for (int i = 0; i < len; i++)
                {
                    if (mTargets[i].isBeCaught)
                    {
                        mTargets[i].character.SetActive(false);
                    }
                    /*
                    else
                    {
                        Vector3 pos = mTargets[i].character.localBattlePos;
                        float dist = Vector3.Distance(mTargets[i].character.localPosition, pos);
                        float time = dist / BattleDef.CHARACTER_MOVE_SPEED;
                        TweenUtil.MoveTo(mTargets[i].character.displayModelContainer.transform, pos, time);
                    }
                    */
                }
            }
        }

        private void DoPerform()
        {
            if (mTpl.isNearAttack == 1 && mSkill.data.skillTpl.Id != BatSkillID.USE_ITEM && mSkill.data.skillTpl.Id != BatSkillID.SUMMON)
            {
                mHost.LookAt(mTargets[0].character.globalPosition);
            }

            mSkillAnim = mHost.PlayAnimation(mTpl.actionId);
            mIsSkillAnimStarted = true;

            if (mSkillAnim == null)
            {
                int len = mTargets.Count;
                for (int i = 0; i < len; i++)
                {
                    mSkill.ImpactTarget(mTargets[i], 1, 1);
                }
            }
            else
            {
                mImpactTimes = 0;
                //mStartTime = BattleModel.ins.battleTime;
                
                /*
                if (mSkill.data.skillTpl.Id != BatSkillID.USE_ITEM && mSkill.data.skillTpl.Id != BatSkillID.SUMMON)
                {
                    CheckEffectShow();
                }
                */
                CheckEffectShow();
                CheckSoundPlay();
            }
        }

        private void InitEffectCfgs()
        {
            int len = mTpl.effectItemList.Count;
            for (int i = 0; i < len; i++)
            {
                SkillPerformEffectItemTemplate effectItemTpl = mTpl.effectItemList[i];
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
            int len = mTpl.soundItemList.Count;
            for (int i = 0; i < len; i++)
            {
                SkillPerformSoundItemTemplate soundItemTpl = mTpl.soundItemList[i];
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

        private void CheckEffectShow()
        {
            int effectsLen = mEffectConfigs.Count;
            for (int i = 0; i < effectsLen; i++)
            {
                EffectConfig cfg = mEffectConfigs[i];
                if (mFixedTimePassed >= cfg.showTime && !cfg.isShown)
                {
                    if (cfg.target == SkillEffectShowTarget.SELF)
                    {
                        BatEffectBase effect = ShowEffect(cfg, mHost);
                        if (cfg.type == SkillEffectType.BULLET)
                        {
                            List<string> impactTargetIds = new List<string>();
                            List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                            int len = mTargets.Count;
                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (!impactTargetIds.Contains(target.character.data.uuidS))
                                {
                                    impactTargets.Add(target);
                                    impactTargetIds.Add(target.character.data.uuidS);
                                }
                            }
                            ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.ENEMY_SKILL_TARGET)
                    {
                        if (cfg.impactTargetType == SkillEffectImpactTargetType.ALL)
                        {
                            BatEffectBase effect = ShowEffect(cfg, null);
                            if (cfg.type == SkillEffectType.BULLET)
                            {
                                List<string> impactTargetIds = new List<string>();
                                List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                                int len = mTargets.Count;
                                for (int j = 0; j < len; j++)
                                {
                                    BatSkillTarget target = mTargets[j];
                                    if (!impactTargetIds.Contains(target.character.data.uuidS))
                                    {
                                        impactTargets.Add(target);
                                        impactTargetIds.Add(target.character.data.uuidS);
                                    }
                                }
                                ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                            }
                        }
                        else if (cfg.impactTargetType == SkillEffectImpactTargetType.EACH)
                        {
                            List<string> effectedTargets = new List<string>();
                            int len = mTargets.Count;
                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (target.character.siteType != mHost.siteType && !effectedTargets.Contains(target.character.data.uuidS))
                                {
                                    BatEffectBase effect = ShowEffect(cfg, target.character);
                                    if (cfg.type == SkillEffectType.BULLET)
                                    {
                                        List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                                        impactTargets.Add(target);
                                        ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                                    }
                                    effectedTargets.Add(target.character.data.uuidS);
                                }
                            }
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.SELF_SKILL_TARGET)
                    {
                        if (cfg.impactTargetType == SkillEffectImpactTargetType.ALL)
                        {
                            BatEffectBase effect = ShowEffect(cfg, null);
                            if (cfg.type == SkillEffectType.BULLET)
                            {
                                List<string> impactTargetIds = new List<string>();
                                List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                                int len = mTargets.Count;
                                for (int j = 0; j < len; j++)
                                {
                                    BatSkillTarget target = mTargets[j];
                                    if (!impactTargetIds.Contains(target.character.data.uuidS))
                                    {
                                        impactTargets.Add(target);
                                        impactTargetIds.Add(target.character.data.uuidS);
                                    }
                                }
                                ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                            }
                        }
                        else if (cfg.impactTargetType == SkillEffectImpactTargetType.EACH)
                        {
                            List<string> effectedTargets = new List<string>();
                            int len = mTargets.Count;
                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (target.character.siteType == mHost.siteType && !effectedTargets.Contains(target.character.data.uuidS))
                                {
                                    BatEffectBase effect = ShowEffect(cfg, target.character);
                                    if (cfg.type == SkillEffectType.BULLET)
                                    {
                                        List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                                        impactTargets.Add(target);
                                        ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                                    }
                                    effectedTargets.Add(target.character.data.uuidS);
                                }
                            }
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.FULL_SCREEN)
                    {
                        BatEffectBase effect = ShowEffect(cfg, null);
                        if (cfg.type == SkillEffectType.BULLET)
                        {
                            List<string> impactTargetIds = new List<string>();
                            List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                            int len = mTargets.Count;
                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (!impactTargetIds.Contains(target.character.data.uuidS))
                                {
                                    impactTargets.Add(target);
                                    impactTargetIds.Add(target.character.data.uuidS);
                                }
                            }
                            ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                        }
                    }
                    else if (cfg.target == SkillEffectShowTarget.ALL_TARGETS)
                    {
                        int len = mTargets.Count;

                        if (cfg.impactTargetType == SkillEffectImpactTargetType.ALL)
                        {
                            bool hasSelfSiteTarget = false;
                            bool hasEnemySiteTarget = false;

                            List<string> selfImpactTargetIds = new List<string>();
                            List<string> enemyImpactTargetIds = new List<string>();

                            List<BatSkillTarget> selfImpactTargets = new List<BatSkillTarget>();
                            List<BatSkillTarget> enemyImpactTargets = new List<BatSkillTarget>();

                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (target.character.siteType == mHost.siteType)
                                {
                                    hasSelfSiteTarget = true;
                                    if (!selfImpactTargetIds.Contains(target.character.data.uuidS))
                                    {
                                        selfImpactTargets.Add(target);
                                        selfImpactTargetIds.Add(target.character.data.uuidS);
                                    }
                                }
                                else
                                {
                                    hasEnemySiteTarget = true;
                                    if (!enemyImpactTargetIds.Contains(target.character.data.uuidS))
                                    {
                                        enemyImpactTargets.Add(target);
                                        enemyImpactTargetIds.Add(target.character.data.uuidS);
                                    }
                                }
                            }

                            if (hasSelfSiteTarget)
                            {
                                cfg.target = SkillEffectShowTarget.SELF_SKILL_TARGET;
                                BatEffectBase effect = ShowEffect(cfg, null);
                                if (cfg.type == SkillEffectType.BULLET)
                                {
                                    ((BatSkillBulletEffect)effect).impactTargets = selfImpactTargets;
                                }
                            }

                            if (hasEnemySiteTarget)
                            {
                                cfg.target = SkillEffectShowTarget.ENEMY_SKILL_TARGET;
                                BatEffectBase effect = ShowEffect(cfg, null);
                                if (cfg.type == SkillEffectType.BULLET)
                                {
                                    ((BatSkillBulletEffect)effect).impactTargets = enemyImpactTargets;
                                }
                            }
                        }
                        else if (cfg.impactTargetType == SkillEffectImpactTargetType.EACH)
                        {
                            List<string> effectedTargetIds = new List<string>();
                            for (int j = 0; j < len; j++)
                            {
                                BatSkillTarget target = mTargets[j];
                                if (!effectedTargetIds.Contains(target.character.data.uuidS))
                                {
                                    BatEffectBase effect = ShowEffect(cfg, target.character);
                                    if (cfg.type == SkillEffectType.BULLET)
                                    {
                                        List<BatSkillTarget> impactTargets = new List<BatSkillTarget>();
                                        impactTargets.Add(target);
                                        ((BatSkillBulletEffect)effect).impactTargets = impactTargets;
                                    }
                                    effectedTargetIds.Add(target.character.data.uuidS);
                                }
                            }
                        }
                    }
                }
            }
        }

        private BatEffectBase ShowEffect(EffectConfig cfg, BatCharacter effectShowTarget)
        {
            BatEffectBase effect = null;

            if (cfg.type == SkillEffectType.BULLET)
            {
                BatSkillBulletEffect bullet = BatEffectHelper.CreateBulletEffect(cfg.effectId);
                bullet.impactTargetType = cfg.impactTargetType;
                bullet.isFired = false;
                mBullets.Add(bullet);
                effect = bullet;
            }
            else
            {
                effect = BatEffectHelper.CreateBatEffectBase(cfg.effectId);
                mEffects.Add(effect);
            }

            if (effect != null)
            {
                effect.SetActive(false);
            }

            //effect.SetActive(false);

            if (effectShowTarget == null)
            {
                GameObjectUtil.Bind(effect.displayModel.transform, SceneModel.ins.battleModelContainer.transform, true, true);
                /*
                if (mHost.siteType == BatCharacterSiteType.ATTACKER)
                {
                    effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                }
                else if (mHost.siteType == BatCharacterSiteType.DEFENDER)
                {
                    effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                
                if (cfg.target == SkillEffectShowTarget.SELF_SKILL_TARGET)
                {
                    effect.displayModel.transform.localPosition = 
                        mHost.siteType == BatCharacterSiteType.ATTACKER ? BattleDef.ATTACKER_POSES[5] : BattleDef.DEFENDER_POSES[5];
                }
                else if (cfg.target == SkillEffectShowTarget.ENEMY_SKILL_TARGET)
                {
                    effect.displayModel.transform.localPosition = 
                        mHost.siteType == BatCharacterSiteType.ATTACKER ? BattleDef.DEFENDER_POSES[5] : BattleDef.ATTACKER_POSES[5];
                }
                */

                if (cfg.target == SkillEffectShowTarget.SELF_SKILL_TARGET)
                {
                    if (mHost.sitePoses == BattleDef.ATTACKER_POSES)
                    {
                        effect.displayModel.transform.localPosition = BattleDef.ATTACKER_POSES[5] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                    }
                    else if (mHost.sitePoses == BattleDef.DEFENDER_POSES)
                    {
                        effect.displayModel.transform.localPosition = BattleDef.DEFENDER_POSES[5] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                    }
                }
                else if (cfg.target == SkillEffectShowTarget.ENEMY_SKILL_TARGET)
                {
                    if (mHost.sitePoses == BattleDef.ATTACKER_POSES)
                    {
                        effect.displayModel.transform.localPosition = BattleDef.DEFENDER_POSES[5] + mEffectOffset;
                        effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                    }
                    else if (mHost.sitePoses == BattleDef.DEFENDER_POSES)
                    {
                        effect.displayModel.transform.localPosition = BattleDef.ATTACKER_POSES[5] + mEffectOffset;
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
                        GameObjectUtil.Bind(effect.displayModel.transform, SceneModel.ins.battleModelContainer.transform, true, true);
                        effect.displayModel.transform.localPosition = effectShowTarget.localPosition + mEffectOffset;
                        if (effectShowTarget.sitePoses == BattleDef.ATTACKER_POSES)
                        {
                            effect.displayModel.transform.localEulerAngles = new Vector3(0, 90, 0);
                        }
                        else if (effectShowTarget.sitePoses == BattleDef.DEFENDER_POSES)
                        {
                            effect.displayModel.transform.localEulerAngles = new Vector3(0, -90, 0);
                        }
                        //_effect.model.transform.LookAt(_effect.model.transform.localPosition + effectShowTarget.forward);
                        break;
                    case SkillEffectPosType.BODY:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.transform, true, true);
                        effect.displayModel.transform.localPosition += mEffectOffset;
                        break;
                    case SkillEffectPosType.HEAD_TOP:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.transform, true, true);
                        Vector3 localPos = effect.displayModel.transform.localPosition;
                        localPos.y = effectShowTarget.displayModel.totalHeight;
                        effect.displayModel.transform.localPosition = localPos;
                        break;
                    case SkillEffectPosType.LEFT_HAND:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.leftHand != null ? effectShowTarget.leftHand : effectShowTarget.transform, true, true);
                        break;
                    case SkillEffectPosType.RIGHT_HAND:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.rightHand != null ? effectShowTarget.rightHand : effectShowTarget.transform, true, true);
                        break;
                    case SkillEffectPosType.FIRE_ROOT:
                        GameObjectUtil.Bind(effect.displayModel.transform, effectShowTarget.fireRoot != null ? effectShowTarget.fireRoot : effectShowTarget.transform, true, true);
                        break;
                    default:
                        GameObjectUtil.Bind(effect.displayModel.transform, SceneModel.ins.battleModelContainer.transform, true, true);
                        break;
                }
            }

            effect.displayModel.transform.localPosition += effect.orgPos;
            effect.displayModel.transform.localEulerAngles += effect.orgAngle;
            //effect.SetActive(true);
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
                if (mFixedTimePassed >= cfg.startTime && !cfg.isPlayed)
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

        public void Update()
        {
            if (!mIsSkillAnimStarted)
            {
                return;
            }

            mTimePassed += Time.deltaTime;

            if (mTpl != null)
            {
                UpdateBullets(Time.deltaTime);

                SkillActionType actionType = (SkillActionType)mTpl.actionType;

                if (mFixedTimePassed >= mTpl.impactStartTime)
                {
                    if ((mSkill.data.skillTpl.Id == BatSkillID.USE_ITEM || mSkill.data.skillTpl.Id == BatSkillID.SUMMON) && mImpactTimes != mTpl.impactTimes)
                    {
                        mImpactTimes = mTpl.impactTimes;
                        int targetsLen = mTargets.Count;
                        for (int j = 0; j < targetsLen; j++)
                        {
                            mSkill.ImpactTarget(mTargets[j], mImpactTimes, mTpl.impactTimes);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < mTpl.impactTimes; i++)
                        {
                            if (mFixedTimePassed >= mTpl.impactStartTime + i * mTpl.impactInterval)
                            {
                                if (mImpactTimes == i)
                                {
                                    if (actionType == SkillActionType.OTHERS)
                                    {
                                        int targetsLen = mTargets.Count;
                                        for (int j = 0; j < targetsLen; j++)
                                        {
                                            ShowImpactEffect(mTargets[j], null);
                                            mSkill.ImpactTarget(mTargets[j], mImpactTimes + 1, mTpl.impactTimes);
                                        }
                                        mImpactTimes++;
                                    }
                                    else
                                    {
                                        float deltaTime = mFixedTimePassed - (mTpl.impactStartTime + i * mTpl.impactInterval);
                                        FireBullets(deltaTime);
                                    }
                                }
                            }
                        }
                    }
                }

                int len = mBullets.Count;
                for (int i = 0; i < len; i++)
                {
                    BatSkillBulletEffect bullet = mBullets[i];
                    if (bullet.GetIsUsed() && bullet.isFired && bullet.curPos == bullet.endPos)
                    {
                        int targetsLen = bullet.impactTargets.Count;
                        for (int j = 0; j < targetsLen; j++)
                        {
                            ShowImpactEffect(bullet.impactTargets[j], bullet);
                            mSkill.ImpactTarget(bullet.impactTargets[j], mImpactTimes + 1, mTpl.impactTimes);
                        }
                        mImpactTimes++;
                        bullet.UnUse();
                    }
                }

                len = mImpactEffects.Count;
                for (int i = 0; i < len; i++)
                {
                    BatSkillImpactEffect impactEffect = mImpactEffects[i];
                    impactEffect.age += Time.deltaTime;
                    if (impactEffect.age >= BattleDef.IMPACT_EFFECT_MAX_AGE)
                    {
                        impactEffect.UnUse();
                        mImpactEffects.RemoveAt(i);
                        i--;
                        len--;
                    }
                }

                if (isSkillAnimFinished)
                {
                    if (!mIsArrivedBattlePos && !mIsRunningBack)
                    {
                        if (mSkill.data.isCounterAttacksDone)
                        {
                            RunBack();
                        }
                    }
                }
            }
        }

        public void FixedUpdate()
        {
            if (!mIsSkillAnimStarted)
            {
                return;
            }

            mFixedTimePassed += Time.fixedDeltaTime;

            if (mTpl != null)
            {
                CheckEffectShow();
                CheckSoundPlay();
            }
        }

        public int FireBullets(float deltaTime)
        {
            int res = 0;
            int len = mBullets.Count;

            for (int i = 0; i < len; i++)
            {
                BatSkillBulletEffect bullet = mBullets[i];
                Vector3 firePos = Vector3.zero;
                if (bullet.GetIsUsed() && !bullet.isFired)
                {
                    if (bullet.displayModel.transform.parent != null)
                    {
                        firePos = bullet.displayModel.transform.parent.parent.TransformPoint(bullet.displayModel.transform.parent.localPosition);
                        GameObjectUtil.Bind(bullet.displayModel.transform, SceneModel.ins.battleModelContainer.transform, false);
                    }
                    else
                    {
                        firePos = bullet.displayModel.transform.localPosition;
                    }

                    bullet.startPos = firePos;

                    if (bullet.impactTargetType == SkillEffectImpactTargetType.EACH)
                    {
                        bullet.endPos = bullet.impactTargets[0].character.localPosition + bullet.impactTargets[0].character.forward * bullet.impactTargets[0].character.displayModel.radiusFront;
                        bullet.endPos.y = bullet.impactTargets[0].character.displayModel.footHeight + bullet.impactTargets[0].character.displayModel.bodyHeight * 0.65f;
                    }
                    else if (bullet.impactTargetType == SkillEffectImpactTargetType.ALL)
                    {
                        bullet.endPos =
                            mTargets[0].character.siteType == BatCharacterSiteType.ATTACKER ? BattleDef.ATTACKER_POSES[5] : BattleDef.DEFENDER_POSES[5];
                    }

                    if (mActionType == SkillActionType.THROW)
                    {
                        bullet.trackAngle = BattleDef.BULLET_THROW_ANGLE;
                        bullet.speed = BattleDef.BULLET_THROW_SPEED;
                    }
                    else if (mActionType == SkillActionType.SHOT)
                    {
                        bullet.trackAngle = 0f;
                        bullet.speed = BattleDef.BULLET_SHOT_SPEED;
                    }

                    Vector3 speedV3 = bullet.endPos - bullet.startPos;
                    speedV3.Normalize();
                    bullet.speedV3 = speedV3;
                    bullet.speedV3 = bullet.speedV3 * bullet.speed;
                    bullet.curPos = bullet.startPos;
                    bullet.targetDist = Vector3.Distance(bullet.startPos, bullet.endPos);

                    //_bullet.model.transform.LookAt(_bullet.endPos);
                    bullet.displayModel.transform.forward = bullet.endPos;
                    float angle = Mathf.Min(1, Vector3.Distance(bullet.curPos, bullet.endPos) / bullet.targetDist) * bullet.trackAngle;

                    if (bullet.trackAngle != 0)
                    {
                        bullet.displayModel.transform.rotation = bullet.displayModel.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -angle, angle), 0, 0);
                    }

                    bullet.displayModel.transform.localPosition = firePos + bullet.orgPos;
                    bullet.displayModel.transform.localEulerAngles += bullet.orgAngle;
                    bullet.isFired = true;
                    res++;
                    if (deltaTime > 0)
                    {
                        UpdateBulletPos(bullet, deltaTime);
                    }
                }
            }
            return res;
        }

        private void UpdateBullets(float deltaTime)
        {
            int len = mBullets.Count;
            for (int i = 0; i < len; i++)
            {
                if (mBullets[i].isFired)
                {
                    if (!mBullets[i].GetIsUsed())
                    {
                        mBullets.RemoveAt(i);
                        i--;
                        len--;
                    }
                    else
                    {
                        UpdateBulletPos(mBullets[i], deltaTime);
                    }
                }
            }
        }

        private void UpdateBulletPos(BatSkillBulletEffect bullet, float deltaTime)
        {
            float _dist = Vector3.Distance(bullet.startPos, bullet.endPos);
            //bullet.model.transform.LookAt(bullet.endPos);
            bullet.displayModel.transform.forward = bullet.endPos;
            if (_dist > 0)
            {
                float angle = Mathf.Min(1, Vector3.Distance(bullet.curPos, bullet.endPos) / _dist) * bullet.trackAngle;
                bullet.displayModel.transform.rotation = bullet.displayModel.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -angle, angle), 0, 0);
            }
            float currentDist = Vector3.Distance(bullet.curPos, bullet.endPos);
            bullet.displayModel.transform.Translate(Vector3.forward * Mathf.Min(BattleModel.ins.ReviseSpeed(bullet.speed), currentDist));
            bullet.curPos = bullet.displayModel.transform.localPosition;
        }

        private void ShowImpactEffect(BatSkillTarget target, BatSkillBulletEffect bullet)
        {
            if (target.isDodgy)
            {
                return;
            }
            else if (target.isDefense)
            {
                return;
                //TODO 防守特效
                /*
                BatSkillImpactEffect effect = BatEffectHelper.CreateImpactEffect(mTpl.blowEffectId);
                effect.age = 0;
                //effect.SetActive(true);
                GameObjectUtil.Bind(effect.displayModel.transform, SceneModel.ins.battleModelContainer.transform, true, true);
                effect.displayModel.transform.forward = mHost.forward * -1;
                effect.displayModel.transform.localPosition += effect.orgPos;
                effect.displayModel.transform.localEulerAngles += effect.orgAngle;

                mImpactEffects.Add(effect);
                */
            }
            else if (target.isNoBubble)
            {
                return;
            }
            else
            {
                if (PropertyUtil.IsLegalID(mTpl.blowEffectId) && mImpactEffectPos != SkillImpactEffectPosType.NONE)
                {
                    BatSkillImpactEffect effect = BatEffectHelper.CreateImpactEffect(mTpl.blowEffectId);
                    effect.age = 0;
                    //effect.SetActive(true);
                    GameObjectUtil.Bind(effect.displayModel.transform, SceneModel.ins.battleModelContainer.transform, true, true);

                    Vector3 pos = target.character.localPosition;
                    Vector3 forward = Vector3.zero;

                    if (bullet == null)
                    {
                        forward = mHost.forward * -1;
                    }
                    else
                    {
                        forward = bullet.displayModel.transform.forward * -1;
                    }
                    forward.y = 0;

                    switch (mImpactEffectPos)
                    {
                        case SkillImpactEffectPosType.HEAD_TOP:
                            pos.y = target.character.displayModel.totalHeight;
                            break;
                        case SkillImpactEffectPosType.CHEST:
                            //pos = pos + forward * target.character.radiusZ;
                            pos.y = target.character.displayModel.footHeight + target.character.displayModel.bodyHeight * 0.65f;
                            break;
                        case SkillImpactEffectPosType.FOOT:

                            break;
                        default:
                            break;
                    }

                    forward.y = pos.y;
                    effect.displayModel.transform.forward = forward;

                    effect.displayModel.transform.localPosition = pos + effect.orgPos;
                    effect.displayModel.transform.localEulerAngles += effect.orgAngle;

                    mImpactEffects.Add(effect);
                    effect.SetActive(true);
                }
            }
        }

        public void Destroy()
        {
            mEffectConfigs.Clear();
            int effectsLen = mEffects.Count;
            for (int i = 0; i < effectsLen; i++)
            {
                if (mEffects[i].GetIsUsed())
                {
                    mEffects[i].UnUse();
                }
            }
            mEffects.Clear();

            int bulletsLen = mBullets.Count;
            for (int i = 0; i < bulletsLen; i++)
            {
                if (mBullets[i].GetIsUsed())
                {
                    mBullets[i].UnUse();
                }
            }
            mBullets.Clear();

            int impactEffectsLen = mImpactEffects.Count;
            for (int i = 0; i < impactEffectsLen; i++)
            {
                if (mImpactEffects[i].GetIsUsed())
                {
                    mImpactEffects[i].UnUse();
                }
            }
            mImpactEffects.Clear();

            if (mTargets != null)
            {
                mTargets.Clear();
            }
        }

        public bool isSkillAnimFinished
        {
            get
            {
                if (mIsSkillAnimFinished)
                {
                    return true;
                }

                if (mTpl == null)
                {
                    mIsSkillAnimFinished = true;
                    return true;
                }

                if (mIsSkillAnimStarted)
                {
                    if (mSkillAnim != null)
                    {
                        if (mTimePassed >= mSkillAnim.length && mTimePassed >= mTpl.impactStartTime + (mTpl.impactTimes - 1) * mTpl.impactInterval)
                        {
                            mIsSkillAnimFinished = true;
                            return true;
                        }
                    }
                    else
                    {
                        mIsSkillAnimFinished = true;
                        return true;
                    }

                }
                return false;
            }
        }

        public bool isAnimFinished
        {
            get
            {
                if (mSkill.data.skillTpl.Id == BatSkillID.ESCAPE)
                {
                    return isSkillAnimFinished;
                }

                if (mIsArrivedBattlePos)
                {
                    return isSkillAnimFinished;
                }

                return false;
            }
        }

        public bool isCanDestroy
        {
            get
            {
                if (isAnimFinished)
                {
                    int len = mTargets.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (mTargets[i].isDeadFly && !mTargets[i].character.isFlied)
                        {
                            return false;
                        }

                        if (mTargets[i].character.isBlowingBack)
                        {
                            return false;
                        }
                    }

                    if (mSkill.data.skillTpl.Id == BatSkillID.CATCH)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            if (!mTargets[i].isBeCaught && (mTargets[i].character.localPosition != mTargets[i].character.localBattlePos))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if (mSkill.data.skillTpl.Id == BatSkillID.ESCAPE)
                    {
                        //int len = mTargets.Count;
                        for (int i = 0; i < len; i++)
                        {
                            if (!mTargets[i].character.isEscapeFinished)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if (mSkillAnim != null)
                    {
                        /*
                        if (mHost.curAnimName == mTpl.actionId)
                        {
                            return mAnim.time >= (mTpl.impactStartTime + (mTpl.impactTimes - 1) * mTpl.impactInterval + mTpl.effectStopDelayTime) && 
                                mBullets.Count == 0 && 
                                mImpactEffects.Count == 0;
                        }
                        return true;
                        */
                        bool res = mFixedTimePassed >= (mTpl.impactStartTime + (mTpl.impactTimes - 1) * mTpl.impactInterval + mTpl.effectStopDelayTime) &&
                        mBullets.Count == 0 &&
                        mImpactEffects.Count == 0;
                        return res;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}