using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派福利模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsBenifitTemplateDBBase : TemplateDBBase<CorpsBenifitTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsBenifitTemplate> idKeyDic = new Dictionary<int, CorpsBenifitTemplate>();
        
		protected static CorpsBenifitTemplateDB _ins;
        public static CorpsBenifitTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsBenifitTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsBenifitTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsBenifitTemplate corpsbenifittemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsbenifittemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsbenifittemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsbenifittemplate.Id, corpsbenifittemplate);
            return true;
        }

        public override CorpsBenifitTemplate getTemplate(int id)
        {
            CorpsBenifitTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsBenifitTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsBenifitTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsBenifitTemplate corpsbenifittemplate = new CorpsBenifitTemplate();
				//id，每个表都有
				corpsbenifittemplate.Id = reader.GetInt32(startIndex++);
		
				corpsbenifittemplate.ContributionFoot = reader.GetInt32(startIndex++);
	
				corpsbenifittemplate.ContributionTop = reader.GetInt32(startIndex++);
	
				corpsbenifittemplate.currencyType = reader.GetInt32(startIndex++);
	
				corpsbenifittemplate.currencyNum = reader.GetInt32(startIndex++);
	
				CorpsBenifitTemplateDB.Instance.addTemplate(corpsbenifittemplate);
				}
			}
		}

}
}