using UnityEngine;
using app.utils;
using app.db;

namespace app.battle
{
    public class BatChivalric
    {
        public bool isDestroied { get; private set; }
        public BatCharacter host { get; private set; }
        public int id { get; private set; }
        private SkillLabelTemplate mTpl;

        private string mEffectPath = null;
        private BatEffectBase mEffect = null;

        public BatChivalric(BatCharacter host, int id)
        {
            this.host = host;
            this.id = id;
            mTpl = SkillLabelTemplateDB.Instance.getTemplate(id);
        }

        public void Start()
        {
            isDestroied = false;
            LoadRes();
        }

        private void LoadRes()
        {
            if (mEffect == null)
            {
                if (PropertyUtil.IsLegalID(mTpl.effect))
                {

                    mEffectPath = PathUtil.Ins.GetEffectPath(mTpl.effect);
                    SourceLoader.Ins.load(mEffectPath, OnResLoaded);
                }
                else
                {
                    ClientLog.LogWarning("Buff " + mTpl.Id + " has no display effect!");
                }
            }
            else
            {
                mEffect.Use();
                mEffect.SetActive(true);
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
            mEffect = BatEffectHelper.CreateBatEffectBase(mTpl.effect);
            GameObjectUtil.Bind(mEffect.displayModel.transform, host.displayModelContainer.transform, true, true);
            Vector3 localPos = host.displayModel.colliderCenterOffset;
            if ((SkillBuffPosType)(mTpl.effectShowType) == SkillBuffPosType.HEAD_TOP)
            {
                localPos.y = host.displayModel.totalHeight;
            }
            else if ((SkillBuffPosType)(mTpl.effectShowType) == SkillBuffPosType.FOOT)
            {
                localPos.y = 0;
            }
            else if ((SkillBuffPosType)(mTpl.effectShowType) == SkillBuffPosType.BODY)
            {
                localPos.y = host.displayModel.footHeight + host.displayModel.bodyHeight / 2.0f;
            }
            mEffect.displayModel.transform.localPosition = localPos;
            mEffect.SetActive(true);
        }

        public void Update()
        {

        }

        public void FixedUpdate()
        {

        }

        public void ShowEffect()
        {
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
                this.mTpl = null;
                this.mEffectPath = null;
                isDestroied = true;
            }
        }
    }
}