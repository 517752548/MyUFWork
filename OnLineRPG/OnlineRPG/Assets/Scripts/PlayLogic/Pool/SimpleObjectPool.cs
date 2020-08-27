using System;
using UnityEngine;

public class SimpleObjectPool<T> : Pool<T>
{
    private readonly Action<T> mResetMethod;

    public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
    {
        mFactory = new CustomObjectFactory<T>(factoryMethod);
        mResetMethod = resetMethod;
		
        for (int i = 0; i < initCount; i++)
        {
            T aObj = mFactory.Create();
            if (mResetMethod != null) mResetMethod.Invoke(aObj);
            mCacheQueue.Enqueue(aObj);
        }
    }

    public override bool Recycle(T obj)
    {
        if (mResetMethod != null)
        {
            mResetMethod.Invoke(obj);
        }
        mCacheQueue.Enqueue(obj);
        return true;
    }
	public void DestroyQueueObjects()
	{
		while (mCacheQueue.Count > 0) {
			var obj = mCacheQueue.Dequeue();
			if (obj is GameObject) {
				UnityEngine.Object.Destroy(obj as GameObject);
			} else {
				UnityEngine.Object.Destroy((obj as Component).gameObject);
			}
		}
	}
}