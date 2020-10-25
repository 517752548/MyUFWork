package com.imop.lj.gm.model.log;

import java.util.List;

public class PlayerLoginLog extends BaseLog {
//	device
//	player_login_time
//	source
//	登陆终端
//	登陆时间
//	登陆信息--设备来源|终端id|设备类型|设备版本号|客户端版本号|客户端语言类型

	private String device;
	private long player_login_time;
	private String source;
	public String getDevice() {
		return device;
	}
	public void setDevice(String device) {
		this.device = device;
	}
	public long getPlayer_login_time() {
		return player_login_time;
	}
	public void setPlayer_login_time(long player_login_time) {
		this.player_login_time = player_login_time;
	}
	public String getSource() {
		return source;
	}
	public void setSource(String source) {
		this.source = source;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.device);
		list.add(this.player_login_time);
		list.add(this.source);
		return list;
	}
}
