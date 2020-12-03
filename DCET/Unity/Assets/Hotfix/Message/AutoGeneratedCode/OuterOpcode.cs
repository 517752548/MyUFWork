namespace DCET
{
	[Message(OuterOpcode.C2M_TestRequest)]
	public partial class C2M_TestRequest : IActorLocationRequest
	{
	}
	[Message(OuterOpcode.M2C_TestResponse)]
	public partial class M2C_TestResponse : IActorLocationResponse
	{
	}
	[Message(OuterOpcode.Actor_TransferRequest)]
	public partial class Actor_TransferRequest : IActorLocationRequest
	{
	}
	[Message(OuterOpcode.Actor_TransferResponse)]
	public partial class Actor_TransferResponse : IActorLocationResponse
	{
	}
	[Message(OuterOpcode.C2G_EnterMap)]
	public partial class C2G_EnterMap : IRequest
	{
	}
	[Message(OuterOpcode.G2C_EnterMap)]
	public partial class G2C_EnterMap : IResponse
	{
	}
	[Message(OuterOpcode.M2C_CreateUnits)]
	public partial class M2C_CreateUnits : IActorMessage
	{
	}
	[Message(OuterOpcode.Frame_ClickMap)]
	public partial class Frame_ClickMap : IActorLocationMessage
	{
	}
	[Message(OuterOpcode.M2C_PathfindingResult)]
	public partial class M2C_PathfindingResult : IActorMessage
	{
	}
	[Message(OuterOpcode.C2R_Ping)]
	public partial class C2R_Ping : IRequest
	{
	}
	[Message(OuterOpcode.R2C_Ping)]
	public partial class R2C_Ping : IResponse
	{
	}
	[Message(OuterOpcode.G2C_Test)]
	public partial class G2C_Test : IMessage
	{
	}
	[Message(OuterOpcode.C2M_Reload)]
	public partial class C2M_Reload : IRequest
	{
	}
	[Message(OuterOpcode.M2C_Reload)]
	public partial class M2C_Reload : IResponse
	{
	}
	[Message(OuterOpcode.C2R_Login)]
	public partial class C2R_Login : IRequest
	{
	}
	[Message(OuterOpcode.R2C_Login)]
	public partial class R2C_Login : IResponse
	{
	}
	[Message(OuterOpcode.C2G_LoginGate)]
	public partial class C2G_LoginGate : IRequest
	{
	}
	[Message(OuterOpcode.G2C_LoginGate)]
	public partial class G2C_LoginGate : IResponse
	{
	}
	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	public partial class G2C_TestHotfixMessage : IMessage
	{
	}
	[Message(OuterOpcode.C2M_TestActorRequest)]
	public partial class C2M_TestActorRequest : IActorLocationRequest
	{
	}
	[Message(OuterOpcode.M2C_TestActorResponse)]
	public partial class M2C_TestActorResponse : IActorLocationResponse
	{
	}
	[Message(OuterOpcode.PlayerInfo)]
	public partial class PlayerInfo : IMessage
	{
	}
	[Message(OuterOpcode.C2G_PlayerInfo)]
	public partial class C2G_PlayerInfo : IRequest
	{
	}
	[Message(OuterOpcode.G2C_PlayerInfo)]
	public partial class G2C_PlayerInfo : IResponse
	{
	}
	public static partial class OuterOpcode
	{
		 public const ushort C2M_TestRequest = 10001;
		 public const ushort M2C_TestResponse = 10002;
		 public const ushort Actor_TransferRequest = 10003;
		 public const ushort Actor_TransferResponse = 10004;
		 public const ushort C2G_EnterMap = 10005;
		 public const ushort G2C_EnterMap = 10006;
		 public const ushort M2C_CreateUnits = 10007;
		 public const ushort Frame_ClickMap = 10008;
		 public const ushort M2C_PathfindingResult = 10009;
		 public const ushort C2R_Ping = 10010;
		 public const ushort R2C_Ping = 10011;
		 public const ushort G2C_Test = 10012;
		 public const ushort C2M_Reload = 10013;
		 public const ushort M2C_Reload = 10014;
		 public const ushort C2R_Login = 10015;
		 public const ushort R2C_Login = 10016;
		 public const ushort C2G_LoginGate = 10017;
		 public const ushort G2C_LoginGate = 10018;
		 public const ushort G2C_TestHotfixMessage = 10019;
		 public const ushort C2M_TestActorRequest = 10020;
		 public const ushort M2C_TestActorResponse = 10021;
		 public const ushort PlayerInfo = 10022;
		 public const ushort C2G_PlayerInfo = 10023;
		 public const ushort G2C_PlayerInfo = 10024;
	}
}
