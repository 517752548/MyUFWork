using System;
using app.chat;
using app.model;
using app.state;
using UnityEngine;
using UnityEngine.UI;
using app.zone;
using app.db;
using System.Collections.Generic;

namespace app.avatar
{
    public abstract class AvatarBase
    {
        public const string ANIM_NAME_IDLE = "idle";
        public const string ANIM_NAME_MOVE = "move";
        public const string ANIM_NAME_DAMAGE = "damage";
        public const string ANIM_NAME_DEFENSE = "defense";
        public const string ANIM_NAME_DIE = "die";

        public const string ANIM_NAME_RIDE_IDLE = "c_idle";
        public const string ANIM_NAME_RIDE_MOVE = "c_move";

        public const string ANIM_NAME_ATTACK = "attack";

        public bool isActive { get; private set; }
        public bool isDestroied { get; private set; }

        public string curAnimName { get; private set; }

        public string displayModelId { get; private set; }
        protected string[] mResPathes = null;
        private AvatarDisplayCache mDisplayModel = null;
        protected Animation mAnim = null;
        protected AnimationState mCurPlayingAnim = null;

        protected string mChatBubblePath = null;
        protected UGUIRichTextOptimized mChatBubbleText = null;
        protected GameObject mChatBubbleGo = null;
        protected GameObject chatBubbleTextgo;
        protected string chatContent = "";
        private float chatBubbleY = 0.0f;
        protected Vector3 mLastFixedChatContentPos = Vector3.zero;
        protected RTimer chatShowTimer;
        private string mShadowEffectPath = null;
        public AvatarWing wing { get; private set; }
        public bool isEnableWing { get; protected set; }
        protected WingTemplate wingTpl = null;
        protected bool mIsEnableRidePet = true;
        private bool mIsDisplayModelCreated = false;
        private bool mNeedShowWingAfterInitDisplayModel = false;

        public bool isEnableWeapon { get; protected set; }
        public bool isShowingWeapon { get; private set; }
        public EquipItemTemplate weaponTpl { get; protected set; }
        //protected string mWeaponLName = null;
        //protected string mWeaponRName = null;
        private bool mNeedShowWeaponAfterInitDisplayModel = false;
        public AvatarWeapon weaponL { get; private set; }
        public AvatarWeapon weaponR { get; private set; }
        
        protected bool mIsTeamLeaderWhenChat = false;
        protected bool mIsInBattleWhenChat = false;

        public bool isHalfOpaque { get; private set; }

        private Transform mInitParent = null;
        private Vector3 mInitPos = Vector3.zero;
        private Vector3 mInitRot = Vector3.zero;
        //private int mInitLayer = 0;
        private bool mInitNeedSetPPR = false;

        private bool mParticlesWritable = false;

        public AvatarBase()
        {
            isEnableWing = true;
            isEnableWeapon = true;
            isActive = true;
            isDestroied = false;
        }

        public void Init(string displayModelId, bool showShadow = true, bool particlesWritable = true)
        {
            mInitNeedSetPPR = false;
            mParticlesWritable = particlesWritable;
            InitAndLoadDisplayModel(displayModelId, showShadow);
        }


        public void Init(string displayModelId, Vector3 pos, Vector3 rot, Transform parent, bool showShadow = true, bool particlesWritable = true)
        {
            mInitNeedSetPPR = true;
            mInitPos = pos;
            mInitRot = rot;
            mInitParent = parent;
            mParticlesWritable = particlesWritable;
            //mInitLayer = layer;
            InitAndLoadDisplayModel(displayModelId, showShadow);
        }


