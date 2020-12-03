using FairyGUI;
using System;
using System.Threading.Tasks;

namespace DCETRuntime
{
	public class FUIDownloader : IDisposable
	{
		private FUILoading fuiLoading;
		private BundleDownloader bundleDownloader;

		public FUIDownloader()
		{
			fuiLoading = FUILoading.CreateInstance();
			GRoot.inst.AddChild(fuiLoading);
			fuiLoading.MakeFullScreen();

			bundleDownloader = new BundleDownloader();

			GameLoop.onUpdate += Update;
		}

		private void Update()
		{
			fuiLoading.loadingText.text = bundleDownloader.Progress.ToString() + "%";
		}

		public void Dispose()
		{
			GameLoop.onUpdate -= Update;
			fuiLoading.Dispose();
			fuiLoading = null;
			bundleDownloader.Dispose();
			bundleDownloader = null;
		}

		public async Task<bool> DownloadAsync()
		{
			var result = await bundleDownloader.StartAsync();

			if (result)
			{
				return await bundleDownloader.DownloadAsync();
			}

			return result;
		}
	}
}
