using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 随机名称表，名
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class RoleNameMaleMingTemplateDBBase : TemplateDBBase<RoleNameMaleMingTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, RoleNameMaleMingTemplate> idKeyDic = new Dictionary<int, RoleNameMaleMingTemplate>();
        
		protected static RoleNameMaleMingTemplateDB _ins;
        public static RoleNameMaleMingTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new RoleNameMaleMingTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, RoleNameMaleMingTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(RoleNameMaleMingTemplate rolenamemalemingtemplate)
        {
            if (this.idKeyDic.ContainsKey(rolenamemalemingtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + rolenamemalemingtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(rolenamemalemingtemplate.Id, rolenamemalemingtemplate);
            return true;
        }

        public override RoleNameMaleMingTemplate getTemplate(int id)
        {
            RoleNameMaleMingTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get RoleNameMaleMingTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_RoleNameMaleMingTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				RoleNameMaleMingTemplate rolenamemalemingtemplate = new RoleNameMaleMingTemplate();
				//id，每个表都有
				rolenamemalemingtemplate.Id = reader.GetInt32(startIndex++);
		
				rolenamemalemingtemplate.wordLangId = reader.GetInt64(startIndex++);
	
				rolenamemalemingtemplate.word = reader.GetString(startIndex++);
	
				RoleNameMaleMingTemplateDB.Instance.addTemplate(rolenamemalemingtemplate);
				}
			}
		}

}
}