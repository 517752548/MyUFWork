using UnityEngine;
using app.main;
using app.utils;

namespace app.effect
{
    public class EffectBase : Cacheable
    {
        public GameObject displayModel { get; private set; }
        private string mCacheName = null;
        private string mEffectPath = null;
        private bool mActive = false;
        
        public virtual void SetDisplayModel(string effectPath)
        {
            mEffectPath = effectPath;
            mCacheName = effectPath;
            this.displayModel = SourceManager.Ins.createObjectFromAssetBundle(mEffectPath);
            SetActive(false);
        }
        
        public void SetLayer(int layer)
        {
            if (displayModel!=null&&displayModel.layer != layer)
            {
                GameObjectUtil.SetLayer(displayModel, layer);
            }
        }

        public override void Use()
        {
            base.Use();
            //SetActive(true);
        }

        public override void UnUse()
        {
            if(displayModel!=null&&displayModel.transform!=null)displayModel.transform.SetParent(GameClient.ins.cachedDisplayModels.transform);
            base.UnUse();
            SetActive(false);
        }
        
        public override bool IsBroken()
        {
            return (displayModel == null);
        }

        public override string GetPoolName()
        {
            return mCacheName;
        }
        
        public override int GetCacheType()
        {
            return MemCacheType.EFFECT;
        }

        public override void Destroy()
        {
            if (GetIsUsed())
            {
                UnUse();
            }

            SourceManager.Ins.removeReference(mEffectPath, displayModel);
            //Object.DestroyImmediate(displayModel);
            displayModel = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="reset">是否重置播放进度。</param>
        public void SetActive(bool value/*, bool reset = true*/)
        {
            //if (mActive != value)
            //{
                /*
                ParticleSystem[] pss = displayModel.GetComponentsInChildren<ParticleSystem>();
                int len = pss.Length;

                if (reset)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (value)
                        {
                            pss[i].Play(true);
                        }
                        else
                        {
                            pss[i].Stop(true);
                            pss[i].Clear(true);
                        }
                    }
                }
                */
            if (displayModel!=null) displayModel.SetActive(value);
                //mActive = value;
            //}
        }

        public bool GetActive()
        {
            return mActive;
        }
    }
}