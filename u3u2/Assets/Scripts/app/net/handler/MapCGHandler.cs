
namespace app.net
{
    public class MapCGHandler
    {
        public static void sendCGMapPlayerEnter(
                int mapId)
        {
            CGMapPlayerEnter msg = new CGMapPlayerEnter(
                mapId);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGMapPlayerMove(
                int mapId,
                int x,
                int y,
                int fx,
                int fy)
        {
            CGMapPlayerMove msg = new CGMapPlayerMove(
                mapId,
                x,
                y,
                fx,
                fy);
            GameConnection.Instance.sendMessage(msg);
        }

        public static void sendCGMapFightNpc(
                int npcId,
                string uuid)
        {
            CGMapFightNpc msg = new CGMapFightNpc(
                npcId,
                uuid);
            GameConnection.Instance.sendMessage(msg);
        }

    }
}