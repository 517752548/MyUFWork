/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCETRuntime
{
	public partial class FUILoading : GComponent
	{
		public GImage bg;
		public GTextField loadingText;
		public FUILoadingProgressBar loadingBar;

		public const string URL = "ui://1n4czledsfv94";

		public static FUILoading CreateInstance()
		{
			return (FUILoading)UIPackage.CreateObject("Runtime","Loading");
		}

		public FUILoading()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GImage)this.GetChild("bg");
			loadingText = (GTextField)this.GetChild("loadingText");
			loadingBar = (FUILoadingProgressBar)this.GetChild("loadingBar");
		}
	}
}