using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 提升模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PromoteTemplateDBBase : TemplateDBBase<PromoteTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PromoteTemplate> idKeyDic = new Dictionary<int, PromoteTemplate>();
        
		protected static PromoteTemplateDB _ins;
        public static PromoteTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PromoteTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PromoteTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PromoteTemplate promotetemplate)
        {
            if (this.idKeyDic.ContainsKey(promotetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + promotetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(promotetemplate.Id, promotetemplate);
            return true;
        }

        public override PromoteTemplate getTemplate(int id)
        {
            PromoteTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PromoteTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PromoteTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PromoteTemplate promotetemplate = new PromoteTemplate();
				//id，每个表都有
				promotetemplate.Id = reader.GetInt32(startIndex++);
		
				promotetemplate.promoteId = reader.GetInt32(startIndex++);
	
				promotetemplate.promoteName = reader.GetString(startIndex++);
	
				PromoteTemplateDB.Instance.addTemplate(promotetemplate);
				}
			}
		}

}
}