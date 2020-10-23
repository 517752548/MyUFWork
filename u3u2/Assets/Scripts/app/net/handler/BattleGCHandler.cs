using UnityEngine;
using app.human;
using app.state;
using app.battle;
using app.zone;
using app.utils;
using System.Collections;
using minijson;
using app.confirm;

namespace app.net
{
    public class BattleGCHandler : IGCHandler
    {
        public const string GCPlayBattleReportEvent = "GCPlayBattleReportEvent";
        public const string GCBattleReportPartEvent = "GCBattleReportPartEvent";
        public const string GCBattleForceEndEvent = "GCBattleForceEndEvent";
        public const string GCBattleReportPvpEvent = "GCBattleReportPvpEvent";
        public const string GCBattleReportTeamEvent = "GCBattleReportTeamEvent";
        public const string GCBattleReadyChangedPvpEvent = "GCBattleReadyChangedPvpEvent";
        public const string GCBattleReadyChangedTeamEvent = "GCBattleReadyChangedTeamEvent";
        public const string GCBattleEndEvent = "GCBattleEndEvent";
        public const string GCBattleStartPvpInviteEvent = "GCBattleStartPvpInviteEvent";
		public const string GCBattleSpeedupEvent = "GCBattleSpeedupEvent";

        public const string BATTLE_TYPE = "battleType";

        public BattleGCHandler()
        {
            EventCore.addRMetaEventListener(GCPlayBattleReportEvent, GCPlayBattleReportHandler);
            EventCore.addRMetaEventListener(GCBattleReportPartEvent, GCBattleReportPartHandler);
            EventCore.addRMetaEventListener(GCBattleForceEndEvent, GCBattleForceEndHandler);
            EventCore.addRMetaEventListener(GCBattleReportPvpEvent, GCBattleReportPvpHandler);
            EventCore.addRMetaEventListener(GCBattleReportTeamEvent, GCBattleReportTeamHandler);
            EventCore.addRMetaEventListener(GCBattleReadyChangedPvpEvent, GCBattleReadyChangedPvpHandler);
            EventCore.addRMetaEventListener(GCBattleReadyChangedTeamEvent, GCBattleReadyChangedTeamHandler);
            EventCore.addRMetaEventListener(GCBattleEndEvent, GCBattleEndHandler);
            EventCore.addRMetaEventListener(GCBattleStartPvpInviteEvent, GCBattleStartPvpInviteHandler);
			EventCore.addRMetaEventListener(GCBattleSpeedupEvent, GCBattleSpeedupHandler);
        }

        private void GCPlayBattleReportHandler(RMetaEvent e)
        {
            GCPlayBattleReport msg = e.data as GCPlayBattleReport;
            if (string.IsNullOrEmpty(msg.getReportPack()))
            {
                ClientLog.Log("battle report bag is empty");
                return;
            }
            ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  收到所有回合的战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            BattleModel.ins.battleType = BattleType.PLAY_BATTLE_REPORT;
            BattleModel.ins.selfSiteType = BatCharacterSiteType.NONE;
            BattleManager.ins.ParseWholeBattleReportData(msg.getReportPack());
            BattleModel.ins.battleToBackType = msg.getToBackType();
            if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            {
                StateManager.Ins.changeState(StateDef.battleState);
            }
        }

        private void GCBattleReportPartHandler(RMetaEvent e)
        {
            GCBattleReportPart msg = e.data as GCBattleReportPart;
            if (msg.getPlayType() == 0)
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  开始  PVE  战斗  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }
            else
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  PVE  每轮战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }
            BattleModel.ins.battleType = BattleType.PVE;
            BattleModel.ins.selfSiteType = BatCharacterSiteType.ATTACKER;
            BattleManager.ins.ParseRoundData(msg.getReportPack());

            if (!string.IsNullOrEmpty((msg.getAdditionPack())))
            {
                IDictionary data = (IDictionary)(Json.Deserialize(msg.getAdditionPack()));
                BattleModel.ins.battleToBackType = JsonHelper.GetIntData(BATTLE_TYPE, data);
            }

