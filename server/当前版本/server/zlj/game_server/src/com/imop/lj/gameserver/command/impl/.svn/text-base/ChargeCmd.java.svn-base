package com.imop.lj.gameserver.command.impl;

import java.sql.Timestamp;

import net.sf.json.JSONArray;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 充值测试GM命令
 * 
 */

public class ChargeCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			// 清除充值
			if (commands[0].equalsIgnoreCase("clear")) {
				human.setTotalCharge(0);
				human.setTodayCharge(0);
				human.setLastChargeTime(new Timestamp(0L));
				human.sendErrorMessage("clear ok!");
			} else if (commands[0].equalsIgnoreCase("qq")) {
				// qq充值测试
				int tplId = 2001;
				int tplNum = 2;
				
				String jsonStr = "[{\"openkey\":\"1D1F958ED1507294263DDFEAC76489DC\",\"itemNum\":\""+tplNum+"\",\"platform\":\"qzone\",\"pubacct_payamt_coins\":\"\",\"ts\":\"1404842794\",\"payitem\":\"1034_1_qzone_47_297804923406387180_"+tplId+"*10*"+tplNum+"\",\"zoneid\":\"0\",\"addition\":\"QQCOIN#14048427948054553123257341|8|1|1201|pay\",\"itemId\":\""+tplId+"\",\"version\":\"v3\",\"amt\":\"80\",\"pf\":\"qzone\",\"charid\":\"297804923406387180\",\"itemUnitPrice\":\"10\",\"providetype\":\"0\",\"token\":\"DF33237E945D2751789DC6A3B6C8502C18044\",\"openid\":\"5384057FA0386E601FA03362AAA8E20D\",\"payamt_coins\":\"0\",\"gameServerName\":\"1034\",\"billno\":\"-APPDJ30309-20140709-0206347993\"}]";
				JSONArray chargeOrderJsonArr = JSONArray.fromObject(jsonStr);
//				Globals.getQQService().chargeBondAfterRechargeCheck(human.getCharId(), chargeOrderJsonArr);
			} else {
				// 充值
				if (commands.length < 1) {
					human.sendErrorMessage("invalid params!");
					return;
				}
				int chargeNum = Integer.parseInt(commands[0]);
				Globals.getEventService().fireEvent(new PlayerChargeDiamondEvent(human, chargeNum, true));
				
				human.sendErrorMessage("charge ok!");
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CHARGE;
	}

}
