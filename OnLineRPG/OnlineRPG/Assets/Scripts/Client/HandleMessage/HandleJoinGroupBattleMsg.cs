using BetaFramework;

public class HandleJoinGroupBattleMsg : IPacketHandler
{
    public short OpCode { get; set; }

    public void Handle(IIncommingMessage message)
    {
        var data = message.Deserialize<RepJoinGroupBattlePacket>();

        if (data.code == (int)RepCodes.SUCCESSED)
        {

        }
        else
        {

        }

    }
}
