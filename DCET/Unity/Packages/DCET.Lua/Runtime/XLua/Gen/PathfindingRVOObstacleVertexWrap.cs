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
    public class PathfindingRVOObstacleVertexWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.ObstacleVertex);
			Utils.BeginObjectRegister(type, L, translator, 0, 14, 7, 7);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getignore", _g_get_ignore);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdir", _g_get_dir);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheight", _g_get_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlayer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnext", _g_get_next);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getprev", _g_get_prev);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setignore", _s_set_ignore);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setposition", _s_set_position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdir", _s_set_dir);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheight", _s_set_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlayer", _s_set_layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnext", _s_set_next);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setprev", _s_set_prev);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "ignore", _g_get_ignore);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dir", _g_get_dir);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "height", _g_get_height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "next", _g_get_next);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "prev", _g_get_prev);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "ignore", _s_set_ignore);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "position", _s_set_position);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dir", _s_set_dir);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "height", _s_set_height);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layer", _s_set_layer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "next", _s_set_next);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "prev", _s_set_prev);
            
			
			
			
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
					
					Pathfinding.RVO.ObstacleVertex gen_ret = new Pathfinding.RVO.ObstacleVertex();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.ObstacleVertex constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ignore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ignore);
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
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dir(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.dir);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_next(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.next);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prev(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.prev);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ignore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ignore = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.position = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dir(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.dir = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.height = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.layer = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_next(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.next = (Pathfinding.RVO.ObstacleVertex)translator.GetObject(L, 2, typeof(Pathfinding.RVO.ObstacleVertex));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prev(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.ObstacleVertex gen_to_be_invoked = (Pathfinding.RVO.ObstacleVertex)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prev = (Pathfinding.RVO.ObstacleVertex)translator.GetObject(L, 2, typeof(Pathfinding.RVO.ObstacleVertex));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
