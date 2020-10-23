using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 技能表现
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillPerformTemplateDBBase : TemplateDBBase<SkillPerformTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillPerformTemplate> idKeyDic = new Dictionary<int, SkillPerformTemplate>();
        
		protected static SkillPerformTemplateDB _ins;
        public static SkillPerformTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillPerformTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillPerformTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillPerformTemplate skillperformtemplate)
        {
            if (this.idKeyDic.ContainsKey(skillperformtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skillperformtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skillperformtemplate.Id, skillperformtemplate);
            return true;
        }

        public override SkillPerformTemplate getTemplate(int id)
        {
            SkillPerformTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillPerformTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillPerformTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillPerformTemplate skillperformtemplate = new SkillPerformTemplate();
				//id，每个表都有
				skillperformtemplate.Id = reader.GetInt32(startIndex++);
		
				skillperformtemplate.composeId = reader.GetString(startIndex++);
	
				skillperformtemplate.skillId = reader.GetString(startIndex++);
	
				skillperformtemplate.effectId = reader.GetInt32(startIndex++);
	
				skillperformtemplate.desc = reader.GetString(startIndex++);
	
				skillperformtemplate.actionId = reader.GetString(startIndex++);
	
				skillperformtemplate.actionType = reader.GetInt32(startIndex++);
	
				skillperformtemplate.isNearAttack = reader.GetInt32(startIndex++);
	
				skillperformtemplate.impactStartTime = reader.GetFloat(startIndex++);
	
				skillperformtemplate.impactTimes = reader.GetInt32(startIndex++);
	
				skillperformtemplate.impactInterval = reader.GetFloat(startIndex++);
	
				skillperformtemplate.effectStopDelayTime = reader.GetFloat(startIndex++);
	
		        skillperformtemplate.effectItemList = new List<SkillPerformEffectItemTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            skillperformtemplate.effectItemList.Add(new SkillPerformEffectItemTemplate(reader, startIndex));
		            startIndex += 6;
		        }
	
				skillperformtemplate.blowEffectId = reader.GetString(startIndex++);
	
				skillperformtemplate.blowEffectPosId = reader.GetInt32(startIndex++);
	
		        skillperformtemplate.soundItemList = new List<SkillPerformSoundItemTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            skillperformtemplate.soundItemList.Add(new SkillPerformSoundItemTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				skillperformtemplate.totalTime = reader.GetFloat(startIndex++);
				//临时解决特效时间太长的问题。特效时间加上了声音时间
				if(skillperformtemplate.effectStopDelayTime >0.5){
					skillperformtemplate.effectStopDelayTime  = 0.5f+(skillperformtemplate.effectStopDelayTime-0.5f)/3;
				}
				SkillPerformTemplateDB.Instance.addTemplate(skillperformtemplate);
				}
			}
		}

}
}