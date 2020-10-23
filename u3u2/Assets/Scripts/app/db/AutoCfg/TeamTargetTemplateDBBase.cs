using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 队伍目标模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TeamTargetTemplateDBBase : TemplateDBBase<TeamTargetTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TeamTargetTemplate> idKeyDic = new Dictionary<int, TeamTargetTemplate>();
        
		protected static TeamTargetTemplateDB _ins;
        public static TeamTargetTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TeamTargetTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TeamTargetTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TeamTargetTemplate teamtargettemplate)
        {
            if (this.idKeyDic.ContainsKey(teamtargettemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + teamtargettemplate.Id);
                return false;
            }
            this.idKeyDic.Add(teamtargettemplate.Id, teamtargettemplate);
            return true;
        }

        public override TeamTargetTemplate getTemplate(int id)
        {
            TeamTargetTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TeamTargetTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TeamTargetTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TeamTargetTemplate teamtargettemplate = new TeamTargetTemplate();
				//id，每个表都有
				teamtargettemplate.Id = reader.GetInt32(startIndex++);
		
				teamtargettemplate.nameLangId = reader.GetInt64(startIndex++);
	
				teamtargettemplate.name = reader.GetString(startIndex++);
	
				teamtargettemplate.levelLimit = reader.GetInt32(startIndex++);
	
				teamtargettemplate.memberNumLimit = reader.GetInt32(startIndex++);
	
				teamtargettemplate.descLangId = reader.GetInt64(startIndex++);
	
				teamtargettemplate.desc = reader.GetString(startIndex++);
	
				teamtargettemplate.typeName = reader.GetString(startIndex++);
	
				TeamTargetTemplateDB.Instance.addTemplate(teamtargettemplate);
				}
			}
		}

}
}