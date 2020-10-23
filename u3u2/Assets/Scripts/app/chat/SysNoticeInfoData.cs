using app.net;

namespace app.chat
{
	public class SysNoticeInfoData
	{
		/** 窗口内容 */
		private string content;
		/** 操作标识 */
		private string tag;
		/** 小信封1无选择项2有选择框 */
		private int type;
		/** 小信封icon */
		private int icon;
		/** 点完确定之后播放的动画类型，暂留 */
		private int showAnimation;
		/** 来源角色ID */
		private long fromRoleId;
		/** 来源名称 */
		private string fromRoleName;
		/** 等级 */
		private int fromRoleLevel;
		/** 角色职业 */
		private int fromRoleJobType;
		/** 角色模板Id */
		private int fromRoleTplId;
		/** 聊天时间 */
		private long chatTime;
		private bool hasReaden;
		
		public SysNoticeInfoData(NoticeTipsInfoData data)
        {
			this.content = data.content;
			this.tag = data.tag;
			this.type = data.type;
			this.icon = data.icon;
			this.showAnimation = data.showAnimation;
			this.fromRoleId = data.fromRoleId;
			this.fromRoleName = data.fromRoleName;
			this.fromRoleLevel = data.fromRoleLevel;
			this.fromRoleJobType = data.fromRoleJobType;
			this.fromRoleTplId = data.fromRoleTplId;
			this.chatTime = data.chatTime;
		}
		
		public string getContent()
		{
			return content;
		}
		
		public void setContent(string value)
		{
			this.content = value;
		}
		
		public string getTag()
		{
			return tag;
		}
		
		public void setTag(string value)
		{
			this.tag = value;
		}
		
		public int getType()
		{
			return type;
		}
		
		public void setType(int value)
		{
			this.type = value;
		}
		
		public int getIcon()
		{
			return icon;
		}
		
		public void setIcon(int value)
		{
			this.icon = value;
		}
		
		public int getShowAnimation()
		{
			return showAnimation;
		}
		
		public void setShowAnimation(int value)
		{
			this.showAnimation = value;
		}
		
		public long getFromRoleId()
		{
			return fromRoleId;
		}
		
		public void setFromRoleId(long value)
		{
			this.fromRoleId = value;
		}
		
		public string getFromRoleName()
		{
			return fromRoleName;
		}
		
		public void setFromRoleName(string value)
		{
			this.fromRoleName = value;
		}
		
		public int getFromRoleLevel()
		{
			return fromRoleLevel;
		}
		
		public void setFromRoleLevel(int value)
		{
			this.fromRoleLevel = value;
		}
		
		public int getFromRoleJobType()
		{
			return fromRoleJobType;
		}
		
		public void setFromRoleJobType(int value)
		{
			this.fromRoleJobType = value;
		}
		
		public int getFromRoleTplId()
		{
			return fromRoleTplId;
		}
		
		public void setFromRoleTplId(int value)
		{
			this.fromRoleTplId = value;
		}
		
		public long getChatTime()
		{
			return chatTime;
		}
		
		public void setChatTime(long value)
		{
			this.chatTime = value;
		}
		
		public bool getHasReaden()
		{
			return hasReaden;
		}
		
		public void setHasReaden(bool value)
		{
			this.hasReaden = value;
		}
	}
}