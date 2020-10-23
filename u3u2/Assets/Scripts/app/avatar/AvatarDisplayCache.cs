using System.Collections.Generic;
using UnityEngine;
using app.main;
using app.utils;
using app.system;

namespace app.avatar
{
    public class AvatarDisplayCache : Cacheable
    {
        public GameObject avatar { get; private set; }
        public string avatarName { get; private set; }

        /// <summary>
        /// 模型原始比例。
        /// </summary>
        public Vector3 orgScale { get; private set; }

        public float radiusMin { get; private set; }
        public float radiusMax { get; private set; }
        public float radiusX { get; private set; }
        public float radiusFront { get; private set; }
        public float bodyHeight { get; private set; }
        public float footHeight { get; private set; }
        public float totalHeight { get; private set; }
        public Vector3 colliderCenterOffset { get; private set; }

        private Vector3 mOrgEulerAngles = Vector3.zero;
        private Color? mVariationColor = null;

        private GameObject mShadow = null;

        private string mDisplayModelPath = null;
        private string mShadowModelPath = null;
        private string[] mResPathes = null;

        //private Dictionary<SkinnedMeshRenderer, Shader> mOrgSkinnedMeshShaders = new Dictionary<SkinnedMeshRenderer, Shader>();
        private SkinnedMeshRenderer[] mRenderers = null;
        private Material[] mMaterials = null;
        private Shader[] mShaders = null;

        private Color[] mColors = null;
        private Shader mHalfOpaqueShader = null;
        private bool mIsHalfOpaque = false;
        private int mMaterialsCount = 0;

        private bool mIsShadowHidden = false;

        private bool mIsVariant = false;

        private List<Material> mUnVariatedMats = new List<Material>();
        private Material mVariatiedMat = null;
        private List<int> mMatIdxForVariations = new List<int>();

        private bool mHasInitMaterials = false;

        private bool mParticlesWritable = false;
        
        //private bool mIsParticleEffectsActive = false;

        public AvatarDisplayCache(string name, GameObject displayModel, string displayModelPath, string shadowModelPath, string[] resPathes, bool particlesWritable = true)
        {
            avatarName = name;
            avatar = displayModel;
            mOrgEulerAngles = displayModel.transform.localEulerAngles;
            mDisplayModelPath = displayModelPath;
            mShadowModelPath = shadowModelPath;
            mResPathes = resPathes;
            mParticlesWritable = particlesWritable;

            if (mShadowModelPath != null)
            {
                SourceLoader.Ins.load(shadowModelPath, OnShadowLoaded);
            }

            orgScale = avatar.transform.localScale;

            BoxCollider clder = avatar.GetComponent<BoxCollider>();
            if (clder != null)
            {
                Vector3 clderSize = clder.size;
                clderSize.Scale(avatar.transform.localScale);
                Vector3 clderCenter = clder.center;
                clderCenter.Scale(avatar.transform.localScale);
                radiusX = Mathf.Abs(clderSize.x) / 2.0f;
                radiusFront = Mathf.Abs(clderSize.z) / 2.0f + clderCenter.z;
                radiusMin = Mathf.Min(radiusX, radiusFront);
                radiusMax = Mathf.Max(radiusX, radiusFront);
                footHeight = clderCenter.y - Mathf.Abs(clderSize.y) / 2f;
                bodyHeight = Mathf.Abs(clderSize.y);
                totalHeight = footHeight + bodyHeight;
                colliderCenterOffset = clderCenter;
            }

            mRenderers = avatar.GetComponentsInChildren<SkinnedMeshRenderer>(true);

            mHasInitMaterials = false;
            
            SetParticleEffectsActive(SystemSettings.ins.isShowParticleEffects);
        }

        private void InitMaterials()
        {
            mMaterialsCount = mRenderers.Length;
            mMaterials = new Material[mMaterialsCount];
            mShaders = new Shader[mMaterialsCount];
            mColors = new Color[mMaterialsCount];
            for (int i = 0; i < mMaterialsCount; i++)
            {
                mMaterials[i] = mRenderers[i].material;
                //mMaterials[i].shader = Shader.Find(mMaterials[i].shader.name);
                if (mMaterials[i].name == avatarName + " (Instance)")
                {
                    mUnVariatedMats.Add(mMaterials[i]);
                    mMatIdxForVariations.Add(i);
                }

                mShaders[i] = mMaterials[i].shader;
                if (mMaterials[i].HasProperty("_Color"))
                {
                    mColors[i] = mMaterials[i].GetColor("_Color");
                }
                else
                {
                    mColors[i] = new Color(1, 1, 1, 1);
                }
            }
#if UNITY_EDITOR
            mHalfOpaqueShader = Shader.Find("Mobile/Unlit/HalfOpaqueShader");
#else
            mHalfOpaqueShader = GameClient.ins.gameShaders.FindShader("Mobile/Unlit/HalfOpaqueShader");
#endif
            mHasInitMaterials = true;
        }

