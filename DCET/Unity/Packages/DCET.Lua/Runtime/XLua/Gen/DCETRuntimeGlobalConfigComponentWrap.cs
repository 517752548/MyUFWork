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
    public class DCETRuntimeGlobalConfigComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.GlobalConfigComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 1, 1);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getGlobalProto", _g_get_GlobalProto);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setGlobalProto", _s_set_GlobalProto);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "GlobalProto", _g_get_GlobalProto);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "GlobalProto", _s_set_GlobalProto);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetGlobal", _m_GetGlobal_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getInstance", _g_get_Instance);
            
			
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DCETRuntime.GlobalConfigComponent gen_ret = new DCETRuntime.GlobalConfigComponent();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.GlobalConfigComponent constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGlobal_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                        string gen_ret = DCETRuntime.GlobalConfigComponent.GetGlobal(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, DCETRuntime.GlobalConfigComponent.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GlobalProto(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalConfigComponent gen_to_be_invoked = (DCETRuntime.GlobalConfigComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.GlobalProto);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GlobalProto(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalConfigComponent gen_to_be_invoked = (DCETRuntime.GlobalConfigComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GlobalProto = (DCETRuntime.GlobalProto)translator.GetObject(L, 2, typeof(DCETRuntime.GlobalProto));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
