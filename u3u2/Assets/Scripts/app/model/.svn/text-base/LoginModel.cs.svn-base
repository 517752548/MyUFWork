using System;
using app.config;
using app.main;

namespace app.model
{
    class LoginModel : AbsModel
    {
        private String _loginName;

        public String LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }

        private String _loginPwd;

        public String LoginPwd
        {
            get { return _loginPwd; }
            set { _loginPwd = value; }
        }
        
        private String _source;
        
        public String Source{
            get{return _source;}
            set{_source = value;}
        }

        public LoginModel()
        {
            addListener();
        }
        private static LoginModel _ins;
        public static LoginModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LoginModel();
                }
                return _ins;
            }
        }
        private void addListener()
        {
            EventCore.addRMetaEventListener(GlobalConstDefine.ConnServerSuccess, connectServerCallback);
            EventCore.addRMetaEventListener(GlobalConstDefine.ReConnServerSuccess, reConnectServerCallback);
        }
       
        public void doLogin(String login_name,string login_pwd,string source)
        {
            _loginName = login_name;
            _loginPwd = login_pwd;
            _source = source;
            ClientLog.LogWarning("用户:"+login_name+"正在登陆");

            //连接服务器
            connectServer();
        }

        public void connectServer()
        {
            //建立sokect链接
          //  GameConnection.Instance.connect(ClientConfig.Ins.SocketServerIP, ClientConfig.Ins.SocketServerPort);
			GameConnection.Instance.connect (ServerConfig.instance.gameServer, ServerConfig.instance.gamePort);
        }

        private void connectServerCallback(RMetaEvent e)
        {
            if (!GameConnection.Instance.IsConnected())
            {
                ClientLog.LogError("连接服务器失败!");
                return;
            }
            ClientLog.LogWarning("连接服务器成功!");
            SDKManager.ins.DoLogin();
            
            /*
            CGPlayerLogin msg = new CGPlayerLogin(_loginName, _loginPwd, _source);
            GameConnection.Instance.sendMessage(msg);
            */
        }

        private void reConnectServerCallback(RMetaEvent e)
        {
            if (!GameConnection.Instance.IsConnected())
            {
                ClientLog.LogError("重新连接服务器失败!");
                return;
            }
            ClientLog.LogWarning("重新连接服务器成功!");

            //int screenW = Screen.width;
            //int screenH = Screen.height;
            human.Human.Instance.PlayerModel.isLoginFinished = false;
            SDKManager.ins.ReDoLogin();
            /*
            PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, _source);
            ClientLog.Log(_source);
            */
        }
        
        public override void Destroy()
        {
            EventCore.removeRMetaEventListener(GlobalConstDefine.ConnServerSuccess, connectServerCallback);
            EventCore.removeRMetaEventListener (GlobalConstDefine.ReConnServerSuccess, reConnectServerCallback);
            _ins = null;
        }
    }
}