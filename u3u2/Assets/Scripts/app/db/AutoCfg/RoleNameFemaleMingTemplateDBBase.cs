using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 随机名称表，女名
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class RoleNameFemaleMingTemplateDBBase : TemplateDBBase<RoleNameFemaleMingTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, RoleNameFemaleMingTemplate> idKeyDic = new Dictionary<int, RoleNameFemaleMingTemplate>();
        
		protected static RoleNameFemaleMingTemplateDB _ins;
        public static RoleNameFemaleMingTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new RoleNameFemaleMingTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, RoleNameFemaleMingTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(RoleNameFemaleMingTemplate rolenamefemalemingtemplate)
        {
            if (this.idKeyDic.ContainsKey(rolenamefemalemingtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + rolenamefemalemingtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(rolenamefemalemingtemplate.Id, rolenamefemalemingtemplate);
            return true;
        }

        public override RoleNameFemaleMingTemplate getTemplate(int id)
        {
            RoleNameFemaleMingTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get RoleNameFemaleMingTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_RoleNameFemaleMingTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				RoleNameFemaleMingTemplate rolenamefemalemingtemplate = new RoleNameFemaleMingTemplate();
				//id，每个表都有
				rolenamefemalemingtemplate.Id = reader.GetInt32(startIndex++);
		
				rolenamefemalemingtemplate.wordLangId = reader.GetInt64(startIndex++);
	
				rolenamefemalemingtemplate.word = reader.GetString(startIndex++);
	
				RoleNameFemaleMingTemplateDB.Instance.addTemplate(rolenamefemalemingtemplate);
				}
			}
		}

}
}