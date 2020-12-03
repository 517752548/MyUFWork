using DCETRuntime;
using System;

namespace DCET
{
	public static class LoginHelper
    {
        public static async void OnLoginAsync(string account)
        {
            try
            {
                Session session = Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
				
                R2C_Login r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = "111111" });

                session.Dispose();

                SessionComponent.Instance.Session = Game.Scene.GetComponent<NetOuterComponent>().Create(r2CLogin.Address);

                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await SessionComponent.Instance.Session.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

                Log.Info("登陆gate成功!");

                // 创建Player
                Player player = EntityFactory.CreateWithId<Player>(Game.Scene, g2CLoginGate.PlayerId);
                PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();
                playerComponent.MyPlayer = player;

                Game.EventSystem.Run(EventIdType.LoginFinish);

                // 测试消息有成员是class类型
                G2C_PlayerInfo g2CPlayerInfo = (G2C_PlayerInfo) await SessionComponent.Instance.Session.Call(new C2G_PlayerInfo());
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
        } 
    }
}