using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace BetaFramework
{
    public class DownloadHelper : IDisposable
    {
        private UnityWebRequest m_UnityWebRequest = null;
        private bool m_Disposed = false;

        private event EventHandler<DownloadErrorEventArgs> m_EventHandlerDownloadError = null;

        private event EventHandler<DownloadSuccessEventArgs> m_EventHandlerDownloadSuccess = null;

        private event EventHandler<DownloadUpdateEventArgs> m_EventHandlerDownloadUpdate = null;

        /// <summary>
        /// 下载错误事件。
        /// </summary>
        public event EventHandler<DownloadErrorEventArgs> DownloadErrorEvent
        {
            add
            {
                m_EventHandlerDownloadError += value;
            }
            remove
            {
                m_EventHandlerDownloadError -= value;
            }
        }

        /// <summary>
        /// 下载完成事件。
        /// </summary>
        public event EventHandler<DownloadSuccessEventArgs> DownloadSuccessEvent
        {
            add
            {
                m_EventHandlerDownloadSuccess += value;
            }
            remove
            {
                m_EventHandlerDownloadSuccess -= value;
            }
        }

        /// <summary>
        /// 下载进度事件
        /// </summary>
        public event EventHandler<DownloadUpdateEventArgs> DownloadUpdateEvent
        {
            add
            {
                m_EventHandlerDownloadUpdate += value;
            }
            remove
            {
                m_EventHandlerDownloadUpdate -= value;
            }
        }

        /// <summary>
        /// Get方法
        /// </summary>
        /// <param name="url"></param>
        public void GetBytes(string url)
        {
            m_UnityWebRequest = UnityWebRequest.Get(url);
            m_UnityWebRequest.SendWebRequest();
        }

        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fromPosition"></param>
        public void GetBytes(string url, ulong fromPosition)
        {
            m_UnityWebRequest = UnityWebRequest.Get(url);
            m_UnityWebRequest.SetRequestHeader("Range", string.Format("bytes={0}-", fromPosition.ToString()));
            m_UnityWebRequest.SendWebRequest();
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formFields"></param>
        public void PostBytes(string url, Dictionary<string, string> formFields)
        {
            m_UnityWebRequest = UnityWebRequest.Post(url, formFields);
            m_UnityWebRequest.SendWebRequest();
        }

        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fromPosition"></param>
        /// <param name="formFields"></param>
        public void PostBytes(string url, ulong fromPosition, Dictionary<string, string> formFields)
        {
            m_UnityWebRequest = UnityWebRequest.Post(url, formFields);
            m_UnityWebRequest.SetRequestHeader("Range", string.Format("bytes={0}-", fromPosition.ToString()));
            m_UnityWebRequest.SendWebRequest();
        }

        public void Update()
        {
            if (m_UnityWebRequest == null)
                return;

            if (m_UnityWebRequest.isHttpError)
            {
                if (m_EventHandlerDownloadError != null)
                {
                    m_EventHandlerDownloadError(this, new DownloadErrorEventArgs(m_UnityWebRequest.error));
                }

                return;
            }

            if (!m_UnityWebRequest.isDone)
            {
                if (m_EventHandlerDownloadUpdate != null)
                {
                    m_EventHandlerDownloadUpdate(this, new DownloadUpdateEventArgs(m_UnityWebRequest.downloadedBytes, null));
                }

                return;
            }

            if (m_UnityWebRequest.isDone)
            {
                if (m_EventHandlerDownloadSuccess != null)
                {
                    m_EventHandlerDownloadSuccess(this, new DownloadSuccessEventArgs(m_UnityWebRequest.downloadedBytes, m_UnityWebRequest.downloadHandler.data));
                }
            }
        }

        public void Shut()
        {
            if (m_UnityWebRequest != null)
            {
                m_UnityWebRequest.Abort();
                m_UnityWebRequest.Dispose();
                m_UnityWebRequest = null;
            }
        }

        /// <summary>
        /// 可手动回收资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 由GC调用，不确定什么时候会调用
        /// </summary>
        ~DownloadHelper()
        {
            if (m_UnityWebRequest != null)
            {
                m_UnityWebRequest.Dispose();
                m_UnityWebRequest = null;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    if (m_UnityWebRequest != null)
                    {
                        m_UnityWebRequest.Dispose();
                        m_UnityWebRequest = null;
                    }
                }

                m_Disposed = true;
            }
        }
    }
}