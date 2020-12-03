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
    public class PathfindingAstarProfilerProfilePointWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarProfiler.ProfilePoint);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 4);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwatch", _g_get_watch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettotalCalls", _g_get_totalCalls);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettmpBytes", _g_get_tmpBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettotalBytes", _g_get_totalBytes);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwatch", _s_set_watch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settotalCalls", _s_set_totalCalls);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settmpBytes", _s_set_tmpBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settotalBytes", _s_set_totalBytes);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "watch", _g_get_watch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "totalCalls", _g_get_totalCalls);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tmpBytes", _g_get_tmpBytes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "totalBytes", _g_get_totalBytes);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "watch", _s_set_watch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "totalCalls", _s_set_totalCalls);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tmpBytes", _s_set_tmpBytes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "totalBytes", _s_set_totalBytes);
            
			
			
			
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
					
					Pathfinding.AstarProfiler.ProfilePoint gen_ret = new Pathfinding.AstarProfiler.ProfilePoint();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarProfiler.ProfilePoint constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_watch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.watch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_totalCalls(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.totalCalls);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tmpBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.tmpBytes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_totalBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.totalBytes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_watch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.watch = (System.Diagnostics.Stopwatch)translator.GetObject(L, 2, typeof(System.Diagnostics.Stopwatch));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_totalCalls(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.totalCalls = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tmpBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tmpBytes = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_totalBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarProfiler.ProfilePoint gen_to_be_invoked = (Pathfinding.AstarProfiler.ProfilePoint)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.totalBytes = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
