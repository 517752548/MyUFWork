using System.Runtime.InteropServices;

public class IOSPlat : IPlat
{

#if !UNITY_EDITOR&&UNITY_IPHONE
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void startRec();//开始录音
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void stopRec();//停止本次录音，但不影响本次识别
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void cancelRec();//取消本次录音和识别
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void playSound(string fileName);//播放录音
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void getAppID(out string appId);
    [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
    private static extern void setRecUploadURL(string url);
#endif
    public void PlatStartChat()
    {
        #if !UNITY_EDITOR && UNITY_IPHONE
            startRec();
        #endif
    }
    public void PlatStopChat()
    {
        #if !UNITY_EDITOR && UNITY_IPHONE
            stopRec();
        #endif
    }
    public void PlatCancelChat()
    {
        #if !UNITY_EDITOR && UNITY_IPHONE
            cancelRec();
        #endif
    }
    public void PlatPlayChat(string filename)
    {
        #if !UNITY_EDITOR && UNITY_IPHONE
            playSound(filename);
        #endif
    }
    
    public int LoadSound(string soundName)
    {
        return 0;
    }
    
    public void PlaySound(int soundId, float vol = 1.0f)
    {
        
    }

    public string GetAppID()
    {
        string appId = "";
        #if !UNITY_EDITOR && UNITY_IPHONE
        getAppID(out appId);
        #endif
        return appId;
    }

    public void SetRecUploadURL(string url)
    {
        #if !UNITY_EDITOR && UNITY_IPHONE
        setRecUploadURL(url);
        #endif
    }
}
