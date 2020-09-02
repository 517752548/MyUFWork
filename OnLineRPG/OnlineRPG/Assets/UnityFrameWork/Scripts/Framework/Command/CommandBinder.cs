using System;

namespace BetaFramework
{
    public static class CommandBinder
    {
        private static Binding<Enum, ICommand> m_Bindings = new Binding<Enum, ICommand>();

        public static void AddBinding<T>(Enum key) where T : ICommand
        {
            Type cmdType = typeof(T);
            object commadnInstance = Activator.CreateInstance(cmdType);

            if (m_Bindings.IsBound(key))
            {
                ICommand command = (ICommand)commadnInstance;
                command.Initilize();

                m_Bindings.Bind(key, command);
            }
            else
            {
                ICommand command = (ICommand)commadnInstance;
                command.Initilize();

                m_Bindings.Bind(key, command);
            }
        }

        public static void RemoveBinding(Enum key)
        {
            if (m_Bindings.IsBound(key))
            {
                m_Bindings[key].Release();
                m_Bindings.Clear(key);
            }
        }

        public static void RemoveAllBinding()
        {
            m_Bindings.Clear();
        }

        private static object ResolveBinding(Enum key)
        {
            return !m_Bindings.IsBound(key) ? null : m_Bindings.Resolve(key);
        }

        public static void DispatchBinding(Enum key, object data = null)
        {
            try
            {
                var command = ResolveBinding(key) as ICommand;
                if (command == null) return;

                command.Data = data;
                command.Execute();
            }
            catch (Exception ex)
            {
                LoggerHelper.Exception(ex);
            }
        }
    }

    public class CmdParamData
    {
        private object[] datas;

        public CmdParamData(params object[] args)
        {
            datas = args;
        }

        public T Get<T>(int index, T defVal)
        {
            if (index >= 0 && datas != null && index < datas.Length)
                return (T)datas[index];
            return defVal;
        }

        public int Count { get { return datas != null ? datas.Length : 0; } }
    }
}