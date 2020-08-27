namespace BetaFramework
{
    public interface IObjectPool<T>
    {
        T Spawn(T prefab);

        bool Despawn(T prefab);
    }
}