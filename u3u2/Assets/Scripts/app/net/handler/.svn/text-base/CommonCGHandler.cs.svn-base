
namespace app.net
{
    public class CommonCGHandler
    {
        public static void sendCGSetConsumeConfirm(
                ConsumeConfirmData[] consumeConfirmInfoList)
        {
            CGSetConsumeConfirm msg = new CGSetConsumeConfirm(
                consumeConfirmInfoList);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGSelectOption(
                string tag,
                int isSelected,
                int seletctedValue)
        {
            CGSelectOption msg = new CGSelectOption(
                tag,
                isSelected,
                seletctedValue);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGPing(
    )
        {
            CGPing msg = new CGPing(
    );
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGClickNoticeTipsInfo(
                string tag,
                string value)
        {
            CGClickNoticeTipsInfo msg = new CGClickNoticeTipsInfo(
                tag,
                value);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGSendNoticeTips(
                string content,
                long roleId)
        {
            CGSendNoticeTips msg = new CGSendNoticeTips(
                content,
                roleId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGOfflineUserBaseInfo(
                long roleId)
        {
            CGOfflineUserBaseInfo msg = new CGOfflineUserBaseInfo(
                roleId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGOfflineUserLeaderInfo(
                long roleId)
        {
            CGOfflineUserLeaderInfo msg = new CGOfflineUserLeaderInfo(
                roleId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGOfflineUserPetInfo(
                long roleId,
                long petId)
        {
            CGOfflineUserPetInfo msg = new CGOfflineUserPetInfo(
                roleId,
                petId);
            GameConnection.Instance.sendMessage(msg);
        }

    }
}