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
    public class PathfindingExamplesMineBotAnimationWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Examples.MineBotAnimation);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 4);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getanim", _g_get_anim);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsleepVelocity", _g_get_sleepVelocity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getanimationSpeed", _g_get_animationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendOfPathEffect", _g_get_endOfPathEffect);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setanim", _s_set_anim);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsleepVelocity", _s_set_sleepVelocity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setanimationSpeed", _s_set_animationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendOfPathEffect", _s_set_endOfPathEffect);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "anim", _g_get_anim);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sleepVelocity", _g_get_sleepVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "animationSpeed", _g_get_animationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endOfPathEffect", _g_get_endOfPathEffect);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "anim", _s_set_anim);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sleepVelocity", _s_set_sleepVelocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "animationSpeed", _s_set_animationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endOfPathEffect", _s_set_endOfPathEffect);
            
			
			
			
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
					
					Pathfinding.Examples.MineBotAnimation gen_ret = new Pathfinding.Examples.MineBotAnimation();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Examples.MineBotAnimation constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anim(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.anim);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sleepVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.sleepVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_animationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.animationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endOfPathEffect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.endOfPathEffect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anim(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.anim = (UnityEngine.Animation)translator.GetObject(L, 2, typeof(UnityEngine.Animation));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sleepVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sleepVelocity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_animationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.animationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endOfPathEffect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Examples.MineBotAnimation gen_to_be_invoked = (Pathfinding.Examples.MineBotAnimation)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.endOfPathEffect = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
