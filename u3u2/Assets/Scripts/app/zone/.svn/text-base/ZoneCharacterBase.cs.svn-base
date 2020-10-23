using app.avatar;
using UnityEngine;
using app.utils;
using app.model;
using UnityEngine.UI;

namespace app.zone
{
    public class ZoneCharacterBase : AvatarBase
    {
        public long uuid { get; private set; }
        public string name { get; private set; }
        public bool isSelf { get; set; }
        //public bool m_bneedCh = false; //是否需要创建称号

        public AvatarDisplayCache displayModelForLoc { get; protected set; }
        protected GameObject mDisplayModelContainer = null;
        protected GameObject mAvatarText { get; private set; }
        protected Color mCharacterNameColor = Color.white;
        //protected bool mIsEnableRidePet = false;
        //private int mWearingFashionTplId = -1;
        private Text mNameLabel = null; //name的text
        private Vector3 mLastFixedModelPos = Vector3.zero;
        private Vector3 mLastFixedAvatarTextPos = Vector3.zero;

        private Vector3 mLastCheckOpaqueUnityPos = Vector3.zero;
        private int[] mLastCheckOpaqueTilePos = new int[2];

        /// <summary>
        /// 0默认，1伐木，2采药，3采矿，4狩猎，5战斗
        /// </summary>
        protected HeadFlag mIsInBattle = HeadFlag.NONE;
        protected GameObject mBattleSign = null;
        protected GameObject mBattleSignParetn = null;
        protected Vector3 mLastFixedBattleSignPos = Vector3.zero;
        /// <summary>
        /// 上次路径名称，头顶状态
        /// </summary>
        private string m_lastpath = "";

        public ZoneCharacterBase()
        {

        }

        public virtual HeadFlag isInBattle

        {
            get
            {
                return mIsInBattle;
            }
            set
            {
                mIsInBattle = value;
                if (HeadFlag.NONE != value)
                {
                    ShowBattleSign();
                }
                else
                {
                    HideBattleSign();
                }
            }
        }
        public virtual void Init(long uuid, string displayModelId, string name, Vector3 pos, Vector3 angle, bool showShadow = true, bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true, bool particlesWritable = true)
        {
            this.uuid = uuid;
            this.name = name;
            mIsEnableRidePet = isEnableRidePet;
            base.isEnableWing = isEnableWing;
            base.isEnableWeapon = isEnableWeapon;
            if (mDisplayModelContainer == null)
            {
                mDisplayModelContainer = new GameObject(name);
            }
            mDisplayModelContainer.transform.SetParent(GetParent());
            mDisplayModelContainer.layer = GetLayer();
            localPosition = pos;
            localEulerAngles = angle;
            CreateAvatarText();
            base.Init(displayModelId, ZoneUtil.GetFixedPosition(mDisplayModelContainer.transform), Vector3.zero, mDisplayModelContainer.transform, showShadow, particlesWritable);
            //base.Init(displayModelId, showShadow);
        }

        public virtual Transform GetParent()
        {
            return SceneModel.ins.zoneModelContainer.transform;
        }

        public override int GetLayer()
        {
            return SceneModel.ins.zoneModelContainer.layer;
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);
            displayModelForLoc = displayModel;
            //displayModel.avatar.SetActive(false);
            //displayModel.avatar.name = this.uuid.ToString();
            //displayModel.avatar.transform.SetParent(mDisplayModelContainer.transform);
            //GameObjectUtil.SetLayer(displayModel.avatar, mDisplayModelContainer.layer);

            //Debug.LogError(displayModelId + ":" + ZoneUtil.GetFixedPosition(mDisplayModelContainer.transform));
            mLastFixedModelPos = displayModel.avatar.transform.localPosition;
			if (mAvatarText != null)
			{
				mAvatarText.SetActive (this.isActive);
			}
            //FixPosition();
            //displayModel.avatar.SetActive(true);
            //本来称号判断是写这里的 但是觉得每次NPC创建也会走这 因为NPC不需要称号嘛 所以我移到父类zonecharacter中 但是还没测试是否有bug、
            //如果有bug在移回来吧  马劲松~~
        }

