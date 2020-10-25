
package com.imop.lj.gameserver.overman.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.overman.OvermanDef;
import com.imop.lj.gameserver.overman.msg.*;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.team.TeamDef;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

import java.text.MessageFormat;
import java.util.List;

/**
 * $message.comment
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class OvermanMessageHandler {

    public OvermanMessageHandler() {
    }


    public void handleOvermanInfo(Player player, CGOvermanInfo cgOvermanInfo) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        Globals.getOvermanService().sendCurOvermanMsg(human);
    }

    public void handleOverman(Player player, CGOverman cgOverman) {
        Human human = player.getHuman();
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }
        int canagree = cgOverman.getCanOverman();
        if (canagree == 0) {
            overmanhuman[0].sendErrorMessage(MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OVERMAN_LOWERNAM_NOT_APPLY_OVERMAN), overmanhuman[1].getName()));
        } else {
            Globals.getOvermanService().createOverman(overmanhuman[0], overmanhuman[1]);
        }

    }

    public void handleForceFireOverman(Player player, CGForceFireOverman cgForceFireOverman) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        OvermanDef.OVERMANTYPE humanovermantype = Globals.getOvermanService().getOvermanType(human.getCharId());
        if (humanovermantype == OvermanDef.OVERMANTYPE.OVERMAN) {
            long lowermanCharId = cgForceFireOverman.getCharId();
            Globals.getOvermanService().forceFireLowerman(human, lowermanCharId); //由师傅强制接触徒弟的关系
        } else if (humanovermantype == OvermanDef.OVERMANTYPE.LOWERMAN) {
            Globals.getOvermanService().forceFireOverman(human); //由徒弟强制解除师傅的关系
        }
    }

    /**
     * 出师
     *
     * @param player
     * @param cgFireOverman
     */
    public void handleFireOverman(Player player, CGFireOverman cgFireOverman) {
        Human human = player.getHuman();
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }

        Globals.getOvermanService().fireOverman(overmanhuman[0], overmanhuman[1]);
    }

    public void handleGetOvermanReward(Player player, CGGetOvermanReward cgGetOvermanReward) {
        long lowermanCharId = cgGetOvermanReward.getLowermanCharId();
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        if (!Globals.getOvermanService().isNormalOverman(human.getCharId())) {
            return;
        }
        Globals.getOvermanService().sendCurOvermanReward(human, lowermanCharId);

    }

    public void handleGetLowermanReward(Player player, CGGetLowermanReward cgGetLowermanReward) {
        Human lowermanHuman = player.getHuman();
        if (lowermanHuman == null) {
            return;
        }
        if (!Globals.getOvermanService().isNormalLowerman(lowermanHuman.getCharId())) {
            return;
        }
        Globals.getOvermanService().sendCurLowermanReward(lowermanHuman);

    }

    public void handleAddOvermanReward(Player player, CGAddOvermanReward cgAddOvermanReward) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        int rewardIndex = cgAddOvermanReward.getRewardId();
        long lowermanCharId = cgAddOvermanReward.getLowermanCharId();
        Globals.getOvermanService().addOvermanReward(human, lowermanCharId, rewardIndex);
        Globals.getOvermanService().sendCurOvermanReward(human, lowermanCharId);
    }

    public void handleAddLowermanReward(Player player, CGAddLowermanReward cgAddLowermanReward) {
        Human human = player.getHuman();
        if (human == null) {
            return;
        }
        int rewardIndex = cgAddLowermanReward.getRewardId();
        Globals.getOvermanService().addLowermanReward(human, rewardIndex);
        Globals.getOvermanService().sendCurLowermanReward(human);

    }

    public void handleFirstOverman(Player player, CGFirstOverman cgFirstOverman) {
        Human human = player.getHuman();
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }
        overmanhuman[1].sendMessage(new GCFirstOverman());
    }

    public void handleFirstFireOverman(Player player, CGFirstFireOverman cgFirstFireOverman) {
        Human human = player.getHuman();
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }
        overmanhuman[1].sendMessage(new GCFirstFireOverman());
    }

    public void handleFirstTeamFireOverman(Player player, CGFirstTeamFireOverman cgFirstTeamFireOverman) {
        Human human = player.getHuman();
        Team team = Globals.getTeamService().getHumanTeam(player.getHuman().getCharId());
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }
        overmanhuman[0].sendMessage(new GCFirstTeamFireOverman());
        overmanhuman[1].sendMessage(new GCFirstTeamFireOverman());
        Globals.getOvermanService().addFireOvermanTeamInfo(team.getId(), overmanhuman[0].getCharId(), overmanhuman[1].getCharId()); //加入临时表中
    }

    public void handleTeamFireOverman(Player player, CGTeamFireOverman cgTeamFireOverman) {
        Human human = player.getHuman();
        Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
        Human[] overmanhuman = new Human[2];
        if (!getOverman(overmanhuman, human)) {
            return;
        }
        int canagree = cgTeamFireOverman.getCanOverman(); //是否同意
        if (human.getCharId() == overmanhuman[0].getCharId()) {
            Globals.getOvermanService().TeamFireOverman(team.getId(), overmanhuman[0], overmanhuman[1], canagree, -1);
        } else {
            Globals.getOvermanService().TeamFireOverman(team.getId(), overmanhuman[0], overmanhuman[1], -1, canagree);
        }
    }

    /**
     * 0 是师傅,1是徒弟
     *
     * @param tovermanhuman
     * @param human
     */
    private boolean getOverman(Human[] tovermanhuman, Human human) {

        Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
        if (team == null) {
            human.sendErrorMessage(LangConstants.OVERMAN_NOT_TEAM);
            return false;
        }
        int teamcount = Globals.getTeamService().getMemberNumOfNormal(team.getId());
        if (teamcount != 2) {
            human.sendErrorMessage(LangConstants.OVERMAN_NOT_TEAM);
            return false;
        }

        long lowermanCharId = 0l;
        long humanCharId = 0l;
        List<TeamMember> memberList = team.getMemberList();
        for (int i = 0; i < memberList.size(); i++) {
            if (memberList.get(i).getType() == TeamDef.MemberType.MEMBER) {
                lowermanCharId = memberList.get(i).getRoleId();
            } else {
                humanCharId = memberList.get(i).getRoleId();
            }
        }
        Player lowermanPlayer = Globals.getOnlinePlayerService().getPlayer(lowermanCharId);
        if (lowermanPlayer == null) {
            return false;
        }
        Human lowermanHuman = lowermanPlayer.getHuman();
        if (lowermanHuman == null) {
            return false;
        }
        Player overmanPlayer = Globals.getOnlinePlayerService().getPlayer(humanCharId);
        if (overmanPlayer == null) {
            return false;
        }
        Human overmanHuman = overmanPlayer.getHuman();
        tovermanhuman[0] = overmanHuman;
        tovermanhuman[1] = lowermanHuman;
        return true;
    }

}
