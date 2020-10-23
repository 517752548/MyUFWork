using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 遇怪
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyNumTemplateDBBase : TemplateDBBase<EnemyNumTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EnemyNumTemplate> idKeyDic = new Dictionary<int, EnemyNumTemplate>();
        
		protected static EnemyNumTemplateDB _ins;
        public static EnemyNumTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EnemyNumTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EnemyNumTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EnemyNumTemplate enemynumtemplate)
        {
            if (this.idKeyDic.ContainsKey(enemynumtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + enemynumtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(enemynumtemplate.Id, enemynumtemplate);
            return true;
        }

        public override EnemyNumTemplate getTemplate(int id)
        {
            EnemyNumTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EnemyNumTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EnemyNumTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EnemyNumTemplate enemynumtemplate = new EnemyNumTemplate();
				//id，每个表都有
				enemynumtemplate.Id = reader.GetInt32(startIndex++);
		
				enemynumtemplate.minNum = reader.GetInt32(startIndex++);
	
				enemynumtemplate.maxNum = reader.GetInt32(startIndex++);
	
				EnemyNumTemplateDB.Instance.addTemplate(enemynumtemplate);
				}
			}
		}

}
}