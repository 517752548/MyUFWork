package com.imop.lj.gameserver.npc.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class npcGetLoopStrTemplate {
	//NPC循环播放文字1
	@BeanFieldNumber(number = 1)
	private String content1;
	//NPC循环播放文字2
	@BeanFieldNumber(number = 2)
	private String content2;
	public String getContent1() {
		return content1;
	}
	public void setContent1(String content1) {
		this.content1 = content1;
	}
	public String getContent2() {
		return content2;
	}
	public void setContent2(String content2) {
		this.content2 = content2;
	}
	
	
}
