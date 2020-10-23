using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物被动技能效果
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanSubPassiveSkillTemplateDBBase : TemplateDBBase<HumanSubPassiveSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanSubPassiveSkillTemplate> idKeyDic = new Dictionary<int, HumanSubPassiveSkillTemplate>();
        
		protected static HumanSubPassiveSkillTemplateDB _ins;
        public static HumanSubPassiveSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanSubPassiveSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanSubPassiveSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanSubPassiveSkillTemplate humansubpassiveskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(humansubpassiveskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humansubpassiveskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humansubpassiveskilltemplate.Id, humansubpassiveskilltemplate);
            return true;
        }

        public override HumanSubPassiveSkillTemplate getTemplate(int id)
        {
            HumanSubPassiveSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanSubPassiveSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanSubPassiveSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanSubPassiveSkillTemplate humansubpassiveskilltemplate = new HumanSubPassiveSkillTemplate();
				//id，每个表都有
				humansubpassiveskilltemplate.Id = reader.GetInt32(startIndex++);
		
				humansubpassiveskilltemplate.name = reader.GetString(startIndex++);
	
				humansubpassiveskilltemplate.propType = reader.GetInt32(startIndex++);
	
				humansubpassiveskilltemplate.baseProp = reader.GetInt32(startIndex++);
	
				humansubpassiveskilltemplate.addProp = reader.GetInt32(startIndex++);
	
				HumanSubPassiveSkillTemplateDB.Instance.addTemplate(humansubpassiveskilltemplate);
				}
			}
		}

}
}