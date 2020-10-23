using app.zone;

namespace app.state
{
    public class ZoneState : StateBase
    {
        public ZoneState()
        {
            this.state = StateDef.zoneState;
        }

        public override bool canEnter()
        {
            return true;
        }

        public override bool canLeave()
        {
            //TODO
            return true;
        }

        public override void onEnter()
        {
            base.onEnter();
            ZoneManager.ins.EnterZoneState();
        }

        public override void onLeave(StateDef nextState)
        {
            base.onLeave(nextState);
            ZoneManager.ins.ExitZoneState(nextState);
            EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
            EffectUtil.Ins.RemoveEffect(ClientConstantDef.GUAJI_EFFECT_NAME);

            EffectUtil.Ins.RemoveEffect("common_shengji");
        }

        public override void onUpdate()
        {
            base.onUpdate();
            ZoneManager.ins.Update();
        }

        public override void onFixedUpdate()
        {
            base.onFixedUpdate();
            ZoneManager.ins.FixedUpdate();
        }

        public override void onLateUpdate()
        {
            base.onLateUpdate();
            ZoneManager.ins.LateUpdate();
        }
        
        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            ZoneManager.ins.DoUpdate(deltaTime);
        }
    }
}
