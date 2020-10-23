using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宝石摘除消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemDownTemplateDBBase : TemplateDBBase<GemDownTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemDownTemplate> idKeyDic = new Dictionary<int, GemDownTemplate>();
        
		protected static GemDownTemplateDB _ins;
        public static GemDownTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemDownTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemDownTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemDownTemplate gemdowntemplate)
        {
            if (this.idKeyDic.ContainsKey(gemdowntemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemdowntemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemdowntemplate.Id, gemdowntemplate);
            return true;
        }

        public override GemDownTemplate getTemplate(int id)
        {
            GemDownTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemDownTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemDownTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemDownTemplate gemdowntemplate = new GemDownTemplate();
				//id，每个表都有
				gemdowntemplate.Id = reader.GetInt32(startIndex++);
		
				gemdowntemplate.costGold = reader.GetInt32(startIndex++);
	
				gemdowntemplate.itemId1 = reader.GetInt32(startIndex++);
	
				gemdowntemplate.itemNum1 = reader.GetInt32(startIndex++);
	
				gemdowntemplate.itemId2 = reader.GetInt32(startIndex++);
	
				gemdowntemplate.itemNum2 = reader.GetInt32(startIndex++);
	
				GemDownTemplateDB.Instance.addTemplate(gemdowntemplate);
				}
			}
		}

}
}