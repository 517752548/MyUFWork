using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宝石开孔
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemOpenTemplateDBBase : TemplateDBBase<GemOpenTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemOpenTemplate> idKeyDic = new Dictionary<int, GemOpenTemplate>();
        
		protected static GemOpenTemplateDB _ins;
        public static GemOpenTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemOpenTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemOpenTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemOpenTemplate gemopentemplate)
        {
            if (this.idKeyDic.ContainsKey(gemopentemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemopentemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemopentemplate.Id, gemopentemplate);
            return true;
        }

        public override GemOpenTemplate getTemplate(int id)
        {
            GemOpenTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemOpenTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemOpenTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemOpenTemplate gemopentemplate = new GemOpenTemplate();
				//id，每个表都有
				gemopentemplate.Id = reader.GetInt32(startIndex++);
		
				gemopentemplate.openLevel = reader.GetInt32(startIndex++);
	
				GemOpenTemplateDB.Instance.addTemplate(gemopentemplate);
				}
			}
		}

}
}