        private void CreateAvatarText()
        {
            if (mAvatarText != null)
            {
                GameObject.DestroyImmediate(mAvatarText, true);
                mAvatarText = null;
            }
            if (!string.IsNullOrEmpty(name))
            {
                GameObject[] objs = AvatarTextManager.Ins.CreateAvatarText(GetGameObjectName(), name, mCharacterNameColor, true, GetLayer());
                mAvatarText = objs[0];
                mNameLabel = objs[1].GetComponent<Text>();
                mAvatarText.transform.localRotation = SceneModel.ins.zone3DModelCam.transform.localRotation;
                //mAvatarText.SetActive(this.isActive);
            }
            FixAvatarTextPosition();
        }

        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId);
        }

        /// <summary>
        /// 更新角色名字显示。
        /// </summary>
        public void UpdateNameDisplay(string text)
        {
            if (mNameLabel != null)
            {
                mNameLabel.text = text;
            }
        }

        public virtual string GetGameObjectName()
        {
            return uuid.ToString();
        }

        public override bool Update()
        {
            if (base.Update())
            {
                FixPosition();
                return true;
            }
            return false;
        }

        public override bool FixedUpdate()
        {
            if (base.FixedUpdate())
            {
                return true;
            }
            return false;
        }

        public override bool LateUpdate()
        {
            if (base.LateUpdate())
            {
                FixAvatarTextPosition();
                FixBattleSignPosition();
                CheckOpaque();
                return true;
            }
            return false;
        }

        public virtual Vector3 localPosition
        {
            get
            {
                if (mDisplayModelContainer == null)
                {
                    return Vector3.zero;
                }
                return mDisplayModelContainer.transform.localPosition;
            }
            set
            {
                if (mDisplayModelContainer != null)
                {
                    mDisplayModelContainer.transform.localPosition = value;
                }
            }
        }

        public virtual Vector3 globalPosition
        {
            get
            {
                return mDisplayModelContainer.transform.position;
            }
            set
            {
                mDisplayModelContainer.transform.position = value;
            }
        }

        public Vector3 localEulerAngles
        {
            get
            {
                return mDisplayModelContainer.transform.localEulerAngles;
            }
            set
            {
                mDisplayModelContainer.transform.localEulerAngles = value;
            }
        }

        public Vector3 forward
        {
            get
            {
                return mDisplayModelContainer.transform.forward;
            }
        }
        /*
        public int WearingFashionTplId
        {
            get { return mWearingFashionTplId; }
            set { mWearingFashionTplId = value; }
        }
        */
        protected virtual void FixPosition()
        {
            if (displayModelForLoc != null && displayModelForLoc.avatar != null)
            {
                Vector3 pos = ZoneUtil.GetFixedPosition(mDisplayModelContainer.transform);
                if (pos != mLastFixedModelPos)
                {
                    displayModelForLoc.avatar.transform.localPosition = pos;
                    mLastFixedModelPos = pos;
                }
            }
        }

        protected virtual void FixAvatarTextPosition()
        {
			if (mAvatarText != null)
			{
				Vector3 v3;
				if (displayModelForLoc != null && displayModelForLoc.avatar != null)
				{
					v3 = displayModelForLoc.avatar.transform.position;
                    if (displayModelForLoc.radiusMax >= displayModelForLoc.radiusMin * 2)
                    {
                        v3.y -= (displayModelForLoc.radiusMin + displayModelForLoc.radiusMax) / 3.0f;
                    }
                    else
                    {
                        v3.y -= (displayModelForLoc.radiusMin + displayModelForLoc.radiusMax) / 2.0f;
                    }
				}
				else
				{
					v3 = mDisplayModelContainer.transform.TransformPoint (ZoneUtil.GetFixedPosition (mDisplayModelContainer.transform));
				}
				if (mLastFixedAvatarTextPos != v3)
				{
					mAvatarText.transform.localPosition = v3;
					//AvatarTextManager.Ins.updateAvatarTextPosition(uuid.ToString(), v3);
					mLastFixedAvatarTextPos = v3;
				}
			}
        }

        protected virtual void FixBattleSignPosition()
        {
            if (mBattleSignParetn != null)
            {
                Vector3 v3 = Vector3.zero;
                if (displayModelForLoc != null && displayModelForLoc.avatar != null)
                {
                    v3 = displayModelForLoc.avatar.transform.position;
                    if (null != mBattleSign)
                    {
                        v3.x -= mBattleSign.transform.localPosition.x;
                        v3.y -= mBattleSign.transform.localPosition.y - 0.4f;
                        v3.z -= mBattleSign.transform.localPosition.z;
                    }
                    v3.y += (displayModelForLoc.totalHeight + 0.1f);
                }

                v3.z -= 0.05f;
                mBattleSignParetn.transform.position = v3;
                if (mLastFixedBattleSignPos != v3)
                {
                    mBattleSignParetn.transform.position = v3;
                    mLastFixedBattleSignPos = v3;
                }
            }
        }

        protected virtual void CheckOpaque()
        {
            if (displayModel != null)
                {
                    if (mLastCheckOpaqueUnityPos != localPosition)
                    {
                        mLastCheckOpaqueUnityPos = localPosition;
                        int[] pathTilePos = ZoneUtil.ConvertUnityPos2PathTilePos(localPosition);
                        if (mLastCheckOpaqueTilePos[0] != pathTilePos[0] || mLastCheckOpaqueTilePos[1] != pathTilePos[1])
                        {
                            mLastCheckOpaqueTilePos[0] = pathTilePos[0];
                            mLastCheckOpaqueTilePos[1] = pathTilePos[1];
                            int colCount = SceneModel.ins.zoneMapConfig.pathTileColCount;
                            int rowCount = SceneModel.ins.zoneMapConfig.pathTileRowCount;

                            if (pathTilePos[0] >= 0 && pathTilePos[0] < colCount && pathTilePos[1] >= 0 && pathTilePos[1] < rowCount)
                            {
                                if (SceneModel.ins.zoneMapConfig.pathTilesMarix[pathTilePos[0]][pathTilePos[1]] == 'o')
                                {
                                    SetIsHalfOpaque(true);
                                }
                                else
                                {
                                    SetIsHalfOpaque(false);
                                }
                            }
                            else
                            {
                                SetIsHalfOpaque(false);
                            }
                        }
                    }
                }
        }

        public override void SetActive(bool value)
        {
            if (mDisplayModelContainer != null)
            {
                mDisplayModelContainer.SetActive(value);
            }
            if (mAvatarText != null)
            {
                mAvatarText.SetActive(value);
            }
            base.SetActive(value);
        }

        public void ShowBattleSign()
        {
            if (mBattleSign == null || !mBattleSign.name.Contains(GetHeadFlagEffectName()))
            {

                SourceLoader.Ins.load(PathUtil.Ins.GetEffectPath(GetHeadFlagEffectName()), OnBattleSignLoaded,null,mIsInBattle);
            }
            else
            {
                mBattleSign.SetActive(true);
            }
        }

        private void OnBattleSignLoaded(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo data = e.data as LoadInfo;
                HeadFlag battleflag = (HeadFlag)data.param;
                if (mIsInBattle == HeadFlag.NONE)
                {
                    HideBattleSign();
                }
                else if (mIsInBattle == battleflag)
                {
                    if (null == mBattleSignParetn)
                    {
                        mBattleSignParetn = new GameObject(GetGameObjectName()+"battlesign");
                        mBattleSignParetn.transform.SetParent(mAvatarText.transform.parent);
                        mBattleSignParetn.transform.localScale = Vector3.one;
                        mBattleSignParetn.transform.localEulerAngles = Vector3.zero;
                        FixBattleSignPosition();
                    }
                    if (null != mBattleSign)
                    {
                        SourceManager.Ins.removeReference(m_lastpath, mBattleSign);
                    }
                    string path = PathUtil.Ins.GetEffectPath(GetHeadFlagEffectName());
                    mBattleSign = SourceManager.Ins.createObjectFromAssetBundle(path);

                    mBattleSign.transform.SetParent(mBattleSignParetn.transform);
                    GameObjectUtil.SetLayer(mBattleSign, mDisplayModelContainer.layer);
                    m_lastpath = path;
                    mBattleSign.SetActive(true);
                }
            }
        }

        private string GetHeadFlagEffectName()
        {
            string effectname = "";
            switch (mIsInBattle)
            {
                case HeadFlag.FA_MU:
                    effectname = "common_famubuff";
                    break;
                case HeadFlag.CAI_YAO:
                    effectname = "common_zhandou";
                    break;
                case HeadFlag.CAI_KUANG:
                    effectname = "common_caikuangbuff";
                    break;
                case HeadFlag.SHOU_LIE:
                    effectname = "common_shouliebuff";
                    break;
                case HeadFlag.ZHAN_DOU:
                    effectname = "common_zhandou";
                    break;
            }
            return effectname;
        }

        public void HideBattleSign()
        {
            if (mBattleSign != null)
            {
                mBattleSign.SetActive(false);
            }
        }

        public override void Destroy()
        {
            if (!isDestroied)
            {
                base.Destroy();
                //AvatarTextManager.Ins.RemoveAvatarText(uuid.ToString());
                GameObject.DestroyImmediate(mDisplayModelContainer, true);
                mDisplayModelContainer = null;
                GameObject.DestroyImmediate(mAvatarText, true);
                mAvatarText = null;
                if(null != mBattleSignParetn)
                {
                    GameObject.DestroyImmediate(mBattleSignParetn, true);
                }
                mBattleSignParetn = null;
            }
        }


    }
}

