using System.Collections.Generic;
using app.avatar;
using app.battle;
using app.db;
using app.npc;
using UnityEngine;
using UnityEngine.UI;
using app.model;
using DG.Tweening;

namespace app.story
{
    /// <summary>
    /// 对一个目标播放技能
    /// 说话
    /// 掉血冒字
    /// 逃跑
    /// 击飞 
    /// </summary>
    public class StoryBattleAvatar:AvatarBase
    {
        //当前角色的战斗位置
        private Vector3 avatarPos;
        //当前角色的朝向
        private Vector3 avatarEulerAngles;
        
        //对象
        public GameObject displayModelContainer { get; private set; }
        private ProgressBar mBloodBar = null;
        private GameObject mBloodBarGo = null;
        private GameObject mAvatarNameGo = null;
        private GameObject mSkillNameGo = null;
        private StoryBatSkill mCurSkill = null;
        private List<BatBubble> mDoingBubbles = new List<BatBubble>();
        //状态
        public bool isInited { get; private set; }
        //当前数据
        public StoryBattleTemplate CurData;
        //最大血量
        public int maxHP;
        //当前血量
        public int curHP { get; private set; }

        private float mSkillNamesTotalHeight = 0.0f;
        private float mSkillNameHideCD = 0;
        private string mCurSkillNameTexturePath = null;
        private Vector3 mLastFixedWorldPos = Vector3.zero;

        private bool mIsShaking = false;
        private int mLastShakeStamp = 0;

        public StoryBattleAvatar()
        {
            isInited = false;
        }

        public void InitStory(StoryBattleTemplate data)
        {
            isInited = false;
            
            if (displayModelContainer == null)
            {
                displayModelContainer = new GameObject(data.targetName);
            }
            displayModelContainer.transform.SetParent(GetParent());
            displayModelContainer.layer = GetLayer();

            this.CurData = StoryDef.cloneTpl(data);
            maxHP = data.hp;
            curHP = maxHP;
            Vector3 position = Vector3.zero;
            position = SceneModel.ins.zoneCamsContainer.transform.localPosition + StoryDef.getPos(data);
            avatarPos = position;

            Vector3 angle = Vector3.zero;
            if (data.posX==1)
            {
                angle = new Vector3(0, NPCDefine.GetNpcDirectionById(7), 0);
            }
            else if(data.posX==2)
            {
                angle = new Vector3(0, NPCDefine.GetNpcDirectionById(4), 0);
            }
            this.avatarEulerAngles = angle;

            base.Init(data.modelName, Vector3.zero, Vector3.zero, displayModelContainer.transform, true);

            CreateAvatarName();
            CreateBloodBar();
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);

            SetActive(true);
            if (curAnimName != ANIM_NAME_DEFENSE)
            {
                Idle();
            }
            if (null != displayModel)
            {
                displayModel.SetParticleEffectsActive(true);
            }
            localEulerAngles = avatarEulerAngles;
            
            InitPosition();
            UpdateBloodBarValue();

            displayModel.SetIsVariant(false);
            isInited = true;
        }

        public void changeModel(StoryBattleTemplate data)
        {
            CurData.modelName = data.modelName;
            base.Init(data.modelName, Vector3.zero, Vector3.zero, displayModelContainer.transform, true);
            //public void Init(string displayModelId, Vector3 pos, Vector3 rot, Transform parent, bool showShadow = true)
            //{
            //    mInitNeedSetPPR = true;
            //    mInitPos = pos;
            //    mInitRot = rot;
            //    mInitParent = parent;
            //    //mInitLayer = layer;
            //    InitAndLoadDisplayModel(displayModelId, showShadow);
            //}
        }

