package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.title.handler.TitleHandlerFactory;

import java.util.Arrays;

/**
 * 获得物品gm命令
 *
 * @author yuanbo.gao
 */
public class GiveTitleCmd implements IAdminCommand<ISession> {

    @Override
    public void execute(ISession playerSession, String[] commands) {
        if (!(playerSession instanceof GameClientSession)) {
            return;
        }
        Player player = ((GameClientSession) playerSession).getPlayer();
        Human human = player.getHuman();
        long charid = human.getCharId();
        System.out.println(Arrays.toString(commands));
        try {


            int activeid = Integer.parseInt(commands[0]);
            if (activeid == 1) {
                TitleHandlerFactory.getHandler().handleTitlePanel(player, null);
            } else if (activeid == 2) {
                if (commands.length < 2) {
                    return;
                }
                int templateid = Integer.parseInt(commands[1]);
                Globals.getTitleService().addTitleInfo(charid, templateid);
            }


        } catch (Exception e) {
            human.sendSystemMessage("错误的命令！");
            e.printStackTrace();
        }
    }

    @Override
    public String getCommandName() {
        return CommandConstants.GM_CMD_GIVE_TITLE;
    }

}
