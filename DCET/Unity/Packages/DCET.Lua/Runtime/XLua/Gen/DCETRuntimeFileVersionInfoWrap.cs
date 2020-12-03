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
    public class DCETRuntimeFileVersionInfoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.FileVersionInfo);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 3, 3);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFile", _g_get_File);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMD5", _g_get_MD5);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getSize", _g_get_Size);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setFile", _s_set_File);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setMD5", _s_set_MD5);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setSize", _s_set_Size);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "File", _g_get_File);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MD5", _g_get_MD5);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Size", _g_get_Size);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "File", _s_set_File);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MD5", _s_set_MD5);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Size", _s_set_Size);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DCETRuntime.FileVersionInfo gen_ret = new DCETRuntime.FileVersionInfo();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.FileVersionInfo constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_File(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.File);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MD5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.MD5);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.Size);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_File(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.File = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MD5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MD5 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.FileVersionInfo gen_to_be_invoked = (DCETRuntime.FileVersionInfo)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Size = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
