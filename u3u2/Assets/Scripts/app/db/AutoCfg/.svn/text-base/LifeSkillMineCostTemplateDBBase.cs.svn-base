using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能-采矿-消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineCostTemplateDBBase : TemplateDBBase<LifeSkillMineCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMineCostTemplate> idKeyDic = new Dictionary<int, LifeSkillMineCostTemplate>();
        
		protected static LifeSkillMineCostTemplateDB _ins;
        public static LifeSkillMineCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMineCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMineCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMineCostTemplate lifeskillminecosttemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillminecosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillminecosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillminecosttemplate.Id, lifeskillminecosttemplate);
            return true;
        }

        public override LifeSkillMineCostTemplate getTemplate(int id)
        {
            LifeSkillMineCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMineCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMineCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMineCostTemplate lifeskillminecosttemplate = new LifeSkillMineCostTemplate();
				//id，每个表都有
				lifeskillminecosttemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillminecosttemplate.currencyType = reader.GetInt32(startIndex++);
	
				lifeskillminecosttemplate.currencyNum = reader.GetInt32(startIndex++);
	
				lifeskillminecosttemplate.costTime = reader.GetInt32(startIndex++);
	
				LifeSkillMineCostTemplateDB.Instance.addTemplate(lifeskillminecosttemplate);
				}
			}
		}

}
}