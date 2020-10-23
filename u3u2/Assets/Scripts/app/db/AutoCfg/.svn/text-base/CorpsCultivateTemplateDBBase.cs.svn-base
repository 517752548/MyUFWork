using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派修炼技能配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsCultivateTemplateDBBase : TemplateDBBase<CorpsCultivateTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsCultivateTemplate> idKeyDic = new Dictionary<int, CorpsCultivateTemplate>();
        
		protected static CorpsCultivateTemplateDB _ins;
        public static CorpsCultivateTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsCultivateTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsCultivateTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsCultivateTemplate corpscultivatetemplate)
        {
            if (this.idKeyDic.ContainsKey(corpscultivatetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpscultivatetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpscultivatetemplate.Id, corpscultivatetemplate);
            return true;
        }

        public override CorpsCultivateTemplate getTemplate(int id)
        {
            CorpsCultivateTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsCultivateTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsCultivateTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsCultivateTemplate corpscultivatetemplate = new CorpsCultivateTemplate();
				//id，每个表都有
				corpscultivatetemplate.Id = reader.GetInt32(startIndex++);
		
				corpscultivatetemplate.cultivateId = reader.GetInt32(startIndex++);
	
				corpscultivatetemplate.icon = reader.GetString(startIndex++);
	
				corpscultivatetemplate.playerSkillFlag = reader.GetInt32(startIndex++);
	
				corpscultivatetemplate.cultivateName = reader.GetString(startIndex++);
	
				corpscultivatetemplate.cultivateDesc = reader.GetString(startIndex++);
	
		        corpscultivatetemplate.propList = new List<PassiveTalentPropItem>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            corpscultivatetemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				CorpsCultivateTemplateDB.Instance.addTemplate(corpscultivatetemplate);
				}
			}
		}

}
}