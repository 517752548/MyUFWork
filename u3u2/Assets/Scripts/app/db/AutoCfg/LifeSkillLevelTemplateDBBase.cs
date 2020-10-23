using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能升级消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillLevelTemplateDBBase : TemplateDBBase<LifeSkillLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillLevelTemplate> idKeyDic = new Dictionary<int, LifeSkillLevelTemplate>();
        
		protected static LifeSkillLevelTemplateDB _ins;
        public static LifeSkillLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillLevelTemplate lifeskillleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillleveltemplate.Id, lifeskillleveltemplate);
            return true;
        }

        public override LifeSkillLevelTemplate getTemplate(int id)
        {
            LifeSkillLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillLevelTemplate lifeskillleveltemplate = new LifeSkillLevelTemplate();
				//id，每个表都有
				lifeskillleveltemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillleveltemplate.lifeSkillId = reader.GetInt32(startIndex++);
	
				lifeskillleveltemplate.name = reader.GetString(startIndex++);
	
				lifeskillleveltemplate.needHumanLevel = reader.GetInt32(startIndex++);
	
				lifeskillleveltemplate.lifeSkillLevel = reader.GetInt32(startIndex++);
	
		        lifeskillleveltemplate.lifeSkillCostList = new List<HumanSubSkillCost>(8);
		        for (int i = 0; i < 8; i++)
		        {
		            lifeskillleveltemplate.lifeSkillCostList.Add(new HumanSubSkillCost(reader, startIndex));
		            startIndex += 1;
		        }
	
				lifeskillleveltemplate.maxResNum = reader.GetInt32(startIndex++);
	
				lifeskillleveltemplate.itemId = reader.GetInt32(startIndex++);
	
				lifeskillleveltemplate.itemName = reader.GetString(startIndex++);
	
				lifeskillleveltemplate.lifeSkillBookId = reader.GetInt32(startIndex++);
	
				lifeskillleveltemplate.upgradeDes = reader.GetString(startIndex++);
	
				LifeSkillLevelTemplateDB.Instance.addTemplate(lifeskillleveltemplate);
				}
			}
		}

}
}