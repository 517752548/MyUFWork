
using System;
namespace app.net
{
/**
 * 返回称号界面
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTitlePanel :BaseMessage
{
	/** 称号信息页面 */
	private TitleInfo[] titleList;

	public GCTitlePanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 称号信息页面
	int titleListSize = ReadShort();
	TitleInfo[] _titleList = new TitleInfo[titleListSize];
	int titleListIndex = 0;
	TitleInfo _titleListTmp = null;
	for(titleListIndex=0; titleListIndex<titleListSize; titleListIndex++){
		_titleListTmp = new TitleInfo();
		_titleList[titleListIndex] = _titleListTmp;
	// 称号名称
	string _titleList_titleName = ReadString();	_titleListTmp.titleName = _titleList_titleName;
		// 称号类型id
	int _titleList_templateId = ReadInt();	_titleListTmp.templateId = _titleList_templateId;
		// 称号过期时间
	long _titleList_titleEndTime = ReadLong();	_titleListTmp.titleEndTime = _titleList_titleEndTime;
		}
	//end



		this.titleList = _titleList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TITLE_PANEL;
	}
	
	public override string getEventType()
	{
		return TitleGCHandler.GCTitlePanelEvent;
	}
	

	public TitleInfo[] getTitleList(){
		return titleList;
	}


}
}