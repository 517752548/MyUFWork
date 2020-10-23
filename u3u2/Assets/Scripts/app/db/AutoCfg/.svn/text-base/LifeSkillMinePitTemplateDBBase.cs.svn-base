using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能-采矿-矿坑
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMinePitTemplateDBBase : TemplateDBBase<LifeSkillMinePitTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMinePitTemplate> idKeyDic = new Dictionary<int, LifeSkillMinePitTemplate>();
        
		protected static LifeSkillMinePitTemplateDB _ins;
        public static LifeSkillMinePitTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMinePitTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMinePitTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMinePitTemplate lifeskillminepittemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillminepittemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillminepittemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillminepittemplate.Id, lifeskillminepittemplate);
            return true;
        }

        public override LifeSkillMinePitTemplate getTemplate(int id)
        {
            LifeSkillMinePitTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMinePitTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMinePitTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMinePitTemplate lifeskillminepittemplate = new LifeSkillMinePitTemplate();
				//id，每个表都有
				lifeskillminepittemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillminepittemplate.openNeedMineLevel = reader.GetInt32(startIndex++);
	
				LifeSkillMinePitTemplateDB.Instance.addTemplate(lifeskillminepittemplate);
				}
			}
		}

}
}