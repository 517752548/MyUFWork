package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageParseException;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.msg.recognizer.BaseMessageRecognizer;
import com.imop.lj.gameserver.common.msg.GCHandshake;

public class RobotClientMsgRecognizer extends BaseMessageRecognizer implements InitializeRequired {

	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();

	public RobotClientMsgRecognizer() {
		this.init();
	}

	@Override
	public IMessage createMessageImpl(short type) throws MessageParseException {
		Class<?> clazz = msgs.get(type);
		if (clazz == null) {
			throw new MessageParseException("Unknow msgType:" + type);
		} else {
			try {
				IMessage msg = (IMessage) clazz.newInstance();
				return msg;
			} catch (Exception e) {
				throw new MessageParseException("Message Newinstance Failed，msgType:" + type, e);
			}
		}
	}

	/**
	 * 注册消息号和消息类的映射
	 *
	 * @param mappingProvider
	 */
	private void registerMsgMapping(MessageMappingProvider mappingProvider) {
		msgs.putAll(mappingProvider.getMessageMapping());
	}

	@Override
	public void init() {
		registerMsgMapping(new MessageMappingProvider(){
			@Override
			public Map<Short, Class<?>> getMessageMapping() {
				Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
				map.put(MessageType.GC_HANDSHAKE, GCHandshake.class);
				return map;
			}
		});
		registerMsgMapping(new RobotPlayerClientMsgRecognizer());
		registerMsgMapping(new RobotHumanClientMsgRecognizer());
		registerMsgMapping(new RobotCommonClientMsgRecognizer());
		registerMsgMapping(new RobotChatClientMsgRecognizer());
		registerMsgMapping(new RobotItemClientMsgRecognizer());
		registerMsgMapping(new RobotSceneClientMsgRecognizer());
		registerMsgMapping(new RobotQuestClientMsgRecognizer());
		registerMsgMapping(new RobotPetClientMsgRecognizer());
		registerMsgMapping(new RobotActivityClientMsgRecognizer());
		registerMsgMapping(new RobotActivityuiClientMsgRecognizer());
		registerMsgMapping(new RobotMailClientMsgRecognizer());
		registerMsgMapping(new RobotTestClientMsgRecognizer());
		registerMsgMapping(new RobotWallowClientMsgRecognizer());
		registerMsgMapping(new RobotRelationClientMsgRecognizer());
		registerMsgMapping(new RobotMallClientMsgRecognizer());
		registerMsgMapping(new RobotGoodactivityClientMsgRecognizer());
		registerMsgMapping(new RobotPrizeClientMsgRecognizer());
		registerMsgMapping(new RobotMysteryshopClientMsgRecognizer());
		registerMsgMapping(new RobotMapClientMsgRecognizer());
		registerMsgMapping(new RobotBattleClientMsgRecognizer());
		registerMsgMapping(new RobotPubtaskClientMsgRecognizer());
		registerMsgMapping(new RobotCorpsClientMsgRecognizer());
		registerMsgMapping(new RobotThesweeneytaskClientMsgRecognizer());
		registerMsgMapping(new RobotTeamClientMsgRecognizer());
		registerMsgMapping(new RobotWizardraidClientMsgRecognizer());
		registerMsgMapping(new RobotTreasuremapClientMsgRecognizer());
		registerMsgMapping(new RobotForagetaskClientMsgRecognizer());
		registerMsgMapping(new RobotOvermanClientMsgRecognizer());
		registerMsgMapping(new RobotMarryClientMsgRecognizer());
		registerMsgMapping(new RobotNvnClientMsgRecognizer());
		registerMsgMapping(new RobotWingClientMsgRecognizer());
		registerMsgMapping(new RobotArenaClientMsgRecognizer());
		registerMsgMapping(new RobotOnlinegiftClientMsgRecognizer());
		registerMsgMapping(new RobotTitleClientMsgRecognizer());
		registerMsgMapping(new RobotTradeClientMsgRecognizer());
		registerMsgMapping(new RobotCorpstaskClientMsgRecognizer());
		registerMsgMapping(new RobotGuideClientMsgRecognizer());
		registerMsgMapping(new RobotPromoteClientMsgRecognizer());
		registerMsgMapping(new RobotTowerClientMsgRecognizer());
		registerMsgMapping(new RobotCorpsbossClientMsgRecognizer());
		registerMsgMapping(new RobotExamClientMsgRecognizer());
		registerMsgMapping(new RobotPlotdungeonClientMsgRecognizer());
		registerMsgMapping(new RobotCraftClientMsgRecognizer());
		registerMsgMapping(new RobotEquipClientMsgRecognizer());
		registerMsgMapping(new RobotHumanskillClientMsgRecognizer());
		registerMsgMapping(new RobotLifeskillClientMsgRecognizer());
		registerMsgMapping(new RobotTimelimitClientMsgRecognizer());
		registerMsgMapping(new RobotTimelimitmonsterClientMsgRecognizer());
		registerMsgMapping(new RobotTimelimitnpcClientMsgRecognizer());
		registerMsgMapping(new RobotSiegedemonClientMsgRecognizer());
	}
}
