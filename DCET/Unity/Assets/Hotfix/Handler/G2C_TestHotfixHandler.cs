using System.Threading.Tasks;

namespace DCET
{
	[MessageHandler]
	public class G2C_TestHotfixMessageHandler : AMHandler<G2C_TestHotfixMessage>
	{
		protected override async Task Run(Session session, G2C_TestHotfixMessage message)
		{
			Log.Debug(message.Info);
			await Task.CompletedTask;
		}
	}
}