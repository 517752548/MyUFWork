using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 标识配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillLabelTemplateDBBase : TemplateDBBase<SkillLabelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillLabelTemplate> idKeyDic = new Dictionary<int, SkillLabelTemplate>();
        
		protected static SkillLabelTemplateDB _ins;
        public static SkillLabelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillLabelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillLabelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillLabelTemplate skilllabeltemplate)
        {
            if (this.idKeyDic.ContainsKey(skilllabeltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilllabeltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilllabeltemplate.Id, skilllabeltemplate);
            return true;
        }

        public override SkillLabelTemplate getTemplate(int id)
        {
            SkillLabelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillLabelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillLabelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillLabelTemplate skilllabeltemplate = new SkillLabelTemplate();
				//id，每个表都有
				skilllabeltemplate.Id = reader.GetInt32(startIndex++);
		
				skilllabeltemplate.nameLangId = reader.GetInt64(startIndex++);
	
				skilllabeltemplate.name = reader.GetString(startIndex++);
	
				skilllabeltemplate.effect = reader.GetString(startIndex++);
	
				skilllabeltemplate.effectShowType = reader.GetInt32(startIndex++);
	
				skilllabeltemplate.maxLabelNum = reader.GetInt32(startIndex++);
	
				SkillLabelTemplateDB.Instance.addTemplate(skilllabeltemplate);
				}
			}
		}

}
}