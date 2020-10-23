using UnityEngine;
using System.Collections;

public class PlatForm {

	private static PlatForm _ins;

	private IPlat plat ;

	public static PlatForm Instance
	{
		get {
			if (_ins == null)
			{
				_ins = new PlatForm();
			}
			return _ins;
		}
	}

	public PlatForm()
	{
	    #if UNITY_ANDROID
        ClientLog.LogWarning("UNITY_ANDROID=true");
		plat = new AndroidPlat();
        #elif UNITY_IPHONE
        ClientLog.LogWarning("UNITY_IPHONE=true");
		plat = new IOSPlat();
#endif
    }

	public void StartChat()
	{
		plat.PlatStartChat();
	}

	public void StopChat()
	{
		plat.PlatStopChat ();
	}
	
	public void CancelChat()
	{
		plat.PlatCancelChat ();
	}

	public void PlayChat(string filename)
	{
		plat.PlatPlayChat(filename);
	}
	
	public int LoadSound(string soundName)
	{
		return plat.LoadSound(soundName);
	}
	
	public void PlaySound(int soundId)
	{
		plat.PlaySound(soundId);
	}

    public string GetAppID()
    {
        return plat.GetAppID();
    }

    public void SetRecUploadURL(string url)
    {
        plat.SetRecUploadURL(url);
    }
}