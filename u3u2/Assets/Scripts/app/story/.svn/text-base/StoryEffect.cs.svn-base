using UnityEngine;

namespace app.story
{
    public class StoryEffect
    {
        /// <summary>
        /// 特效名称
        /// </summary>
        private string m_effectname = "";

        private GameObject mDisplayModelContainer;
        /// <summary>
        /// 播放特效
        /// </summary>
        /// <param name="effectname"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void PlayEffect(string effectname, string name, Vector3 position)
        {
            m_effectname = effectname;
            if (mDisplayModelContainer == null)
            {
                mDisplayModelContainer = new GameObject(name);
            }
            mDisplayModelContainer.transform.SetParent(GetParent());
            mDisplayModelContainer.layer = GetLayer();
            mDisplayModelContainer.transform.localPosition = position;
            EffectUtil.Ins.PlayEffect(m_effectname, LayerConfig.Layer_StoryModel, false, mDisplayModelContainer);
        }
        
        public GameObject DisplayModelContainer
        {
            get
            {
                return mDisplayModelContainer;
            }
            set
            {
                mDisplayModelContainer = value;
            }
        }

        public Transform GetParent()
        {
            return StoryManager.ins.GetModelsContainer().transform;
        }

        public int GetLayer()
        {
            return LayerConfig.Layer_StoryModel;
        }

        public void Destroy()
        {
            ///判断是否为特效///
            if (!string.IsNullOrEmpty(m_effectname))
            {
                EffectUtil.Ins.RemoveEffect(m_effectname);
            }
        }
    }
}
