
using System;
namespace app.net
{
/**
 * 返回在线礼物展示信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSpecOnlineGiftShowInfo :BaseMessage
{
	/** X轴偏移量 */
	private int offsetX;
	/** Y轴偏移量 */
	private int offsetY;
	/** 领取倒计时 */
	private long cd;
	/** 资源类型; 1：动画；2：图片 */
	private int resType;
	/** 资源ID */
	private string resId;
	/** 美术字ID */
	private int artFontId;
	/** 展示描述，不可领取时显示 */
	private string showDesc;
	/** 领取描述，可领取时显示 */
	private string receiveDesc;

	public GCSpecOnlineGiftShowInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// X轴偏移量
	int _offsetX = ReadInt();
	// Y轴偏移量
	int _offsetY = ReadInt();
	// 领取倒计时
	long _cd = ReadLong();
	// 资源类型; 1：动画；2：图片
	int _resType = ReadInt();
	// 资源ID
	string _resId = ReadString();
	// 美术字ID
	int _artFontId = ReadInt();
	// 展示描述，不可领取时显示
	string _showDesc = ReadString();
	// 领取描述，可领取时显示
	string _receiveDesc = ReadString();


		this.offsetX = _offsetX;
		this.offsetY = _offsetY;
		this.cd = _cd;
		this.resType = _resType;
		this.resId = _resId;
		this.artFontId = _artFontId;
		this.showDesc = _showDesc;
		this.receiveDesc = _receiveDesc;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SPEC_ONLINE_GIFT_SHOW_INFO;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCSpecOnlineGiftShowInfoEvent;
	}
	

	public int getOffsetX(){
		return offsetX;
	}
		

	public int getOffsetY(){
		return offsetY;
	}
		

	public long getCd(){
		return cd;
	}
		

	public int getResType(){
		return resType;
	}
		

	public string getResId(){
		return resId;
	}
		

	public int getArtFontId(){
		return artFontId;
	}
		

	public string getShowDesc(){
		return showDesc;
	}
		

	public string getReceiveDesc(){
		return receiveDesc;
	}
		

}
}