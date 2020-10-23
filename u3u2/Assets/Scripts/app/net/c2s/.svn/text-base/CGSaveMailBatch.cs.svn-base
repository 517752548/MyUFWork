using System;
using System.IO;
namespace app.net
{

/**
 * 批量保存邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSaveMailBatch :BaseMessage
{
	
	/** 要保存的所有邮件uuid */
	private string[] uuidlist;
	
	public CGSaveMailBatch ()
	{
	}
	
	public CGSaveMailBatch (
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
	// 要保存的所有邮件uuid
	WriteShort((short)uuidlist.Length);
	int uuidlistSize = uuidlist.Length;
	int uuidlistIndex = 0;
	for(uuidlistIndex=0; uuidlistIndex<uuidlistSize; uuidlistIndex++){
		WriteString(uuidlist [ uuidlistIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SAVE_MAIL_BATCH;
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