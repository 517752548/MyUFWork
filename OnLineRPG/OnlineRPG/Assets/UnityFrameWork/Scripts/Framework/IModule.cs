namespace BetaFramework
{
    public abstract class IModule
    {
        //private string m_ModuleName;
        public bool Enable = true;

        public virtual void Init()
        {

        }

        public virtual void Execute(float deltaTime)
        {

        }

        public virtual void Shut()
        {

        }

        public virtual void Pause(bool pause)
        {

        }
        public virtual void OnEnterUI(GameUI UiToSwitch)
        {
            
        }
        
        //public void SetModuleName(string name)
        //{
        //    m_ModuleName = name;
        //}

        //public string GetModuleName()
        //{
        //    return m_ModuleName;
        //}
    };
}