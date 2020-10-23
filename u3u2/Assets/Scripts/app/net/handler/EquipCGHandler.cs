
namespace app.net
{
    public class EquipCGHandler
    {
        public static void sendCGEqpCraft(
                int costTplId,
                int gradeId,
                int[] itemNumList,
                int isSimulate)
        {
            CGEqpCraft msg = new CGEqpCraft(
                costTplId,
                gradeId,
                itemNumList,
                isSimulate);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpUpstar(
                int equipPosition,
                int useExtraItem)
        {
            CGEqpUpstar msg = new CGEqpUpstar(
                equipPosition,
                useExtraItem);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpGemTakedown(
                string equipUuid,
                int holeNum,
                int extraItemId)
        {
            CGEqpGemTakedown msg = new CGEqpGemTakedown(
                equipUuid,
                holeNum,
                extraItemId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpGemSet(
                string equipUuid,
                int holeNum,
                int gemItemId,
                int extraItemId)
        {
            CGEqpGemSet msg = new CGEqpGemSet(
                equipUuid,
                holeNum,
                gemItemId,
                extraItemId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpGemSynthesis(
                int gemTplId,
                int synthesisBase,
                int synthesisType)
        {
            CGEqpGemSynthesis msg = new CGEqpGemSynthesis(
                gemTplId,
                synthesisBase,
                synthesisType);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpRecast(
                string equipUuid,
                int[] EquipRecastInfo)
        {
            CGEqpRecast msg = new CGEqpRecast(
                equipUuid,
                EquipRecastInfo);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpDecompose(
                string[] equipList)
        {
            CGEqpDecompose msg = new CGEqpDecompose(
                equipList);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGEqpHole(
                string equipUUId,
                int holeNum,
                int holeItemId,
                int isRefresh)
        {
            CGEqpHole msg = new CGEqpHole(
                equipUUId,
                holeNum,
                holeItemId,
                isRefresh);
            GameConnection.Instance.sendMessage(msg);
        }

    }
}