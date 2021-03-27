using ETHotfix;

namespace ETModel
{
    [ObjectSystem]
    public class PlayerSystem: AwakeSystem<Player, string>
    {
        public override void Awake(Player self, string a)
        {
            self.Awake(a);
        }
    }

    public sealed class Player: Entity
    {
        public string Account { get; private set; }

        public long UnitId { get; set; }

        public Session GateSession;

        public void Awake(string account)
        {
            this.Account = account;
            SendMessage();
        }

        private async void SendMessage()
        {
            for (int i = 0; i < 100; i++)
            {
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(500);
                if (this.GateSession != null)
                {
                    GateSession.Send(new G2C_TestHotfixMessage() { Info = "recv hotfix message success" + i });
                }
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}