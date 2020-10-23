using UnityEngine;

public class AndroidPlat :IPlat {
    
    #if !UNITY_EDITOR&&UNITY_ANDROID
    private AndroidJavaClass m_jc = null;
    private AndroidJavaObject m_jo = null;
    private AndroidJavaObject m_sound_jo = null;
    
    public AndroidJavaClass jc
    {
        get
        {
            if (m_jc == null)
            {
                m_jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            }
            return m_jc;
        }
    }
    
    public AndroidJavaObject jo
    {
        get
        {
            if (m_jo == null)
            {
                m_jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return m_jo;
        }
    }
    
    public AndroidJavaObject soundJo
    {
        get
        {
            if (m_sound_jo == null)
            {
                m_sound_jo = new AndroidJavaObject( "com.u3u2.main.AudioCenter", 5, jo);
            }
            return m_sound_jo;
        }
    }
    
    #endif

	public void PlatStartChat()
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID  
        {
            //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		    //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		    jo.Call("StartListener");
        }
        #endif
	}

	public void PlatStopChat(){
       #if !UNITY_EDITOR&&UNITY_ANDROID  
        {
		    //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		    //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		    jo.Call("StopListener");
        }
        #endif
	}
    
    public void PlatCancelChat(){
       #if !UNITY_EDITOR&&UNITY_ANDROID  
        {
		    //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		    //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		    jo.Call("cancelListening");
        }
        #endif
	}

	public void PlatPlayChat(string filename)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID  
            {
		        //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                if (jc == null)
                {
                    ClientLog.LogError("AndroidPlat:PlatPlayChat jc is null!");
                    return;
                }
		        //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
                if (jo == null)
                {
                    ClientLog.LogError("AndroidPlat:PlatPlayChat jo is null!");
                    return;
                }
		        jo.Call("PlaySound",filename);
            }
        #endif
    }
    
    public int LoadSound(string soundName)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID
        return soundJo.Call<int>( "loadSound", new object[] { soundName } );
        #else
        return 0;
        #endif
    }
    
    public void PlaySound(int soundId, float vol = 1.0f)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID
        soundJo.Call( "playSound", new object[] { soundId, vol } );
        #endif
    }

    public string GetAppID()
    {
        string appId = "";
        #if !UNITY_EDITOR&&UNITY_ANDROID
        appId = jo.Call<string>("getAppID");
        #endif
        return appId;
    }

    public void SetRecUploadURL(string url)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID  
        jo.Call("setRecUploadURL",url);
        #endif
    }
}
