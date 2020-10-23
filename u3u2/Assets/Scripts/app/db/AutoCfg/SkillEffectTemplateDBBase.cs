using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 效果配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectTemplateDBBase : TemplateDBBase<SkillEffectTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillEffectTemplate> idKeyDic = new Dictionary<int, SkillEffectTemplate>();
        
		protected static SkillEffectTemplateDB _ins;
        public static SkillEffectTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillEffectTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillEffectTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillEffectTemplate skilleffecttemplate)
        {
            if (this.idKeyDic.ContainsKey(skilleffecttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilleffecttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilleffecttemplate.Id, skilleffecttemplate);
            return true;
        }

        public override SkillEffectTemplate getTemplate(int id)
        {
            SkillEffectTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillEffectTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillEffectTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillEffectTemplate skilleffecttemplate = new SkillEffectTemplate();
				//id，每个表都有
				skilleffecttemplate.Id = reader.GetInt32(startIndex++);
		
				skilleffecttemplate.effectTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffMutex = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.effectLevel = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.effectWeight = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.effectGroupId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffOverlapNum = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffRoundNum = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffContinued = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffGoodBad = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.buffTargetLiveFlag = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.calcTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.cdRound = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.nearby = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.targetSelect = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.targetSelf = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.targetTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.targetRangeTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.targetNum = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.isNegativeFlag = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.effectValueTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.valueTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.valueCoef = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.valueBase = reader.GetInt64(startIndex++);
	
				skilleffecttemplate.valueAdd = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.mindCoef = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.extraCoef1 = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.extraCoef2 = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.extraCoef3 = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.extraCoef4 = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.extraCoef5 = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.attackTypeId = reader.GetInt32(startIndex++);
	
				skilleffecttemplate.skillLayerEffectList = new List<int>(10);
				for (int i = 0; i < 10; i++)
		        {
		            skilleffecttemplate.skillLayerEffectList.Add(reader.GetInt32(startIndex++));
		        }
	
				SkillEffectTemplateDB.Instance.addTemplate(skilleffecttemplate);
				}
			}
		}

}
}