        private void InitAndLoadDisplayModel(string displayModelId, bool showShadow = true)
        {
            this.displayModelId = displayModelId;
            mResPathes = GetDisplayModelPath();
            mAnim = null;
            mCurPlayingAnim = null;
            mIsDisplayModelCreated = false;

            if (showShadow)
            {
                mShadowEffectPath = PathUtil.Ins.GetEffectPath("shadow_shadow");
            }

            int len = mResPathes.Length;
            List<object[]> kvList = new List<object[]>();
            for (int i = 0; i < len; i++)
            {
                if (!SourceManager.Ins.hasAssetBundle(mResPathes[i]))
                {
                    kvList.Add(new object[]{mResPathes[i], LoadArgs.SLIMABLE, LoadContentType.ABL});
                }
            }

            SourceLoader.Ins.loadList(kvList, InitDisplayModel);
            //SourceLoader.Ins.load(mResPath, InitDisplayModel);
        }

        public abstract string[] GetDisplayModelPath();

        public void ShowChatBubble(string chatcontent, bool isTeamLeader = false, bool isInBattle = false, float y = 0.0f)
        {
            this.chatContent = chatcontent;
            this.mIsTeamLeaderWhenChat = isTeamLeader;
            this.mIsInBattleWhenChat = isInBattle;
            this.chatBubbleY = y;
            if (mChatBubbleGo == null)
            {
                mChatBubblePath = PathUtil.Ins.GetUIPath("CharacterSceneChatUI");
                SourceLoader.Ins.load(mChatBubblePath, OnChatBubblePrefabLoaded);
            }
            else
            {
                OnChatBubblePrefabLoaded();
            }
        }

        private void OnChatBubblePrefabLoaded(RMetaEvent e = null)
        {
            if (this.isDestroied)
            {
                return;
            }
            if (mChatBubbleGo == null)
            {
                GameObject chatBubblePrefab = SourceManager.Ins.createObjectFromAssetBundle(mChatBubblePath);
                chatBubbleTextgo = chatBubblePrefab.transform.Find("beijing/Text").gameObject;
                /*
                mChatBubbleGo = AvatarTextManager.Ins.CreateAvatarText(displayModelId + "_ChatBubble", chatBubblePrefab,
                    mDisplayModel!=null?mDisplayModel.avatar.layer:LayerConfig.Layer_ZoneModel);
                */
                mChatBubbleGo = AvatarTextManager.Ins.CreateAvatarText(displayModelId + "_ChatBubble", chatBubblePrefab, GetLayer());
            }
            if (mChatBubbleText == null)
            {
                mChatBubbleText = UGUIRichTextOptimized.Create(chatBubbleTextgo.transform, "chatText");
            }
            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;
                mChatBubbleGo.transform.eulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
            }
            else if (StateManager.Ins.getCurState().state == StateDef.zoneState || StateManager.Ins.getCurState().state == StateDef.storyState)
            {
                mChatBubbleGo.transform.localRotation = SceneModel.ins.zone3DModelCam.transform.localRotation;
            }

            ChatModel.Ins.setChatText(mChatBubbleText,chatContent,24,0,Color.white);
            mChatBubbleGo.SetActive(true);
            mChatBubbleGo.transform.SetAsLastSibling();
            UpdateChatBubblePos();
            if (chatShowTimer == null)
            {
                chatShowTimer = TimerManager.Ins.createTimer(1000, ClientConstantDef.CHAT_BUBBLE_SHOW_TIME_MS, null, timerEnd);
            }
            else
            {
                chatShowTimer.stop();
                chatShowTimer.Reset(1000, ClientConstantDef.CHAT_BUBBLE_SHOW_TIME_MS);
                chatShowTimer.Restart();
            }
            chatShowTimer.start();
        }


        private void timerEnd(RTimer r)
        {
            chatShowTimer = null;
            if (mChatBubbleGo != null) mChatBubbleGo.SetActive(false);
            if (mChatBubbleText != null) GameObject.DestroyImmediate(mChatBubbleText.gameObject,true);
            mChatBubbleText = null;
        }

