
package com.imop.lj.gameserver.marry.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.marry.msg.*;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

import java.util.List;

/**
 * $message.comment
 *
 * @author CodeGenerator, don't modify this file please.
 */

public class MarryMessageHandler {

    public MarryMessageHandler() {
    }

    private boolean checkRoleAndFunc(Player player) {
        if (player == null) {
            return false;
        }
        if (player.getHuman() == null) {
            return false;
        }
        if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.THE_SWEENEY)) {
            Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.THE_SWEENEY);
            return false;
        }
        return true;
    }

    /**
     * 组队 结婚
     * @param player
     * @param cgMarry
     */
    public void handleMarry(Player player, CGMarry cgMarry) {
        if (!checkRoleAndFunc(player)) {
            return;
        }
        Human human = player.getHuman();
        Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
        Human[] marrys = new Human[2];
        if(!getMarryTeam(marrys,human)){
            return ;
        }
        int canagree = cgMarry.getCanMarry();
        if(human.getCharId() == marrys[0].getCharId()){
            Globals.getMarryService().wangMarry(team.getId(),marrys[0],marrys[1],canagree,-1);
        }else{
            Globals.getMarryService().wangMarry(team.getId(),marrys[0],marrys[1],-1,canagree);
        }

    }

    /**
     * 组队 解除婚姻
     * CodeGenerator
     */
    public void handleFireMarry(Player player, CGFireMarry cgFireMarry) {
        if (!checkRoleAndFunc(player)) {
            return;
        }
        Human human = player.getHuman();
        Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
        Human[] marrys = new Human[2];
        if(!getMarryTeam(marrys,human)){
            return ;
        }
        int canagree = cgFireMarry.getCanFire();
        if(human.getCharId() == marrys[0].getCharId()){
            Globals.getMarryService().teamFireMarry(team.getId(),marrys[0],marrys[1],canagree,-1);
        }else{
            Globals.getMarryService().teamFireMarry(team.getId(),marrys[0],marrys[1],-1,canagree);
        }
    }

    /**
     * 单方强制解除婚姻
     * @param player
     * @param cgForceFireMarry
     */
    public void handleForceFireMarry(Player player, CGForceFireMarry cgForceFireMarry) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        Globals.getMarryService().froceFireMarry(human);
    }

    public void handleFirstFireMarry(Player player, CGFirstFireMarry cgFirstFireMarry) {
        if (!checkRoleAndFunc(player)) {
            return;
        }
        Human human = player.getHuman();
        Team team = Globals.getTeamService().getHumanTeam(human.getDbId());
        Human[] marrys = new Human[2];
        if(!getMarryTeam(marrys,human)){
            return ;
        }
        marrys[0].sendMessage(new GCFirstFireMarry());
        marrys[1].sendMessage(new GCFirstFireMarry());
        Globals.getMarryService().addFirstMarry(team.getId(),marrys[0].getDbId(),marrys[1].getDbId());
    }

    public void handleFirstMarry(Player player, CGFirstMarry cgFirstMarry) {
        Human human = player.getHuman();
        if(human==null){
            return ;
        }
        Team team = Globals.getTeamService().getHumanTeam(human.getDbId());
        Human[] marrys = new Human[2];
        if(!getMarryTeam(marrys,human)){
            return ;
        }
        marrys[0].sendMessage(new GCFirstMarry());
        marrys[1].sendMessage(new GCFirstMarry());
        Globals.getMarryService().addFirstMarry(team.getId(),marrys[0].getDbId(),marrys[1].getDbId());
    }

    public void handleMarryInfo(Player player, CGMarryInfo cgMarryInfo) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        Globals.getMarryService().sendCurMarryInfo(human);
    }

    /**
     * 1 是丈夫,2是妻子
     *
     * @param tovermanhuman
     * @param human
     */
    private boolean getMarryTeam(Human[] tovermanhuman, Human human) {

        Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
        if (team == null) {
            human.sendErrorMessage(LangConstants.MARRY_BEFORE_SET_UP_TEAM);
            return false;
        }
        int teamcount = Globals.getTeamService().getMemberNumOfNormal(team.getId());
        if (teamcount != 2) {
            human.sendErrorMessage(LangConstants.MARRY_BEFORE_SET_UP_TEAM);
            return false;
        }
        List<TeamMember> memberList = team.getMemberList();
        for (int i = 0; i < memberList.size(); i++) {
            long tcharid = memberList.get(i).getRoleId();
            if (Globals.getOnlinePlayerService().getPlayer(tcharid) == null) {
            	human.sendErrorMessage(LangConstants.MARRY_BEFORE_SET_UP_TEAM);
            	return false;
            }
            Human h = Globals.getOnlinePlayerService().getPlayer(tcharid).getHuman();
            if (h.getSex() == PetDef.Sex.FEMALE) {
                tovermanhuman[1] = h;
            } else {
                tovermanhuman[0] = h;
            }
        }
        if(tovermanhuman[0] == null ||tovermanhuman[1]==null){
            human.sendErrorMessage(LangConstants.MARRY_BEFORE_SET_UP_TEAM);
            return false;
        }
        return true;
    }
}
