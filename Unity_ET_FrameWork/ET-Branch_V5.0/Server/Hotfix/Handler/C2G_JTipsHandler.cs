using System;
using ETModel;

namespace ETHotfix
{
	// 用来测试消息包含复杂类型，是否产生gc
	[MessageHandler(AppType.Gate)]
	public class C2G_JTipsHandler : AMRpcHandler<C2R_JTips, R2C_JTips>
	{
		protected override async ETTask Run(Session session, C2R_JTips request, R2C_JTips response, Action reply)
		{
			response.Message = "shoudao";
			//DBProxyComponent db = Game.Scene.GetComponent<DBProxyComponent>();
			//await db.Save(ComponentFactory.CreateWithId<Entity>(1223));
			reply();
			await ETTask.CompletedTask;
		}
	}
}
