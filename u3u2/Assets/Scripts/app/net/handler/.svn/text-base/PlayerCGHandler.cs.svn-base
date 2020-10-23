
namespace app.net 
{
	public class PlayerCGHandler
	{
	public static void sendCGPlayerLogin(
			string account,
			string password,
			string source)
	{
		CGPlayerLogin msg = new CGPlayerLogin(
			account,
			password,
			source);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlayerCookieLogin(
			string cookieValue,
			string source)
	{
		CGPlayerCookieLogin msg = new CGPlayerCookieLogin(
			cookieValue,
			source);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGRoleTemplate(
)
	{
		CGRoleTemplate msg = new CGRoleTemplate(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGRoleRandomName(
			int sex)
	{
		CGRoleRandomName msg = new CGRoleRandomName(
			sex);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCreateRole(
			string name,
			int templateId)
	{
		CGCreateRole msg = new CGCreateRole(
			name,
			templateId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlayerEnter(
			long roleUUID)
	{
		CGPlayerEnter msg = new CGPlayerEnter(
			roleUUID);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGEnterScene(
)
	{
		CGEnterScene msg = new CGEnterScene(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlayerChargeDiamond(
			int mmCost)
	{
		CGPlayerChargeDiamond msg = new CGPlayerChargeDiamond(
			mmCost);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlayerQueryAccount(
)
	{
		CGPlayerQueryAccount msg = new CGPlayerQueryAccount(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGReportPlayer(
			int scope,
			long charId,
			string charName,
			string chatText,
			string token)
	{
		CGReportPlayer msg = new CGReportPlayer(
			scope,
			charId,
			charName,
			chatText,
			token);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAccountActivationcode(
			string activationCode)
	{
		CGAccountActivationcode msg = new CGAccountActivationcode(
			activationCode);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGIosAndroidCharge(
)
	{
		CGIosAndroidCharge msg = new CGIosAndroidCharge(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetSmsCheckcode(
			string phoneNum)
	{
		CGGetSmsCheckcode msg = new CGGetSmsCheckcode(
			phoneNum);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCheckSmsCheckcode(
			string qqNum,
			string phoneNum,
			string checkCode)
	{
		CGCheckSmsCheckcode msg = new CGCheckSmsCheckcode(
			qqNum,
			phoneNum,
			checkCode);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSmsCheckcodePanel(
)
	{
		CGSmsCheckcodePanel msg = new CGSmsCheckcodePanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetSmsCheckcodeReward(
)
	{
		CGGetSmsCheckcodeReward msg = new CGGetSmsCheckcodeReward(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlayerTokenLogin(
			string pid,
			long rid,
			string token,
			string source)
	{
		CGPlayerTokenLogin msg = new CGPlayerTokenLogin(
			pid,
			rid,
			token,
			source);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGChargeGenOrderid(
			string channelCode,
			string channelExt)
	{
		CGChargeGenOrderid msg = new CGChargeGenOrderid(
			channelCode,
			channelExt);
		GameConnection.Instance.sendMessage(msg);
	}

	public static void sendCGIoschargeCheck(
			string token)
	{
		CGIoschargeCheck msg = new CGIoschargeCheck(
			token);
		GameConnection.Instance.sendMessage(msg);
	}

	}
}