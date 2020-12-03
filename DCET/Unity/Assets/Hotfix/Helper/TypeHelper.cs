using System.Reflection;

namespace DCET
{
	public class TypeHelper
	{
		public static void Init()
		{
#if __CSharpLua__
			InitByLua();
#else
			InitByMono();
#endif
		}

#if __CSharpLua__
		private static void InitByLua()
		{
			/*
			[[
			for k,v in pairs(DCET) do
				if v.__metadata__ and v.__metadata__.class  then
					DCET.Game.getEventSystem():AddType(System.typeof(v))
				end
			end
			]]
			*/
		}
#else
		private static void InitByMono()
		{
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.Core);
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.Config);
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.FairyGUI);
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.Message);
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.BehaviorTree);
			Game.EventSystem.AddAssemblyType(DCETRuntime.MonoHelper.Hotfix);

			DCETRuntime.MongoHelper.LookupTypes(Game.EventSystem.GetAllType());
		}
#endif
	}
}