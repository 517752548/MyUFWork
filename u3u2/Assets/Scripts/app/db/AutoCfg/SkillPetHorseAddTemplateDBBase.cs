using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠技能加成配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillPetHorseAddTemplateDBBase : TemplateDBBase<SkillPetHorseAddTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillPetHorseAddTemplate> idKeyDic = new Dictionary<int, SkillPetHorseAddTemplate>();
        
		protected static SkillPetHorseAddTemplateDB _ins;
        public static SkillPetHorseAddTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillPetHorseAddTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillPetHorseAddTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillPetHorseAddTemplate skillpethorseaddtemplate)
        {
            if (this.idKeyDic.ContainsKey(skillpethorseaddtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skillpethorseaddtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skillpethorseaddtemplate.Id, skillpethorseaddtemplate);
            return true;
        }

        public override SkillPetHorseAddTemplate getTemplate(int id)
        {
            SkillPetHorseAddTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillPetHorseAddTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillPetHorseAddTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillPetHorseAddTemplate skillpethorseaddtemplate = new SkillPetHorseAddTemplate();
				//id，每个表都有
				skillpethorseaddtemplate.Id = reader.GetInt32(startIndex++);
		
				skillpethorseaddtemplate.name = reader.GetString(startIndex++);
	
				skillpethorseaddtemplate.effectSkillId = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.scenarios = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.extraCoef1 = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.extraCoef2 = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.extraCoef3 = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.extraCoef4 = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.extraCoef5 = reader.GetInt32(startIndex++);
	
				skillpethorseaddtemplate.levelAddList = new List<int>(10);
				for (int i = 0; i < 10; i++)
		        {
		            skillpethorseaddtemplate.levelAddList.Add(reader.GetInt32(startIndex++));
		        }
	
				SkillPetHorseAddTemplateDB.Instance.addTemplate(skillpethorseaddtemplate);
				}
			}
		}

}
}