        private void OnShadowLoaded(RMetaEvent e)
        {
            if (mShadowModelPath != null && e.type == SourceLoader.LOAD_COMPLETE)
            {
                mShadow = SourceManager.Ins.createObjectFromAssetBundle(mShadowModelPath);
                GameObjectUtil.Bind(mShadow.transform, avatar.transform);
                GameObjectUtil.SetLayer(mShadow, avatar.layer);
                if (mIsHalfOpaque || mIsShadowHidden)
                {
                    mShadow.SetActive(false);
                }
                else
                {
                    mShadow.SetActive(true);
                }
            }
        }

        public override void Use()
        {
            if (!GetIsUsed())
            {
                base.Use();
                /*
                SetIsVariant(false);
                SetIsHalfOpaque(false);
                if (avatar != null)
                {
                    avatar.SetActive(true);
                }
                */
            }
        }

        public override void UnUse()
        {
            if (GetIsUsed())
            {
                base.UnUse();
                if (mIsVariant)
                {
                    SetIsVariant(false);
                }

                if (mIsHalfOpaque)
                {
                    SetIsHalfOpaque(false);
                }

                if (avatar != null)
                {
                    avatar.transform.SetParent(GameClient.ins.cachedDisplayModels.transform);
                    avatar.transform.localScale = orgScale;
                    avatar.transform.localEulerAngles = mOrgEulerAngles;
                    avatar.SetActive(false);
                }
            }
        }

        public override string GetPoolName()
        {
            return mDisplayModelPath;
        }

        public override int GetCacheType()
        {
            return MemCacheType.AVATAR;
        }
        
        public override bool IsBroken()
        {
            return (avatar == null); 
        }

        public override void Destroy()
        {
            if (GetIsUsed())
            {
                UnUse();
            }

            int len = mResPathes.Length;
            for (int i = 0; i < len; i++)
            {
                SourceManager.Ins.removeReference(mResPathes[i]);
            }
            GameObject.DestroyImmediate(avatar, true);
            avatar = null;

            if (mShadowModelPath != null)
            {
                SourceManager.Ins.removeReference(mShadowModelPath, mShadow);
            }
            mShadow = null;

            if (mHasInitMaterials)
            {
                len = mUnVariatedMats.Count;
                for (int i = 0; i < len; i++)
                {
                    GameObject.DestroyImmediate(mUnVariatedMats[i], true);
                    mUnVariatedMats[i] = null;
                }
                mUnVariatedMats = null;

                if (mVariatiedMat != null)
                {
                    SourceManager.Ins.removeReference(PathUtil.Ins.GetVariationMatPath(avatarName));
                    //GameObject.DestroyImmediate(mVariatiedMat, true);
                    mVariatiedMat = null;
                }

                len = mMaterials.Length;
                for (int i = 0; i < len; i++)
                {
                    GameObject.DestroyImmediate(mMaterials[i], true);
                    mMaterials[i] = null;
                }
                mMaterials = null;

                mShaders = null;
                mHalfOpaqueShader = null;
                mHasInitMaterials = false;
            }

            avatarName = null;

            //Object.DestroyImmediate(displayModel);
        }

