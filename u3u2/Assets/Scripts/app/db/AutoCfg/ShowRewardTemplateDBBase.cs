using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 显示奖励配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ShowRewardTemplateDBBase : TemplateDBBase<ShowRewardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ShowRewardTemplate> idKeyDic = new Dictionary<int, ShowRewardTemplate>();
        
		protected static ShowRewardTemplateDB _ins;
        public static ShowRewardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ShowRewardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ShowRewardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ShowRewardTemplate showrewardtemplate)
        {
            if (this.idKeyDic.ContainsKey(showrewardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + showrewardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(showrewardtemplate.Id, showrewardtemplate);
            return true;
        }

        public override ShowRewardTemplate getTemplate(int id)
        {
            ShowRewardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ShowRewardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ShowRewardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ShowRewardTemplate showrewardtemplate = new ShowRewardTemplate();
				//id，每个表都有
				showrewardtemplate.Id = reader.GetInt32(startIndex++);
		
		        showrewardtemplate.rewardTempalteSet = new List<RewardTemplate>(20);
		        for (int i = 0; i < 20; i++)
		        {
		            showrewardtemplate.rewardTempalteSet.Add(new RewardTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				ShowRewardTemplateDB.Instance.addTemplate(showrewardtemplate);
				}
			}
		}

}
}