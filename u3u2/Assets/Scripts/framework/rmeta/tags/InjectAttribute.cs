using System;

    [AttributeUsage (AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class InjectAttribute:Attribute
    {
        public InjectAttribute()
        {

        }

        private String _ui;

        public String ui
        {
            get
            {
                return _ui;
            }
            set
            {
                _ui = value; 
            }
        }
    }