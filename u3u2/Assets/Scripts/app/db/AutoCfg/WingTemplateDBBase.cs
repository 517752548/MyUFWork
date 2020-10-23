using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 翅膀
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WingTemplateDBBase : TemplateDBBase<WingTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WingTemplate> idKeyDic = new Dictionary<int, WingTemplate>();
        
		protected static WingTemplateDB _ins;
        public static WingTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WingTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WingTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WingTemplate wingtemplate)
        {
            if (this.idKeyDic.ContainsKey(wingtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wingtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wingtemplate.Id, wingtemplate);
            return true;
        }

        public override WingTemplate getTemplate(int id)
        {
            WingTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WingTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WingTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WingTemplate wingtemplate = new WingTemplate();
				//id，每个表都有
				wingtemplate.Id = reader.GetInt32(startIndex++);
		
				wingtemplate.wingName = reader.GetString(startIndex++);
	
				wingtemplate.icon = reader.GetString(startIndex++);
	
				wingtemplate.modelId = reader.GetString(startIndex++);
	
				wingtemplate.rarityId = reader.GetInt32(startIndex++);
	
		        wingtemplate.propList = new List<PassiveTalentPropItem>(6);
		        for (int i = 0; i < 6; i++)
		        {
		            wingtemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				WingTemplateDB.Instance.addTemplate(wingtemplate);
				}
			}
		}

}
}