using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * VIP升级配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class VipConfigTemplateDBBase : TemplateDBBase<VipConfigTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, VipConfigTemplate> idKeyDic = new Dictionary<int, VipConfigTemplate>();
        
		protected static VipConfigTemplateDB _ins;
        public static VipConfigTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new VipConfigTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, VipConfigTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(VipConfigTemplate vipconfigtemplate)
        {
            if (this.idKeyDic.ContainsKey(vipconfigtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + vipconfigtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(vipconfigtemplate.Id, vipconfigtemplate);
            return true;
        }

        public override VipConfigTemplate getTemplate(int id)
        {
            VipConfigTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get VipConfigTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_VipConfigTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				VipConfigTemplate vipconfigtemplate = new VipConfigTemplate();
				//id，每个表都有
				vipconfigtemplate.Id = reader.GetInt32(startIndex++);
		
				vipconfigtemplate.descLangId = reader.GetInt64(startIndex++);
	
				vipconfigtemplate.desc = reader.GetString(startIndex++);
	
				vipconfigtemplate.sortId = reader.GetInt32(startIndex++);
	
				vipconfigtemplate.show = reader.GetBoolean(startIndex++);
	
		        vipconfigtemplate.vipItemList = new List<VipItemTemplate>(16);
		        for (int i = 0; i < 16; i++)
		        {
		            vipconfigtemplate.vipItemList.Add(new VipItemTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				VipConfigTemplateDB.Instance.addTemplate(vipconfigtemplate);
				}
			}
		}

}
}