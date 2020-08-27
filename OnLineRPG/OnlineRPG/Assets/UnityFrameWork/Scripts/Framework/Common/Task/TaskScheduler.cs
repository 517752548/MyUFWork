using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BetaFramework
{
    public class TaskScheduler
    {
        public bool AutoRun = false;
        private Dictionary<string, List<Task>> queueDic = new Dictionary<string, List<Task>>();
        private Dictionary<string, bool> queueAutoDic = new Dictionary<string, bool>();
        private List<Task> workingTasks = new List<Task>();

        public void InitQueue(string queueName, bool autoRun)
        {
            if (!queueDic.ContainsKey(queueName))
            {
                List<Task> tasks = new List<Task>();
                queueDic.Add(queueName, tasks);
            }
            if (queueAutoDic.ContainsKey(queueName))
            {
                queueAutoDic[queueName] = autoRun;
            }
            else
            {
                queueAutoDic.Add(queueName, autoRun);
            }
        }

        public void AddTaskToQueue(Task task, string queueName)
        {
            task.onTaskOver += OnTaskFinish;
            if (queueDic.ContainsKey(queueName))
            {
                queueDic[queueName].Add(task);
            }
            else
            {
                List<Task> tasks = new List<Task>
                {
                    task
                };
                queueDic.Add(queueName, tasks);
            }
        }

        public void AddTaskToSpecificQueue(Task task, string queueName)
        {

        }

        public void RemoveTask(Task task)
        {
            if (task != null && queueDic.ContainsKey(task.queueName))
            {
                queueDic[task.queueName].Remove(task);
                workingTasks.Remove(task);
            }
        }

        public bool CheckStartNextTask(string queueName)
        {
            if (queueDic.ContainsKey(queueName)
                && queueDic[queueName].Count > 0)
            {
                Task task = queueDic[queueName][0];
                if (task.State == TaskState.waiting)
                {
                    workingTasks.Add(task);
                    task.Run();
                    return true;
                }
            }
            return false;
        }

        public void UpdateTask()
        {

        }

        public void Update(float deltaTime)
        {

        }

        private void OnTaskFinish(Task task)
        {
            RemoveTask(task);
        }
    } 
}
