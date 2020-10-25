package com.imop.lj.gameserver.redenvelope.msg;

import java.util.List;

import com.google.common.collect.Lists;
import com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo;
import com.imop.lj.common.model.corps.OpenRedEnveloperInfo;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsRedEnvelopePanel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.redenvelope.RedEnvelope;
import com.imop.lj.gameserver.redenvelope.model.OpenRedEnveloper;

public class RedEnvelopeMsgBuilder {

	public static GCOpenCorpsRedEnvelopePanel createGCOpenCorpsRedEnvelopePanel(Human human, List<RedEnvelope> list){
		GCOpenCorpsRedEnvelopePanel msg = new GCOpenCorpsRedEnvelopePanel();
		List<CorpsRedEnvelopeInfo> corpsRedEnvelopeInfoList = Lists.newArrayList();
		for (RedEnvelope redEnvelope : list) {
			corpsRedEnvelopeInfoList.add(createCorpsRedEnvelopeInfo(redEnvelope));
		}
		msg.setCorpsRedEnvelopeInfoList(corpsRedEnvelopeInfoList.toArray(new CorpsRedEnvelopeInfo[0]));
		return msg;
		
	}
	
	public static GCOpenCorpsRedEnvelopePanel createGCOpenCorpsRedEnvelopePanel(Human human, RedEnvelope redEnvelope){
		GCOpenCorpsRedEnvelopePanel msg = new GCOpenCorpsRedEnvelopePanel();
		List<CorpsRedEnvelopeInfo> corpsRedEnvelopeInfoList = Lists.newArrayList();
		corpsRedEnvelopeInfoList.add(createCorpsRedEnvelopeInfo(redEnvelope));
		msg.setCorpsRedEnvelopeInfoList(corpsRedEnvelopeInfoList.toArray(new CorpsRedEnvelopeInfo[0]));
		return msg;
		
	}
	
	
	
	public static CorpsRedEnvelopeInfo createCorpsRedEnvelopeInfo(RedEnvelope redEnvelope){
		CorpsRedEnvelopeInfo info = new CorpsRedEnvelopeInfo();
		info.setUuid(redEnvelope.getUuid());
		info.setCorpsId(redEnvelope.getCorpsId());
		info.setSendId(redEnvelope.getSendId());
		info.setSendName(redEnvelope.getSendName());
		info.setContent(redEnvelope.getContent());
		info.setRedEnvelopeType(redEnvelope.getRedEnvelopeType().getIndex());
		info.setRedEnvelopeStatus(redEnvelope.getRedEnvelopeStatus().getIndex());
		info.setCreateTime(redEnvelope.getCreateTime());
		info.setBonusAmount(redEnvelope.getBonusAmount());
		info.setRemainingBonus(redEnvelope.getRemainingBonus());
		info.setRemainingNum(redEnvelope.getRemainingNum());
		List<OpenRedEnveloperInfo> openLst = Lists.newArrayList();
		for(OpenRedEnveloper openRedEnveloper : redEnvelope.getOpenRedEnveloperMap().values()){
			openLst.add(createOpenRedEnveloperInfo(openRedEnveloper));
		}
		info.setOpenRedEnveloperInfoList(openLst.toArray(new OpenRedEnveloperInfo[0]));
		return info;
		
	}
	
	
	public static OpenRedEnveloperInfo createOpenRedEnveloperInfo(OpenRedEnveloper openRedEnveloper){
		OpenRedEnveloperInfo info = new OpenRedEnveloperInfo();
		info.setRecId(openRedEnveloper.getRecId());
		info.setRecName(openRedEnveloper.getRecName());
		info.setOpenTime(openRedEnveloper.getOpenTime());
		info.setGotBonus(openRedEnveloper.getGotBonus());
		return info;
	}
}
