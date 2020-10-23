using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 护送粮草等级模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ForageTaskTemplateDBBase : TemplateDBBase<ForageTaskTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ForageTaskTemplate> idKeyDic = new Dictionary<int, ForageTaskTemplate>();
        
		protected static ForageTaskTemplateDB _ins;
        public static ForageTaskTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ForageTaskTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ForageTaskTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ForageTaskTemplate foragetasktemplate)
        {
            if (this.idKeyDic.ContainsKey(foragetasktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + foragetasktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(foragetasktemplate.Id, foragetasktemplate);
            return true;
        }

        public override ForageTaskTemplate getTemplate(int id)
        {
            ForageTaskTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ForageTaskTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ForageTaskTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ForageTaskTemplate foragetasktemplate = new ForageTaskTemplate();
				//id，每个表都有
				foragetasktemplate.Id = reader.GetInt32(startIndex++);
		
				foragetasktemplate.levelMin = reader.GetInt32(startIndex++);
	
				foragetasktemplate.levelMax = reader.GetInt32(startIndex++);
	
				foragetasktemplate.questGroupId = reader.GetInt32(startIndex++);
	
				foragetasktemplate.weight = reader.GetInt32(startIndex++);
	
				ForageTaskTemplateDB.Instance.addTemplate(foragetasktemplate);
				}
			}
		}

}
}