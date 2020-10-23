using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 地图资源坐标及产出表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMapTemplateDBBase : TemplateDBBase<LifeSkillMapTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMapTemplate> idKeyDic = new Dictionary<int, LifeSkillMapTemplate>();
        
		protected static LifeSkillMapTemplateDB _ins;
        public static LifeSkillMapTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMapTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMapTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMapTemplate lifeskillmaptemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillmaptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillmaptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillmaptemplate.Id, lifeskillmaptemplate);
            return true;
        }

        public override LifeSkillMapTemplate getTemplate(int id)
        {
            LifeSkillMapTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMapTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMapTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMapTemplate lifeskillmaptemplate = new LifeSkillMapTemplate();
				//id，每个表都有
				lifeskillmaptemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillmaptemplate.mapId = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.needHumanLevel = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.lifeSkillLevel = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.resourceType = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.resourceId = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.resourceName = reader.GetString(startIndex++);
	
				lifeskillmaptemplate.showFlag = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.itemId = reader.GetInt32(startIndex++);
	
				lifeskillmaptemplate.itemName = reader.GetString(startIndex++);
	
				LifeSkillMapTemplateDB.Instance.addTemplate(lifeskillmaptemplate);
				}
			}
		}

}
}