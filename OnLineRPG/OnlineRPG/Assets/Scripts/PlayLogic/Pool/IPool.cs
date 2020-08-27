public interface IPool<T>
{
    bool Recycle(T obj);
}