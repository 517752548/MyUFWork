using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宝石等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemCostTemplateDBBase : TemplateDBBase<GemCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemCostTemplate> idKeyDic = new Dictionary<int, GemCostTemplate>();
        
		protected static GemCostTemplateDB _ins;
        public static GemCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemCostTemplate gemcosttemplate)
        {
            if (this.idKeyDic.ContainsKey(gemcosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemcosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemcosttemplate.Id, gemcosttemplate);
            return true;
        }

        public override GemCostTemplate getTemplate(int id)
        {
            GemCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemCostTemplate gemcosttemplate = new GemCostTemplate();
				//id，每个表都有
				gemcosttemplate.Id = reader.GetInt32(startIndex++);
		
				gemcosttemplate.humanLevel = reader.GetInt32(startIndex++);
	
				gemcosttemplate.value = reader.GetInt32(startIndex++);
	
				gemcosttemplate.currencyType1 = reader.GetInt32(startIndex++);
	
				gemcosttemplate.currencyNum1 = reader.GetInt32(startIndex++);
	
				gemcosttemplate.currencyType2 = reader.GetInt32(startIndex++);
	
				gemcosttemplate.currencyNum2 = reader.GetInt32(startIndex++);
	
				gemcosttemplate.synthesisCostGemNum = reader.GetInt32(startIndex++);
	
				gemcosttemplate.synthesisCostCurrencyType = reader.GetInt32(startIndex++);
	
				gemcosttemplate.synthesisCostCurrencyNum = reader.GetInt32(startIndex++);
	
				gemcosttemplate.synthesisProb = reader.GetInt32(startIndex++);
	
				GemCostTemplateDB.Instance.addTemplate(gemcosttemplate);
				}
			}
		}

}
}