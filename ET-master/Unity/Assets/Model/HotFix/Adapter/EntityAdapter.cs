using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

namespace ET
{   
    public class EntityAdapter : CrossBindingAdaptor
    {
        static CrossBindingMethodInfo mDispose_0 = new CrossBindingMethodInfo("Dispose");
        static CrossBindingMethodInfo mBeginInit_1 = new CrossBindingMethodInfo("BeginInit");
        static CrossBindingMethodInfo mEndInit_2 = new CrossBindingMethodInfo("EndInit");
        public override Type BaseCLRType
        {
            get
            {
                return typeof(ET.Entity);
            }
        }

        public override Type AdaptorType
        {
            get
            {
                return typeof(Adapter);
            }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adapter(appdomain, instance);
        }

        public class Adapter : ET.Entity, CrossBindingAdaptorType
        {
            ILTypeInstance instance;
            ILRuntime.Runtime.Enviorment.AppDomain appdomain;

            public Adapter()
            {

            }

            public Adapter(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance { get { return instance; } }

            public override void Dispose()
            {
                if (mDispose_0.CheckShouldInvokeBase(this.instance))
                    base.Dispose();
                else
                    mDispose_0.Invoke(this.instance);
            }

            public override void BeginInit()
            {
                if (mBeginInit_1.CheckShouldInvokeBase(this.instance))
                    base.BeginInit();
                else
                    mBeginInit_1.Invoke(this.instance);
            }

            public override void EndInit()
            {
                if (mEndInit_2.CheckShouldInvokeBase(this.instance))
                    base.EndInit();
                else
                    mEndInit_2.Invoke(this.instance);
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                {
                    return instance.ToString();
                }
                else
                    return instance.Type.FullName;
            }
        }
    }
}

