using UnityEngine;
using System.Collections;
using System;

namespace BetaFramework
{
    public abstract class Task
    {
        public TaskState State = TaskState.waiting;
        public Action<Task> onTaskOver = null;
        public int index;
        public string queueName;

        public virtual void Run()
        {
            State = TaskState.executing;
        }

        public virtual void OnFinish()
        {
            State = TaskState.done;
            onTaskOver?.Invoke(this);
        }

        public virtual void Update(float deltaTime)
        {

        }
    }

    public enum TaskState
    {
        none,
        waiting,
        executing,
        done
    }

    public class FuncTask : Task
    {
        private Func<Task, bool> task;

        public FuncTask(Func<Task, bool> task)
        {
            State = TaskState.waiting;
            this.task = task;
        }

        public override void Run()
        {
            base.Run();
            if (task != null && task(this))
            {
                OnFinish();
            }
            else if (task == null)
            {
                OnFinish();
            }
        }
    }
}
