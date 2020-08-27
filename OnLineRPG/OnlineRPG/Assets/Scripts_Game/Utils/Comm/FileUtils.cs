using System;
using System.IO;
using UnityEngine;

namespace Scripts_Game.Utils.Comm
{
    public class FileUtils
    {
        private static string dir = "";
        static FileUtils()
        {
            //string dir = "";
#if UNITY_EDITOR
            dir = Application.persistentDataPath + "/Caches/";//路径：/AssetsCaches/
#elif UNITY_IOS
            dir = Application.temporaryCachePath + "/Download/";//路径：Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Library/Caches/
#elif UNITY_ANDROID
            dir = Application.persistentDataPath + "/Download/";//路径：/data/data/xxx.xxx.xxx/files/
#else
            dir = Application.streamingAssetsPath + "/Download/";//路径：/xxx_Data/StreamingAssets/
#endif
        }
        public static string AssetCachesDir
        {
            get
            {
                return dir;
            }
        }
        public static string ImagePathName { get { return AssetCachesDir + "Image/"; } }
        
        public static string TittleImagePath { get { return AssetCachesDir + "TittleImage/"; } }
        
        public static string TextPathName { get { return AssetCachesDir + "Config/"; } }
        public static bool CheckFileExists(string path, string name)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileInfo t = new FileInfo(path + "//" + name);
            if (!t.Exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void DeleteFile(string path, string name)
        {
            if (Directory.Exists(path))
            {
                FileInfo t = new FileInfo(path + "//" + name);
                if (t.Exists)
                {
                 t.Delete();   
                }
            }
        }
        public static void CreateFile(string path, string name,byte[] bytes)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
 
            FileStream fs;
            FileInfo t = new FileInfo(path + "//" + name);
            if (!t.Exists)
            {
                fs = t.Create();
            }
            else
            {
                t.Delete();
                fs = t.Create();
            }
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            fs.Dispose();
        }

        public static string LoadCacheText(string fileName)
        {
           return File.ReadAllText(TextPathName + "//" + fileName);
        }
        public static Texture2D LoadTexture(string name)
        {
            if (CheckFileExists(ImagePathName,name))
            {
                try
                {
                    var bytes = File.ReadAllBytes(ImagePathName + "//" + name);
                    Texture2D tex = new Texture2D(2,2);
                    tex.LoadImage(bytes);
                    return tex;
                }
                catch (Exception e)
                {
                    Debug.LogError(e.StackTrace);
                    Debug.LogError("删除文件" + name);
                    DeleteFile(ImagePathName,name);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}