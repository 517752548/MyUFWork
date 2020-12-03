using DCETRuntime;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace DCET
{
	[ObjectSystem]
	public class UnityWebRequestUpdateSystem : UpdateSystem<UnityWebRequestAsync>
	{
		public override void Update(UnityWebRequestAsync self)
		{
			self.Update();
		}
	}
	
	public class UnityWebRequestAsync : Entity
	{
		public static AcceptAllCertificate certificateHandler = new AcceptAllCertificate();
		
		public UnityWebRequest Request;

		public bool isCancel;

		public TaskCompletionSource<bool> tcs;
		
		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

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
				tcs.SetException(new Exception($"request error: {Request.error}"));
				return;
			}
			
			if (!Request.isDone)
			{
				return;
			}
			if (!string.IsNullOrEmpty(Request.error))
			{
				tcs.SetException(new Exception($"request error: {Request.error}"));
				return;
			}

			tcs.SetResult(true);
		}

		public Task DownloadAsync(string url)
		{
			tcs = new TaskCompletionSource<bool>();
			
			url = url.Replace(" ", "%20");
			Request = UnityWebRequest.Get(url);
			Request.certificateHandler = certificateHandler;
			Request.SendWebRequest();
			
			return tcs.Task;
		}
	}
}
