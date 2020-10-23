using System;
using System.Collections.Generic;
using app.main;
using app.report;

namespace app.state
{
    public class LoginState : StateBase
    {
        public LoginState()
        {
            this.state = StateDef.login;
        }

        public override void onEnter()
        {
            base.onEnter();

            onBackToLogin();

            DataReport.Instance.Game_SetEventBeforeLogin("enter_LoginState","enter","success");
            
            //打开登录面板
            //WndManager.open(GlobalConstDefine.LoginView_Name);
            SDKManager.ins.ShowLogin();
        }

        public override void onLeave(StateDef nextState)
        {
            base.onLeave(nextState);
        }

        public override void onUpdate()
        {
            base.onUpdate();
        }

        private void onBackToLogin()
        {
            //清除连接状态
            GameConnection.Instance.onBackToLogin();
            
            //玩家各个model的数据清除
            Dictionary<Type, AbsModel>.ValueCollection models = AbsModel.getAllModel();
        }
    }
}
