using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace BetaFramework
{
    public class DownloadManager : IModule
    {
        private TaskPool<DownloadTask> m_DownloadTasks;
        private Dictionary<int, IDownloadListener> m_SingleTaskListeners;
        private Dictionary<int, DownloadMultiTask> m_MultiTaskListeners;

        private uint m_FlushSize;
        private int m_MultiTaskId;

        private struct DownloadMultiTask
        {
            public List<DownloadTask> Tasks;
            public IDownloadListener Listener;
        }

        public DownloadManager()
        {
            m_MultiTaskId = 0;
            m_FlushSize = 1024 * 1024;
            m_DownloadTasks = new TaskPool<DownloadTask>();
            m_SingleTaskListeners = new Dictionary<int, IDownloadListener>();
            m_MultiTaskListeners = new Dictionary<int, DownloadMultiTask>();
        }

        public override void Init()
        {
        }


        public override void Execute(float deltaTime)
        {
            m_DownloadTasks.Update(deltaTime);
        }

        public override void Shut()
        {
            m_DownloadTasks.ClearAllTask();
            m_SingleTaskListeners.Clear();
            m_MultiTaskListeners.Clear();
        }

        public override void Pause(bool pause)
        {
        }

        /// <summary>
        /// 指定存储位置的get下载方法
        /// </summary>
        public int GetBytes(IDownloadListener listener, string url, string location, int timeout = 30)
        {
            DownloadTask task = new DownloadTask(url, timeout, m_FlushSize);
            task.Location = location;
            task.DownloadError += OnDownloadError;
            task.DownloadUpdate += OnDownloadUpdate;
            task.DownloadSuccess += OnDownloadSuccess;

            task.Init();
            task.HttpVerb = UnityWebRequest.kHttpVerbGET;

            if (listener != null)
            {
                AddListener(task.TransactionId, listener);
            }

            m_DownloadTasks.AddTask(task);
            return task.TransactionId;
        }

        public int GetBytes(IDownloadListener listener, string url, bool isCache = false, int timeout = 30)
        {
            DownloadTask task = new DownloadTask(url, timeout, m_FlushSize);
            task.IsCache = isCache;
            task.DownloadError += OnDownloadError;
            task.DownloadUpdate += OnDownloadUpdate;
            task.DownloadSuccess += OnDownloadSuccess;

            task.Init();
            task.HttpVerb = UnityWebRequest.kHttpVerbGET;

            if (listener != null)
            {
                AddListener(task.TransactionId, listener);
            }

            m_DownloadTasks.AddTask(task);
            return task.TransactionId;
        }

        /// <summary>
        /// 多任务下载
        /// </summary>
        public int GetBytes(IDownloadListener listener, List<string> listUrl, int timeout = 30)
        {
            List<DownloadTask> tasks = new List<DownloadTask>();
            for (int i = 0; i < listUrl.Count; i++)
            {
                DownloadTask task = new DownloadTask(listUrl[i], timeout, m_FlushSize);

                task.DownloadError += OnDownloadMultiTaskError;
                task.DownloadUpdate += OnDownloadMultiTaskUpdate;
                task.DownloadSuccess += OnDownloadMultiTaskSuccess;

                task.Init();
                task.HttpVerb = UnityWebRequest.kHttpVerbGET;
                m_DownloadTasks.AddTask(task);
                tasks.Add(task);
            }

            AddMultiTaskListener(++m_MultiTaskId, tasks, listener);
            return m_MultiTaskId;
        }

        /// <summary>
        /// 多任务下载
        /// </summary>
        public int GetBytes(IDownloadListener listener, List<MultiDownloadMeta> metas, int timeout = 30)
        {
            List<DownloadTask> tasks = new List<DownloadTask>();
            for (int i = 0; i < metas.Count; i++)
            {
                DownloadTask task = new DownloadTask(metas[i].url, timeout, m_FlushSize)
                {
                    Location = "/Buffer/" + metas[i].location
                };
                task.DownloadError += OnDownloadMultiTaskError;
                task.DownloadUpdate += OnDownloadMultiTaskUpdate;
                task.DownloadSuccess += OnDownloadMultiTaskSuccess;

                task.Init();
                task.HttpVerb = UnityWebRequest.kHttpVerbGET;
                m_DownloadTasks.AddTask(task);
                tasks.Add(task);
            }

            AddMultiTaskListener(++m_MultiTaskId, tasks, listener);
            return m_MultiTaskId;
        }

        /// <summary>
        ///
        /// </summary>
        public int GetBytes(IDownloadListener listener, List<string> listUrl, bool isBuffer, int timeout = 30)
        {
            List<DownloadTask> tasks = new List<DownloadTask>();
            for (int i = 0; i < listUrl.Count; i++)
            {
                DownloadTask task = new DownloadTask(listUrl[i], timeout, m_FlushSize)
                {
                    IsCache = isBuffer
                };
                task.DownloadError += OnDownloadMultiTaskError;
                task.DownloadUpdate += OnDownloadMultiTaskUpdate;
                task.DownloadSuccess += OnDownloadMultiTaskSuccess;

                task.Init();
                task.HttpVerb = UnityWebRequest.kHttpVerbGET;
                m_DownloadTasks.AddTask(task);
                tasks.Add(task);
            }

            AddMultiTaskListener(++m_MultiTaskId, tasks, listener);
            return m_MultiTaskId;
        }

        /// <summary>
        /// post下载方法
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="url"></param>
        /// <param name="formFields"></param>
        /// <param name="timeout"></param>
        /// <returns>任务id</returns>
        public int PostBytes(IDownloadListener listener, string url, Dictionary<string, string> formFields, int timeout = 30)
        {
            DownloadTask task = new DownloadTask(url, timeout, m_FlushSize);
            task.DownloadError += OnDownloadError;
            task.DownloadUpdate += OnDownloadUpdate;
            task.DownloadSuccess += OnDownloadSuccess;

            task.Init();
            task.FormFields = formFields;
            task.HttpVerb = UnityWebRequest.kHttpVerbPOST;

            if (listener != null)
            {
                AddListener(task.TransactionId, listener);
            }

            m_DownloadTasks.AddTask(task);
            return task.TransactionId;
        }

        public int PostBytes(IDownloadListener listener, string url, Dictionary<string, string> formFields, bool isBuffer, int timeout = 30)
        {
            DownloadTask task = new DownloadTask(url, timeout, m_FlushSize);
            task.IsCache = isBuffer;
            task.DownloadError += OnDownloadError;
            task.DownloadUpdate += OnDownloadUpdate;
            task.DownloadSuccess += OnDownloadSuccess;

            task.Init();
            task.FormFields = formFields;
            task.HttpVerb = UnityWebRequest.kHttpVerbPOST;

            if (listener != null)
            {
                AddListener(task.TransactionId, listener);
            }

            m_DownloadTasks.AddTask(task);
            return task.TransactionId;
        }

        public int PostBytes(IDownloadListener listener, List<string> listUrl, Dictionary<string, string> formFields, int timeout = 30)
        {
            List<DownloadTask> tasks = new List<DownloadTask>();
            for (int i = 0; i < listUrl.Count; i++)
            {
                DownloadTask task = new DownloadTask(listUrl[i], timeout, m_FlushSize);
                task.DownloadError += OnDownloadMultiTaskError;
                task.DownloadUpdate += OnDownloadMultiTaskUpdate;
                task.DownloadSuccess += OnDownloadMultiTaskSuccess;

                task.Init();
                task.HttpVerb = UnityWebRequest.kHttpVerbPOST;
                m_DownloadTasks.AddTask(task);
                tasks.Add(task);
            }

            AddMultiTaskListener(++m_MultiTaskId, tasks, listener);
            return m_MultiTaskId;
        }

        public int PostBytes(IDownloadListener listener, List<string> listUrl, Dictionary<string, string> formFields, bool isBuffer, int timeout = 30)
        {
            List<DownloadTask> tasks = new List<DownloadTask>();
            for (int i = 0; i < listUrl.Count; i++)
            {
                DownloadTask task = new DownloadTask(listUrl[i], timeout, m_FlushSize)
                {
                    IsCache = isBuffer
                };
                task.DownloadError += OnDownloadMultiTaskError;
                task.DownloadUpdate += OnDownloadMultiTaskUpdate;
                task.DownloadSuccess += OnDownloadMultiTaskSuccess;

                task.Init();
                task.HttpVerb = UnityWebRequest.kHttpVerbPOST;
                m_DownloadTasks.AddTask(task);
                tasks.Add(task);
            }

            AddMultiTaskListener(++m_MultiTaskId, tasks, listener);
            return m_MultiTaskId;
        }

        private void OnDownloadError(DownloadTask task, string error)
        {
            IDownloadListener listener = null;
            if (m_SingleTaskListeners.TryGetValue(task.TransactionId, out listener))
            {
                listener.OnError(task.TransactionId, error);
                m_SingleTaskListeners.Remove(task.TransactionId);
            }

            m_DownloadTasks.RemoveTask(task);
            RemoveTaskEvents(task);
        }

        private void OnDownloadUpdate(DownloadTask task, ulong length)
        {
            IDownloadListener listener = null;
            if (m_SingleTaskListeners.TryGetValue(task.TransactionId, out listener))
            {
                listener.OnUpdate(task.TransactionId, 0);
            }
        }

        private void OnDownloadSuccess(DownloadTask task, ulong length)
        {
            IDownloadListener listener = null;
            if (m_SingleTaskListeners.TryGetValue(task.TransactionId, out listener))
            {
                listener.OnSuccess(task.TransactionId, task.Bytes);
                m_SingleTaskListeners.Remove(task.TransactionId);
            }

            m_DownloadTasks.RemoveTask(task);
            RemoveTaskEvents(task);
        }

        private void RemoveTaskEvents(DownloadTask task)
        {
            task.DownloadError -= OnDownloadError;
            task.DownloadUpdate -= OnDownloadUpdate;
            task.DownloadSuccess -= OnDownloadSuccess;
        }

        private void OnDownloadMultiTaskError(DownloadTask task, string error)
        {
            int removeId = -1;
            foreach (int id in m_MultiTaskListeners.Keys)
            {
                DownloadMultiTask multiTask = m_MultiTaskListeners[id];

                bool isExist = multiTask.Tasks.Exists(x => x.TransactionId == task.TransactionId);
                if (isExist)
                {
                    removeId = id;
                }
            }

            DownloadMultiTask rmMultiTask;
            if (m_MultiTaskListeners.TryGetValue(removeId, out rmMultiTask))
            {
                //下载失败
                rmMultiTask.Listener.OnError(removeId, error);

                //移除正在下载的任务
                List<DownloadTask> downloadTasks = rmMultiTask.Tasks;
                for (int i = 0; i < downloadTasks.Count; i++)
                {
                    m_DownloadTasks.RemoveTask(downloadTasks[i]);
                    RemoveMultiTaskEvents(downloadTasks[i]);
                }

                m_MultiTaskListeners.Remove(removeId);
            }
        }

        private void OnDownloadMultiTaskUpdate(DownloadTask task, ulong length)
        {
        }

        private void OnDownloadMultiTaskSuccess(DownloadTask task, ulong length)
        {
            int removeId = -1;
            foreach (int id in m_MultiTaskListeners.Keys)
            {
                DownloadMultiTask multiTask = m_MultiTaskListeners[id];

                bool isExist = multiTask.Tasks.Exists(x => x.TransactionId == task.TransactionId);
                if (isExist)
                {
                    removeId = id;
                }
            }

            DownloadMultiTask rmMultiTask;
            if (m_MultiTaskListeners.TryGetValue(removeId, out rmMultiTask))
            {
                rmMultiTask.Tasks.Remove(task);
                m_DownloadTasks.RemoveTask(task);
                RemoveMultiTaskEvents(task);

                //全部下载完成
                if (rmMultiTask.Tasks.Count == 0)
                {
                    rmMultiTask.Listener.OnSuccess(removeId, task.Bytes);
                    m_MultiTaskListeners.Remove(removeId);
                }
            }
        }

        private void RemoveMultiTaskEvents(DownloadTask task)
        {
            task.DownloadError -= OnDownloadMultiTaskError;
            task.DownloadUpdate -= OnDownloadMultiTaskUpdate;
            task.DownloadSuccess -= OnDownloadMultiTaskSuccess;
        }

        public void AddListener(int id, IDownloadListener listener)
        {
            if (!m_SingleTaskListeners.ContainsKey(id))
            {
                m_SingleTaskListeners.Add(id, listener);
            }
        }

        public void AddMultiTaskListener(int id, List<DownloadTask> tasks, IDownloadListener listener)
        {
            if (!m_MultiTaskListeners.ContainsKey(id))
            {
                DownloadMultiTask multiTask = new DownloadMultiTask
                {
                    Tasks = tasks,
                    Listener = listener
                };
                m_MultiTaskListeners.Add(id, multiTask);
            }
        }
    }

    public class MultiDownloadMeta
    {
        public string url;
        public string location;

        public MultiDownloadMeta(string url, string location)
        {
            this.url = url;
            this.location = location;
        }
    }
}