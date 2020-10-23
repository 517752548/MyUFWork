using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派修炼消耗配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsCultivateCostTemplateDBBase : TemplateDBBase<CorpsCultivateCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsCultivateCostTemplate> idKeyDic = new Dictionary<int, CorpsCultivateCostTemplate>();
        
		protected static CorpsCultivateCostTemplateDB _ins;
        public static CorpsCultivateCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsCultivateCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsCultivateCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsCultivateCostTemplate corpscultivatecosttemplate)
        {
            if (this.idKeyDic.ContainsKey(corpscultivatecosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpscultivatecosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpscultivatecosttemplate.Id, corpscultivatecosttemplate);
            return true;
        }

        public override CorpsCultivateCostTemplate getTemplate(int id)
        {
            CorpsCultivateCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsCultivateCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsCultivateCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsCultivateCostTemplate corpscultivatecosttemplate = new CorpsCultivateCostTemplate();
				//id，每个表都有
				corpscultivatecosttemplate.Id = reader.GetInt32(startIndex++);
		
				corpscultivatecosttemplate.cultivateLevel = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.playerLevel = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.corpsLevel = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.zqLevel = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.cultivateLimit = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.costContri = reader.GetInt32(startIndex++);
	
				corpscultivatecosttemplate.costExp = reader.GetInt64(startIndex++);
	
				CorpsCultivateCostTemplateDB.Instance.addTemplate(corpscultivatecosttemplate);
				}
			}
		}

}
}