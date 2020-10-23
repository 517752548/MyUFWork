using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 伙伴配置表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetFriendTemplateDBBase : TemplateDBBase<PetFriendTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetFriendTemplate> idKeyDic = new Dictionary<int, PetFriendTemplate>();
        
		protected static PetFriendTemplateDB _ins;
        public static PetFriendTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetFriendTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetFriendTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetFriendTemplate petfriendtemplate)
        {
            if (this.idKeyDic.ContainsKey(petfriendtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petfriendtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petfriendtemplate.Id, petfriendtemplate);
            return true;
        }

        public override PetFriendTemplate getTemplate(int id)
        {
            PetFriendTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetFriendTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetFriendTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetFriendTemplate petfriendtemplate = new PetFriendTemplate();
				//id，每个表都有
				petfriendtemplate.Id = reader.GetInt32(startIndex++);
		
				petfriendtemplate.needUnlock = reader.GetInt32(startIndex++);
	
				petfriendtemplate.unlockCostList = new List<int>(3);
				for (int i = 0; i < 3; i++)
		        {
		            petfriendtemplate.unlockCostList.Add(reader.GetInt32(startIndex++));
		        }
	
				PetFriendTemplateDB.Instance.addTemplate(petfriendtemplate);
				}
			}
		}

}
}