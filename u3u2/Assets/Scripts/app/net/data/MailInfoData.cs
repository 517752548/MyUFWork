
namespace app.net
{
	public class MailInfoData
	{
		/** 邮件的唯一标识 */
		public string uuid;
		/** 邮件的标题 */
		public string title;
		/** 发送玩家名称 */
		public string senderName;
		/** 接收玩家名称 */
		public string recName;
		/** 邮件的内容 */
		public string content;
		/** 邮件类型 */
		public int mailType;
		/** 邮件状态 */
		public int mailStatus;
		/** 是否有附件，0没有，1有 */
		public int attachmented;
		/** 发送时间 */
		public string createTime;
		/** 删除时间 */
		public string deleteTime;
		/** 最后更新时间 */
		public long updateTime;
		/** 附件奖励信息 */
		public RewardInfoData rewardInfo;
	}
}