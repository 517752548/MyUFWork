using System;
    public class Config:IConfig
    {

        private static Config _instance;

        public static Config instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        public Config()
        {
            if (_instance != null)
            {
                throw new Exception("Config is a singeton class!!!");
            } else
            {
                startUpWndManager();
            }
        }

        private void startUpWndManager()
        {
            WndManager.Ins.initWnd();
        }
    }
