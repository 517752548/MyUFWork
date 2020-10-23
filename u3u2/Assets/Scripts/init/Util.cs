using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace init
{
    public class Util
    {
        public static string GetFileMd5(string filePath)
        {
            string md5Str = "";
            FileInfo finfo = new FileInfo(filePath);
            if (finfo.Exists)
            {
                finfo.Attributes = FileAttributes.Normal;
            }
            if (File.Exists(filePath))
            {
                try
                {
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    MD5 md = MD5.Create();
                    stream.Position = 0L;
                    byte[] hashValue = md.ComputeHash(stream);
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        md5Str = md5Str + string.Format("{0:x2}", hashValue[i]);
                    }
                    stream.Close();
                    stream.Dispose();
                }
                catch (IOException e)
                {
                    Debug.LogError("GetFileMd5 ERROR!" + e.ToString());
                }
            }
            Debug.LogWarning("GetFileMd5 md5Str=" + md5Str);
            return md5Str;
        }
        
        public static string[] ParseAppVersion(string v)
        {
            string[] res = new string[2];
            int idx = v.LastIndexOf('.');
            res[0] = v.Substring(0, idx);
            res[1] = v.Substring(idx + 1);
            return res;
        }
    }
}