        /// <summary>
        /// 还原角色位置
        /// </summary>
        public void InitPosition()
        {
            localPosition = avatarPos;
            localEulerAngles = avatarEulerAngles;
        }
        /// <summary>
        /// 更新站位
        /// </summary>
        /// <param name="posx"></param>
        /// <param name="posy"></param>
        public void UpdatePosAndEuler(StoryBattleTemplate da)
        {
            Vector3 position = Vector3.zero;
                position = SceneModel.ins.zoneCamsContainer.transform.localPosition + StoryDef.getPos(da);
            avatarPos = position;
            localPosition = avatarPos;
            int direct = 0;
            if (da.direction != 0)
            {
                direct = da.direction;
            }
            else
            {
                if (da.posX == 1)
                {
                    direct = 7;
                }else if (da.posX==2)
                {
                    direct = 4;
                }
            }
            UpdateEulerAngles(direct);
            //存储 当前 位置数据
            CurData.posX = da.posX;
            CurData.posY = da.posY;
            CurData.direction = da.direction;
        }
        /// <summary>
        /// 更改朝向
        /// </summary>
        /// <param name="direction"></param>
        public void UpdateEulerAngles(int direction)
        {
            Vector3 angle = new Vector3(0, NPCDefine.GetNpcDirectionById(direction), 0);
            avatarEulerAngles = angle;
            localEulerAngles = avatarEulerAngles;
            //存储 当前 朝向数据
            CurData.direction = direction;
        }

        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId);
        }

        public Transform GetParent()
        {
            return StoryManager.ins.GetModelsContainer().transform;
        }

        public override int GetLayer()
        {
            return LayerConfig.Layer_StoryModel;
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
                UpdateBubbles();
                if (mCurPlayingAnim != null && mCurPlayingAnim.wrapMode != WrapMode.Loop &&
                    mCurPlayingAnim.time >= mCurPlayingAnim.length)
                {
                    if (curAnimName != ANIM_NAME_DIE && curAnimName != ANIM_NAME_DEFENSE)
                    {
                        Idle();
                    }
                }
                if (mIsShaking)
                {
                    if (mCurPlayingAnim != null && mCurPlayingAnim.name == ANIM_NAME_IDLE)
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

        public override bool FixedUpdate()
        {
            if (mCurSkill!=null)
            {
                mCurSkill.FixedUpdate();
            }
            if (base.FixedUpdate())
            {
                return true;
            }
            return false;
        }

        public void DoBatSkill(StoryBattleTemplate mdata)
        {
            CurData.skillId = mdata.skillId;
            CurData.skillTargets = mdata.skillTargets;
            CurData.hp = mdata.hp;

            if (CurData.skillId!=0)
            {
                DoSkill();
            }
        }

        /// <summary>
        /// 释放技能。
        /// </summary>
        public void DoSkill()
        {
            ClientLog.Log("###############  DO SKILL  ###################");
            if (CurData.skillId != 0)
            {
                if (!isActive)
                {
                    SetActive(true);
                }
                StoryBatSkill skill = new StoryBatSkill(this, CurData);
                skill.Start();
                mCurSkill = skill;
                //SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(CurData.skillid);
                //if (skillTpl != null && skillTpl.needShowOnRelease == 1 && !string.IsNullOrEmpty(skillTpl.bubble))
                //{
                //    ShowSkillName(skillTpl.bubble, PathUtil.Ins.skillNameAtlasPath);
                //}
                //ShowChatBubble("哎呀哎呀哎呀哎呀哎呀哎呀", false, true, 0);
            }
        }
        
        public void XPChanged(int hpDiff, bool isCrit, bool isDodgy, bool isDeadFly, BatCharacterAttackType attackType, bool isNoBubble)
        {
            ClientLog.Log("生命变化:" + hpDiff + "  法力变化:" + 0 + "  怒气变化:" + 0 + "  暴击:" + isCrit + "  闪避:" + isDodgy + "   攻击类型:" + attackType + "  是否不冒泡:" + isNoBubble);
            curHP += hpDiff;

            UpdateBloodBarValue();
            UpdateBloodBarVisible();

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
                        displayModel.SetParticleEffectsActive(false);

                        //角色语音
                        //if (data.type == PetType.FRIEND || data.type == PetType.LEADER || data.type == PetType.PET)
                        //{
                        //    if (!string.IsNullOrEmpty(data.petTpl.musicIds))
                        //    {
                        //        AudioManager.Ins.PlayAudio(data.petTpl.musicIds, AudioEnumType.Role);
                        //    }
                        //}
                    }
                    else
                    {
                        if (curAnimName != ANIM_NAME_DEFENSE)
                        {
                            PlayAnimation(ANIM_NAME_DAMAGE,1,0.2f,false,false);
                            if (isCrit)
                            {
                                DoDamageTween();
                            }
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
                    bubble = BattleBubbleManager.ins.BubbleHPChange(hpDiff, this.globalPosition, isCrit, attackType, mDoingBubbles.Count * 0.5f,true);
                    if (bubble != null)
                    {
                        mDoingBubbles.Add(bubble);
                    }
                }

                if (isCrit)
                {
                    BattleManager.ins.ShakeCamera();
                }
            }
        }

        private void DoDamageTween()
        {
            Vector3 pos = localPosition;
            if (this.CurData.posY >= 1 && this.CurData.posY <= 10)
            {
                if (this.CurData.posX == 1)
                {
                    //pos = StoryDef.atkPosList[this.CurData.posy - 1];
                    pos.x += 1.0f;
                }
                else
                {
                    //pos = StoryDef.defPosList[this.CurData.posy - 1];
                    pos.x -= 1.0f;
                }
            }
            else
            {
                pos = localPosition;
                pos.y -= 1.0f;
            }

            TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.2f, null, OnDamageTweenComplete, OnTweenUpdate);
        }

        private void OnDamageTweenComplete()
        {
            TweenUtil.MoveTo(this.displayModelContainer.transform, avatarPos, 0.2f, null, null, OnTweenUpdate);
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

        public void DoEscape(bool isEscaped=true)
        {
            Vector3 pos = Vector3.zero;
            if (this.CurData.posY >= 1 && this.CurData.posY <= 10)
            {
                if (this.CurData.posX == 1)
                {
                    pos = localPosition;
                    pos.x += (isEscaped ? 2.0f : 2.0f);
                    pos.z -= (isEscaped ? 2.0f : 2.0f);
                }
                else
                {
                    pos = localPosition;
                    pos.x -= (isEscaped ? 2.0f : 2.0f);
                    pos.z += (isEscaped ? 2.0f : 2.0f);
                }
            }
            else
            {
                pos = localPosition;
                pos.y -= 1.0f;
            }
            //转向
            Vector3 angle = localEulerAngles;
            if (CurData.posX == 1)
            {
                angle = new Vector3(0, NPCDefine.GetNpcDirectionById(4), 0);
            }
            else
            {
                angle = new Vector3(0, NPCDefine.GetNpcDirectionById(7), 0);
            }
            localEulerAngles = angle;

            //TweenUtil.RotateTo(this.displayModelContainer.transform, this.displayModelContainer.transform.localEulerAngles * -1, 0.1f);

            if (isEscaped)
            {
                TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.8f, DoEscapeStart, DoEscapeFinished, OnTweenUpdate, 0.1f);
            }
            else
            {
                TweenUtil.MoveTo(this.displayModelContainer.transform, pos, 0.5f, DoEscapeStart, DoEscapeFailed, OnTweenUpdate, 0.1f);
            }
        }

        private void DoEscapeStart()
        {
            PlayAnimation(ANIM_NAME_MOVE);
        }

        private void DoEscapeFailed()
        {
            localEulerAngles = avatarEulerAngles;
            TweenUtil.MoveTo(this.displayModelContainer.transform, avatarPos, 0.3f, null, DoEscapeFinished, OnTweenUpdate);
        }

        private void DoEscapeFinished()
        {
            Idle();
            SetActive(false);
            //InitPosition();
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

            Camera cam = StoryManager.ins.ModelCam.GetComponent<Camera>();

            Ray mRay;
            RaycastHit mHit;

            Vector3 footScrPos = cam.WorldToScreenPoint(localPosition);
            //Vector3 lbScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(-radiusX, 0, radiusZ));
            //Vector3 rtScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(radiusX, totalHeight, radiusZ));
            Vector3 centerScrPos = cam.WorldToScreenPoint(localPosition + new Vector3(0, displayModel.totalHeight / 2.0f, 0));

            Vector3[] path = new Vector3[3];
            if (CurData.posX == 1)
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
        }

        private void OnFlyComplete()
        {
            //Destroy();
            SetActive(false);
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

        public Vector3 localEulerAngles
        {
            get
            {
                return displayModelContainer.transform.localEulerAngles;
            }
            set
            {
                displayModelContainer.transform.localEulerAngles = value;
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

                if (CurData == null)
                {
                    return false;
                }

                return curHP > 0;
            }
        }

        public override void Destroy()
        {
            if (!isDestroied)
            {
                maxHP = 0;
                mIsShaking = false;
                isInited = false;
                CurData = null;
                DestroyBubbles();
                
                //AvatarTextManager.Ins.RemoveAvatarText(this.data.uuid + "_bloodbar");
                //AvatarTextManager.Ins.RemoveAvatarText(this.data.uuid + "_name");
                GameObject.DestroyImmediate(mBloodBar, true);
                GameObject.DestroyImmediate(mBloodBarGo, true);
                GameObject.DestroyImmediate(mAvatarNameGo, true);
                //SourceManager.Ins.removeReference(mBloodBarPath);
                GameObject.DestroyImmediate(mSkillNameGo, true);

                mBloodBar = null;
                mBloodBarGo = null;
                mAvatarNameGo = null;
                mSkillNameGo = null;
                base.Destroy();

                GameObject.DestroyImmediate(displayModelContainer, true);
                displayModelContainer = null;
                if (mCurSkill!=null)
                {
                    mCurSkill.Destroy();
                }
                mCurSkill = null;

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

                mBloodBarGo = AvatarTextManager.Ins.CreateAvatarText(CurData.targetName+ "_bloodbar", bloodBarPrefab, displayModelContainer.layer);
                mBloodBarGo.transform.eulerAngles = new Vector3(cavRot.x, 0, 0);
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
                v3.y += (StoryManager.ModelMaxHeight + 0.1f);
                mBloodBarGo.transform.position = v3;
            }
        }

        private void UpdateBloodBarValue()
        {
            if (mBloodBar != null)
            {
                mBloodBar.MaxValue = maxHP;
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
                if (CurData.targetType == 1)
                {//主角
                    color = new Color(71.0f / 255.0f, 1.0f, 57.0f / 255.0f);
                }
                else
                {//其他角色
                    color = new Color(71.0f / 255.0f, 1.0f, 57.0f / 255.0f);
                }
                mAvatarNameGo = AvatarTextManager.Ins.CreateAvatarText(this.CurData.targetName + "_name", this.CurData.targetName, color, true, 24, displayModelContainer.layer)[0];
                //AvatarTextManager.Ins.ShowAvatarText(mAvatarNameGo, displayModel.layer);
                mAvatarNameGo.transform.eulerAngles = new Vector3(cavRot.x, 0, 0);
                UpdateNamePos();
                UpdateNameVisible();
            }
        }

        public void UpdateAvatarName(string targetname)
        {
            if (CurData.targetType!=1&&!string.IsNullOrEmpty(targetname)&&CurData.targetName!=targetname)
            {
                //非主角
                CurData.targetName = targetname;
                if (mAvatarNameGo != null)
                {
                    Text label = mAvatarNameGo.GetComponentInChildren<Text>();
                    if (label != null)
                    {
                        label.text = CurData.targetName;
                    }
                }
            }
        }

        private void UpdateNamePos()
        {
            if (mAvatarNameGo != null)
            {
                Vector3 v3 = this.globalPosition;
                v3.y += (StoryManager.ModelMaxHeight + 0.55f);
                mAvatarNameGo.transform.position = v3;
            }
        }

        private void UpdateNameVisible()
        {
            if (mAvatarNameGo != null)
            {
                mAvatarNameGo.SetActive(this.isActive);
            }
        }

        public void ShowSkillName(string skillNameId, string dic)
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

                mSkillNameGo = AvatarTextManager.Ins.CreateAvatarText(CurData.targetId + "_skillName", skillNameGo, displayModelContainer.layer);
                mSkillNameGo.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                mSkillNameGo.transform.localEulerAngles = new Vector3(cavRot.x, 0, 0);
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
            if (CurData.posX == 1)
            {
                img.transform.localPosition = new Vector3(100, mSkillNamesTotalHeight, 0);
            }
            else if (CurData.posX==2)
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
                v3.y += (StoryManager.ModelMaxHeight + 0.2f);
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

        
    }
}
