package com.imop.lj.gameserver.title.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.title.Title;
import com.imop.lj.gameserver.title.TitleInfo;
import com.imop.lj.gameserver.title.msg.CGDisTitle;
import com.imop.lj.gameserver.title.msg.CGTitlePanel;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.title.msg.CGUseTitle;
import com.imop.lj.gameserver.title.msg.GCTitlePanel;

import java.util.*;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TitleMessageHandler {	
	
	public TitleMessageHandler() {	
	}	
		/**
 	* 申请称号界面
 	* 
 	* CodeGenerator
 	*/
	public void handleTitlePanel(Player player, CGTitlePanel cgTitlePanel) {
        GCTitlePanel gc = new GCTitlePanel();
        Title t = Globals.getTitleService().getHumanTitleList(player.getHuman().getCharId());
        if(t==null){
        	player.sendErrorMessage(LangConstants.NO_TITLE);
            return ;
        }
        Collection<TitleInfo> titleList = t.getAllTitleInfo().values();
        TitleInfo[] array = new TitleInfo[titleList.size()];
        gc.setTitleList(titleList.toArray(array));
        player.sendMessage(gc);

	}
		/**
 	* 使用称号
 	* 
 	* CodeGenerator
 	*/
	public void handleUseTitle(Player player, CGUseTitle cgUserTitle) {
		Integer templateId = cgUserTitle.getTitleTemplateId();
        if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
            return;
		}
		Globals.getTitleService().useTitle(player.getHuman(),templateId);

	}


    public void handleDisTitle(Player player, CGDisTitle cgDisTitle) {
        if (player == null){
            return ;
        }
        Human human = player.getHuman();
        if(human==null){
            return ;
        }
        Globals.getTitleService().disTitle(human,cgDisTitle.getDistitle());
    }
}
