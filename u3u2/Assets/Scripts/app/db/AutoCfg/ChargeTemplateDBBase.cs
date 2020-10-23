using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 充值模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ChargeTemplateDBBase : TemplateDBBase<ChargeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ChargeTemplate> idKeyDic = new Dictionary<int, ChargeTemplate>();
        
		protected static ChargeTemplateDB _ins;
        public static ChargeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ChargeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ChargeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ChargeTemplate chargetemplate)
        {
            if (this.idKeyDic.ContainsKey(chargetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + chargetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(chargetemplate.Id, chargetemplate);
            return true;
        }

        public override ChargeTemplate getTemplate(int id)
        {
            ChargeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ChargeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ChargeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ChargeTemplate chargetemplate = new ChargeTemplate();
				//id，每个表都有
				chargetemplate.Id = reader.GetInt32(startIndex++);
		
				chargetemplate.rmb = reader.GetInt32(startIndex++);
	
				chargetemplate.bond = reader.GetInt32(startIndex++);
	
				chargetemplate.firstSysBond = reader.GetInt32(startIndex++);
	
				chargetemplate.giftSysBond = reader.GetInt32(startIndex++);
	
				ChargeTemplateDB.Instance.addTemplate(chargetemplate);
				}
			}
		}

}
}