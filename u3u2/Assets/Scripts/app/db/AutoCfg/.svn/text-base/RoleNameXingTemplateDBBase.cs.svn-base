using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 随机名称表，姓
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class RoleNameXingTemplateDBBase : TemplateDBBase<RoleNameXingTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, RoleNameXingTemplate> idKeyDic = new Dictionary<int, RoleNameXingTemplate>();
        
		protected static RoleNameXingTemplateDB _ins;
        public static RoleNameXingTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new RoleNameXingTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, RoleNameXingTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(RoleNameXingTemplate rolenamexingtemplate)
        {
            if (this.idKeyDic.ContainsKey(rolenamexingtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + rolenamexingtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(rolenamexingtemplate.Id, rolenamexingtemplate);
            return true;
        }

        public override RoleNameXingTemplate getTemplate(int id)
        {
            RoleNameXingTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get RoleNameXingTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_RoleNameXingTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				RoleNameXingTemplate rolenamexingtemplate = new RoleNameXingTemplate();
				//id，每个表都有
				rolenamexingtemplate.Id = reader.GetInt32(startIndex++);
		
				rolenamexingtemplate.wordLangId = reader.GetInt64(startIndex++);
	
				rolenamexingtemplate.word = reader.GetString(startIndex++);
	
				RoleNameXingTemplateDB.Instance.addTemplate(rolenamexingtemplate);
				}
			}
		}

}
}