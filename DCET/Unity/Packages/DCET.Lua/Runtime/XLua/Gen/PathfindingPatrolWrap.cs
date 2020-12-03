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
    public class PathfindingPatrolWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Patrol);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 2, 2);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettargets", _g_get_targets);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdelay", _g_get_delay);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "settargets", _s_set_targets);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdelay", _s_set_delay);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "targets", _g_get_targets);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "delay", _g_get_delay);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "targets", _s_set_targets);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "delay", _s_set_delay);
            
			
			
			
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
					
					Pathfinding.Patrol gen_ret = new Pathfinding.Patrol();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Patrol constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targets(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Patrol gen_to_be_invoked = (Pathfinding.Patrol)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.targets);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_delay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Patrol gen_to_be_invoked = (Pathfinding.Patrol)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.delay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targets(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Patrol gen_to_be_invoked = (Pathfinding.Patrol)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.targets = (UnityEngine.Transform[])translator.GetObject(L, 2, typeof(UnityEngine.Transform[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_delay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Patrol gen_to_be_invoked = (Pathfinding.Patrol)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.delay = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
