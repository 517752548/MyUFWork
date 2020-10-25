package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.player.msg.GCRoleList;
import com.imop.lj.gameserver.player.msg.GCRoleTemplate;
import com.imop.lj.gameserver.player.msg.GCGameEnterPlayerNum;
import com.imop.lj.gameserver.player.msg.GCRoleRandomName;
import com.imop.lj.gameserver.player.msg.GCFailedMsg;
import com.imop.lj.gameserver.player.msg.GCSceneInfo;
import com.imop.lj.gameserver.player.msg.GCEnterScene;
import com.imop.lj.gameserver.player.msg.GCNotifyException;
import com.imop.lj.gameserver.player.msg.GCPopupPanelEnd;
import com.imop.lj.gameserver.player.msg.GCPlayerChargeDiamond;
import com.imop.lj.gameserver.player.msg.GCPlayerQueryAccount;
import com.imop.lj.gameserver.player.msg.GCWallowLoginNotice;
import com.imop.lj.gameserver.player.msg.GCGetSmsCheckcode;
import com.imop.lj.gameserver.player.msg.GCCheckSmsCheckcode;
import com.imop.lj.gameserver.player.msg.GCSmsCheckcodePanel;
import com.imop.lj.gameserver.player.msg.GCRelogin;
import com.imop.lj.gameserver.player.msg.GCUpdateToken;
import com.imop.lj.gameserver.player.msg.GCChargeRecord;
import com.imop.lj.gameserver.player.msg.GCChargeGenOrderid;
import com.imop.lj.gameserver.player.msg.GCLoginPopPanel;

public class RobotPlayerClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_ROLE_LIST, GCRoleList.class);
		msgs.put(MessageType.GC_ROLE_TEMPLATE, GCRoleTemplate.class);
		msgs.put(MessageType.GC_GAME_ENTER_PLAYER_NUM, GCGameEnterPlayerNum.class);
		msgs.put(MessageType.GC_ROLE_RANDOM_NAME, GCRoleRandomName.class);
		msgs.put(MessageType.GC_FAILED_MSG, GCFailedMsg.class);
		msgs.put(MessageType.GC_SCENE_INFO, GCSceneInfo.class);
		msgs.put(MessageType.GC_ENTER_SCENE, GCEnterScene.class);
		msgs.put(MessageType.GC_NOTIFY_EXCEPTION, GCNotifyException.class);
		msgs.put(MessageType.GC_POPUP_PANEL_END, GCPopupPanelEnd.class);
		msgs.put(MessageType.GC_PLAYER_CHARGE_DIAMOND, GCPlayerChargeDiamond.class);
		msgs.put(MessageType.GC_PLAYER_QUERY_ACCOUNT, GCPlayerQueryAccount.class);
		msgs.put(MessageType.GC_WALLOW_LOGIN_NOTICE, GCWallowLoginNotice.class);
		msgs.put(MessageType.GC_GET_SMS_CHECKCODE, GCGetSmsCheckcode.class);
		msgs.put(MessageType.GC_CHECK_SMS_CHECKCODE, GCCheckSmsCheckcode.class);
		msgs.put(MessageType.GC_SMS_CHECKCODE_PANEL, GCSmsCheckcodePanel.class);
		msgs.put(MessageType.GC_RELOGIN, GCRelogin.class);
		msgs.put(MessageType.GC_UPDATE_TOKEN, GCUpdateToken.class);
		msgs.put(MessageType.GC_CHARGE_RECORD, GCChargeRecord.class);
		msgs.put(MessageType.GC_CHARGE_GEN_ORDERID, GCChargeGenOrderid.class);
		msgs.put(MessageType.GC_LOGIN_POP_PANEL, GCLoginPopPanel.class);
		return msgs;
	}
}
