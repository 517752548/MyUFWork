using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 关卡配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MissionTemplateDBBase : TemplateDBBase<MissionTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MissionTemplate> idKeyDic = new Dictionary<int, MissionTemplate>();
        
		protected static MissionTemplateDB _ins;
        public static MissionTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MissionTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MissionTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MissionTemplate missiontemplate)
        {
            if (this.idKeyDic.ContainsKey(missiontemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + missiontemplate.Id);
                return false;
            }
            this.idKeyDic.Add(missiontemplate.Id, missiontemplate);
            return true;
        }

        public override MissionTemplate getTemplate(int id)
        {
            MissionTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MissionTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MissionTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MissionTemplate missiontemplate = new MissionTemplate();
				//id，每个表都有
				missiontemplate.Id = reader.GetInt32(startIndex++);
		
				missiontemplate.mapId = reader.GetString(startIndex++);
	
				missiontemplate.bornPos = reader.GetString(startIndex++);
	
				missiontemplate.music = reader.GetString(startIndex++);
	
				missiontemplate.isBoss = reader.GetInt32(startIndex++);
	
				missiontemplate.missionPrizeId = reader.GetInt32(startIndex++);
	
		        missiontemplate.enemyGroupList = new List<MissionUnitTemplate>(5);
		        for (int i = 0; i < 5; i++)
		        {
		            missiontemplate.enemyGroupList.Add(new MissionUnitTemplate(reader, startIndex));
		            startIndex += 4;
		        }
	
				MissionTemplateDB.Instance.addTemplate(missiontemplate);
				}
			}
		}

}
}