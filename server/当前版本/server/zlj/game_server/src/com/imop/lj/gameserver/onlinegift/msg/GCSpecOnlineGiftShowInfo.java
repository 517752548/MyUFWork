package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回在线礼物展示信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSpecOnlineGiftShowInfo extends GCMessage{
	
	/** X轴偏移量 */
	private int offsetX;
	/** Y轴偏移量 */
	private int offsetY;
	/** 领取倒计时 */
	private long cd;
	/** 资源类型; 1：动画；2：图片 */
	private int resType;
	/** 资源ID */
	private String resId;
	/** 美术字ID */
	private int artFontId;
	/** 展示描述，不可领取时显示 */
	private String showDesc;
	/** 领取描述，可领取时显示 */
	private String receiveDesc;

	public GCSpecOnlineGiftShowInfo (){
	}
	
	public GCSpecOnlineGiftShowInfo (
			int offsetX,
			int offsetY,
			long cd,
			int resType,
			String resId,
			int artFontId,
			String showDesc,
			String receiveDesc ){
			this.offsetX = offsetX;
			this.offsetY = offsetY;
			this.cd = cd;
			this.resType = resType;
			this.resId = resId;
			this.artFontId = artFontId;
			this.showDesc = showDesc;
			this.receiveDesc = receiveDesc;
	}

	@Override
	protected boolean readImpl() {

	// X轴偏移量
	int _offsetX = readInteger();
	//end


	// Y轴偏移量
	int _offsetY = readInteger();
	//end


	// 领取倒计时
	long _cd = readLong();
	//end


	// 资源类型; 1：动画；2：图片
	int _resType = readInteger();
	//end


	// 资源ID
	String _resId = readString();
	//end


	// 美术字ID
	int _artFontId = readInteger();
	//end


	// 展示描述，不可领取时显示
	String _showDesc = readString();
	//end


	// 领取描述，可领取时显示
	String _receiveDesc = readString();
	//end



		this.offsetX = _offsetX;
		this.offsetY = _offsetY;
		this.cd = _cd;
		this.resType = _resType;
		this.resId = _resId;
		this.artFontId = _artFontId;
		this.showDesc = _showDesc;
		this.receiveDesc = _receiveDesc;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// X轴偏移量
	writeInteger(offsetX);


	// Y轴偏移量
	writeInteger(offsetY);


	// 领取倒计时
	writeLong(cd);


	// 资源类型; 1：动画；2：图片
	writeInteger(resType);


	// 资源ID
	writeString(resId);


	// 美术字ID
	writeInteger(artFontId);


	// 展示描述，不可领取时显示
	writeString(showDesc);


	// 领取描述，可领取时显示
	writeString(receiveDesc);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SPEC_ONLINE_GIFT_SHOW_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SPEC_ONLINE_GIFT_SHOW_INFO";
	}

	public int getOffsetX(){
		return offsetX;
	}
		
	public void setOffsetX(int offsetX){
		this.offsetX = offsetX;
	}

	public int getOffsetY(){
		return offsetY;
	}
		
	public void setOffsetY(int offsetY){
		this.offsetY = offsetY;
	}

	public long getCd(){
		return cd;
	}
		
	public void setCd(long cd){
		this.cd = cd;
	}

	public int getResType(){
		return resType;
	}
		
	public void setResType(int resType){
		this.resType = resType;
	}

	public String getResId(){
		return resId;
	}
		
	public void setResId(String resId){
		this.resId = resId;
	}

	public int getArtFontId(){
		return artFontId;
	}
		
	public void setArtFontId(int artFontId){
		this.artFontId = artFontId;
	}

	public String getShowDesc(){
		return showDesc;
	}
		
	public void setShowDesc(String showDesc){
		this.showDesc = showDesc;
	}

	public String getReceiveDesc(){
		return receiveDesc;
	}
		
	public void setReceiveDesc(String receiveDesc){
		this.receiveDesc = receiveDesc;
	}
}