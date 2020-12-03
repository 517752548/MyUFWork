#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PFNNInfoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.NNInfo);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 2, 0);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnode", _g_get_node);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "node", _g_get_node);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Explicit", _m_op_Explicit);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				PF.NNInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<PF.NNInfoInternal>(L, 2))
				{
					PF.NNInfoInternal _internalInfo;translator.Get(L, 2, out _internalInfo);
					
					PF.NNInfo gen_ret = new PF.NNInfo(_internalInfo);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(PF.NNInfo));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NNInfo constructor!");
            
        }
        
		
        
		
        
        

		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_Explicit(RealStatePtr L)
        {					
			
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                PF.NNInfo rightside;translator.Get(L, 1, out rightside);
				
				translator.PushUnityEngineVector3(L, (UnityEngine.Vector3) rightside)
				;
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_node(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.node);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NNInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
