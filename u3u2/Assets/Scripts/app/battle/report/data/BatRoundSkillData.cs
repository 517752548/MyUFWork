using System.Collections;
using System.Collections.Generic;
using app.db;
using app.utils;

namespace app.battle
{
    /// <summary>
    /// 一个技能数据。
    /// </summary>
    public class BatRoundSkillData : BatRoundBehavData
    {
        public List<BatRoundSkillResultData> results { get; private set; }
        public SkillTemplate skillTpl { get; private set; }
        public bool doPerform { get; private set; }
        public List<int> skillEffects { get; private set; }
		public bool isCombo { get; private set; }
		//public bool isComboTrigger { get; set; }

        public BatRoundSkillData(BatRoundStageType stageType) : base(stageType)
        {
            type = BattleRoundBehavType.SKILL;
            results = new List<BatRoundSkillResultData>();
            skillEffects = new List<int>();
        }

        public void Parse(IDictionary data, bool doPerform)
        {
            hostUUID = JsonHelper.GetStringData(BattleReportDef.RECORD_CONTENT_OWNER.ToString(), data);
            int skillId = JsonHelper.GetIntData(BattleReportDef.RECORD_CONTENT_SKILLID.ToString(), data);
            if (PropertyUtil.IsLegalID(skillId))
            {
                skillTpl = SkillTemplateDB.Instance.getTemplate(skillId);
            }
            
            IList skillReses = JsonHelper.GetListData(BattleReportDef.RECORD_CONTENT_ITEMLIST.ToString(), data);
            if (skillReses != null)
            {
                int len = skillReses.Count;
                for (int i = 0; i < len; i++)
                {
                    BatRoundSkillResultData resData = new BatRoundSkillResultData(stageType);
                    resData.Parse((IDictionary)(skillReses[i]));
                    results.Add(resData);
                }
            }

			IList effectList = JsonHelper.GetListData(BattleReportDef.RECORD_CONTENT_SKILL_EFFECT_LIST.ToString(), data);
            if (effectList != null)
            {
                int len = effectList.Count;
                for (int i = 0; i < len; i++)
                {
                    this.skillEffects.Add(int.Parse(effectList[i].ToString()));
                }
            }

			isCombo = JsonHelper.GetBoolData(BattleReportDef.RECORD_CONTENT_SKILL_IS_COMBO.ToString(), data);

            this.doPerform = doPerform;
        }

        public bool isCounterAttacksDone
        {
            get
            {
                int len = results.Count;
                for (int i = 0; i < len; i++)
                {
                    if (results[i].counterattack != null)
                    {
                        if (!results[i].counterattack.isDone)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public override bool isDone
        {
            get
            {
                return base.isDone && isCounterAttacksDone;
            }
            set
            {
                base.isDone = value;
            }
        }
    }
}