using System.Collections.Generic;
using app.avatar;
using UnityEngine;
using UnityEngine.UI;
using app.utils;
using app.model;
using app.pet;
using app.system;
using app.db;
using DG.Tweening;

namespace app.battle
{
    public class BatCharacter : AvatarBase
    {
        public BatCharacterStatusData data { get; private set; }
        public BatCharacterSiteType siteType { get; private set; }
        //public BatCharacter target { get; private set; }
        public Transform leftHand { get; private set; }
        public Transform rightHand { get; private set; }
        public Transform fireRoot { get; private set; }

        public Vector3 localBattlePos { get; private set; }
        public Vector3 globalBattlePos { get; private set; }

        public bool isInited { get; private set; }
        public bool isEscapeFinished { get; private set; }
        public bool isFadeOuted { get; private set; }
        public bool isFlied { get; set; }

        public int curHP { get; private set; }
        public int curMP { get; private set; }
        public int curSP { get; private set; }

        public BattleBehavStatusType behavStatusType { get; set; }

        public GameObject displayModelContainer { get; private set; }

        public Vector3[] sitePoses { get; private set; }

        private bool mIsEscaping = false;
        private bool mIsFlying = false;
        public bool isBlowingBack { get; private set; }

        private List<BatSkill> mSkills = new List<BatSkill>();
        private List<BatBuff> mBuffs = new List<BatBuff>();

        private List<Material> mMaterials = new List<Material>();
        private List<Color> mMatOrgColors = new List<Color>();

        private BatSkill mCurSkill = null;

        //private string mBloodBarPath = null;
        private ProgressBar mBloodBar = null;
        private GameObject mBloodBarGo = null;
        private GameObject mAvatarNameGo = null;
        private GameObject mSkillNameGo = null;
        private float mSkillNamesTotalHeight = 0.0f;
        private float mSkillNameHideCD = 0;
        private string mCurSkillNameTexturePath = null;

        private Vector3 mLastFixedWorldPos = Vector3.zero;

        private Dictionary<string, int> mExistingBuffEffects = new Dictionary<string, int>();
        private Dictionary<int, int> mExistingSpecialBuffEffects = new Dictionary<int, int>();

        private bool mIsShaking = false;
        private int mLastShakeStamp = 0;

        private List<BatBubble> mDoingBubbles = new List<BatBubble>();

        private GameObject mSelectFrame = null;
        private GameObject mPrepareSign = null;

        //private List<string> mLoadedSkillNameTextures = new List<string>();

        private BatChivalric mChivalric = null;

        public BatCharacter()
        {
            isInited = false;
            isFadeOuted = false;
        }

        public void Init(BatCharacterStatusData data, BatCharacterSiteType siteType)
        {
            if (data == null)
            {
                return;
            }
            isInited = false;
            this.data = data;
            this.siteType = siteType;
            if (displayModelContainer == null)
            {
                displayModelContainer = new GameObject(data.uuidS);
            }
            displayModelContainer.transform.SetParent(SceneModel.ins.battleModelContainer.transform);
            displayModelContainer.layer = GetLayer();
            base.Init(data.displayModelId, Vector3.zero, Vector3.zero, displayModelContainer.transform, true);
        }

        public override int GetLayer()
        {
            return SceneModel.ins.battleModelContainer.layer;
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);
            /*
            displayModel.avatar.transform.SetParent(displayModelContainer.transform);
            displayModel.avatar.transform.localPosition = Vector3.zero;
            displayModel.avatar.transform.localEulerAngles = Vector3.zero;
            GameObjectUtil.SetLayer(displayModel.avatar, displayModelContainer.layer);
            */
            UpdateData(this.data);
            InitPosition();
            //displayModel.avatar.SetActive(true);
            GetShaders();

            if (data.variantionColor != null)
            {
                displayModel.variationColor = ColorUtil.GetColorRGB(data.variantionColor);
            }
            if (data.isVariant)
            {
                if (data.petTpl!=null&&data.petTpl.petpetTypeId != 2)
                {
                    displayModel.SetIsVariant(data.isVariant);
                }
            }
            else
            {
                displayModel.SetIsVariant(data.isVariant);
            }
            //CreateBloodBar();
            //CreateAvatarName();
            CreateSelectFrame();
            CreatePrepareSign();
            if (data.weaponTpl != null)
            {
                ShowWeapon(data.weaponTpl);
            }
            
