/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace DCETRuntime
{
	public class RuntimeBinder
	{
		public static void BindAll()
		{
			UIObjectFactory.SetPackageItemExtension(FUILoading.URL, typeof(FUILoading));
			UIObjectFactory.SetPackageItemExtension(FUILoadingProgressBar.URL, typeof(FUILoadingProgressBar));
		}
	}
}