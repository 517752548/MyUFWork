using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public abstract class TemplateDBBase<T> where T : TemplateObject
    {
        public abstract Dictionary<int, T> getIdKeyDic();
        public abstract bool addTemplate(T tpl);
        public abstract T getTemplate(int id);
        public abstract void loadAllTemplate();
    }
}
