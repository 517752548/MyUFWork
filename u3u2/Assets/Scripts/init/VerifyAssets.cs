using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace init
{
    public class VerifyAssets
    {
        public string extFilesRoot { get; private set; }
        /// <summary>
        /// 解压完后的素材目录。
        /// </summary>
        public string extAssetsDir { get; private set; }

        /// <summary>
        /// 素材zip包下载目录。
        /// </summary>
        public string extAssetsDownloadedDir { get; private set; }

        public string dbZipFileName { get; private set; }

        public string downloadedDbZipFilePath { get; private set; }

        public string unzippedDbFileDir { get; private set; }

        public string unzippedDbFileName { get; private set; }

        public string unzippedDbFilePath { get; private set; }

        public string finalDbFileName { get; private set; }

        public string finalDbFilePath { get; private set; }

        /// <summary>
        /// 本地调试用的时候设为true，直接连本地的db
        /// </summary>
        public const bool isLocalDB = false;
        public const string localDBFile = "E:\\uuu\\config_1001.db";

        public const bool ENC_FLAG = true;
        public static readonly byte[] ENC_ARR = { 1, 0, 0, 1, 1, 0, 1, 1 };
        public static readonly int ENC_BYTE_NUM = ENC_ARR.Length;

        public string error = "";

        private static VerifyAssets mIns = null;
        public static VerifyAssets ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new VerifyAssets();
                }
                return mIns;
            }
        }

        public VerifyAssets()
        {
            extFilesRoot = Application.temporaryCachePath;
            #if !UNITY_EDITOR && UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            extFilesRoot = jo.Call<string>("getTheFilesDir");
            #endif

            extAssetsDir = extFilesRoot + "/Assets/";
            extAssetsDownloadedDir = extFilesRoot + "/AssetsDownloaded/";
            dbZipFileName = "config.db.zip";
            downloadedDbZipFilePath = extAssetsDownloadedDir + dbZipFileName;
            unzippedDbFileDir = extFilesRoot + "/";
            unzippedDbFileName = "config.db";
            unzippedDbFilePath = unzippedDbFileDir + unzippedDbFileName;
            finalDbFileName = "db";
            finalDbFilePath = unzippedDbFileDir + finalDbFileName;
        }

        public List<string[]> GetArtsToDownload()
        {
            List<string[]> res = new List<string[]>();
            List<string[]> assetsDownloadList = ServerVersionConfig.Ins.GetAssetsDownloadList(LocalVersionConfig.Ins.GetBaseVersion());
            int len = assetsDownloadList.Count;
            int startIdx = len;
            for (int i = 0; i < len; i++)
            {
                if (assetsDownloadList[i][0] == LocalVersionConfig.Ins.GetAppVersion())
                {
                    startIdx = i + 1;
                    break;
                }
            }
            
            for (int i = startIdx; i < len; i++)
            {
                res.Add(assetsDownloadList[i]);
                if (assetsDownloadList[i][0] == ServerVersionConfig.Ins.appVersion)
                {
                    break;
                }
            }
            
            return res;
        }

        public bool UnZipAssets(string zipName, string zipMD5)
        {
            string downloadedFilePath = extAssetsDownloadedDir + zipName;
            string downloadedFileMD5 = Util.GetFileMd5(downloadedFilePath);
            string serverFileMD5 = zipMD5;
            if (downloadedFileMD5 != serverFileMD5)
            {
                error = zipName + " 文件MD5不匹配！下载成功的文件 MD5:" + downloadedFileMD5 + " 服务器版本中的文件 MD5:" + serverFileMD5;
                Debug.LogError(error);
                return false;
            }

            if (!Directory.Exists(extAssetsDir))
            {
                Directory.CreateDirectory(extAssetsDir);
            }

            try
            {
                if (File.Exists(downloadedFilePath))
                {
                    Debug.Log("UnZip " + downloadedFilePath + "  to  " + extAssetsDir);
                    ZipUtil.Unzip(downloadedFilePath, extAssetsDir);

                    File.Delete(downloadedFilePath);
                    /*
                    if (Directory.Exists(downloadedFilePath))
                    {
                        Directory.Delete(downloadedFilePath, true);
                    }
                    */
                    error = "";
                    return true;
                }
                else
                {
                    error = downloadedFilePath + " 文件不存在";
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                try
                {
                    if (File.Exists(downloadedFilePath))
                    {
                        File.Delete(downloadedFilePath);
                    }
                }
                catch (Exception)
                {
                    error = e.Message;
                    Debug.LogError(error);
                    return false;
                }

                error = e.Message;
                Debug.LogError(error);
                return false;
            }
        }

        /**
         * 解压缩配置文件
         */
        public bool unZipDbFile()
        {
            string downloadedDBMD5 = Util.GetFileMd5(downloadedDbZipFilePath);
            Debug.Log("downloadedDBMD5:" + downloadedDBMD5);

            if (!ClientConfig.Ins.debug)
            {
                if (downloadedDBMD5 != ServerVersionConfig.Ins.dbMD5)
                {
                    error = "数据库MD5不匹配！下载成功的DB MD5:" + downloadedDBMD5 + " 服务器版本config中的DB MD5:" + ServerVersionConfig.Ins.dbMD5;
                    Debug.LogError(error);
                    return false;
                }
            }
            
            try
            {
                if (!Directory.Exists(unzippedDbFileDir))
                {
                    Directory.CreateDirectory(unzippedDbFileDir);
                }

                // 如果解压后的文件存在，则删除
                if (File.Exists(unzippedDbFilePath))
                {
                    File.Delete(unzippedDbFilePath);
                }

                ZipUtil.Unzip(downloadedDbZipFilePath, unzippedDbFileDir);
                File.Delete(downloadedDbZipFilePath);

                if (ENC_FLAG)
                {
                    if (!decryptDbFile(unzippedDbFilePath, finalDbFilePath))
                    {
                        return false;
                    }
                    File.Delete(unzippedDbFilePath);
                }
                else
                {
                    File.Move(unzippedDbFilePath, finalDbFilePath);
                }
                Debug.LogWarning("unZipDbFile OK. path=" + downloadedDbZipFilePath);
                error = "";
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                Debug.LogError("unZipDbFile Exception! " + error);
                return false;
            }
        }

        private bool decryptDbFile(string unzipeedDBFilePath, string decryptedDBFilePath)
        {
            if (!File.Exists(unzipeedDBFilePath))
            {
                error = unzipeedDBFilePath + " 文件不存在！";
                Debug.LogError(error);
                return false;
            }
            try
            {
                if (File.Exists(decryptedDBFilePath))
                {
                    File.Delete(decryptedDBFilePath);
                }

                FileStream fs = new FileStream(unzipeedDBFilePath, FileMode.Open);
                fs.Seek(0, SeekOrigin.Begin);
                byte[] barr = new byte[ENC_BYTE_NUM];
                byte[] farr = new byte[fs.Length - ENC_BYTE_NUM];
                fs.Read(barr, 0, ENC_BYTE_NUM);
                fs.Read(farr, 0, farr.Length);
                fs.Close();
                fs.Dispose();

                for (int i = 0; i < ENC_BYTE_NUM; i++)
                {
                    barr[i] = (byte)(barr[i] ^ ENC_ARR[i]);
                }

                FileStream localfs = new FileStream(decryptedDBFilePath, FileMode.CreateNew);
                localfs.Seek(0, SeekOrigin.Begin);
                localfs.Write(barr, 0, ENC_BYTE_NUM);
                localfs.Write(farr, 0, farr.Length);

                localfs.Flush();
                localfs.Close();
                localfs.Dispose();
            }
            catch (Exception e)
            {
                error = e.Message;
                Debug.LogError(error);
                return false;
            }
            
            error = "";
            return true;
        }
    }
}