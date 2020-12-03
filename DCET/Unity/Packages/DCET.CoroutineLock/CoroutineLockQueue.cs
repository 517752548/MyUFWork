using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCET
{
    public class CoroutineLockQueue: Entity
    {
        private readonly Queue<TaskCompletionSource<CoroutineLock>> queue = new Queue<TaskCompletionSource<CoroutineLock>>();

        public void Enqueue(TaskCompletionSource<CoroutineLock> tcs)
        {
            this.queue.Enqueue(tcs);
        }

        public TaskCompletionSource<CoroutineLock> Dequeue()
        {
            return this.queue.Dequeue();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            
            base.Dispose();
            
            this.queue.Clear();
        }
    }
}