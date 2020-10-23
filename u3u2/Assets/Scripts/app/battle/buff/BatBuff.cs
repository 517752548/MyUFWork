using UnityEngine;
using app.utils;

namespace app.battle
{
    public class BatBuff
    {
        public bool isDestroied { get; private set; }
        public BatCharacter host { get; private set; }
        public BatRoundBuffData data { get; private set; }
        public bool isShowingEffect { get; private set; }

        private string mEffectPath = null;
        private BatEffectBase mEffect = null;

        public BatBuff(BatCharacter host, BatRoundBuffData data)
        {
            this.host = host;
            this.data = data;
        }

        public void Start(bool isShowEffect)
        {
            isDestroied = false;
            isShowingEffect = isShowEffect;
            LoadRes();
        }

        private void LoadRes()
        {
            if (mEffect == null)
            {
                if (PropertyUtil.IsLegalID(data.tpl.effect))
                {
                    mEffectPath = PathUtil.Ins.GetEffectPath(data.tpl.effect);
                    SourceLoader.Ins.load(mEffectPath, OnResLoaded);
                }
                else
                {
                    ClientLog.LogWarning("Buff " + data.tpl.Id + " has no display effect!");
                }
            }
            else
            {
                mEffect.Use();
                mEffect.SetActive(isShowingEffect);
            }
        }

        private void OnResLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                BattleModel.ins.SetResUndisposable(mEffectPath);
                if (!isDestroied)
                {
                    Show();
                }
            }
        }

        private void Show()
        {
            mEffect = BatEffectHelper.CreateBatEffectBase(data.tpl.effect);
            GameObjectUtil.Bind(mEffect.displayModel.transform, host.displayModelContainer.transform, true, true);
            Vector3 localPos = host.displayModel.colliderCenterOffset;
            if ((SkillBuffPosType)(data.tpl.effectShowType) == SkillBuffPosType.HEAD_TOP)
            {
                localPos.y = host.displayModel.totalHeight;
            }
            else if ((SkillBuffPosType)(data.tpl.effectShowType) == SkillBuffPosType.FOOT)
            {
                localPos.y = 0;
            }
            else if ((SkillBuffPosType)(data.tpl.effectShowType) == SkillBuffPosType.BODY)
            {
                localPos.y = host.displayModel.footHeight + host.displayModel.bodyHeight / 2.0f;
            }
            mEffect.displayModel.transform.localPosition = localPos;
            mEffect.SetActive(isShowingEffect);
        }

        public void Update()
        {

        }

        public void FixedUpdate()
        {
            
        }

        public void ShowEffect()
        {
            isShowingEffect = true;
            if (mEffect != null)
            {
                mEffect.SetActive(true);
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
                this.data = null;
                //this.mEffectPath = null;
                isDestroied = true;
            }
        }
    }
}