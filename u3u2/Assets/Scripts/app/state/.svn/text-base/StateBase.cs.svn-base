
namespace app.state
{
    public class StateBase
    {
        public StateDef state;

        public float enterTime;
        public float liveTime;

        /// <summary>
        /// 能否离开当前状态，默认为可以离开
        /// </summary>
        /// <returns></returns>
        public virtual bool canLeave()
        {
            return true;
        }

        /// <summary>
        /// 能否进入当前状态，默认为可以进入
        /// </summary>
        /// <returns></returns>
        public virtual bool canEnter()
        {
            return true;
        }
        
        public virtual void onEnter()
        {
            ClientLog.Log("onEnter state " + state);
        }

        public virtual void onLeave(StateDef nextState)
        {
            ClientLog.Log("onLeave state " + state);
        }

        public virtual void onUpdate()
        {
        }

        public virtual void onFixedUpdate()
        {

        }

        public virtual void onLateUpdate()
        {
            
        }
        
        public virtual void DoUpdate(float deltaTime)
        {
            
        }
    }
}
