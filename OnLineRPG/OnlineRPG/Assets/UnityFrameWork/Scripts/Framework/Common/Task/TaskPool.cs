using System.Collections.Generic;

namespace BetaFramework
{
    public class TaskPool<T> where T : ITask
    {
        private LinkedList<T> m_WorkingTasks;
        private LinkedList<T> m_WaitTasks;

        private int m_MaxTasks = 5;

        public int MaxTasks
        {
            get { return m_MaxTasks; }
            set { m_MaxTasks = value; }
        }

        public TaskPool()
        {
            m_WorkingTasks = new LinkedList<T>();
            m_WaitTasks = new LinkedList<T>();
        }

        public void Update(float elapseSeconds)
        {
            if (m_WaitTasks.Count > 0)
            {
                if (m_WorkingTasks.Count < m_MaxTasks)
                {
                    T task = m_WaitTasks.First.Value;
                    m_WorkingTasks.AddLast(task);
                    m_WaitTasks.RemoveFirst();
                    task.Start();
                }
            }

            LinkedListNode<T> current = m_WorkingTasks.First;
            while (current != null)
            {
                current.Value.Update(elapseSeconds);
                current = current.Next;
            }
        }

        public void AddTask(T task)
        {
            if (m_WorkingTasks.Count < m_MaxTasks)
            {
                m_WorkingTasks.AddLast(task);
                task.Start();
            }
            else
            {
                m_WaitTasks.AddLast(task);
            }
        }

        internal void AddTask<V>(T task) where V : UnityEngine.Object
        {
            if (m_WorkingTasks.Count < m_MaxTasks)
            {
                m_WorkingTasks.AddLast(task);
                task.Start();
            }
        }

        public void RemoveTask(T task)
        {
            if (m_WorkingTasks.Contains(task))
            {
                task.Stop();
                m_WorkingTasks.Remove(task);
            }

            if (m_WaitTasks.Contains(task))
            {
                m_WaitTasks.Remove(task);
            }
        }

        public void ClearAllTask()
        {
            foreach (T task in m_WorkingTasks)
            {
                task.Stop();
            }

            m_WorkingTasks.Clear();
            m_WaitTasks.Clear();
        }
    }
}