            isInited = true;
        }

        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId);
        }

        private void CreateSelectFrame()
        {
            mSelectFrame = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath("common_miaozhun"));
            if (mSelectFrame != null)
            {
                mSelectFrame.transform.SetParent(AvatarTextManager.Ins.avatarTextContainer.transform);
                mSelectFrame.transform.localPosition = Vector3.zero;
                mSelectFrame.transform.localEulerAngles = Vector3.zero;
                GameObjectUtil.SetLayer(mSelectFrame, displayModelContainer.layer);
                Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;
                mSelectFrame.transform.localEulerAngles = new Vector3(0, 0, 0);
                mSelectFrame.transform.localPosition = localPosition;
                mSelectFrame.SetActive(false);
            }
        }

        public GameObject GetSelectFrame()
        {
            return mSelectFrame;
        }

        private void CreatePrepareSign()
        {
            Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;
            mPrepareSign = new GameObject("prepareSign");
            Sprite t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "zhunbei");
            if (t != null)
            {
                Image prepareSignImg = mPrepareSign.AddComponent<Image>();
                prepareSignImg.rectTransform.pivot = new Vector2(0.5f, 0);
                prepareSignImg.sprite = t;
                prepareSignImg.SetNativeSize();
                mPrepareSign.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            mPrepareSign = AvatarTextManager.Ins.CreateAvatarText(data.uuidS + "_prepareSign", mPrepareSign, displayModelContainer.layer);
            mPrepareSign.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            mPrepareSign.transform.localEulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
            mPrepareSign.SetActive(false);
        }

        private void GetShaders()
        {
            mMaterials.Clear();
            mMatOrgColors.Clear();
            SkinnedMeshRenderer[] _renderers = displayModel.avatar.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int _i = 0; _i < _renderers.Length; _i++)
            {
                Material mat = _renderers[_i].material;
                if (mat.HasProperty("_Color"))
                {
                    mMaterials.Add(mat);
                    mMatOrgColors.Add(mat.GetColor("_Color"));
                }
            }
        }

        public void InitPosition()
        {
            if (mIsEscaping || isEscapeFinished || mIsFlying || isFlied || isBlowingBack)
            {
                return;
            }

            Vector3[] poses = null;

            if (siteType == BatCharacterSiteType.ATTACKER)
            {
                if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                {
                    poses = BattleDef.ATTACKER_POSES;
                }
                else
                {
                    if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                    {
                        poses = BattleDef.ATTACKER_POSES;
                    }
                    else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                    {
                        poses = BattleDef.DEFENDER_POSES;
                    }
                    else
                    {
                        ClientLog.LogError("玩家阵营不合法!");
                    }
                }

            }
            else if (siteType == BatCharacterSiteType.DEFENDER)
            {
                if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                {
                    poses = BattleDef.DEFENDER_POSES;
                }
                else
                {
                    if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                    {
                        poses = BattleDef.DEFENDER_POSES;
                    }
                    else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                    {
                        poses = BattleDef.ATTACKER_POSES;
                    }
                    else
                    {
                        ClientLog.LogError("玩家阵营不合法!");
                    }
                }
            }
            else
            {
                ClientLog.LogError("角色阵营不合法!");
            }

            sitePoses = poses;

            if (poses != null)
            {
                localPosition = (data != null && data.pos >= 1 && data.pos <= 10) ? poses[data.pos - 1] : Vector3.zero;
                /*
                if (poses == BattleDef.ATTACKER_POSES)
                {
                    localPosition = localPosition + BattleModel.ins.atkPosesOffset;
                }
                else
                {
                    localPosition = localPosition + BattleModel.ins.defPosesOffset;
                }
                */
            }

            if (data == null)
            {
                ClientLog.LogError("有一个角色没有角色信息!");
            }
            else
            {
                if (data.pos < 1 || data.pos > 10)
                {
                    ClientLog.LogError("角色站位非法!被扔到了战场中央! uuid:" + data.uuidS + "    当前站位:" + data.pos);
                }
            }

            Vector3 pos = globalPosition;
            pos.x = SceneModel.ins.battleModelContainer.transform.position.x;
            LookAt(pos);

            this.localBattlePos = localPosition;
            this.globalBattlePos = globalPosition;
        }

        public override bool Update()
        {
            if (base.Update())
            {
                if (mLastFixedWorldPos != globalPosition)
                {
                    UpdateBloodBarPos();
                    UpdateNamePos();
                    mLastFixedWorldPos = globalPosition;
                }

                UpdateSkills();
                UpdateBuffs();
                UpdateBubbles();
				/*
                if (mCurSkill != null)
                {
                    if (mCurSkill.isAnimFinished)
                    {
						if (!mCurSkill.data.isComboTrigger) {
							InitPosition ();
						}
                    }
                }
				*/
                if (mCurPlayingAnim != null && mCurPlayingAnim.wrapMode != WrapMode.Loop && mCurPlayingAnim.time >= mCurPlayingAnim.length)
                {
                    if (curAnimName != ANIM_NAME_DIE && curAnimName != ANIM_NAME_DEFENSE)
                    {
                        Idle();
                    }
                }

                if (mIsShaking)
                {
                    if (mCurPlayingAnim != null && mCurPlayingAnim.name == ANIM_NAME_IDLE && localPosition == localBattlePos)
                    {
                        if (mLastShakeStamp >= 2)
                        {
                            float x = Random.Range(-0.06f, 0.06f);
                            float z = Random.Range(-0.06f, 0.06f);
                            if (displayModel != null && displayModel.avatar != null)
                            {
                                displayModel.avatar.transform.localPosition = new Vector3(x, 0, z);
                            }
                            mLastShakeStamp = 0;
                        }
                        mLastShakeStamp++;
                    }
                }

                if (mSkillNameHideCD > 0)
                {
                    mSkillNameHideCD -= Time.deltaTime;
                    if (mSkillNameHideCD <= 0)
                    {
                        HideSkillName();
                    }
                }

                return true;
            }
            return false;
        }

        private void UpdateSkills()
        {
            int len = mSkills.Count;
            for (int i = 0; i < len; i++)
            {
                if (mSkills[i].isDestroied)
                {
                    if (mCurSkill == mSkills[i])
                    {
                        mCurSkill = null;
                    }
                    mSkills.RemoveAt(i);
                    i--;
                    len--;
                }
                else
                {
                    mSkills[i].Update();
                }
            }
        }

        private void UpdateBuffs()
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                if (mBuffs[i].isDestroied)
                {
                    mBuffs.RemoveAt(i);
                    i--;
                    len--;
                }
                else
                {
                    mBuffs[i].Update();
                }
            }
        }

        private void UpdateBubbles()
        {
            int len = mDoingBubbles.Count;
            for (int i = 0; i < len; i++)
            {
                mDoingBubbles[i].Update();
                if (!mDoingBubbles[i].GetIsUsed())
                {
                    mDoingBubbles.RemoveAt(i);
                    i--;
                    len--;
                    continue;
                }
            }
        }

        private void UpdateBubblesPosition()
        {
            int len = mDoingBubbles.Count;
            for (int i = len - 1; i >= 1; i--)
            {
                BatBubble downBubble = mDoingBubbles[i];
                if (downBubble.GetIsUsed())
                {
                    Vector3 downBubblePos = downBubble.imgText.gameObject.transform.localPosition;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        BatBubble upBubble = mDoingBubbles[j];
                        if (upBubble.GetIsUsed())
                        {
                            Vector3 upBubblePos = upBubble.imgText.gameObject.transform.localPosition;
                            if ((upBubblePos.y - downBubblePos.y) < (upBubble.height + downBubble.height) / 2.0f)
                            {
                                upBubble.KillMoveTweener();
                                upBubblePos.y = downBubblePos.y + (upBubble.height + downBubble.height) / 2.0f;
                                upBubble.imgText.gameObject.transform.localPosition = upBubblePos;
                            }
                        }
                    }
                }
            }
        }

        public override bool FixedUpdate()
        {
            if (base.FixedUpdate())
            {
                FixedUpdateSkills();
                FixedUpdateBuffs();
                return true;
            }
            return false;
        }

        private void FixedUpdateSkills()
        {
            int len = mSkills.Count;
            for (int i = 0; i < len; i++)
            {
                if (mSkills[i].isDestroied)
                {
                    //i--;
                    //len--;
                }
                else
                {
                    mSkills[i].FixedUpdate();
                }
            }
        }

        private void FixedUpdateBuffs()
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                if (mBuffs[i].isDestroied)
                {
                    //i--;
                    //len--;
                }
                else
                {
                    mBuffs[i].FixedUpdate();
                }
            }
        }

        public void UpdateData(BatCharacterStatusData newData)
        {
            //displayModelContainer.name = newData.uuidS;
            curHP = newData.hp;
            curMP = newData.mp;
            curSP = newData.sp;
            isFlied = false;
            mIsFlying = false;
            mIsEscaping = false;
            isEscapeFinished = false;
            isBlowingBack = false;

            if (newData.HasStatus(BatCharacterStatus.BE_CAUGHT))
            {
                SetActive(false);
                DestroyAllBuffs();
                DestroyChivalric();
                //Destroy();
            }
            else if (newData.HasStatus(BatCharacterStatus.DEAD_FLY))
            {
                //Destroy();
                isFlied = true;
                SetActive(false);
                DestroyAllBuffs();
                DestroyChivalric();
            }
            else if (newData.HasStatus(BatCharacterStatus.ESCAPE))
            {
                isEscapeFinished = true;
                SetActive(false);
                DestroyAllBuffs();
                DestroyChivalric();
            }
            else if (newData.HasStatus(BatCharacterStatus.DEAD))
            {
                //if (!mIsFlied)
                //{
                SetActive(true);
                PlayAnimation(ANIM_NAME_DIE, -1);
                DestroyAllBuffs();
                DestroyChivalric();
                if (null != displayModel)
                {
                    displayModel.SetParticleEffectsActive(false);
                }
                //}
            }
            else
            {
                SetActive(true);
                if (curAnimName != ANIM_NAME_DEFENSE)
                {
                    Idle();
                }
                SyncBuffsWithDatas(newData.buffDatas);
                UpdateChivalric(newData.hasChivalric, newData.chivalricId);
                if (null != displayModel)
                {
                    displayModel.SetParticleEffectsActive(SystemSettings.ins.isShowParticleEffects);
                }
            }
            UpdateBloodBarValue();
            UpdateAvatarName();

            if (this == BattleCharacterManager.ins.mainRole)
            {
                BattleManager.ins.UpdateMainRoleInfo(this);
            }
            else if (this == BattleCharacterManager.ins.mainPet)
            {
                BattleManager.ins.UpdateMainPetInfo(this);
            }
            this.data = newData;

			InitPosition();
        }

        private void SyncBuffsWithDatas(List<BatRoundBuffData> datas)
        {
            if (datas != null)
            {
                int len = mBuffs.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!mBuffs[i].isDestroied && !HasBuffData(mBuffs[i].data.uuid, datas))
                    {
                        RemoveBuff(mBuffs[i].data);
                    }
                }

                len = datas.Count;
                BatRoundBuffData data = null;
                for (int i = 0; i < len; i++)
                {
                    data = datas[i];
                    if (data.stateType == SkillBuffStateType.ADD || data.stateType == SkillBuffStateType.ING)
                    {
                        AddBuff(data);
                    }
                    else if (data.stateType == SkillBuffStateType.REMOVE)
                    {
                        RemoveBuff(data);
                    }
                }
            }
        }

        private bool HasBuffData(int uuid, List<BatRoundBuffData> datas)
        {
            int len = datas.Count;
            for (int i = 0; i < len; i++)
            {
                if (datas[i].uuid == uuid)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateChivalric(bool hasChivalric, int id)
        {
            if (hasChivalric && PropertyUtil.IsLegalID(id))
            {
                if (mChivalric != null)
                {
                    if (mChivalric.id != id)
                    {
                        DestroyChivalric();
                    }
                }

                if (mChivalric == null)
                {
                    mChivalric = new BatChivalric(this, id);
                    mChivalric.Start();
                }
            }
            else
            {
                if (mChivalric != null)
                {
                    DestroyChivalric();
                }
            }
        }

        public void DoBatRoundBehav(BatRoundBehavData data)
        {
            //if (mIsEscaping || isEscapeFinished || this.data.HasStatus(BatCharacterStatus.DEAD_FLY))
            //{
            mIsEscaping = false;
            isEscapeFinished = false;
            mIsFlying = false;
            isFlied = false;
            //}

            //InitPosition();

            switch (data.type)
            {
                case BattleRoundBehavType.SKILL:
                    DoSkill((BatRoundSkillData)data);
                    break;
                case BattleRoundBehavType.BUFF:
                    DoBuff((BatRoundBuffData)data);
                    break;
                default:
                    data.isDone = true;
                    break;
            }

            //HidePrepareSign();
            BattleCharacterManager.ins.HideAllPrepareSign();
        }

        /// <summary>
        /// 释放技能。
        /// </summary>
        public void DoSkill(BatRoundSkillData data)
        {
            ClientLog.Log("###############  DO SKILL  ###################");
            if (data.skillTpl != null)
            {
                ClientLog.Log("id:" + data.skillTpl.Id + "  name:" + data.skillTpl.name + " host:" + this.data.uuidS);
                if (!isActive)
                {
                    SetActive(true);
                }

                data.isDone = false;
                BatSkill skill = new BatSkill(this, data);
                skill.Start();
                mSkills.Add(skill);
                mCurSkill = skill;
                /*
                if (data.skillTpl.Id == BatSkillID.ESCAPE)
                {
                    int len = data.results.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (!data.results[i].isEscaped)
                        {
                            zone.ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ESCAPE_FAIL);
                            break;
                        }
                    }
                }
                */

                if (data.stageType == BatRoundStageType.PROGRESS && data.skillTpl.needShowOnRelease == 1)
                {
                    ShowSkillName(data.skillTpl.bubble, PathUtil.Ins.skillNameAtlasPath);

                    int skillEffectsLen = data.skillEffects.Count;
                    for (int i = 0; i < skillEffectsLen; i++)
                    {
                        int skillEffectId = data.skillEffects[i];
                        SkillEffectTemplate skillEffectTpl = SkillEffectTemplateDB.Instance.getTemplate(skillEffectId);
                        if (skillEffectTpl != null && skillEffectTpl.calcTypeId == 1)
                        {
                            SkillEffectDescTemplate skillEffectDescTpl = SkillEffectDescTemplateDB.Instance.getTemplate(skillEffectId);
                            if (PropertyUtil.IsLegalID(skillEffectDescTpl.bubble))
                            {
                                ShowSkillName(skillEffectDescTpl.bubble, PathUtil.Ins.skillEffectNameAtlasPath);
                            }
                        }
                    }
                }

				if (data.isCombo)
				{
					zone.ZoneBubbleManager.ins.BubbleSysMsg("连击提示（临时）");
				}
            }
            else
            {
                data.isDone = true;
            }
        }

        /// <summary>
        /// 被技能命中。
        /// </summary>
        /// <param name="value">value.</param>
        public void ImpactedBySkill(int hpDiff, int mpDiff, int spDiff, BatRoundBuffData buffData, bool isCrit, bool isDodgy, bool isDefense, bool isDeadFly, BatCharacterAttackType attackType, bool isNoBubble)
        {
            XPChanged(hpDiff, mpDiff, spDiff, isCrit, isDodgy, isDeadFly, attackType, isNoBubble);

            if (buffData != null)
            {
                DoBuff(buffData);
            }
        }

        /// <summary>
        /// Buff状态发生变化。
        /// </summary>
        /// <param name="data">Data.</param>
        public void DoBuff(BatRoundBuffData data)
        {
            ClientLog.Log("###############  DO BUFF  ###################");

            if (isAlive)
            {
                ClientLog.Log("id:" + data.id + "  host:" + this.data.uuidS + "  status:" + data.stateType);

                if (data.stateType == SkillBuffStateType.ADD)
                {
                    AddBuff(data);
                }
                else if (data.stateType == SkillBuffStateType.REMOVE)
                {
                    RemoveBuff(data);
                }
            }
            else
            {
                ClientLog.Log("host:" + this.data.uuidS + "  is not alive");
            }
        }

        private void XPChanged(int hpDiff, int mpDiff, int spDiff, bool isCrit, bool isDodgy, bool isDeadFly, BatCharacterAttackType attackType, bool isNoBubble)
        {
            ClientLog.Log("+++++++++" + data.uuidS + " XP Changed ++++++++++");
            ClientLog.Log("生命变化:" + hpDiff + "  法力变化:" + mpDiff + "  怒气变化:" + spDiff + "  暴击:" + isCrit + "  闪避:" + isDodgy + "   攻击类型:" + attackType + "  是否不冒泡:" + isNoBubble);
            curHP += hpDiff;
            curMP += mpDiff;
            curSP += spDiff;

            if (isDodgy)
            {
                //闪避。
                DoDodgy();
            }
            else if (isDeadFly)
            {
                Fly();
            }
            else
            {
                if (hpDiff < 0)
                {
                    if (curHP <= 0)
                    {
                        PlayAnimation(ANIM_NAME_DIE);

                        DestroyAllBuffs();
                        HideSelectFrame();
                        HidePrepareSign();
                        
                        displayModel.SetParticleEffectsActive(false);

                        if (data.type == PetType.FRIEND || data.type == PetType.LEADER || data.type == PetType.PET)
                        {
                            if (!string.IsNullOrEmpty(data.petTpl.musicIds))
                            {
                                //AudioManager.Ins.PlayAudio(data.petTpl.musicIds, AudioEnumType.Role);
                            }
                        }
                    }
                    else
                    {
                        if (curAnimName != ANIM_NAME_DEFENSE)
                        {
                            PlayAnimation(ANIM_NAME_DAMAGE);
                            if (isCrit)
                            {
                                DoDamageTween();
                            }
                            /*
                            if (data.type == PetType.FRIEND || data.type == PetType.LEADER || data.type == PetType.PET)
                            {
                                if (!string.IsNullOrEmpty(data.petTpl.musicIds))
                                {
                                    AudioManager.Ins.PlayAudio(data.petTpl.musicIds, AudioEnumType.Role);
                                }
                            }
                            */
                        }
                    }
                }
                else if (hpDiff > 0)
                {
                    if (curHP > 0)
                    {
                        if (curAnimName == ANIM_NAME_DIE)
                        {
                            Idle();
                        }
                    }
                }
            }

            if (isActive && !isNoBubble)
            {
                BatBubble bubble = null;

                //冒字。
                if (hpDiff != 0)
                {
                    bubble = BattleBubbleManager.ins.BubbleHPChange(hpDiff, this.globalPosition, isCrit, attackType, mDoingBubbles.Count * 0.5f);
                    if (bubble != null)
                    {
                        mDoingBubbles.Add(bubble);
                    }
                }

                if (mpDiff != 0)
                {
                    bubble = BattleBubbleManager.ins.BubbleMPChange(mpDiff, this.globalPosition, isCrit, attackType, mDoingBubbles.Count * 0.5f);
                    if (bubble != null)
                    {
                        mDoingBubbles.Add(bubble);
                    }
                }

                /*
                if (spDiff != 0)
                {
                    bubble = BattleBubbleManager.ins.BubbleSPChange(spDiff, this, isCrit, attackType);
                    if (bubble != null)
                    {
                        mDoingBubbles.Add(bubble);
                    }
                }
                */
                
                if (isCrit)
                {
                    BattleManager.ins.ShakeCamera();
                }
            }
            this.curHP = Mathf.Min(this.data.maxHp, this.curHP);
            this.curMP = Mathf.Min(this.data.maxMp, this.curMP);
            this.curSP = Mathf.Min(this.data.maxSp, this.curSP);

            UpdateBloodBarValue();
            UpdateBloodBarVisible();

            if (this == BattleCharacterManager.ins.mainRole)
            {
                BattleManager.ins.UpdateMainRoleInfo(this);
            }
            else if (this == BattleCharacterManager.ins.mainPet)
            {
                BattleManager.ins.UpdateMainPetInfo(this);
            }
        }

        private void DoDamageTween()
        {
            Vector3 pos = Vector3.zero;
            if (this.data.pos >= 1 && this.data.pos <= 10)
            {
                if (this.sitePoses == BattleDef.ATTACKER_POSES)
                {
                    pos = BattleDef.ATTACKER_POSES[this.data.pos - 1];
                    pos.x += 1.0f;
                }
                else
                {
                    pos = BattleDef.DEFENDER_POSES[this.data.pos - 1];
                    pos.x -= 1.0f;
                }
            }
            else
            {
                pos = localPosition;
                pos.y -= 1.0f;
            }

            TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.2f, null, OnDamageTweenComplete, OnTweenUpdate);
            isBlowingBack = true;
        }

        private void OnDamageTweenComplete()
        {
            TweenUtil.MoveTo(this.displayModelContainer.transform, localBattlePos, 0.2f, null, null, OnTweenUpdate);
            isBlowingBack = false;
        }

        /// <summary>
        /// 反击。
        /// </summary>
        public void Counterattack(BatRoundSkillData data)
        {
            DoSkill(data);
        }

        /// <summary>
        /// 做闪避动作。
        /// </summary>
        public void DoDodgy()
        {
            Vector3 startPos = localPosition;
            Vector3 endPos = localPosition + (forward * -1f);
            TweenUtil.MoveTo(displayModelContainer.transform, endPos, 0.1f, null, null, OnTweenUpdate);
            TweenUtil.MoveTo(displayModelContainer.transform, startPos, 0.1f, null, null, OnTweenUpdate, 0.2f);
        }

        /// <summary>
        /// 做防御动作。
        /// </summary>
        public void DoDefense()
        {
            if (curAnimName != ANIM_NAME_DEFENSE)
            {
                PlayAnimation(ANIM_NAME_DEFENSE);
            }
        }

        public void DoEscape(bool isEscaped)
        {
            Vector3 pos = Vector3.zero;
            if (this.data.pos >= 1 && this.data.pos <= 10)
            {
                if (this.sitePoses == BattleDef.ATTACKER_POSES)
                {
                    pos = BattleDef.ATTACKER_POSES[this.data.pos - 1];
                    pos.x += (isEscaped ? 11.0f : 8.0f);
                }
                else
                {
                    pos = BattleDef.DEFENDER_POSES[this.data.pos - 1];
                    pos.x -= (isEscaped ? 11.0f : 8.0f);
                }
            }
            else
            {
                pos = localPosition;
                pos.y -= 1.0f;
            }

            //this.LookAt(pos);

            TweenUtil.RotateTo(this.displayModelContainer.transform, this.displayModelContainer.transform.localEulerAngles * -1, 0.1f);

            if (isEscaped)
            {
                TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.8f, DoEscapeStart, DoEscapeFinished, OnTweenUpdate, 0.1f);
            }
            else
            {
                TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.5f, DoEscapeStart, DoEscapeFailed, OnTweenUpdate, 0.1f);
            }
            this.mIsEscaping = true;
            this.isEscapeFinished = false;
        }

        private void DoEscapeStart()
        {
            PlayAnimation(ANIM_NAME_MOVE);
        }

        private void DoEscapeFailed()
        {
            this.LookAt(globalBattlePos);
            TweenUtil.MoveTo(this.displayModelContainer.transform, localBattlePos, 0.3f, null, DoEscapeFinished, OnTweenUpdate);
        }

        private void DoEscapeFinished()
        {
            this.mIsEscaping = false;
            this.isEscapeFinished = true;
            Idle();
            InitPosition();
        }

        /// <summary>
        /// 击飞。
        /// </summary>
        public void Fly()
        {
            //int scrW = Screen.width;
            //int scrH = Screen.height;
            int scrW = UGUIConfig.ScreenWidth;
            int scrH = UGUIConfig.ScreenHeight;

            Camera cam = SceneModel.ins.battleCam.GetComponent<Camera>();

            Ray mRay;
            RaycastHit mHit;

            Vector3 footScrPos = cam.WorldToScreenPoint(localPosition);
            //Vector3 lbScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(-radiusX, 0, radiusZ));
            //Vector3 rtScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(radiusX, totalHeight, radiusZ));
            Vector3 centerScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(0, displayModel.totalHeight / 2.0f, 0));

            Vector3[] path = new Vector3[3];
            if (sitePoses == BattleDef.ATTACKER_POSES)
            {
                //在屏幕右下方（功方）。
                if (Random.Range(0.0f, 1.0f) > 0.33f)
                {
                    //右边靠下->下边靠右->（左边靠下）

                    //右边靠下的点。
                    Vector3 p0 = new Vector3(scrW, Random.Range(0.2f, 0.5f) * scrH, 0);
                    //下边靠右的点。
                    Vector3 p1 = new Vector3(Random.Range(0.6f, 0.8f) * scrW, 0, 0);
                    //左边靠下的点。
                    Vector3 p2 = new Vector3(0, Random.Range(0.2f, 0.5f) * scrH, 0);

                    mRay = cam.ScreenPointToRay(p0);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p0 = mHit.point;
                    }
                    else
                    {
                        p0 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p1);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p1 = mHit.point;
                    }
                    else
                    {
                        p1 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p2);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p2 = mHit.point;
                    }
                    else
                    {
                        p2 = Vector3.zero;
                    }

                    path[0] = p0;
                    path[1] = p1;
                    path[2] = Random.Range(0.0f, 1.0f) > 0.5f ? p2 : p1;
                }
                else if (Random.Range(0.0f, 1.0f) > 0.66f)
                {
                    //右边靠上->上边靠右->（左边靠上）

                    //右边靠上的点。
                    Vector3 p0 = new Vector3(scrW, Random.Range(0.6f, 0.8f) * scrH, 0);
                    //下边靠右的点。
                    Vector3 p1 = new Vector3(Random.Range(0.6f, 0.8f) * scrW, scrH, 0);
                    //左边靠上的点。
                    Vector3 p2 = new Vector3(0, Random.Range(0.6f, 0.8f) * scrH, 0);

                    mRay = cam.ScreenPointToRay(p0);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p0 = mHit.point;
                    }
                    else
                    {
                        p0 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p1);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p1 = mHit.point;
                    }
                    else
                    {
                        p1 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p2);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p2 = mHit.point;
                    }
                    else
                    {
                        p2 = Vector3.zero;
                    }

                    path[0] = p0;
                    path[1] = p1;
                    path[2] = Random.Range(0.0f, 1.0f) > 0.5f ? p2 : p1;
                }
                else
                {
                    //平行往右->下边靠右->垂直往上
                    //或
                    //平行往右->上边靠右->垂直往下

                    if (Random.Range(0.0f, 1.0f) > 0.5f)
                    {
                        //平行往右->下边靠右->垂直往上

                        //平行往右的点。
                        Vector3 p0 = new Vector3(scrW, centerScrPos.y, 0);
                        //下边靠右的点。
                        Vector3 p1 = new Vector3(Random.Range(0.6f, 0.8f) * scrW, 0, 0);
                        //垂直往上的点。
                        Vector3 p2 = new Vector3(p1.x, scrH, 0);

                        mRay = cam.ScreenPointToRay(p0);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p0 = mHit.point;
                        }
                        else
                        {
                            p0 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p1);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p1 = mHit.point;
                        }
                        else
                        {
                            p1 = Vector3.zero;
                        }


                        mRay = cam.ScreenPointToRay(p2);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p2 = mHit.point;
                        }
                        else
                        {
                            p2 = Vector3.zero;
                        }

                        path[0] = p0;
                        path[1] = p1;
                        path[2] = p2;
                    }
                    else
                    {
                        //平行往右->上边靠右->垂直往下

                        //平行往右的点。
                        Vector3 p0 = new Vector3(scrW, centerScrPos.y, 0);
                        //上边靠右的点。
                        Vector3 p1 = new Vector3(Random.Range(0.6f, 0.8f) * scrW, scrH, 0);
                        //垂直往下的点。
                        Vector3 p2 = new Vector3(p1.x, 0, 0);

                        mRay = cam.ScreenPointToRay(p0);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p0 = mHit.point;
                        }
                        else
                        {
                            p0 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p1);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p1 = mHit.point;
                        }
                        else
                        {
                            p1 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p2);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p2 = mHit.point;
                        }
                        else
                        {
                            p2 = Vector3.zero;
                        }

                        path[0] = p0;
                        path[1] = p1;
                        path[2] = p2;
                    }
                }
            }
            else
            {
                //在屏幕左上方（守方）。
                if (Random.Range(0.0f, 1.0f) > 0.33f)
                {
                    //左边靠上->上边靠左->（右边靠上）

                    //左边靠上的点。
                    Vector3 p0 = new Vector3(0, Random.Range(0.6f, 0.8f) * scrH, 0);
                    //上边靠左的点。
                    Vector3 p1 = new Vector3(Random.Range(0.2f, 0.5f) * scrW, scrH, 0);
                    //右边靠上的点。
                    Vector3 p2 = new Vector3(scrW, Random.Range(0.6f, 0.8f) * scrH, 0);

                    mRay = cam.ScreenPointToRay(p0);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p0 = mHit.point;
                    }
                    else
                    {
                        p0 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p1);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p1 = mHit.point;
                    }
                    else
                    {
                        p1 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p2);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p2 = mHit.point;
                    }
                    else
                    {
                        p2 = Vector3.zero;
                    }

                    path[0] = p0;
                    path[1] = p1;
                    path[2] = Random.Range(0.0f, 1.0f) > 0.5f ? p2 : p1;
                }
                else if (Random.Range(0.0f, 1.0f) > 0.66f)
                {
                    //左边靠下->下边靠左->（右边靠下）
                    //左边靠下的点。
                    Vector3 p0 = new Vector3(0, Random.Range(0.2f, 0.5f) * scrH, 0);
                    //下边靠左的点。
                    Vector3 p1 = new Vector3(Random.Range(0.2f, 0.5f) * scrW, 0, 0);
                    //右边靠下的点。
                    Vector3 p2 = new Vector3(scrW, Random.Range(0.2f, 0.5f) * scrH, 0);

                    mRay = cam.ScreenPointToRay(p0);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p0 = mHit.point;
                    }
                    else
                    {
                        p0 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p1);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p1 = mHit.point;
                    }
                    else
                    {
                        p1 = Vector3.zero;
                    }

                    mRay = cam.ScreenPointToRay(p2);
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        p2 = mHit.point;
                    }
                    else
                    {
                        p2 = Vector3.zero;
                    }

                    path[0] = p0;
                    path[1] = p1;
                    path[2] = Random.Range(0.0f, 1.0f) > 0.5f ? p2 : p1;
                }
                else
                {
                    //平行往左->下边靠左->垂直往上
                    //或
                    //平行往左->上边靠左->垂直往下

                    if (Random.Range(0.0f, 1.0f) > 0.5f)
                    {
                        //平行往左->下边靠左->垂直往上
                        //平行往左的点。
                        Vector3 p0 = new Vector3(0, centerScrPos.y, 0);
                        //下边靠左的点。
                        Vector3 p1 = new Vector3(Random.Range(0.2f, 0.5f) * scrW, 0, 0);
                        //垂直往上的点。
                        Vector3 p2 = new Vector3(p1.x, scrH, 0);

                        mRay = cam.ScreenPointToRay(p0);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p0 = mHit.point;
                        }
                        else
                        {
                            p0 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p1);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p1 = mHit.point;
                        }
                        else
                        {
                            p1 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p2);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p2 = mHit.point;
                        }
                        else
                        {
                            p2 = Vector3.zero;
                        }

                        path[0] = p0;
                        path[1] = p1;
                        path[2] = p2;
                    }
                    else
                    {
                        //平行往左->上边靠左->垂直往下
                        //平行往左的点。
                        Vector3 p0 = new Vector3(0, centerScrPos.y, 0);
                        //上边靠左的点。
                        Vector3 p1 = new Vector3(Random.Range(0.2f, 0.5f) * scrW, scrH, 0);
                        //垂直往下的点。
                        Vector3 p2 = new Vector3(p1.x, 0, 0);

                        mRay = cam.ScreenPointToRay(p0);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p0 = mHit.point;
                        }
                        else
                        {
                            p0 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p1);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p1 = mHit.point;
                        }
                        else
                        {
                            p1 = Vector3.zero;
                        }

                        mRay = cam.ScreenPointToRay(p2);
                        if (Physics.Raycast(mRay, out mHit))
                        {
                            p2 = mHit.point;
                        }
                        else
                        {
                            p2 = Vector3.zero;
                        }

                        path[0] = p0;
                        path[1] = p1;
                        path[2] = p2;
                    }
                }
            }

            float duration = 1.0f;
            if (path[2] == path[1])
            {
                duration = 0.5f;
            }
            displayModelContainer.transform.DOLocalPath(path, duration).OnUpdate(OnTweenUpdate).OnComplete(OnFlyComplete);
            mIsFlying = true;
        }

        private void OnFlyComplete()
        {
            //Destroy();
            SetActive(false);
            mIsFlying = false;
            isFlied = true;
            InitPosition();
        }

        private void OnTweenUpdate()
        {
            UpdateBloodBarPos();
            UpdateNamePos();
        }

        public void Idle()
        {
            if (curAnimName != ANIM_NAME_IDLE)
            {
                PlayAnimation(ANIM_NAME_IDLE);
            }
        }

        /// <summary>
        /// 加buff。
        /// </summary>
        private void AddBuff(BatRoundBuffData buffData)
        {
            if (!HasBuffUUID(buffData.uuid))
            {
                ClientLog.Log("----------添加buff   角色:" + this.data.name + "  角色UUID:" + this.data.uuidS + "  buff:" + buffData.tpl.name + "  buffUUID:" + buffData.uuid + "----------");
                BatBuff buff = new BatBuff(this, buffData);

                mBuffs.Add(buff);
                if (mExistingBuffEffects.ContainsKey(buffData.tpl.effect))
                {
                    ClientLog.Log("相同buff特效记录中已经有了，个数：" + mExistingBuffEffects[buffData.tpl.effect]);
                    if (mExistingBuffEffects[buffData.tpl.effect] <= 0)
                    {
                        ClientLog.Log("显示此buff特效");
                    }
                    else
                    {
                        ClientLog.Log("隐藏此buff特效");
                    }
                    buff.Start(mExistingBuffEffects[buffData.tpl.effect] <= 0);
                    mExistingBuffEffects[buffData.tpl.effect]++;
                }
                else
                {
                    ClientLog.Log("相同buff特效记录中没有");
                    ClientLog.Log("显示此buff特效");
                    mExistingBuffEffects.Add(buffData.tpl.effect, 1);
                    buff.Start(true);
                }

                if (!mExistingSpecialBuffEffects.ContainsKey(buffData.id) || mExistingSpecialBuffEffects[buffData.id] <= 0)
                {
                    ShowBuffSpecialEffect(buffData.id);
                    if (!mExistingSpecialBuffEffects.ContainsKey(buffData.id))
                    {
                        mExistingSpecialBuffEffects[buffData.id] = 1;
                    }
                    else
                    {
                        mExistingSpecialBuffEffects[buffData.id]++;
                    }
                }
            }
        }

        /// <summary>
        /// 删buff。
        /// </summary>
        private void RemoveBuff(BatRoundBuffData buffData)
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                if (!mBuffs[i].isDestroied && mBuffs[i].data.uuid == buffData.uuid)
                {
                    ClientLog.Log("----------删除Buff    角色:" + this.data.name + "  角色UUID:" + this.data.uuidS + "  buff:" + buffData.tpl.name + "  buffUUID:" + buffData.uuid + "----------");

                    if (mExistingBuffEffects.ContainsKey(buffData.tpl.effect))
                    {
                        ClientLog.Log("相同buff特效数－1");
                        mExistingBuffEffects[buffData.tpl.effect]--;
                        ClientLog.Log("相同buff特效剩余数:" + mExistingBuffEffects[buffData.tpl.effect]);
                        if (mExistingBuffEffects[buffData.tpl.effect] <= 0)
                        {
                            mExistingBuffEffects.Remove(buffData.tpl.effect);
                        }
                        else if (mBuffs[i].isShowingEffect)
                        {
                            for (int j = 0; j < len; j++)
                            {
                                ClientLog.Log("查找一个相同特效的buff并显示特效");
                                if (!mBuffs[j].isDestroied && mBuffs[j].data.tpl.effect == buffData.tpl.effect && mBuffs[j].data.uuid != buffData.uuid)
                                {
                                    mBuffs[j].ShowEffect();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ClientLog.Log("当前显示特效的buff不是要删除的这个，不用管");
                        }
                    }

                    if (mExistingSpecialBuffEffects.ContainsKey(buffData.id))
                    {
                        mExistingSpecialBuffEffects[buffData.id]--;
                        if (mExistingSpecialBuffEffects[buffData.id] <= 0)
                        {
                            RemoveBuffSpecialEffect(buffData.id);
                        }
                    }

                    mBuffs[i].Destroy();
                    break;
                }
            }
        }

        public bool HasBuffUUID(int uuid)
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                if (!mBuffs[i].isDestroied && mBuffs[i].data.uuid == uuid)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasBuffTplID(int tplId)
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                if (!mBuffs[i].isDestroied && mBuffs[i].data.id == tplId)
                {
                    return true;
                }
            }
            return false;
        }

        private void ShowBuffSpecialEffect(int tplId)
        {
            ClientLog.Log("----------Show Buff Special Effect     fighterUUID:" + this.data.uuidS + "    buffID:" + tplId + "----------");

            if (tplId == BatBuffID.DEFENSE)
            {
                //DoDefense();
            }
            else if (tplId == BatBuffID.CHAOS)
            {
                //mIsShaking = true;
            }
        }

        private void RemoveBuffSpecialEffect(int tplId)
        {
            ClientLog.Log("----------Remove Buff Special Effect     fighterUUID:" + this.data.uuidS + "    buffID:" + tplId + "----------");

            if (!HasBuffTplID(tplId))
            {
                if (tplId == BatBuffID.DEFENSE)
                {
                    Idle();
                }
                else if (tplId == BatBuffID.CHAOS)
                {
                    mIsShaking = false;
                    displayModel.avatar.transform.localPosition = Vector3.zero;
                }
            }
        }

        public Vector3 localPosition
        {
            get
            {
                return displayModelContainer.transform.localPosition;
            }
            set
            {
                displayModelContainer.transform.localPosition = value;
            }
        }

        public Vector3 globalPosition
        {
            get
            {
                if (displayModelContainer != null)
                {
                    return displayModelContainer.transform.position;
                }
                return Vector3.zero;
            }
            set
            {
                if (displayModelContainer != null)
                {
                    displayModelContainer.transform.position = value;
                }
            }
        }

        public Transform transform
        {
            get
            {
                return displayModelContainer.transform;
            }
        }

        public void LookAt(Vector3 worldPos)
        {
            displayModelContainer.transform.LookAt(worldPos);
        }

        public Vector3 forward
        {
            get
            {
                return displayModelContainer.transform.forward;
            }
        }

        public bool isAlive
        {
            get
            {
                if (!isActive)
                {
                    return false;
                }

                if (data == null)
                {
                    return false;
                }

                if (data.HasStatus(BatCharacterStatus.DEAD))
                {
                    return false;
                }

                return curHP > 0;
            }
        }

        public bool isCanDoSkill
        {
            get
            {
                if (!isAlive || data.HasStatus(BatCharacterStatus.DISABLE) || data.HasStatus(BatCharacterStatus.CHAOS))
                {
                    return false;
                }
                return true;
            }
        }

        public override void Destroy()
        {
            if (!isDestroied)
            {
                /*
                int len = mLoadedSkillNameTextures.Count;
                for (int i = 0; i < len; i++)
                {
                    SourceManager.Ins.ClearAllReference(mLoadedSkillNameTextures[i]);
                }
                mLoadedSkillNameTextures.Clear();
                mLoadedSkillNameTextures = null;
                */
                DestroyChivalric();
                DestroySkills();
                DestroyAllBuffs();
                DestroyBubbles();
                mMaterials.Clear();
                mMatOrgColors.Clear();
                mExistingBuffEffects.Clear();
                //AvatarTextManager.Ins.RemoveAvatarText(this.data.uuid + "_bloodbar");
                //AvatarTextManager.Ins.RemoveAvatarText(this.data.uuid + "_name");
                GameObject.DestroyImmediate(mBloodBarGo, true);
                GameObject.DestroyImmediate(mAvatarNameGo, true);
                //SourceManager.Ins.removeReference(mBloodBarPath);
                GameObject.DestroyImmediate(mSelectFrame, true);
                GameObject.DestroyImmediate(mPrepareSign, true);
                GameObject.DestroyImmediate(mSkillNameGo, true);

                mBloodBar = null;
                mBloodBarGo = null;
                mAvatarNameGo = null;
                mSelectFrame = null;
                mPrepareSign = null;
                mSkillNameGo = null;
                base.Destroy();

                GameObject.DestroyImmediate(displayModelContainer, true);
                displayModelContainer = null;
            }
        }

        public void FadeOut()
        {
            if (!isFadeOuted)
            {
                /*
                int len = mMaterials.Count;
                for (int i = 0; i < len; i++)
                {
                    mMaterials[i].SetColor("_Color", new Color(0.2f, 0.2f, 0.2f, 1.0f));
                }
                */
                isFadeOuted = true;
            }
        }

        public void FadeIn()
        {
            if (isFadeOuted)
            {
                /*
                int len = mMaterials.Count;
                for (int i = 0; i < len; i++)
                {
                    mMaterials[i].SetColor("_Color", mMatOrgColors[i]);
                }
                */
                isFadeOuted = false;
            }
        }

        private void DestroySkills()
        {
            int len = mSkills.Count;
            for (int i = 0; i < len; i++)
            {
                mSkills[i].Destroy();
            }
            mSkills.Clear();
        }

        private void DestroyAllBuffs()
        {
            int len = mBuffs.Count;
            for (int i = 0; i < len; i++)
            {
                mBuffs[i].Destroy();
            }
            mExistingBuffEffects.Clear();
            mBuffs.Clear();
        }

        private void DestroyChivalric()
        {
            if (mChivalric != null)
            {
                mChivalric.Destroy();
                mChivalric = null;
            }
        }

        private void DestroyBubbles()
        {
            int len = mDoingBubbles.Count;
            for (int i = 0; i < len; i++)
            {
                if (mDoingBubbles[i].GetIsUsed())
                {
                    mDoingBubbles[i].UnUse();
                }
            }

            mDoingBubbles.Clear();
        }

        public override void SetActive(bool value)
        {
            base.SetActive(value);
            displayModelContainer.SetActive(value);
            UpdateBloodBarVisible();
            UpdateNameVisible();
            if (!value)
            {
                HideSelectFrame();
                HidePrepareSign();
            }
        }

        public void CreateBloodBar()
        {
            if (mBloodBarGo == null)
            {
                Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;

                //mBloodBarGo = new GameObject(data.uuid + "_bloodbar");
                //AvatarTextManager.Ins.ShowAvatarText(mBloodBarGo, displayModel.layer);

                //Canvas cav = mBloodBarGo.AddComponent<Canvas>();
                GameObject bloodBarPrefab = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("battleCharacterBloodBar")));
                mBloodBar = bloodBarPrefab.gameObject.AddComponent<ProgressBar>();
                mBloodBar.Init(bloodBarPrefab.transform.Find("bg").GetComponent<Image>(), bloodBarPrefab.transform.Find("bg/fg").GetComponent<Image>(), null, 58);
                bloodBarPrefab.transform.localScale = new Vector3(2, 2, 2);
                //bloodBarPrefab.transform.SetParent(mBloodBarGo.transform);

                mBloodBarGo = AvatarTextManager.Ins.CreateAvatarText(data.uuidS + "_bloodbar", bloodBarPrefab, displayModelContainer.layer);
                mBloodBarGo.transform.eulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
                //mBloodBarGo.transform.localScale = new Vector3(0.8f, 0.6f, 1f);

                UpdateBloodBarPos();
                UpdateBloodBarValue();
                UpdateBloodBarVisible();
            }
        }

        private void HideBloodBar()
        {
            if (mBloodBarGo != null)
            {
                mBloodBarGo.SetActive(false);
            }
        }

        private void ShowBloodBar()
        {
            if (mBloodBarGo != null)
            {
                mBloodBarGo.SetActive(true);
            }
        }

        private void UpdateBloodBarPos()
        {
            if (this.mBloodBarGo != null)
            {
                Vector3 v3 = this.globalPosition;
                v3.y += (BattleModel.ins.maxModelHeight + 0.1f);
                mBloodBarGo.transform.position = v3;
            }
        }

        private void UpdateBloodBarValue()
        {
            if (mBloodBar != null)
            {
                mBloodBar.MaxValue = this.data.maxHp;
                mBloodBar.Value = this.curHP;
            }
        }

        private void UpdateBloodBarVisible()
        {
            if (mBloodBar != null)
            {
                if (this.isActive)
                {
                    ShowBloodBar();
                }
                else
                {
                    HideBloodBar();
                }
            }
        }

        public void CreateAvatarName()
        {
            if (mAvatarNameGo == null)
            {
                Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;
                Color color = Color.white;
                if (data.type == PetType.LEADER)
                {
                    color = new Color(71.0f / 255.0f, 1.0f, 57.0f / 255.0f);
                }
                else if (data.type == PetType.PET)
                {
                    color = new Color(71.0f / 255.0f, 1.0f, 57.0f / 255.0f);
                }
                else if (data.type == PetType.FRIEND)
                {
                    color = new Color(249.0f / 255.0f, 153.0f / 255.0f, 1.0f);
                }
                else if (data.type == PetType.MONSTER)
                {
                    color = new Color(27.0f / 226.0f, 226.0f / 255.0f, 1.0f);
                }
                mAvatarNameGo = AvatarTextManager.Ins.CreateAvatarText(this.data.uuidS + "_name", this.data.name, color, true, 24, displayModelContainer.layer)[0];
                //AvatarTextManager.Ins.ShowAvatarText(mAvatarNameGo, displayModel.layer);
                mAvatarNameGo.transform.eulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
                UpdateNamePos();
                UpdateNameVisible();
            }
        }

        public void UpdateAvatarName()
        {
            if (mAvatarNameGo != null)
            {
                Text label = mAvatarNameGo.GetComponentInChildren<Text>();
                if (label != null)
                {
                    label.text = data.name;
                }
            }
        }

        private void UpdateNamePos()
        {
            if (mAvatarNameGo != null)
            {
                Vector3 v3 = this.globalPosition;
                v3.y += (BattleModel.ins.maxModelHeight + 0.55f);
                mAvatarNameGo.transform.position = v3;
            }
        }

        private void UpdateSelectFramePos()
        {
            if (mSelectFrame != null && mSelectFrame.activeSelf)
            {
                Vector3 pos = this.globalPosition;
                pos.z -= displayModel.radiusMax;
                float xOffset = Mathf.Tan(45.0f * Mathf.PI / 180.0f) * displayModel.radiusMax;
                float yOffset = Mathf.Tan(30.0f * Mathf.PI / 180.0f) * displayModel.radiusMax;
                pos.x += xOffset;
                pos.y += yOffset;
                mSelectFrame.transform.position = pos;
            }
        }

        private void UpdatePrepareSignPos()
        {
            if (mPrepareSign != null && mPrepareSign.activeSelf)
            {
                Vector3 v3 = this.globalPosition;
                v3.y += (BattleModel.ins.maxModelHeight + 0.6f);
                mPrepareSign.transform.position = v3;
            }
        }

        private void UpdateNameVisible()
        {
            if (mAvatarNameGo != null)
            {
                mAvatarNameGo.SetActive(this.isActive);
            }
        }

        private void ShowSkillName(string skillNameId, string dic)
        {
            GameObject skillNameGo = new GameObject(dic + skillNameId);

            if (mSkillNameGo == null)
            {
                Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;

                //mBloodBarGo = new GameObject(data.uuid + "_bloodbar");
                //AvatarTextManager.Ins.ShowAvatarText(mBloodBarGo, displayModel.layer);

                //Canvas cav = mBloodBarGo.AddComponent<Canvas>();

                //bloodBarPrefab.transform.SetParent(mBloodBarGo.transform);
                //bloodBarPrefab.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

                mSkillNameGo = AvatarTextManager.Ins.CreateAvatarText(data.uuidS + "_skillName", skillNameGo, displayModelContainer.layer);
                mSkillNameGo.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                mSkillNameGo.transform.localEulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
                mSkillNameGo.SetActive(false);
                //mSkillNameGo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                UpdateSkillNamePos();
            }
            else
            {
                skillNameGo.transform.SetParent(mSkillNameGo.transform);
                skillNameGo.layer = mSkillNameGo.layer;
                skillNameGo.transform.localEulerAngles = Vector3.zero;
            }
                
            skillNameGo.transform.localScale = new Vector3(2, 2, 2);
            Image img = skillNameGo.AddComponent<Image>();
            img.rectTransform.pivot = new Vector2(0.5f, 0);
            if (sitePoses == BattleDef.ATTACKER_POSES)
            {
                img.transform.localPosition = new Vector3(100, mSkillNamesTotalHeight, 0);
            }
            else if (sitePoses == BattleDef.DEFENDER_POSES)
            {
                img.transform.localPosition = new Vector3(-100, mSkillNamesTotalHeight, 0);
            }
            else
            {
                img.transform.localPosition = new Vector3(0, mSkillNamesTotalHeight, 0);
            }

            string atlasName = "";
            if (dic == PathUtil.Ins.skillNameAtlasPath)
            {
                atlasName = "skillName";
                mSkillNamesTotalHeight += 100;
            }
            else if (dic == PathUtil.Ins.skillEffectNameAtlasPath)
            {
                atlasName = "skillEffectName";
                mSkillNamesTotalHeight += 66;
            }
            skillNameGo.SetActive(false);
            //PathUtil.Ins.SetImageSource(img, skillNameId, dic, false, OnSkillNameTextureLoaded);
            PathUtil.Ins.SetImageSource(img, skillNameId, atlasName, null, true);
            //mCurSkillNameTexturePath = PathUtil.Ins.GetUITexturePath(skillNameId, PathUtil.TEXTUER_SKILL_NAME);
            //SourceLoader.Ins.load(mCurSkillNameTexturePath, OnSkillNameTextureLoaded);
            if (img.sprite != null)
            {
                mSkillNameGo.SetActive(true);
                img.gameObject.SetActive(true);

                img.CrossFadeAlpha(0, 0.0f, false);
                img.CrossFadeAlpha(1, 0.3f, false);
                img.transform.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutQuart);

                mSkillNameHideCD = 1.0f;
            }
        }

        private void UpdateSkillNamePos()
        {
            if (mSkillNameGo != null)
            {
                Vector3 v3 = this.globalPosition;
                v3.y += (BattleModel.ins.maxModelHeight + 0.2f);
                mSkillNameGo.transform.position = v3;
            }
        }

        private void HideSkillName()
        {
            if (mSkillNameGo != null)
            {
                int childCount = mSkillNameGo.transform.childCount;
                for (int i = childCount - 1; i >= 0; i--)
                {
                    GameObject.DestroyImmediate(mSkillNameGo.transform.GetChild(i).gameObject);
                }
                mSkillNameGo.SetActive(false);
                mSkillNamesTotalHeight = 0;
            }
        }

        public void ShowSelectFrame()
        {
            if (mSelectFrame != null)
            {
                mSelectFrame.SetActive(true);
                UpdateSelectFramePos();
            }
        }

        public void HideSelectFrame()
        {
            if (mSelectFrame != null)
            {
                mSelectFrame.SetActive(false);
            }
        }

        private void ShowPrepareSign()
        {
            if (mPrepareSign != null)
            {
                if (!mPrepareSign.activeSelf)
                {
                    mPrepareSign.SetActive(true);
                }
                UpdatePrepareSignPos();
            }
        }

        private void HidePrepareSign()
        {
            if (mPrepareSign != null)
            {
                if (mPrepareSign.activeSelf)
                {
                    mPrepareSign.SetActive(false);
                }
            }
        }

        public void SetPrepareSignActive(bool value)
        {
            if (value)
            {
                ShowPrepareSign();
            }
            else
            {
                HidePrepareSign();
            }
        }

        /**
         * 被抓住后的移动，这里面区分了成功被抓与否的情况。
         * <param name="data">实施抓捕的角色。</param>
         */
        public void DoBeCaughtMove(BatCharacter host, bool isBeCaught)
        {
            LookAt(host.globalBattlePos);
            PlayAnimation(ANIM_NAME_MOVE);
            float dist = Vector3.Distance(host.localPosition, host.localBattlePos);
            float time = dist / BattleDef.CHARACTER_MOVE_SPEED * 6.0f;
            if (isBeCaught)
            {
                Vector3 pos = localPosition + forward * dist;
                TweenUtil.MoveTo(displayModelContainer.transform, pos, time, null, null, OnTweenUpdate);
            }
            else
            {
                Vector3 pos = localPosition + forward * dist * 0.6f;
                TweenUtil.MoveTo(displayModelContainer.transform, pos, time * 0.6f, null, delegate ()
                {
                    DoBeCaughtEscapeAndMoveBack(time * 0.6f / 3.0f);
                }, OnTweenUpdate);
            }
        }

        private void DoBeCaughtEscapeAndMoveBack(float time)
        {
            LookAt(globalBattlePos);
            TweenUtil.MoveTo(displayModelContainer.transform, localBattlePos, time, null, delegate ()
            {
                    Idle();
                InitPosition();
            }, OnTweenUpdate);
        }

        /**
         * 抓住宠物回站位的移动，这里面区分了成功抓到宠物与否的情况。
         * <param name="hasPetCaught">是否成功抓到宠物。</param>
         * <param name="onComplete">回到站位后的回调函数。</param>
         */
        public void DoCatchMoveBack(bool hasPetCaught, TweenCallback onComplete)
        {
            LookAt(globalBattlePos);
            PlayAnimation(ANIM_NAME_MOVE);
            float dist = Vector3.Distance(localPosition, localBattlePos);
            float time = dist / BattleDef.CHARACTER_MOVE_SPEED * 6.0f;

            if (hasPetCaught)
            {
                TweenUtil.MoveTo(displayModelContainer.transform, localBattlePos, time, null, onComplete, OnTweenUpdate);
            }
            else
            {
                Vector3 pos = localPosition + forward * dist * 0.6f;
                TweenUtil.MoveTo(displayModelContainer.transform, pos, time * 0.6f, null, delegate ()
                {
                    DoCatchMoveStepTwo(time * 0.4f / 3.0f, onComplete);
                }, OnTweenUpdate);
            }
        }

        private void DoCatchMoveStepTwo(float time, TweenCallback onComplete)
        {
            TweenUtil.MoveTo(displayModelContainer.transform, localBattlePos, time, null, onComplete, OnTweenUpdate);
        }

        public void TryShowMonsterChat()
        {
            float cdLeft = BattleModel.ins.curRoundWaitTimeLeft;
            if (BattleModel.ins.battleSubType == BattleSubType.AUTO)
            {
                cdLeft -= (BattleDef.MANUAL_ROUND_CD_SECONDS - BattleDef.AUTO_ROUND_CD_SECONDS);
            }
            if (cdLeft * 1000 >= ClientConstantDef.CHAT_BUBBLE_SHOW_TIME_MS)
            {
                if (data.uuidL == 0 && isAlive)
                {
                    //可以说话
                    if (data!=null&&data.enemyTpl!=null&&data.enemyTpl.speakList!=null)
                    {
                        //移除空的
                        for (int i=0;i<data.enemyTpl.speakList.Count;i++)
                        {
                            if (string.IsNullOrEmpty(data.enemyTpl.speakList[i]))
                            {
                                data.enemyTpl.speakList.RemoveAt(i);
                                i--;
                            }
                        }
                        //说话
                        if (data.enemyTpl.speakList.Count>0)
                        {
                            int randIndex = Random.Range(0, data.enemyTpl.speakList.Count);
                            if (randIndex == data.enemyTpl.speakList.Count)
                            {
                                randIndex = data.enemyTpl.speakList.Count-1;
                            }
                            ShowChatBubble(data.enemyTpl.speakList[randIndex],false,true,BattleModel.ins.maxModelHeight + 0.7f);
                        }
                    }
                }
            }
        }

        //temp
        /*
        public void SetInitPos(Vector3 pos)
        {
            localBattlePos = pos;
            globalBattlePos = pos;
            localPosition = pos;
            globalPosition = pos;
        }
        */
    }
}