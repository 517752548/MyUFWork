using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物心法
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanMainSkillTemplateDBBase : TemplateDBBase<HumanMainSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanMainSkillTemplate> idKeyDic = new Dictionary<int, HumanMainSkillTemplate>();
        
		protected static HumanMainSkillTemplateDB _ins;
        public static HumanMainSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanMainSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanMainSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanMainSkillTemplate humanmainskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(humanmainskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humanmainskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humanmainskilltemplate.Id, humanmainskilltemplate);
            return true;
        }

        public override HumanMainSkillTemplate getTemplate(int id)
        {
            HumanMainSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanMainSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanMainSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanMainSkillTemplate humanmainskilltemplate = new HumanMainSkillTemplate();
				//id，每个表都有
				humanmainskilltemplate.Id = reader.GetInt32(startIndex++);
		
				humanmainskilltemplate.jobId = reader.GetInt32(startIndex++);
	
				humanmainskilltemplate.name = reader.GetString(startIndex++);
	
				humanmainskilltemplate.mainSkillTypeDetail = reader.GetString(startIndex++);
	
				humanmainskilltemplate.mainSkillDetail = reader.GetString(startIndex++);
	
				HumanMainSkillTemplateDB.Instance.addTemplate(humanmainskilltemplate);
				}
			}
		}

}
}