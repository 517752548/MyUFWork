namespace DCET
{
    public static class EntityHelper
    {
        public static bool IsEmptyOrDisposed(this Entity component)
        {
            return component == null || component.IsDisposed;
        }

        public static bool ExistAndUndisposed(this Entity component)
        {
            return component != null && !component.IsDisposed;
        }
    }
}
