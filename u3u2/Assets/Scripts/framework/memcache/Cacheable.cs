
public abstract class Cacheable : ICacheable
{
    private bool mIsUsed = false;
    public abstract string GetPoolName();
    public abstract int GetCacheType();
    public abstract void Destroy();
    public virtual void Use()
    {
        ClientLog.Log("Use " + GetPoolName());
        mIsUsed = true;
        MemCache.GetPool(GetPoolName(), GetCacheType()).Use(this);
    }
    public virtual void UnUse()
    {
        ClientLog.Log("UnUse " + GetPoolName());
        mIsUsed = false;
        MemCache.GetPool(GetPoolName(), GetCacheType()).UnUse(this);
    }

    public bool GetIsUsed()
    {
        return mIsUsed;
    }
    
    public virtual bool IsBroken()
    {
        return false;
    }
}