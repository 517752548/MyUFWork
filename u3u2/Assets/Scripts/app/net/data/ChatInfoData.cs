
namespace app.net
{
	public class ChatInfoData
	{
		/** 聊天范围 */
		public int scope;
		/** 类型，0默认，1语音 */
		public int chatType;
		/** 聊天消息发送者角色UUID */
		public string fromRoleUUID;
		/** 聊天消息发送者角色名称 */
		public string fromRoleName;
		/** 聊天消息发送者等级 */
		public int fromRoleLevel;
		/** 聊天消息发送者国家 */
		public int fromRoleCountry;
		/** 聊天消息发送者模板Id */
		public int fromRoleTplId;
		/** 经过过滤后的聊天消息 */
		public string content;
		/** 聊天时间 */
		public long chatTime;
		/** 聊天消息接收者角色UUID */
		public string toRoleUUID;
		/** 聊天消息接收者角色名 */
		public string toRoleName;
		/** 聊天消息接收者模板Id */
		public int toRoleTplId;
		/** 发送者的vip等级 */
		public int fromRoleVipLevel;
		/** 接受者的vip等级 */
		public int toRoleVipLevel;
		/** 发送者是否接受者的好友 */
		public int IsFriendOfToRole;
		/** 发送者qq信息vip等数据 */
		public QQInfoData fromQQInfo;
		/** 接受者qq信息vip等数据 */
		public QQInfoData toQQInfo;
		/** 额外扩展字段 */
		public string ext;
	}
}