            //BattleManager.ins.ParseBattleRewardData(msg.getAdditionPack());
            if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            {
                StateManager.Ins.changeState(StateDef.battleState);
            }
        }

        private void GCBattleForceEndHandler(RMetaEvent e)
        {
            GCBattleForceEnd msg = e.data as GCBattleForceEnd;

            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                BattleManager.ins.BattleFinish(true);
            }
        }

        private void GCBattleReportPvpHandler(RMetaEvent e)
        {
            GCBattleReportPvp msg = e.data as GCBattleReportPvp;

            if (msg.getPlayType() == 0)
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  开始  PVP  战斗  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }
            else
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  PVP  每轮战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }

            BattleModel.ins.battleType = BattleType.PVP;
            BatRoundData roundData = BattleManager.ins.ParseRoundData(msg.getReportPack());
            roundData.pvpAtkerId = msg.getAttackerId();
            roundData.pvpDeferId = msg.getDefenderId();
            roundData.pvpRoundCreateServerTime = msg.getRoundStartTime();
            roundData.pvpRoundBroadcastServerTime = msg.getCurTime();
            roundData.pvpRoundCreateClientTime = Time.unscaledTime - (roundData.pvpRoundBroadcastServerTime - roundData.pvpRoundCreateServerTime) / 1000.0f;
            roundData.pvpRoundFinishClientTime = 0;
            roundData.pvpRoundIsAutoBattle = (msg.getLastAutoFlag() > 0);

            /*
            if (roundData.pvpRoundIsAutoBattle)
            {
                BattleModel.ins.battleSubType = BattleSubType.AUTO;
            }
            else
            {
                BattleModel.ins.battleSubType = BattleSubType.MANUAL;
            }
            */
            if (Human.Instance.Id == roundData.pvpAtkerId)
            {
                //roundData.pvpSiteType = BatCharacterSiteType.ATTACKER;
                BattleModel.ins.selfSiteType = BatCharacterSiteType.ATTACKER;
            }
            else if (Human.Instance.Id == roundData.pvpDeferId)
            {
                //roundData.pvpSiteType = BatCharacterSiteType.DEFENDER;
                BattleModel.ins.selfSiteType = BatCharacterSiteType.DEFENDER;
            }
            else
            {
                //roundData.pvpSiteType = BatCharacterSiteType.NONE;
                BattleModel.ins.selfSiteType = BatCharacterSiteType.NONE;
            }

            //BattleModel.ins.selfSiteType = roundData.pvpSiteType;

            if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            {
                StateManager.Ins.changeState(StateDef.battleState);
            }
        }

        private void GCBattleReportTeamHandler(RMetaEvent e)
        {
            GCBattleReportTeam msg = e.data as GCBattleReportTeam;

            if (msg.getPlayType() == 0)
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  开始  TEAM_PVE或TEAM_PVP  战斗  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }
            else
            {
                ClientLog.Log("&&&&&&&&&&&&&&&&&&&&  TEAM_PVE或TEAM_PVP  每轮战报  &&&&&&&&&&&&&&&&&&&&&&&&&");
            }
            

            BatRoundData roundData = BattleManager.ins.ParseRoundData(msg.getReportPack());
            roundData.teamRoundCreateServerTime = msg.getRoundStartTime();
            roundData.teamRoundBroadcastServerTime = msg.getCurTime();
            roundData.teamRoundCreateClientTime = Time.unscaledTime - (roundData.pvpRoundBroadcastServerTime - roundData.pvpRoundCreateServerTime) / 1000.0f;
            roundData.teamRoundFinishClientTime = 0;
            roundData.teamRoundIsAutoBattle = (msg.getLastAutoFlag() > 0);
            if (!string.IsNullOrEmpty((msg.getAdditionPack())))
            {
                IDictionary data = (IDictionary)(Json.Deserialize(msg.getAdditionPack()));
                BattleModel.ins.battleToBackType = JsonHelper.GetIntData(BATTLE_TYPE, data);
            }
            BattleModel.ins.selfSiteType = (BatCharacterSiteType)msg.getIsAttacker();

            if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER && roundData.defenderStatus[0].uuidL == 0)
            {
                BattleModel.ins.battleType = BattleType.TEAM_PVE;
            }
            else
            {
                BattleModel.ins.battleType = BattleType.TEAM_PVP;
            }
            
            if (StateManager.Ins.getCurState().state != StateDef.battleState && ZoneModel.ins.isZoneLoaded)
            {
                StateManager.Ins.changeState(StateDef.battleState);
            }
        }

        private void GCBattleReadyChangedPvpHandler(RMetaEvent e)
        {
            GCBattleReadyChangedPvp msg = e.data as GCBattleReadyChangedPvp;
            long leaderUUID = msg.getLeaderPetUUId();
            long petUUID = msg.getPetPetUUId();

            if (PropertyUtil.IsLegalID(leaderUUID))
            {
                BatCharacter leader = BattleCharacterManager.ins.GetCharacter(leaderUUID);
                if (leader != null)
                {
                    leader.SetPrepareSignActive(false);
                }
                else
                {
                    BattleModel.ins.charactersNeedHidePrepareSign.Add(leaderUUID);
                }
            }
            if (PropertyUtil.IsLegalID(petUUID))
            {
                BatCharacter pet = BattleCharacterManager.ins.GetCharacter(petUUID);
                if (pet != null)
                {
                    pet.SetPrepareSignActive(false);
                }
                else
                {
                    BattleModel.ins.charactersNeedHidePrepareSign.Add(petUUID);
                }
            }
        }

        private void GCBattleReadyChangedTeamHandler(RMetaEvent e)
        {
            GCBattleReadyChangedTeam msg = e.data as GCBattleReadyChangedTeam;
            long leaderUUID = msg.getLeaderPetUUId();
            long petUUID = msg.getPetPetUUId();

            if (PropertyUtil.IsLegalID(leaderUUID))
            {
                BatCharacter leader = BattleCharacterManager.ins.GetCharacter(leaderUUID);
                if (leader != null) 
                {
                    leader.SetPrepareSignActive(false);
                }
                else
                {
                    BattleModel.ins.charactersNeedHidePrepareSign.Add(leaderUUID);
                }
            }
            if (PropertyUtil.IsLegalID(petUUID))
            {
                BatCharacter pet = BattleCharacterManager.ins.GetCharacter(petUUID); 
                if (pet != null)
                {
                    pet.SetPrepareSignActive(false);
                }
                else
                {
                    BattleModel.ins.charactersNeedHidePrepareSign.Add(petUUID);
                }
            }
        }

        private void GCBattleEndHandler(RMetaEvent e)
        {
            GCBattleEnd msg = e.data as GCBattleEnd;
            //StateManager.Ins.changeState(StateDef.zoneState);

            BattleModel.ins.LinkToBackType();
        }

        private void GCBattleStartPvpInviteHandler(RMetaEvent e)
        {
            GCBattleStartPvpInvite msg = e.data as GCBattleStartPvpInvite;
            BattleModel.ins.pvptarget = msg;
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI,
                "玩家 " + msg.getSourcePlayerName() + " 向你发起pvp挑战，是否应战？", surepvp, cancelpvp);
        }

        private void surepvp(RMetaEvent e)
        {
            BattleCGHandler.sendCGBattleStartPvpConfirm(1,BattleModel.ins.pvptarget.getSourcePlayerId());
            BattleModel.ins.pvptarget = null;
        }

        private void cancelpvp(RMetaEvent e)
        {
            BattleCGHandler.sendCGBattleStartPvpConfirm(0, BattleModel.ins.pvptarget.getSourcePlayerId());
            BattleModel.ins.pvptarget = null;
        }

		private void GCBattleSpeedupHandler(RMetaEvent e)
        {
        	GCBattleSpeedup msg = e.data as GCBattleSpeedup;
            Human.Instance.PlayerModel.battlePlaySpeed = msg.getSpeed();
            Human.Instance.PlayerModel.canBattlePlayFastForward = msg.getCanSpeedup();
        }
    }
}