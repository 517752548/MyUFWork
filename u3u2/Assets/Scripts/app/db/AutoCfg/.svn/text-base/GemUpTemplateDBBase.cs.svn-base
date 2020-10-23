using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宝石镶嵌消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemUpTemplateDBBase : TemplateDBBase<GemUpTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemUpTemplate> idKeyDic = new Dictionary<int, GemUpTemplate>();
        
		protected static GemUpTemplateDB _ins;
        public static GemUpTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemUpTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemUpTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemUpTemplate gemuptemplate)
        {
            if (this.idKeyDic.ContainsKey(gemuptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemuptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemuptemplate.Id, gemuptemplate);
            return true;
        }

        public override GemUpTemplate getTemplate(int id)
        {
            GemUpTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemUpTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemUpTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemUpTemplate gemuptemplate = new GemUpTemplate();
				//id，每个表都有
				gemuptemplate.Id = reader.GetInt32(startIndex++);
		
				gemuptemplate.costGold = reader.GetInt32(startIndex++);
	
				gemuptemplate.itemId1 = reader.GetInt32(startIndex++);
	
				gemuptemplate.itemNum1 = reader.GetInt32(startIndex++);
	
				gemuptemplate.itemId2 = reader.GetInt32(startIndex++);
	
				gemuptemplate.itemNum2 = reader.GetInt32(startIndex++);
	
				GemUpTemplateDB.Instance.addTemplate(gemuptemplate);
				}
			}
		}

}
}