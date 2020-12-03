/**
 * 封装List，用于重用
 */

using System.Collections.Generic;

namespace DCET
{
    public class ListComponent <T> : Entity
    {
        public List<T> List = new List<T>();

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            
            base.Dispose();
            
            List.Clear();
        }
    }
    
    public class ListComponentDisposeChildren <T> : Entity where T : Entity
    {
        public List<T> List = new List<T>();

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            
            base.Dispose();

            foreach (T entity in List)
            {
                entity.Dispose();
            }
            List.Clear();
        }
    }
}