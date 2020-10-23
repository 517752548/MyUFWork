using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 小信封内容模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MailBoxInfoTemplateDBBase : TemplateDBBase<MailBoxInfoTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MailBoxInfoTemplate> idKeyDic = new Dictionary<int, MailBoxInfoTemplate>();
        
		protected static MailBoxInfoTemplateDB _ins;
        public static MailBoxInfoTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MailBoxInfoTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MailBoxInfoTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MailBoxInfoTemplate mailboxinfotemplate)
        {
            if (this.idKeyDic.ContainsKey(mailboxinfotemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mailboxinfotemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mailboxinfotemplate.Id, mailboxinfotemplate);
            return true;
        }

        public override MailBoxInfoTemplate getTemplate(int id)
        {
            MailBoxInfoTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MailBoxInfoTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MailBoxInfoTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MailBoxInfoTemplate mailboxinfotemplate = new MailBoxInfoTemplate();
				//id，每个表都有
				mailboxinfotemplate.Id = reader.GetInt32(startIndex++);
		
				mailboxinfotemplate.infoLangId = reader.GetInt64(startIndex++);
	
				mailboxinfotemplate.info = reader.GetString(startIndex++);
	
				mailboxinfotemplate.weight = reader.GetInt32(startIndex++);
	
				mailboxinfotemplate.icon = reader.GetInt32(startIndex++);
	
				MailBoxInfoTemplateDB.Instance.addTemplate(mailboxinfotemplate);
				}
			}
		}

}
}