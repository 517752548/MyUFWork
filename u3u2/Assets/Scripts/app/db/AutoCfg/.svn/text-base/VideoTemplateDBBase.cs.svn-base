using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 剧情录像
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class VideoTemplateDBBase : TemplateDBBase<VideoTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, VideoTemplate> idKeyDic = new Dictionary<int, VideoTemplate>();
        
		protected static VideoTemplateDB _ins;
        public static VideoTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new VideoTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, VideoTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(VideoTemplate videotemplate)
        {
            if (this.idKeyDic.ContainsKey(videotemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + videotemplate.Id);
                return false;
            }
            this.idKeyDic.Add(videotemplate.Id, videotemplate);
            return true;
        }

        public override VideoTemplate getTemplate(int id)
        {
            VideoTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get VideoTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_VideoTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				VideoTemplate videotemplate = new VideoTemplate();
				//id，每个表都有
				videotemplate.Id = reader.GetInt32(startIndex++);
		
				videotemplate.videoId = reader.GetInt32(startIndex++);
	
				videotemplate.timePoint = reader.GetInt32(startIndex++);
	
				videotemplate.targetId = reader.GetString(startIndex++);
	
				videotemplate.targetType = reader.GetInt32(startIndex++);
	
				videotemplate.eventType = reader.GetInt32(startIndex++);
	
				videotemplate.model3DId = reader.GetString(startIndex++);
	
				videotemplate.playerName = reader.GetString(startIndex++);
	
				videotemplate.pixelPoint = reader.GetInt32(startIndex++);
	
				videotemplate.xPoint = reader.GetInt32(startIndex++);
	
				videotemplate.yPoint = reader.GetInt32(startIndex++);
	
				videotemplate.action = reader.GetString(startIndex++);
	
				videotemplate.direction = reader.GetInt32(startIndex++);
	
				videotemplate.talk = reader.GetString(startIndex++);
	
				VideoTemplateDB.Instance.addTemplate(videotemplate);
				}
			}
		}

}
}