package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * Created by zhangzhe on 15/12/29.
 */
public class OvermanCmd implements IAdminCommand<ISession> {
    @Override
    public void execute(ISession playerSession, String[] commands) {
        if (!(playerSession instanceof GameClientSession)) {
            return;
        }
        Player player = ((GameClientSession) playerSession).getPlayer();
        Human human = player.getHuman();
        try {
            String ss = commands[0];
            //进入指定地图
            if (ss.equalsIgnoreCase("addoverman")) {
                Long overmanid = Long.parseLong(commands[1]);
                Player p = Globals.getOnlinePlayerService().getPlayer(overmanid);
                Globals.getOvermanService().createOverman(human,p.getHuman());
            }else if (ss.equalsIgnoreCase("addlowerman")){
                Long lowermanCharid=Long.parseLong(commands[1]);
                Player p = Globals.getOnlinePlayerService().getPlayer(lowermanCharid);
                Globals.getOvermanService().createOverman(human,p.getHuman());
            }else if(ss.equalsIgnoreCase("getovermanreward")){
                Long lowermanCharid=Long.parseLong(commands[1]);
                Globals.getOvermanService().getOvermanRewardList(human,lowermanCharid);
            }else if(ss.equalsIgnoreCase("getlowermanreward")) {
                Globals.getOvermanService().getLowermanRewardList(human);
            }else if(ss.equalsIgnoreCase("forceoverman")){
                Globals.getOvermanService().forceFireOverman(human);
            }else if(ss.equalsIgnoreCase("forcelowerman")){
                Long lowermanCharid=Long.parseLong(commands[1]);
                Globals.getOvermanService().forceFireLowerman(human,lowermanCharid);
            }else if(ss.equalsIgnoreCase("addovermanreward")){
                Long lowermanCharid=Long.parseLong(commands[1]);
                int rewardIndex=  Integer.parseInt(commands[2]);
                Globals.getOvermanService().addOvermanReward(human,lowermanCharid,rewardIndex);
            }else if(ss.equalsIgnoreCase("addlowermanreward")){
                int rewardIndex = Integer.parseInt(commands[1]);
                Globals.getOvermanService().addLowermanReward(human,rewardIndex);

            }

        } catch (Exception e) {
            e.printStackTrace();
            player.sendErrorMessage(e.getMessage());
        }
    }

    @Override
    public String getCommandName() {
        return CommandConstants.GM_CMD_OVERMAN;
    }
}
