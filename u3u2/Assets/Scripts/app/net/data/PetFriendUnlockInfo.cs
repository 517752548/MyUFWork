
namespace app.net
{
	public class PetFriendUnlockInfo
	{
		/** 伙伴模板Id */
		public int tplId;
		/** 剩余的有效时间， -1表示永久有效，0已过期 */
		public long leftTime;
	}
}