using System.Threading.Tasks;

namespace DCET
{
	public class FUIInitComponent : Entity
	{
        public async Task Init()
        {
            await Game.Scene.GetComponent<FUIPackageComponent>().AddPackageAsync(FUIPackage.Hotfix);
        }

        public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

			Game.Scene.GetComponent<FUIPackageComponent>()?.RemovePackage(FUIPackage.Hotfix);
        }
    }
}