using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宝石合成
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemSynthesisTemplateDBBase : TemplateDBBase<GemSynthesisTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemSynthesisTemplate> idKeyDic = new Dictionary<int, GemSynthesisTemplate>();
        
		protected static GemSynthesisTemplateDB _ins;
        public static GemSynthesisTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemSynthesisTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemSynthesisTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemSynthesisTemplate gemsynthesistemplate)
        {
            if (this.idKeyDic.ContainsKey(gemsynthesistemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemsynthesistemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemsynthesistemplate.Id, gemsynthesistemplate);
            return true;
        }

        public override GemSynthesisTemplate getTemplate(int id)
        {
            GemSynthesisTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemSynthesisTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemSynthesisTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemSynthesisTemplate gemsynthesistemplate = new GemSynthesisTemplate();
				//id，每个表都有
				gemsynthesistemplate.Id = reader.GetInt32(startIndex++);
		
				gemsynthesistemplate.gemLevel = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.synthesisBase = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.currencyType = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.currencyNum = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.symbolId = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.symbolNum = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.synthesisProb = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.rewardProb = reader.GetInt32(startIndex++);
	
				gemsynthesistemplate.rewardId = reader.GetInt32(startIndex++);
	
				GemSynthesisTemplateDB.Instance.addTemplate(gemsynthesistemplate);
				}
			}
		}

}
}