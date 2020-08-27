using System.Collections.Generic;

public abstract class Pool<T> : IPool<T>
{
    protected Queue<T> mCacheQueue = new Queue<T>();

    public int CurCount
    {
        get { return mCacheQueue.Count; }
    }

    protected IObjectFactory<T> mFactory;

    protected int mMaxCount = 5;

    public virtual T Allocate()
    {
        return mCacheQueue.Count == 0 ? mFactory.Create() : mCacheQueue.Dequeue();
    }

    public abstract bool Recycle(T obj);

    public virtual Queue<T> GetCacheStack()
    {
        return mCacheQueue;
    }
}