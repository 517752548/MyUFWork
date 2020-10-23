namespace app.state
{
    public class InitState : StateBase
    {
        public InitState()
        {
            this.state = StateDef.init;
        }

        public override void onEnter()
        {
            base.onEnter();
            //StateManager.Ins.changeState(StateDef.initUI);
        }

        public override void onLeave(StateDef nextState)
        {
            base.onLeave(nextState);
        }

        public override void onUpdate()
        {
            base.onUpdate();

            //转到校验配置状态
        }
    }
}
