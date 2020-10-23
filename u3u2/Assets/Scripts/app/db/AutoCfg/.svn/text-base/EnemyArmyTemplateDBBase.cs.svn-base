using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 怪物组表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyArmyTemplateDBBase : TemplateDBBase<EnemyArmyTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EnemyArmyTemplate> idKeyDic = new Dictionary<int, EnemyArmyTemplate>();
        
		protected static EnemyArmyTemplateDB _ins;
        public static EnemyArmyTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EnemyArmyTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EnemyArmyTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EnemyArmyTemplate enemyarmytemplate)
        {
            if (this.idKeyDic.ContainsKey(enemyarmytemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + enemyarmytemplate.Id);
                return false;
            }
            this.idKeyDic.Add(enemyarmytemplate.Id, enemyarmytemplate);
            return true;
        }

        public override EnemyArmyTemplate getTemplate(int id)
        {
            EnemyArmyTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EnemyArmyTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EnemyArmyTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EnemyArmyTemplate enemyarmytemplate = new EnemyArmyTemplate();
				//id，每个表都有
				enemyarmytemplate.Id = reader.GetInt32(startIndex++);
		
				enemyarmytemplate.nameLangId = reader.GetInt64(startIndex++);
	
				enemyarmytemplate.name = reader.GetString(startIndex++);
	
		        enemyarmytemplate.enemyIdAndProbList = new List<EnemyProbTemplate>(10);
		        for (int i = 0; i < 10; i++)
		        {
		            enemyarmytemplate.enemyIdAndProbList.Add(new EnemyProbTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				enemyarmytemplate.rewardId = reader.GetInt32(startIndex++);
	
				enemyarmytemplate.doublePointCost = reader.GetInt32(startIndex++);
	
				enemyarmytemplate.isTower = reader.GetInt32(startIndex++);
	
				EnemyArmyTemplateDB.Instance.addTemplate(enemyarmytemplate);
				}
			}
		}

}
}