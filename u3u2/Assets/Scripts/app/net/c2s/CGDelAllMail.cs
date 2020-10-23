using System;
using System.IO;
namespace app.net
{

/**
 * 删除所有邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelAllMail :BaseMessage
{
	
	/** 要删除的所有邮件uuid */
	private string[] uuidlist;
	
	public CGDelAllMail ()
	{
	}
	
	public CGDelAllMail (
			string[] uuidlist )
	{
			this.uuidlist = uuidlist;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 要删除的所有邮件uuid
	WriteShort((short)uuidlist.Length);
	int uuidlistSize = uuidlist.Length;
	int uuidlistIndex = 0;
	for(uuidlistIndex=0; uuidlistIndex<uuidlistSize; uuidlistIndex++){
		WriteString(uuidlist [ uuidlistIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_DEL_ALL_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public string[] getUuidlist()
	{
		return uuidlist;
	}

	public void setUuidlist(string[] uuidlist)
	{
		this.uuidlist = uuidlist;
	}
	}
}