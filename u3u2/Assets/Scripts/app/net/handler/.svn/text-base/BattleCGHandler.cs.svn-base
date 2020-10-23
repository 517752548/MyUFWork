
namespace app.net
{
    public class BattleCGHandler
    {
        public static void sendCGPlayBattleReport(
                long id,
                int toBackType)
        {
            CGPlayBattleReport msg = new CGPlayBattleReport(
                id,
                toBackType);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGPlayBattleReportByStrId(
                string idStr,
                int toBackType)
        {
            CGPlayBattleReportByStrId msg = new CGPlayBattleReportByStrId(
                idStr,
                toBackType);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleNextRound(
                int isAuto,
                int selSkillId,
                int selTarget,
                int selItemId,
                int petSelSkillId,
                int petSelTarget,
                int petSelItemId,
                long summonPetId)
        {
            CGBattleNextRound msg = new CGBattleNextRound(
                isAuto,
                selSkillId,
                selTarget,
                selItemId,
                petSelSkillId,
                petSelTarget,
                petSelItemId,
                summonPetId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleStartPvp(
                long targetPlayerId)
        {
            CGBattleStartPvp msg = new CGBattleStartPvp(
                targetPlayerId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattlePvpCancelAuto(
    )
        {
            CGBattlePvpCancelAuto msg = new CGBattlePvpCancelAuto(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleNextRoundPvp(
                int isAuto,
                int selSkillId,
                int selTarget,
                int selItemId,
                int petSelSkillId,
                int petSelTarget,
                int petSelItemId,
                long summonPetId)
        {
            CGBattleNextRoundPvp msg = new CGBattleNextRoundPvp(
                isAuto,
                selSkillId,
                selTarget,
                selItemId,
                petSelSkillId,
                petSelTarget,
                petSelItemId,
                summonPetId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleUpdateAutoAction(
                int petTypeId,
                int selSkillId)
        {
            CGBattleUpdateAutoAction msg = new CGBattleUpdateAutoAction(
                petTypeId,
                selSkillId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleTeamCancelAuto(
    )
        {
            CGBattleTeamCancelAuto msg = new CGBattleTeamCancelAuto(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleNextRoundTeam(
                int isAuto,
                int selSkillId,
                int selTarget,
                int selItemId,
                int petSelSkillId,
                int petSelTarget,
                int petSelItemId,
                long summonPetId)
        {
            CGBattleNextRoundTeam msg = new CGBattleNextRoundTeam(
                isAuto,
                selSkillId,
                selTarget,
                selItemId,
                petSelSkillId,
                petSelTarget,
                petSelItemId,
                summonPetId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleLeaderReadyPvp(
    )
        {
            CGBattleLeaderReadyPvp msg = new CGBattleLeaderReadyPvp(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleLeaderReadyTeam(
    )
        {
            CGBattleLeaderReadyTeam msg = new CGBattleLeaderReadyTeam(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleReadReportEnd(
    )
        {
            CGBattleReadReportEnd msg = new CGBattleReadReportEnd(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleStartTeampvp(
            long targetPlayerId)
        {
            CGBattleStartTeampvp msg = new CGBattleStartTeampvp(
                targetPlayerId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGBattleStartPvpConfirm(
            int agree,
            long sourcePlayerId)
        {
            CGBattleStartPvpConfirm msg = new CGBattleStartPvpConfirm(
                agree,
                sourcePlayerId);
            GameConnection.Instance.sendMessage(msg);
        }

		public static void sendCGBattleSpeedup(
				int speed)
		{
			CGBattleSpeedup msg = new CGBattleSpeedup(
				speed);
			GameConnection.Instance.sendMessage(msg);
		}

    }
}