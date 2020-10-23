using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 属性种类对应单价值
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemForPropValueTemplateDBBase : TemplateDBBase<GemForPropValueTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemForPropValueTemplate> idKeyDic = new Dictionary<int, GemForPropValueTemplate>();
        
		protected static GemForPropValueTemplateDB _ins;
        public static GemForPropValueTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemForPropValueTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemForPropValueTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemForPropValueTemplate gemforpropvaluetemplate)
        {
            if (this.idKeyDic.ContainsKey(gemforpropvaluetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemforpropvaluetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemforpropvaluetemplate.Id, gemforpropvaluetemplate);
            return true;
        }

        public override GemForPropValueTemplate getTemplate(int id)
        {
            GemForPropValueTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemForPropValueTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemForPropValueTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemForPropValueTemplate gemforpropvaluetemplate = new GemForPropValueTemplate();
				//id，每个表都有
				gemforpropvaluetemplate.Id = reader.GetInt32(startIndex++);
		
				gemforpropvaluetemplate.name = reader.GetString(startIndex++);
	
				gemforpropvaluetemplate.value = reader.GetInt32(startIndex++);
	
				GemForPropValueTemplateDB.Instance.addTemplate(gemforpropvaluetemplate);
				}
			}
		}

}
}