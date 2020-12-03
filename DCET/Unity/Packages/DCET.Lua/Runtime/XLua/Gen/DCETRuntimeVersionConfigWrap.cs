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
    public class DCETRuntimeVersionConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.VersionConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EndInit", _m_EndInit);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getVersion", _g_get_Version);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTotalSize", _g_get_TotalSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFileInfoDict", _g_get_FileInfoDict);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setVersion", _s_set_Version);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setTotalSize", _s_set_TotalSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setFileInfoDict", _s_set_FileInfoDict);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Version", _g_get_Version);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TotalSize", _g_get_TotalSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FileInfoDict", _g_get_FileInfoDict);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Version", _s_set_Version);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TotalSize", _s_set_TotalSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FileInfoDict", _s_set_FileInfoDict);
            
			
			
			
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
					
					DCETRuntime.VersionConfig gen_ret = new DCETRuntime.VersionConfig();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.VersionConfig constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndInit(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.EndInit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Version);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TotalSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.TotalSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FileInfoDict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.FileInfoDict);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Version = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TotalSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TotalSize = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FileInfoDict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.VersionConfig gen_to_be_invoked = (DCETRuntime.VersionConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FileInfoDict = (System.Collections.Generic.Dictionary<string, DCETRuntime.FileVersionInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, DCETRuntime.FileVersionInfo>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
