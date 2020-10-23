using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 师徒
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class OvermanTemplateDBBase : TemplateDBBase<OvermanTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, OvermanTemplate> idKeyDic = new Dictionary<int, OvermanTemplate>();
        
		protected static OvermanTemplateDB _ins;
        public static OvermanTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new OvermanTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, OvermanTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(OvermanTemplate overmantemplate)
        {
            if (this.idKeyDic.ContainsKey(overmantemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + overmantemplate.Id);
                return false;
            }
            this.idKeyDic.Add(overmantemplate.Id, overmantemplate);
            return true;
        }

        public override OvermanTemplate getTemplate(int id)
        {
            OvermanTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get OvermanTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_OvermanTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				OvermanTemplate overmantemplate = new OvermanTemplate();
				//id，每个表都有
				overmantemplate.Id = reader.GetInt32(startIndex++);
		
				overmantemplate.level = reader.GetInt32(startIndex++);
	
				overmantemplate.overmanReward = reader.GetInt32(startIndex++);
	
				overmantemplate.lowermanReward = reader.GetInt32(startIndex++);
	
				overmantemplate.desc = reader.GetString(startIndex++);
	
				OvermanTemplateDB.Instance.addTemplate(overmantemplate);
				}
			}
		}

}
}