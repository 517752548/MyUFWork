
namespace app.net 
{
	public class MailCGHandler
	{
	public static void sendCGMailList(
			int queryIndex,
			int boxType)
	{
		CGMailList msg = new CGMailList(
			queryIndex,
			boxType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGReadMail(
			string uuid)
	{
		CGReadMail msg = new CGReadMail(
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSendMail(
			string recName,
			string title,
			string content)
	{
		CGSendMail msg = new CGSendMail(
			recName,
			title,
			content);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDelMail(
			string uuid)
	{
		CGDelMail msg = new CGDelMail(
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDelAllMail(
			string[] uuidlist)
	{
		CGDelAllMail msg = new CGDelAllMail(
			uuidlist);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSaveMail(
			string uuid)
	{
		CGSaveMail msg = new CGSaveMail(
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSaveMailBatch(
			string[] uuidlist)
	{
		CGSaveMailBatch msg = new CGSaveMailBatch(
			uuidlist);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSendGuildMail(
			string title,
			string content)
	{
		CGSendGuildMail msg = new CGSendGuildMail(
			title,
			content);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetMailAttachment(
			string uuid)
	{
		CGGetMailAttachment msg = new CGGetMailAttachment(
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}