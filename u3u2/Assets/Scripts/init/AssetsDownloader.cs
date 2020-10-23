using UnityEngine;
using System;
using System.Net;
using System.IO;

namespace init
{
    internal class WebRequestState
    {
        public byte[] buffer;

        public FileStream fs;

        public const int bufferSize = 1024;

        public Stream orginalStream;

        public HttpWebResponse response;

        public long writeStartPos;

        public WebRequestState(string localPath)
        {
            buffer = new byte[bufferSize];
            fs = new FileStream(localPath, FileMode.OpenOrCreate, FileAccess.Write);
            writeStartPos = 0;
            //writeStartPos = fs.Length;
            //fs.Seek(writeStartPos, SeekOrigin.Current);
        }

        public void Dispose()
        {
            if (fs != null)
            {
                fs.Close();
                fs.Dispose();
                fs = null;
            }
            if (orginalStream != null)
            {
                orginalStream.Close();
                orginalStream.Dispose();
                orginalStream = null;

            }
            if (response != null)
            {
                response.GetResponseStream().Close();
                response.GetResponseStream().Dispose();
                response.Close();
                response = null;
            }
        }
    }

    public class AssetsDownloader
    {
        /// <summary>
        /// 记录<需要下载的素材包的大小>的文件的后缀。
        /// </summary>
        public const string SERVER_ASSETS_FILE_SIZE_FILE_POSTFIX = ".size";
        public string downloadingFileName { get; private set; }
        public long totalLen { get; private set; }
        public long curLen { get; private set; }
        public bool isCompleted { get; private set; }
        public bool error { get; private set; }
        public string errorMsg { get; private set; }

        private string mLocalPath;
        private string mUrl;

        private WebRequestState mSt = null;

        //private string mSizeFile = null;

        public AssetsDownloader()
        {
        }

        public void Download(string localDir, string localFileName, string url)
        {
            this.downloadingFileName = localFileName;
            string localPath = localDir + localFileName;
            this.mLocalPath = localPath;
            this.mUrl = url;
            this.totalLen = 0;
            this.curLen = 0;
            this.isCompleted = false;
            this.error = false;
            this.errorMsg = "";

            //mSizeFile = mLocalPath + SERVER_ASSETS_FILE_SIZE_FILE_POSTFIX;
            Debug.Log("Download " + mUrl + "   to   " + mLocalPath);
            //Debug.Log("DownloadSizeFile:" + mSizeFile);

            try
            {
                if (!Directory.Exists(localDir))
                {
                    Directory.CreateDirectory(localDir);
                }

                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }

                /*
                if (File.Exists(mSizeFile))
                {
                    File.Delete(mSizeFile);
                }
                */

                mSt = new WebRequestState(mLocalPath);

                /*
                if (File.Exists(mSizeFile))
                {
                    StreamReader rs = File.OpenText(mSizeFile);
                    string size = rs.ReadLine();
                    rs.Close();
                    rs.Dispose();
                    if (size != "" && size != "0" && mSt.writeStartPos.ToString() == size)
                    {
                        //已经下载完成。
                        this.curLen = mSt.writeStartPos;
                        this.totalLen = mSt.writeStartPos;
                        mSt.Dispose();
                        this.isCompleted = true;
                        this.error = false;
                        this.errorMsg = "";
                        File.Delete(mSizeFile);
                        return;
                    }
                }
                */

                HttpWebRequest httpRequest = WebRequest.Create(mUrl) as HttpWebRequest;
                //httpRequest.Timeout = 10000;
                /*
                {
                    if (mSt.writeStartPos > 0)
                    {
                        httpRequest.AddRange((int)mSt.writeStartPos);
                    }
                }
                */
                httpRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), httpRequest);
                Debug.Log("start download:" + mUrl);
            }
            catch (Exception e)
            {
                if (mSt != null)
                {
                    mSt.Dispose();
                }
                this.isCompleted = true;
                this.error = true;
                this.errorMsg = e.Message;
                Debug.LogError(this.errorMsg);
            }
        }

        void ResponseCallback(IAsyncResult ar)
        {
            try
            {
                HttpWebRequest req = ar.AsyncState as HttpWebRequest;
                if (req == null)
                {
                    isCompleted = true;
                    error = true;
                    errorMsg = "HttpWebRequest is inaviliable";
                    Debug.LogError(errorMsg);
                    mSt.Dispose();
                    return;
                }
                if (mSt.response != null)
                {
                    mSt.response.GetResponseStream().Close();
                    mSt.response.GetResponseStream().Dispose();
                    mSt.response.Close();
                    mSt.response = null;
                    Debug.Log("dispose old response");
                }
                HttpWebResponse response = req.EndGetResponse(ar) as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.PartialContent)
                {
                    isCompleted = true;
                    error = true;
                    errorMsg = response.StatusDescription;
                    Debug.LogError(this.errorMsg);
                    mSt.Dispose();
                    return;
                }

                totalLen = response.ContentLength;
                curLen = mSt.writeStartPos;
                mSt.response = response;
                /*
                StreamWriter ws = null;

                try
                {
                    ws = File.CreateText(mSizeFile);
                    ws.WriteLine(totalLen.ToString());
                    ws.Flush();
                    ws.Close();
                    ws.Dispose();
                }
                catch (Exception e)
                {
                    mSt.Dispose();
                    isCompleted = true;
                    error = true;
                    errorMsg = e.Message;
                    Debug.LogError(this.errorMsg);
                    if (ws != null)
                    {
                        try
                        {
                            ws.Close();
                            ws.Dispose();
                        }
                        catch (Exception ee)
                        {
                            Debug.Log(ee.Message);
                            return;
                        }
                    }
                    return;
                }
                */
                Stream responseStream = response.GetResponseStream();
                mSt.orginalStream = responseStream;
                IAsyncResult readRes = responseStream.BeginRead(mSt.buffer, 0, WebRequestState.bufferSize, new AsyncCallback(ReadDataCallback), mSt);
                //Debug.Log("responseStream.BeginRead size:" + mSt.buffer.Length + " WebRequestState.bufferSize:" + WebRequestState.bufferSize);
            }
            catch (Exception e)
            {
                try
                {
                    mSt.Dispose();
                }
                catch (Exception ee)
                {
                    Debug.Log(ee.Message);
                }
                finally
                {
                    isCompleted = true;
                    error = true;
                    errorMsg = e.Message;
                    Debug.LogError(this.errorMsg);
                }
            }
        }

        void ReadDataCallback(IAsyncResult ar)
        {
            //Debug.Log("ReadDataCallback");
            WebRequestState rs = ar.AsyncState as WebRequestState;
            try
            {
                int read = rs.orginalStream.EndRead(ar);
                if (read > 0)
                {
                    curLen += read;
                    rs.fs.Write(rs.buffer, 0, read);
                    rs.fs.Flush();
                    rs.orginalStream.BeginRead(rs.buffer, 0, WebRequestState.bufferSize, new AsyncCallback(ReadDataCallback), rs);
                    //Debug.Log("rs.orginalStream.BeginRead size:" + rs.buffer.Length + " WebRequestState.bufferSize:" + WebRequestState.bufferSize);
                }
                else
                {
                    Debug.Log("download complete");
                    isCompleted = true;
                    error = false;
                    errorMsg = "";
                    //File.Delete(mSizeFile);
                    rs.Dispose();
                }
            }
            catch (Exception e)
            {
                rs.Dispose();
                isCompleted = true;
                error = true;
                errorMsg = e.Message;
                Debug.LogError(this.errorMsg);
            }
        }
    }
}