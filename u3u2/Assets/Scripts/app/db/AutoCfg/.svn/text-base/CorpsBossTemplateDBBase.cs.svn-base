using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派boss
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsBossTemplateDBBase : TemplateDBBase<CorpsBossTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsBossTemplate> idKeyDic = new Dictionary<int, CorpsBossTemplate>();
        
		protected static CorpsBossTemplateDB _ins;
        public static CorpsBossTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsBossTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsBossTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsBossTemplate corpsbosstemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsbosstemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsbosstemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsbosstemplate.Id, corpsbosstemplate);
            return true;
        }

        public override CorpsBossTemplate getTemplate(int id)
        {
            CorpsBossTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsBossTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsBossTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsBossTemplate corpsbosstemplate = new CorpsBossTemplate();
				//id，每个表都有
				corpsbosstemplate.Id = reader.GetInt32(startIndex++);
		
				corpsbosstemplate.bossLevel = reader.GetInt32(startIndex++);
	
				corpsbosstemplate.enemyArmyId = reader.GetInt32(startIndex++);
	
				corpsbosstemplate.model3DId = reader.GetString(startIndex++);
	
				corpsbosstemplate.rewardId = reader.GetInt32(startIndex++);
	
				corpsbosstemplate.showRewardName = reader.GetString(startIndex++);
	
				corpsbosstemplate.showRewardId = reader.GetInt32(startIndex++);
	
				corpsbosstemplate.chapterName = reader.GetString(startIndex++);
	
				CorpsBossTemplateDB.Instance.addTemplate(corpsbosstemplate);
				}
			}
		}

}
}