using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 护送粮草奖励模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ForageTaskRewardTemplateDBBase : TemplateDBBase<ForageTaskRewardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ForageTaskRewardTemplate> idKeyDic = new Dictionary<int, ForageTaskRewardTemplate>();
        
		protected static ForageTaskRewardTemplateDB _ins;
        public static ForageTaskRewardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ForageTaskRewardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ForageTaskRewardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ForageTaskRewardTemplate foragetaskrewardtemplate)
        {
            if (this.idKeyDic.ContainsKey(foragetaskrewardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + foragetaskrewardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(foragetaskrewardtemplate.Id, foragetaskrewardtemplate);
            return true;
        }

        public override ForageTaskRewardTemplate getTemplate(int id)
        {
            ForageTaskRewardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ForageTaskRewardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ForageTaskRewardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ForageTaskRewardTemplate foragetaskrewardtemplate = new ForageTaskRewardTemplate();
				//id，每个表都有
				foragetaskrewardtemplate.Id = reader.GetInt32(startIndex++);
		
				foragetaskrewardtemplate.forageStar = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.deposit = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.depositType = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.rewardType1 = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.rewardNum1 = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.deductProp1 = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.rewardType2 = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.rewardNum2 = reader.GetInt32(startIndex++);
	
				foragetaskrewardtemplate.rewardProp2 = reader.GetInt32(startIndex++);
	
				ForageTaskRewardTemplateDB.Instance.addTemplate(foragetaskrewardtemplate);
				}
			}
		}

}
}