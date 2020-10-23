using app.db;
using anticheat;

namespace app.pet
{
    public class PetSkill
    {
        // 技能所属武将Id
        private OLong petId;

        public long PetId
        {
            get { return petId; }
            set { petId = value; }
        }

        // 技能Id
        private OInt id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        // 技能等级
        private OInt level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private OFloat maxMagicDist;

        public float MaxMagicDist
        {
            get { return maxMagicDist; }
            set { maxMagicDist = value; }
        }

        //// 技能模板
        //private AvatarSkillTemplate tpl;

        //public AvatarSkillTemplate Tpl
        //{
        //    get { return tpl; }
        //    set { tpl = value; }
        //}

        //public PetSkill(long petId, int id, int level)
        //{
        //    this.petId = petId;
        //    this.id = id;
        //    this.level = level;
        //    this.tpl = AvatarSkillTemplateDB.Instance.getTemplate(id);
        //    if (tpl == null)
        //    {
        //        ClientLog.LogError("skill tpl not exist!skillid=" + id);
        //    }

        //    if (tpl.type1 == 3)
        //    {
        //        for (int _i = 0; _i < tpl.performIds.Count; _i++)
        //        {
        //            if (tpl.performIds[_i] > 0)
        //            {
        //                AvatarSkillTemplate cTpl = AvatarSkillTemplateDB.Instance.getTemplate(tpl.performIds[_i]);
        //                UpdateMaxMagicDist(cTpl);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        UpdateMaxMagicDist(this.tpl);
        //    }
        //}

        //private void UpdateMaxMagicDist(AvatarSkillTemplate tpl)
        //{
        //    for (int _i = 0; _i < tpl.performIds.Count; _i++)
        //    {
        //        if (tpl.performIds[_i] > 0)
        //        {
        //            AvatarSkillPerformTemplate _performTpl = AvatarSkillPerformTemplateDB.Instance.getTemplate(tpl.performIds[_i]);
        //            if (_performTpl != null)
        //            {
        //                if (_performTpl.maxMagicDist > this.maxMagicDist)
        //                {
        //                    this.maxMagicDist = _performTpl.maxMagicDist;
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
