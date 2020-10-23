using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 称号模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TitleTemplateDBBase : TemplateDBBase<TitleTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TitleTemplate> idKeyDic = new Dictionary<int, TitleTemplate>();
        
		protected static TitleTemplateDB _ins;
        public static TitleTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TitleTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TitleTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TitleTemplate titletemplate)
        {
            if (this.idKeyDic.ContainsKey(titletemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + titletemplate.Id);
                return false;
            }
            this.idKeyDic.Add(titletemplate.Id, titletemplate);
            return true;
        }

        public override TitleTemplate getTemplate(int id)
        {
            TitleTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TitleTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TitleTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TitleTemplate titletemplate = new TitleTemplate();
				//id，每个表都有
				titletemplate.Id = reader.GetInt32(startIndex++);
		
				titletemplate.descname = reader.GetString(startIndex++);
	
				titletemplate.gettype = reader.GetString(startIndex++);
	
				titletemplate.deadtime = reader.GetInt32(startIndex++);
	
				titletemplate.desc = reader.GetString(startIndex++);
	
		        titletemplate.basePropList = new List<EquipItemAttribute>(6);
		        for (int i = 0; i < 6; i++)
		        {
		            titletemplate.basePropList.Add(new EquipItemAttribute(reader, startIndex));
		            startIndex += 2;
		        }
	
				TitleTemplateDB.Instance.addTemplate(titletemplate);
				}
			}
		}

}
}