        /// <summary>
        /// 设置是否半透明。
        /// </summary>
        public void SetIsHalfOpaque(bool value)
        {
            if (mIsHalfOpaque != value)
            {
                mIsHalfOpaque = value;

                if (!mHasInitMaterials)
                {
                    InitMaterials();
                }

                if (mIsHalfOpaque)
                {
                    for (int i = 0; i < mMaterialsCount; i++)
                    {
                        if (mMaterials[i] != null)
                        {
                            mMaterials[i].shader = mHalfOpaqueShader;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < mMaterialsCount; i++)
                    {
                        if (mMaterials[i] != null)
                        {
                            mMaterials[i].shader = mShaders[i];
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 设置是否变异。
        /// </summary>
        public void SetIsVariant(bool value)
        {
            if (mIsVariant != value)
            {
                mIsVariant = value;

                if (!mHasInitMaterials)
                {
                    InitMaterials();
                }

                if (value)
                {
                    if (mVariatiedMat == null)
                    {
                        if (avatar != null)
                        {
                            SourceLoader.Ins.load(PathUtil.Ins.GetVariationMatPath(avatarName), LoadVariationMatComplete, null, null, true);
                            return;
                        }
                        else
                        {
                            ClientLog.LogError(avatarName + "设置变异材质时发现没有模型!");
                        }
                    }
                    else
                    {
                        ChangeVariationMat();
                    }
                }
                else
                {
                    ChangeVariationMat();
                }
            }
        }

        private void LoadVariationMatComplete(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo loadInfo = e.data as LoadInfo;
                if (loadInfo != null)
                {
                    mVariatiedMat = SourceManager.Ins.GetAsset<Material>(loadInfo.urlPath);
                    if (mVariatiedMat != null)
                    {
                        //mVariatiedMat.name = avatarName;
                        ChangeVariationMat();
                    }
                    else
                    {
                        ClientLog.LogError(avatarName + "加载变异材质完成后无法从assetbundle中找到材质球!");
                    }
                }
                else
                {
                    ClientLog.LogError(avatarName + "加载变异材质完成后LoadInfo没传过来!");
                }
            }
        }

        private void ChangeVariationMat()
        {
            if (mVariatiedMat != null)
            {
                int len = mMatIdxForVariations.Count;

                if (len == 0 && mIsVariant)
                {
                    ClientLog.LogError(avatarName + "身上找不到名称为" + avatarName + "的原始材质，故无法替换为变异材质");
                }

                for (int i = 0; i < len; i++)
                {
                    if (mIsVariant)
                    {
                        mMaterials[mMatIdxForVariations[i]] = mVariatiedMat;
                        mRenderers[mMatIdxForVariations[i]].material = mVariatiedMat;
                    }
                    else
                    {
                        mMaterials[mMatIdxForVariations[i]] = mUnVariatedMats[i];
                        mRenderers[mMatIdxForVariations[i]].material = mUnVariatedMats[i];
                    }
#if UNITY_EDITOR
                    mRenderers[mMatIdxForVariations[i]].material.shader = Shader.Find(mRenderers[mMatIdxForVariations[i]].material.shader.name);
#endif
                }
            }

            if (variationColor != null)
            {
                int len = mMaterials.Length;
                for (int i = 0; i < len; i++)
                {
                    if (mMaterials[i].HasProperty("_Color"))
                    {
                        mMaterials[i].SetColor("_Color", mIsVariant ? (Color)variationColor : mColors[i]);
                    }
                }
            }
        }

        public void HideShadow()
        {
            if (!mIsShadowHidden)
            {
                if (mShadow != null)
                {
                    mShadow.SetActive(false);
                }
                mIsShadowHidden = true;
            }
        }

        public void ShowShadow()
        {
            if (mIsShadowHidden)
            {
                if (mShadow != null)
                {
                    mShadow.SetActive(true);
                }
                mIsShadowHidden = false;
            }

        }

        public Color? variationColor
        {
            get
            {
                return mVariationColor;
            }
            set
            {
                //mVariationColor = value;
            }
        }

        public void SetParticleEffectsActive(bool active)
        {
            if (avatar != null)
            {
                //if (mIsParticleEffectsActive != active)
                //{
                    if (mParticlesWritable)
                    {
                        SetParticleSystemActive(avatar.GetComponents<ParticleSystem>(), active);
                        SetParticleSystemActive(avatar.GetComponentsInChildren<ParticleSystem>(true), active);
                    }
                    else
                    {
                        SetParticleSystemActive(avatar.GetComponents<ParticleSystem>(), true);
                        SetParticleSystemActive(avatar.GetComponentsInChildren<ParticleSystem>(true), true);
                    }
                    //mIsParticleEffectsActive = active;
                //}
            }
        }

        private void SetParticleSystemActive(ParticleSystem[] psers, bool active)
        {
            int len = psers.Length;
            for (int i = 0; i < len; i++)
            {
                psers[i].gameObject.SetActive(active);
            }
        }
    }
}

