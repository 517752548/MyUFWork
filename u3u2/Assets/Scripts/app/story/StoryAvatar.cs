using System.Collections.Generic;
using app.avatar;
using app.battle;
using app.db;
using app.model;
using app.pet;
using app.system;
using app.utils;
using UnityEngine;
using System.Collections;
using app.zone;
using UnityEngine.UI;
using DG.Tweening;

namespace app.story
{
    public class StoryAvatar : ZoneCharacterBase
    {
        public StoryAvatar()
        {
            //isInited = false;
            //isFadeOuted = false;
        }

        /// <summary>
        /// 特效名称
        /// </summary>
        private string m_effectname = "";

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
            localPosition = position;
            EffectUtil.Ins.PlayEffect(m_effectname, LayerConfig.Layer_StoryModel, false, mDisplayModelContainer);
        }

        public override bool Update()
        {
            ///非循环动画播放到最后一帧切到idle///
            if (mCurPlayingAnim != null && mCurPlayingAnim.wrapMode != WrapMode.Loop && mCurPlayingAnim.time >= mCurPlayingAnim.length)
            {
                if (curAnimName != ANIM_NAME_DIE && curAnimName != ANIM_NAME_DEFENSE)
                {
                    PlayAnimation(ANIM_NAME_IDLE);
                }
            }
            return base.Update();
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

        public override Transform GetParent()
        {
            return StoryManager.ins.GetModelsContainer().transform;
        }

        public override int GetLayer()
        {
            return LayerConfig.Layer_StoryModel;
        }

        public override void Destroy()
        {
            ///判断是否为特效///
            if (!string.IsNullOrEmpty(m_effectname))
            {
                EffectUtil.Ins.RemoveEffect(m_effectname);
            }
            base.Destroy();
        }

        protected override void CheckOpaque()
        {

        }
    }
}