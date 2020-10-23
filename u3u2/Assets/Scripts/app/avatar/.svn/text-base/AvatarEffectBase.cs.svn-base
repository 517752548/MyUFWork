using app.effect;
using UnityEngine;
using app.utils;

namespace app.avatar
{
    public class AvatarEffectBase
    {
        public bool isDestroied { get; private set; }
        public AvatarBase host { get; private set; }
        private string mEffectPath = null;
        private EffectBase mEffect = null;
        private bool mIsShowEffect = false;
        private AvatarBaseEffectPosType posType;

        public AvatarEffectBase(AvatarBase host, string effectpath, AvatarBaseEffectPosType postype)
        {
            this.posType = postype;
            this.host = host;
            mEffectPath = effectpath;
        }

        public void Start(bool isShowEffect)
        {
            isDestroied = false;
            mIsShowEffect = isShowEffect;
            LoadRes();
        }

        private void LoadRes()
        {
            if (mEffect == null)
            {
                SourceLoader.Ins.load(mEffectPath, OnResLoaded);
            }
            else
            {
                mEffect.Use();
                mEffect.SetActive(mIsShowEffect);
            }
        }

        private void OnResLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                if (mEffect == null)
                {
                    mEffect = GetEffectBase();
                }
                //mEffect.SetDisplayModel(mEffectPath);
                mEffect.SetLayer(LayerConfig.Layer_ZoneModel);
                if (!isDestroied)
                {
                    Show();
                }
            }
        }

        private EffectBase GetEffectBase()
        {
            /*
            ICacheable ic = MemCache.Catch(mEffectPath);
            if (ic == null)
            {
                EffectBase e = new EffectBase();
                e.SetDisplayModel(mEffectPath);
                e.SetLayer(LayerConfig.Layer_ZoneModel);
                MemCache.Add(e);
                e.Use();
                return e;
            }
            ic.Use();
            return (EffectBase)ic;
            */
            return EffectHelper.CreateEffectBase(mEffectPath);
        }

        private void Show()
        {
            GameObjectUtil.Bind(mEffect.displayModel.transform, host.displayModel.avatar.transform, true, true);
            Vector3 localPos = host.displayModel.colliderCenterOffset;
            switch (posType)
            {
                case AvatarBaseEffectPosType.HEAD_TOP:
                    localPos.y = host.displayModel.totalHeight;
                    break;
                case AvatarBaseEffectPosType.CHEST:
                    localPos.y = host.displayModel.footHeight + host.displayModel.bodyHeight / 2.0f;
                    break;
                case AvatarBaseEffectPosType.FOOT:
                    localPos.y = 0;
                    break;
            }
            mEffect.displayModel.transform.localPosition = localPos;
            mEffect.SetActive(mIsShowEffect);
        }

        public void ShowEffect()
        {
            mIsShowEffect = true;
            if (mEffect != null)
            {
                mEffect.SetActive(mIsShowEffect);
            }
        }

        public void HideEffect()
        {
            mIsShowEffect = false;
            if (mEffect != null)
            {
                mEffect.SetActive(mIsShowEffect);
            }
        }

        public void Destroy()
        {
            if (!isDestroied)
            {
                if (mEffect != null)
                {
                    mEffect.UnUse();
                    mEffect = null;
                }
                this.host = null;
                this.mEffectPath = null;
                isDestroied = true;
            }
        }
    }

    public enum AvatarBaseEffectPosType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 头顶(1)。
        /// </summary>
        HEAD_TOP,
        /// <summary>
        /// 胸口(2)。
        /// </summary>
        CHEST,
        /// <summary>
        /// 脚下(3)。
        /// </summary>
        FOOT
    }
}