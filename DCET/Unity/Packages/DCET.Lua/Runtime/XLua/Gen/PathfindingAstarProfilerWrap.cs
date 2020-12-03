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
    public class PathfindingAstarProfilerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarProfiler);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 17, 2, 2);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "InitializeFastProfile", _m_InitializeFastProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartFastProfile", _m_StartFastProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndFastProfile", _m_EndFastProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndProfile", _m_EndProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartProfile", _m_StartProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Reset", _m_Reset_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintFastResults", _m_PrintFastResults_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintResults", _m_PrintResults_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getfastProfiles", _g_get_fastProfiles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getfastProfileNames", _g_get_fastProfileNames);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setfastProfiles", _s_set_fastProfiles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setfastProfileNames", _s_set_fastProfileNames);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "fastProfiles", _g_get_fastProfiles);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "fastProfileNames", _g_get_fastProfileNames);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "fastProfiles", _s_set_fastProfiles);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "fastProfileNames", _s_set_fastProfileNames);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.AstarProfiler does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeFastProfile_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string[] _profileNames = (string[])translator.GetObject(L, 1, typeof(string[]));
                    
                    Pathfinding.AstarProfiler.InitializeFastProfile( 
                        _profileNames );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartFastProfile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _tag = LuaAPI.xlua_tointeger(L, 1);
                    
                    Pathfinding.AstarProfiler.StartFastProfile( 
                        _tag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndFastProfile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _tag = LuaAPI.xlua_tointeger(L, 1);
                    
                    Pathfinding.AstarProfiler.EndFastProfile( 
                        _tag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndProfile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                    Pathfinding.AstarProfiler.EndProfile(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _tag = LuaAPI.lua_tostring(L, 1);
                    
                    Pathfinding.AstarProfiler.EndProfile( 
                        _tag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarProfiler.EndProfile!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartProfile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _tag = LuaAPI.lua_tostring(L, 1);
                    
                    Pathfinding.AstarProfiler.StartProfile( 
                        _tag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.AstarProfiler.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintFastResults_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.AstarProfiler.PrintFastResults(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintResults_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.AstarProfiler.PrintResults(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fastProfiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.AstarProfiler.fastProfiles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fastProfileNames(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.AstarProfiler.fastProfileNames);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fastProfiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.AstarProfiler.fastProfiles = (Pathfinding.AstarProfiler.ProfilePoint[])translator.GetObject(L, 1, typeof(Pathfinding.AstarProfiler.ProfilePoint[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fastProfileNames(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.AstarProfiler.fastProfileNames = (string[])translator.GetObject(L, 1, typeof(string[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
