using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 挂机价值配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyGuaJiValueTemplateDBBase : TemplateDBBase<EnemyGuaJiValueTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EnemyGuaJiValueTemplate> idKeyDic = new Dictionary<int, EnemyGuaJiValueTemplate>();
        
		protected static EnemyGuaJiValueTemplateDB _ins;
        public static EnemyGuaJiValueTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EnemyGuaJiValueTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EnemyGuaJiValueTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EnemyGuaJiValueTemplate enemyguajivaluetemplate)
        {
            if (this.idKeyDic.ContainsKey(enemyguajivaluetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + enemyguajivaluetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(enemyguajivaluetemplate.Id, enemyguajivaluetemplate);
            return true;
        }

        public override EnemyGuaJiValueTemplate getTemplate(int id)
        {
            EnemyGuaJiValueTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EnemyGuaJiValueTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EnemyGuaJiValueTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EnemyGuaJiValueTemplate enemyguajivaluetemplate = new EnemyGuaJiValueTemplate();
				//id，每个表都有
				enemyguajivaluetemplate.Id = reader.GetInt32(startIndex++);
		
				enemyguajivaluetemplate.desc = reader.GetString(startIndex++);
	
		        enemyguajivaluetemplate.valueList = new List<GuaJiValueItem>(5);
		        for (int i = 0; i < 5; i++)
		        {
		            enemyguajivaluetemplate.valueList.Add(new GuaJiValueItem(reader, startIndex));
		            startIndex += 2;
		        }
	
				EnemyGuaJiValueTemplateDB.Instance.addTemplate(enemyguajivaluetemplate);
				}
			}
		}

}
}