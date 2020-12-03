using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace DCETRuntime
{
	public class AcceptAllCertificate : CertificateHandler
	{
		protected override bool ValidateCertificate(byte[] certificateData)
		{
			return true;
		}
	}

	public class UnityWebRequestAsync : IDisposable
	{
		public static AcceptAllCertificate certificateHandler = new AcceptAllCertificate();		
		public UnityWebRequest Request;
		public bool isCancel;
		public TaskCompletionSource<string> tcs;
		public int timeout = 5;

		public void Dispose()
		{
			GameLoop.onUpdate -= Update;
			Request?.Dispose();
			Request = null;
			isCancel = false;
		}

		public float Progress
		{
			get
			{
				if (Request == null)
				{
					return 0;
				}
				return Request.downloadProgress;
			}
		}

		public ulong ByteDownloaded
		{
			get
			{
				if (Request == null)
				{
					return 0;
				}
				return Request.downloadedBytes;
			}
		}

		public void Update()
		{
			if (isCancel)
			{
				tcs.SetResult($"request error: {Request.error}");
				return;
			}
			
			if (!Request.isDone)
			{
				return;
			}
			if (!string.IsNullOrEmpty(Request.error))
			{
				tcs.SetResult($"request error: {Request.error}");
				return;
			}

			tcs.SetResult(string.Empty);
		}

		public Task<string> DownloadAsync(string url)
		{
			tcs = new TaskCompletionSource<string>();
			
			url = url.Replace(" ", "%20");
			Request = UnityWebRequest.Get(url);
			Request.timeout = timeout;
			Request.certificateHandler = certificateHandler;
			Request.SendWebRequest();

			GameLoop.onUpdate -= Update;
			GameLoop.onUpdate += Update;

			return tcs.Task;
		}
	}
}
