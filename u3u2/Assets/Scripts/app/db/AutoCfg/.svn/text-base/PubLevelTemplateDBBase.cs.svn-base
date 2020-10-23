using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 酒馆等级模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PubLevelTemplateDBBase : TemplateDBBase<PubLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PubLevelTemplate> idKeyDic = new Dictionary<int, PubLevelTemplate>();
        
		protected static PubLevelTemplateDB _ins;
        public static PubLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PubLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PubLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PubLevelTemplate publeveltemplate)
        {
            if (this.idKeyDic.ContainsKey(publeveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + publeveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(publeveltemplate.Id, publeveltemplate);
            return true;
        }

        public override PubLevelTemplate getTemplate(int id)
        {
            PubLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PubLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PubLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PubLevelTemplate publeveltemplate = new PubLevelTemplate();
				//id，每个表都有
				publeveltemplate.Id = reader.GetInt32(startIndex++);
		
				publeveltemplate.exp = reader.GetInt64(startIndex++);
	
				PubLevelTemplateDB.Instance.addTemplate(publeveltemplate);
				}
			}
		}

}
}