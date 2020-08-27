using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace BetaFramework
{
    public class DownloadTask : IDisposable, ITask
    {
        private DownloadHelper m_DownloadHelper;
        private FileStream m_FileStream;

        //断点续传的进度
        private ulong m_StartLength;

        //当前下载进度
        private ulong m_CurrentLength;

        //新的缓冲区
        private int m_WaitFlushLength;

        //缓冲区大小
        private uint m_FlushSize;

        //超时等待时间
        private float m_WaitTime;

        private DownloadStatus m_DownloadStatus = DownloadStatus.Idle;

        public UnityAction<DownloadTask, string> DownloadError;
        public UnityAction<DownloadTask, ulong> DownloadUpdate;
        public UnityAction<DownloadTask, ulong> DownloadSuccess;

        /// <summary>
        /// 静态全局下载任务id
        /// </summary>
        public static int Id { get; set; }

        /// <summary>
        /// 任务id
        /// </summary>
        private int m_TransactionId;

        public int TransactionId
        {
            set { m_TransactionId = value; }
            get { return m_TransactionId; }
        }

        /// <summary>
        /// 本地存储位置
        /// </summary>
        private string m_Location;

        public string Location
        {
            set { m_Location = value; }
            get { return m_Location; }
        }

        /// <summary>
        /// 是否缓存到本地（默认缓存）
        /// </summary>
        private bool _mIsCache;

        public bool IsCache
        {
            set { _mIsCache = value; }
            get { return _mIsCache; }
        }

        /// <summary>
        /// 任务类型
        /// </summary>
        private string m_HttpVerb;

        public string HttpVerb
        {
            set { m_HttpVerb = value; }
            get { return m_HttpVerb; }
        }

        /// <summary>
        /// 下载超时时间
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 下载内容
        /// </summary>
        private byte[] m_Bytes;

        public byte[] Bytes
        {
            get
            {
                return m_Bytes;
            }
        }

        private string m_FilePath;

        public Dictionary<string, string> FormFields { get; set; }

        public DownloadTask(string url, int timeout, uint flushSize)
        {
            ++Id;
            this.Url = url;
            this.Location = string.Empty;
            this.TimeOut = timeout;
            this.m_FlushSize = flushSize;
            this.m_TransactionId = Id;
            this._mIsCache = false;

            m_DownloadHelper = new DownloadHelper();
        }

        ~DownloadTask()
        {
            if (m_FileStream != null)
            {
                m_FileStream.Flush();
                m_FileStream.Dispose();
                m_FileStream = null;
            }
        }

        public void Start()
        {
            if (m_HttpVerb == UnityWebRequest.kHttpVerbGET)
            {
                StartGetBytes();
            }
            else if (m_HttpVerb == UnityWebRequest.kHttpVerbPOST)
            {
                StartPostBytes();
            }
        }

        public void Stop()
        {
            Shut();
        }

        public void StartGetBytes()
        {
            try
            {
                if (IsCache)
                {
                    string fileName;
                    if (Location == string.Empty)
                    {
                        fileName = Path.GetFileName(new Uri(Url).LocalPath);
                    }
                    else
                    {
                        fileName = Location;
                    }
                    m_FilePath = GetFilePath(fileName);
                    string path = m_FilePath + ".downloading";

                    if (File.Exists(m_FilePath))
                    {
                        m_FileStream = File.OpenWrite(m_FilePath);
                        m_FileStream.Seek(0, SeekOrigin.End);
                        m_StartLength = (ulong)m_FileStream.Length;
                        m_CurrentLength = 0;
                        m_DownloadStatus = DownloadStatus.Ready;

                        m_DownloadHelper.GetBytes(Url, m_StartLength);
                    }
                    else if (File.Exists(path))
                    {
                        m_FileStream = File.OpenWrite(path);
                        m_FileStream.Seek(0, SeekOrigin.End);
                        m_StartLength = (ulong)m_FileStream.Length;
                        m_CurrentLength = 0;
                        m_DownloadStatus = DownloadStatus.Ready;

                        m_DownloadHelper.GetBytes(Url, m_StartLength);
                    }
                    else
                    {
                        string directory = Path.GetDirectoryName(path);
                        if (directory != null && !Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        m_FileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                        m_StartLength = 0;
                        m_CurrentLength = 0;
                        m_DownloadStatus = DownloadStatus.Ready;

                        m_DownloadHelper.GetBytes(Url);
                    }
                }
                else
                {
                    m_DownloadStatus = DownloadStatus.Ready;
                    m_DownloadHelper.GetBytes(Url);
                }
            }
            catch (Exception exception)
            {
                OnDownloadError(this, new DownloadErrorEventArgs(exception.Message));
            }
        }

        public void StartPostBytes()
        {
            try
            {
                if (IsCache)
                {
                    string fileName;
                    if (Location == string.Empty)
                    {
                        fileName = Path.GetFileName(new Uri(Url).LocalPath);
                    }
                    else
                    {
                        fileName = Location;
                    }
                    m_FilePath = GetFilePath(fileName);
                    string path = m_FilePath + ".downloading";

                    if (File.Exists(m_FilePath))
                    {
                        m_FileStream = File.OpenWrite(m_FilePath);
                        m_FileStream.Seek(0, SeekOrigin.End);
                        m_StartLength = (ulong)m_FileStream.Length;
                        m_CurrentLength = 0;
                        m_DownloadStatus = DownloadStatus.Ready;

                        m_DownloadHelper.GetBytes(Url, m_StartLength);
                    }
                    else if (File.Exists(path))
                    {
                        m_FileStream = File.OpenWrite(path);
                        m_FileStream.Seek(0, SeekOrigin.End);
                        m_StartLength = (ulong)m_FileStream.Length;
                        m_CurrentLength = 0;

                        m_DownloadHelper.PostBytes(Url, m_StartLength, FormFields);
                    }
                    else
                    {
                        string directory = Path.GetDirectoryName(path);
                        if (directory != null && !Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        m_FileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                        m_StartLength = 0;
                        m_CurrentLength = 0;

                        m_DownloadHelper.PostBytes(Url, FormFields);
                    }
                }
                else
                {
                    m_DownloadHelper.PostBytes(Url, FormFields);
                }
            }
            catch (Exception exception)
            {
                OnDownloadError(this, new DownloadErrorEventArgs(exception.Message));
            }
        }

        public void Update(float elapseSeconds)
        {
            if (m_DownloadStatus == DownloadStatus.Ready
                || m_DownloadStatus == DownloadStatus.Downloading)
            {
                m_WaitTime += elapseSeconds;
                if (m_WaitTime >= TimeOut)
                {
                    OnDownloadError(this, new DownloadErrorEventArgs("time out"));
                }
            }

            if (m_DownloadHelper != null)
            {
                m_DownloadHelper.Update();
            }
        }

        /// <summary>
        /// 注册监听事件
        /// </summary>
        public void Init()
        {
            if (m_DownloadHelper == null)
                return;

            m_DownloadHelper.DownloadErrorEvent += OnDownloadError;
            m_DownloadHelper.DownloadUpdateEvent += OnDownloadUpdate;
            m_DownloadHelper.DownloadSuccessEvent += OnDownloadSuccess;
        }

        /// <summary>
        /// 清理工作
        /// </summary>
        public void Shut()
        {
            Dispose();

            if (m_DownloadHelper == null)
                return;

            m_DownloadHelper.Shut();
            m_DownloadHelper.DownloadErrorEvent -= OnDownloadError;
            m_DownloadHelper.DownloadUpdateEvent -= OnDownloadUpdate;
            m_DownloadHelper.DownloadSuccessEvent -= OnDownloadSuccess;
        }

        public void Dispose()
        {
            if (m_FileStream != null)
            {
                m_FileStream.Flush();
                m_FileStream.Dispose();
                m_FileStream = null;
            }
        }

        private void OnDownloadSuccess(object sender, DownloadSuccessEventArgs e)
        {
            m_WaitTime = 0f;

            byte[] bytes = e.Bytes;
            if (IsCache)
            {
                Save(bytes);
            }

            m_Bytes = e.Bytes;
            m_CurrentLength = e.Length;
            m_DownloadStatus = DownloadStatus.Done;

            if (m_DownloadHelper != null)
            {
                m_DownloadHelper.Shut();
            }

            if (m_FileStream != null)
            {
                m_FileStream.Flush();
                m_FileStream.Dispose();
                m_FileStream = null;
            }

            try
            {
                if (!string.IsNullOrEmpty(m_FilePath))
                {
                    if (File.Exists(m_FilePath))
                    {
                        File.Delete(m_FilePath);
                    }

                    string loadingFilePath = string.Format("{0}.downloading", m_FilePath);
                    if (File.Exists(loadingFilePath))
                    {
                        File.Move(loadingFilePath, m_FilePath);
                    }
                }
            }
            catch (Exception exception)
            {
                LoggerHelper.Exception(exception);
            }

            if (DownloadSuccess != null)
            {
                DownloadSuccess(this, e.Length);
            }
        }

        private void OnDownloadUpdate(object sender, DownloadUpdateEventArgs e)
        {
            m_WaitTime = 0f;

            byte[] bytes = e.Bytes;
            Save(bytes);

            m_CurrentLength = e.Length;
            m_DownloadStatus = DownloadStatus.Downloading;

            if (DownloadUpdate != null)
            {
                DownloadUpdate(this, e.Length);
            }
        }

        private void OnDownloadError(object sender, DownloadErrorEventArgs e)
        {
            m_WaitTime = 0f;

            if (m_DownloadHelper != null)
            {
                m_DownloadHelper.Shut();
            }

            if (m_FileStream != null)
            {
                m_FileStream.Flush();
                m_FileStream.Dispose();
                m_FileStream = null;
            }

            m_StartLength = 0;
            m_CurrentLength = 0;
            m_WaitFlushLength = 0;
            m_DownloadStatus = DownloadStatus.Error;

            if (DownloadError != null)
            {
                DownloadError(this, e.ErrorMessage);
            }
        }

        private void Save(byte[] bytes)
        {
            if (bytes == null)
            {
                return;
            }

            try
            {
                int length = bytes.Length;
                m_FileStream.Write(bytes, 0, length);
                m_WaitFlushLength += length;

                if (m_WaitFlushLength >= m_FlushSize)
                {
                    m_FileStream.Flush();
                    m_WaitFlushLength = 0;
                }
            }
            catch (Exception exception)
            {
                OnDownloadError(this, new DownloadErrorEventArgs(exception.Message));
            }
        }

        private string GetFilePath(string fileName)
        {
            return string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        }

        private enum DownloadStatus
        {
            /// <summary>
            /// 空闲
            /// </summary>
            Idle,

            /// <summary>
            /// 准备
            /// </summary>
            Ready,

            /// <summary>
            /// 下载中
            /// </summary>
            Downloading,

            /// <summary>
            /// 下载完成
            /// </summary>
            Done,

            /// <summary>
            /// 下载错误
            /// </summary>
            Error
        }
    }
}