        protected virtual void UpdateChatBubblePos()
        {
            if (this.mChatBubbleGo != null && this.mChatBubbleGo.activeSelf)
            {
                Vector3 v3 = Vector3.zero;
                if (mDisplayModel != null && mDisplayModel.avatar != null)
                {
                    v3 = mDisplayModel.avatar.transform.position;
                    if (chatBubbleY != 0)
                    {
                        v3.y += chatBubbleY;
                    }
                    else
                    {
                        v3.y += (mDisplayModel.totalHeight + 0.2f);
                        if (this.mIsInBattleWhenChat)
                        {
                            v3.y += 0.8f;
                        }
                        else if (this.mIsTeamLeaderWhenChat)
                        {
                            v3.y += 0.8f;
                        }
                    }
                    v3.z -= 0.05f;
                }
                
                //mChatBubbleGo.transform.position = v3;
                if (mLastFixedChatContentPos != v3)
                {
                    mChatBubbleGo.transform.position = v3;
                    mLastFixedChatContentPos = v3;
                }
            }
        }

        public virtual void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }

            if (this.mDisplayModel != null)
            {
                this.mDisplayModel.UnUse();
                //SourceManager.Ins.removeReference(mResPath, mDisplayModel);
            }

            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                CreateAvatarDisplayModel(mResPathes[mResPathes.Length - 1]);
            }
            else
            {
                CreateAvatarDisplayModel("empty");
                //ClientLog.LogError(mResPath + "  Load Error!");
            }

            if (mNeedShowWingAfterInitDisplayModel)
            {
                ShowWing(wingTpl);
            }
            else
            {
                if (!isEnableWing)
                {
                    HideWing(false);
                }
            }

            if (mNeedShowWeaponAfterInitDisplayModel)
            {
                ShowWeapon(this.weaponTpl);
            }
            else
            {
                if (!isEnableWeapon)
                {
                    HideWeapon(false);
                }
            }
        }

        public virtual bool Update()
        {   
            if (!isDestroied && isActive)
            {
                UpdateChatBubblePos();
                return true;
            }
            return false;
        }

        public virtual bool FixedUpdate()
        {
            if (!isDestroied && isActive)
            {
                return true;
            }
            return false;
        }

        public virtual bool LateUpdate()
        {
            if (!isDestroied && isActive)
            {
                return true;
            }
            return false;
        }

        public AvatarDisplayCache displayModel
        {
            get
            {
                return mDisplayModel;
            }
        }

        /// <summary>
        /// 播放动作。
        /// </summary>
        /// <param name="name">动作名称。</param>
        /// <param name="speed">播放速度（1为正常速度，－1时直接跳到动作最后一帧）。</param>
        /// <param name="crossFadeTime">动作切换时的过渡时长（秒）。</param>
        public virtual AnimationState PlayAnimation(string name, float speed = 1.0f, float crossFadeTime = 0.2f, bool force = false,bool throwError=true)
        {
            if (mAnim == null)
            {
                if (displayModel != null && displayModel.avatar != null)
                {
                    ClientLog.LogWarning(displayModelId + " 模型没有任何动作!");
                }
                curAnimName = null;
                return null;
            }

            if (mCurPlayingAnim == null || (name != mCurPlayingAnim.name || force))
            {
                if (mAnim.GetClip(name) == null)
                {
                    if (throwError)
                    {
                        ClientLog.LogError(displayModelId + " 模型没有动作： " + name + "!");
                    }
                    curAnimName = null;
                    mCurPlayingAnim = null;
                    return null;
                }

                if (mCurPlayingAnim != null)
                {
                    mAnim.CrossFade(name, crossFadeTime);
                }
                else
                {
                    mAnim.Play(name);
                }

                curAnimName = name;
                mCurPlayingAnim = mAnim[name];

                if (speed == -1)
                {
                    mCurPlayingAnim.time = mCurPlayingAnim.length;
                }
                else
                {
                    mCurPlayingAnim.speed = speed;
                }

                if (wing != null)
                {
                    if (wing.HasAnimation(name))
                    {
                        wing.PlayAnimation(name, speed, crossFadeTime, force);
                    }
                }

                return mCurPlayingAnim;
            }
            return null;
        }

        public bool HasAnimation(string name)
        {
            if (mAnim == null)
            {
                return false;
            }

            return mAnim.GetClip(name) != null;
        }

        public virtual void SetActive(bool value)
        {
            if (isActive != value)
            {
                isActive = value;
                if (mDisplayModel != null)
                {
                    if (mDisplayModel.avatar != null)
                    {
                        mDisplayModel.avatar.SetActive(value);
                    }

                    if (isActive)
                    {
                        if (!string.IsNullOrEmpty(curAnimName))
                        {
                            PlayAnimation(curAnimName, 1.0f, 0.2f, true);
                        }
                    }
                    else
                    {
                        if (chatShowTimer != null)
                        {
                            timerEnd(null);
                        }
                    }
                }
            }

        }

        public virtual void Destroy()
        {
            if (!isDestroied)
            {
                isDestroied = true;

                //SetIsHalfOpaque(false);

                //SourceManager.Ins.removeReference(mResPath, mDisplayModel);
                //SourceManager.Ins.removeReference(mShadowEffectPath, mShadow);
                if (mDisplayModel != null)
                {
                    mDisplayModel.UnUse();
                    mDisplayModel = null;
                }

                if (mCurPlayingAnim != null)
                {
                    mCurPlayingAnim = null;
                }

                SourceManager.Ins.removeReference(mChatBubblePath, mChatBubbleGo);
                mChatBubbleGo = null;
                if (mChatBubbleText != null) GameObject.DestroyImmediate(mChatBubbleText,true);
                if (chatShowTimer != null)
                {
                    timerEnd(null);
                }

                if (wing != null)
                {
                    wing.Destroy();
                    wing = null;
                }
                
                if (weaponL != null)
                {
                    weaponL.Destroy();
                    weaponL = null;
                }
                
                if (weaponR != null)
                {
                    weaponR.Destroy();
                    weaponR = null;
                }
            }
        }

        public virtual void SetIsHalfOpaque(bool value)
        {
            isHalfOpaque = value;

            if (displayModel != null)
            {
                displayModel.SetIsHalfOpaque(value);
            }
            if (wing != null)
            {
                wing.SetIsHalfOpaque(value);
            }
            
            if (weaponL != null)
            {
                weaponL.SetIsHalfOpaque(value);
            }
            
            if (weaponR != null)
            {
                weaponR.SetIsHalfOpaque(value);
            }
        }

        private void CreateAvatarDisplayModel(string cacheName)
        {
            mDisplayModel = (AvatarDisplayCache)(MemCache.FetchFreeCache(cacheName, MemCacheType.AVATAR));
            if (mDisplayModel == null)
            {
                GameObject go = null;

                if (cacheName != "empty")
                {
                    go = (GameObject)SourceManager.Ins.createObjectFromAssetBundle(cacheName);
                    int len = mResPathes.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (mResPathes[i] != cacheName)
                        {
                            SourceManager.Ins.addReference(mResPathes[i]);
                        }
                    }
                }
                else
                {
                    go = new GameObject(cacheName);
                }

                //go.name = displayModelId;

                mDisplayModel = new AvatarDisplayCache(displayModelId, go, cacheName, mShadowEffectPath, mResPathes, mParticlesWritable);
                MemCache.Cache(mDisplayModel);
            }
            mDisplayModel.Use();
            if (mDisplayModel.avatar != null)
            {
                if (mInitNeedSetPPR)
                {
                    mDisplayModel.avatar.transform.SetParent(mInitParent);
                    mDisplayModel.avatar.transform.localPosition = mInitPos;
                    mDisplayModel.avatar.transform.localEulerAngles = mInitRot;
                    GameObjectUtil.SetLayer(displayModel.avatar, GetLayer());
                    mDisplayModel.avatar.SetActive(isActive);
                }

                //mDisplayModel.avatar.transform.localPosition = Vector3.zero;
                //mDisplayModel.avatar.transform.position = Vector3.zero;
                //mDisplayModel.avatar.transform.localEulerAngles = Vector3.zero;
                //mDisplayModel.avatar.transform.eulerAngles = Vector3.zero;
                mAnim = mDisplayModel.avatar.GetComponent<Animation>();
                //this.mDisplayModel.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);

            }
            if (curAnimName != null)
            {
                PlayAnimation(curAnimName);
            }

            mIsDisplayModelCreated = true;
        }

        public void ShowWing(WingTemplate tpl)
        {
            wingTpl = tpl;
            if (tpl == null || string.IsNullOrEmpty(tpl.modelId))
            {
                return;
            }

            if (isEnableWing)
            {
                if (mIsDisplayModelCreated)
                {
                    if (wing == null || wing.isDestroied)
                    {
                        wing = new AvatarWing();
                    }

                    wing.Init(tpl, this);
                    mNeedShowWingAfterInitDisplayModel = false;
                }
                else
                {
                    mNeedShowWingAfterInitDisplayModel = true;
                }
            }
            else
            {
                mNeedShowWingAfterInitDisplayModel = false;
            }
        }

        public void HideWing(bool isHideByServer)
        {
            if (wing != null)
            {
                wing.Destroy();
                wing = null;
                //mWing.SetActive(false);
            }

            if (isHideByServer)
            {
                wingTpl = null;
            }
        }

        public void ShowWeapon(EquipItemTemplate weaponTpl)
        {
            if (weaponTpl == null)
            {
                throw new Exception("隐藏武器请调用HideWeapon");
            }

            this.weaponTpl = weaponTpl;

            if (isEnableWeapon)
            {
                if (mIsDisplayModelCreated)
                {
                    if (string.IsNullOrEmpty(this.weaponTpl.leftModel))
                    {
                        if (weaponL != null && !weaponL.isDestroied)
                        {
                            weaponL.Destroy();
                            weaponL = null;
                        }
                    }
                    else
                    {
                        if (weaponL == null || weaponL.isDestroied)
                        {
                            weaponL = new AvatarWeapon();
                        }
                        if (weaponL.displayModelId != this.weaponTpl.leftModel)
                        {
                            weaponL.Init(this.weaponTpl, this, AvatarWeapon.WeaponPos.L);
                        }
                    }

                    if (string.IsNullOrEmpty(this.weaponTpl.rightModel))
                    {
                        if (weaponR != null && !weaponR.isDestroied)
                        {
                            weaponR.Destroy();
                            weaponR = null;
                        }
                    }
                    else
                    {
                        if (weaponR == null || weaponR.isDestroied)
                        {
                            weaponR = new AvatarWeapon();
                        }
                        if (weaponR.displayModelId != this.weaponTpl.rightModel)
                        {
                            weaponR.Init(this.weaponTpl, this, AvatarWeapon.WeaponPos.R);
                        }
                    }
                    mNeedShowWeaponAfterInitDisplayModel = false;
                }
                else
                {
                    mNeedShowWeaponAfterInitDisplayModel = true;
                }
            }
            else
            {
                mNeedShowWeaponAfterInitDisplayModel = false;
            }

            isShowingWeapon = true;
        }

        public void HideWeapon(bool isHideByServer)
        {
            if (weaponL != null)
            {
                weaponL.Destroy();
                weaponL = null;
            }

            if (weaponR != null)
            {
                weaponR.Destroy();
                weaponR = null;
            }

            if (isHideByServer)
            {
                this.weaponTpl = null;
            }

            isShowingWeapon = false;
        }

        public virtual int GetLayer()
        {
            return LayerConfig.Layer_Default;
        }
    }
}