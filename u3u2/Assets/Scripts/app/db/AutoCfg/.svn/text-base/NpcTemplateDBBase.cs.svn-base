using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * npc模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class NpcTemplateDBBase : TemplateDBBase<NpcTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, NpcTemplate> idKeyDic = new Dictionary<int, NpcTemplate>();
        
		protected static NpcTemplateDB _ins;
        public static NpcTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new NpcTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, NpcTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(NpcTemplate npctemplate)
        {
            if (this.idKeyDic.ContainsKey(npctemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + npctemplate.Id);
                return false;
            }
            this.idKeyDic.Add(npctemplate.Id, npctemplate);
            return true;
        }

        public override NpcTemplate getTemplate(int id)
        {
            NpcTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get NpcTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_NpcTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				NpcTemplate npctemplate = new NpcTemplate();
				//id，每个表都有
				npctemplate.Id = reader.GetInt32(startIndex++);
		
				npctemplate.type = reader.GetInt32(startIndex++);
	
				npctemplate.notShowPanelInt = reader.GetInt32(startIndex++);
	
				npctemplate.nameLangId = reader.GetInt64(startIndex++);
	
				npctemplate.name = reader.GetString(startIndex++);
	
				npctemplate.talkLangId = reader.GetInt64(startIndex++);
	
				npctemplate.talk = reader.GetString(startIndex++);
	
				npctemplate.model3DId = reader.GetString(startIndex++);
	
				npctemplate.model2DId = reader.GetString(startIndex++);
	
				npctemplate.direction = reader.GetInt32(startIndex++);
	
				npctemplate.fuctionIdList = new List<int>(5);
				for (int i = 0; i < 5; i++)
		        {
		            npctemplate.fuctionIdList.Add(reader.GetInt32(startIndex++));
		        }
	
				npctemplate.targetMapId = reader.GetInt32(startIndex++);
	
				npctemplate.enemyGroupId = reader.GetInt32(startIndex++);
	
				npctemplate.musicId = reader.GetString(startIndex++);
	
				npctemplate.questLimit = reader.GetString(startIndex++);
	
		        npctemplate.loopStrList = new List<npcGetLoopStrTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            npctemplate.loopStrList.Add(new npcGetLoopStrTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				NpcTemplateDB.Instance.addTemplate(npctemplate);
				}
			}
		}

}
}