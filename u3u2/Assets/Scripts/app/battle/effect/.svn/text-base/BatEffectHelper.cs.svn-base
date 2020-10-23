namespace app.battle
{
    public class BatEffectHelper
    {
        public BatEffectHelper()
        {
        }

        public static BatEffectBase CreateBatEffectBase(string effectId)
        {
            string effectPath = PathUtil.Ins.GetEffectPath(effectId).ToString();
            ICacheable ic = MemCache.FetchFreeCache(effectPath, MemCacheType.EFFECT);
            if (ic == null)
            {
                BatEffectBase e = new BatEffectBase();
                e.SetDisplayModel(effectPath);
                e.orgPos = e.displayModel.transform.localPosition;
                e.orgAngle = e.displayModel.transform.eulerAngles;
                MemCache.Cache(e);
                e.Use();
                return e;
            }
            ic.Use();
            return (BatEffectBase)ic;
        }

        public static BatSkillBulletEffect CreateBulletEffect(string effectId)
        {
            string effectPath = PathUtil.Ins.GetEffectPath(effectId).ToString();
            ICacheable ic = MemCache.FetchFreeCache(effectPath, MemCacheType.EFFECT);
            if (ic == null)
            {
                BatSkillBulletEffect e = new BatSkillBulletEffect();
                e.SetDisplayModel(effectPath);
                MemCache.Cache(e);
                e.Use();
                return e;
            }

            ic.Use();
            return (BatSkillBulletEffect)ic;
        }

        public static BatSkillImpactEffect CreateImpactEffect(string effectId)
        {
            string effectPath = PathUtil.Ins.GetEffectPath(effectId).ToString();
            ICacheable ic = MemCache.FetchFreeCache(effectPath, MemCacheType.EFFECT);
            if (ic == null)
            {
                BatSkillImpactEffect e = new BatSkillImpactEffect();
                e.SetDisplayModel(effectPath);
                MemCache.Cache(e);
                e.Use();
                return e;
            }
            ic.Use();
            return (BatSkillImpactEffect)ic;
        }
    }
}