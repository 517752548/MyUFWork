using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能-采矿-基础
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineTemplateDBBase : TemplateDBBase<LifeSkillMineTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMineTemplate> idKeyDic = new Dictionary<int, LifeSkillMineTemplate>();
        
		protected static LifeSkillMineTemplateDB _ins;
        public static LifeSkillMineTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMineTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMineTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMineTemplate lifeskillminetemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillminetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillminetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillminetemplate.Id, lifeskillminetemplate);
            return true;
        }

        public override LifeSkillMineTemplate getTemplate(int id)
        {
            LifeSkillMineTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMineTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMineTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMineTemplate lifeskillminetemplate = new LifeSkillMineTemplate();
				//id，每个表都有
				lifeskillminetemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillminetemplate.openLevel = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.mineItemId = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.selfReward1 = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.friendReward1 = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.selfReward2 = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.friendReward2 = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.selfReward3 = reader.GetInt32(startIndex++);
	
				lifeskillminetemplate.friendReward3 = reader.GetInt32(startIndex++);
	
				LifeSkillMineTemplateDB.Instance.addTemplate(lifeskillminetemplate);
				}
			}
		}

}
}