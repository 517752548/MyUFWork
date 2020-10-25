package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PlayerLoginLog extends BaseLog{

	//登陆终端
    private String device;
	//登陆时间
    private long playerLoginTime;
	//登陆信息--设备来源|终端id|设备类型|设备版本号|客户端版本号|客户端语言类型
    private String source;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(device);
		list.add(playerLoginTime);
		list.add(source);
		return list;
	}
	
	public String getDevice() {
		return device;
	}
	public long getPlayerLoginTime() {
		return playerLoginTime;
	}
	public String getSource() {
		return source;
	}
        
	public void setDevice(String device) {
		this.device = device;
	}
	public void setPlayerLoginTime(long playerLoginTime) {
		this.playerLoginTime = playerLoginTime;
	}
	public void setSource(String source) {
		this.source = source;
	}

}