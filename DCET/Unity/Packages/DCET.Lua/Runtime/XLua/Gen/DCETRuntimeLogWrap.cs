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
    public class DCETRuntimeLogWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.Log);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 6, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Warning", _m_Warning_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Info", _m_Info_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exception", _m_Exception_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Error", _m_Error_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Debug", _m_Debug_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "DCETRuntime.Log does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Warning_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _msg = LuaAPI.lua_tostring(L, 1);
                    
                    DCETRuntime.Log.Warning( 
                        _msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Info_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _msg = LuaAPI.lua_tostring(L, 1);
                    
                    DCETRuntime.Log.Info( 
                        _msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exception_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Exception _e = (System.Exception)translator.GetObject(L, 1, typeof(System.Exception));
                    
                    DCETRuntime.Log.Exception( 
                        _e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Error_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _msg = LuaAPI.lua_tostring(L, 1);
                    
                    DCETRuntime.Log.Error( 
                        _msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Debug_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _msg = LuaAPI.lua_tostring(L, 1);
                    
                    DCETRuntime.Log.Debug( 
                        _msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
