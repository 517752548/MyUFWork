using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 敌人组配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MissionEnemyGroupTemplateDBBase : TemplateDBBase<MissionEnemyGroupTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MissionEnemyGroupTemplate> idKeyDic = new Dictionary<int, MissionEnemyGroupTemplate>();
        
		protected static MissionEnemyGroupTemplateDB _ins;
        public static MissionEnemyGroupTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MissionEnemyGroupTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MissionEnemyGroupTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MissionEnemyGroupTemplate missionenemygrouptemplate)
        {
            if (this.idKeyDic.ContainsKey(missionenemygrouptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + missionenemygrouptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(missionenemygrouptemplate.Id, missionenemygrouptemplate);
            return true;
        }

        public override MissionEnemyGroupTemplate getTemplate(int id)
        {
            MissionEnemyGroupTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MissionEnemyGroupTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MissionEnemyGroupTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MissionEnemyGroupTemplate missionenemygrouptemplate = new MissionEnemyGroupTemplate();
				//id，每个表都有
				missionenemygrouptemplate.Id = reader.GetInt32(startIndex++);
		
		        missionenemygrouptemplate.enemyList = new List<MissionUnitEnemyTemplate>(6);
		        for (int i = 0; i < 6; i++)
		        {
		            missionenemygrouptemplate.enemyList.Add(new MissionUnitEnemyTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				MissionEnemyGroupTemplateDB.Instance.addTemplate(missionenemygrouptemplate);
				}
			}
		}

}
}