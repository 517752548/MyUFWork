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
    public class PathfindingRVORVOSimulatorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.RVOSimulator);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 6, 6);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSimulator", _m_GetSimulator);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdesiredSimulationFPS", _g_get_desiredSimulationFPS);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getworkerThreads", _g_get_workerThreads);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdoubleBuffering", _g_get_doubleBuffering);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsymmetryBreakingBias", _g_get_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmovementPlane", _g_get_movementPlane);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdrawObstacles", _g_get_drawObstacles);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdesiredSimulationFPS", _s_set_desiredSimulationFPS);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setworkerThreads", _s_set_workerThreads);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdoubleBuffering", _s_set_doubleBuffering);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsymmetryBreakingBias", _s_set_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmovementPlane", _s_set_movementPlane);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdrawObstacles", _s_set_drawObstacles);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "desiredSimulationFPS", _g_get_desiredSimulationFPS);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "workerThreads", _g_get_workerThreads);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "doubleBuffering", _g_get_doubleBuffering);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "symmetryBreakingBias", _g_get_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "movementPlane", _g_get_movementPlane);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "drawObstacles", _g_get_drawObstacles);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "desiredSimulationFPS", _s_set_desiredSimulationFPS);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "workerThreads", _s_set_workerThreads);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "doubleBuffering", _s_set_doubleBuffering);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "symmetryBreakingBias", _s_set_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "movementPlane", _s_set_movementPlane);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "drawObstacles", _s_set_drawObstacles);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 1, 0);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getactive", _g_get_active);
            
			
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "active", _g_get_active);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.RVO.RVOSimulator gen_ret = new Pathfinding.RVO.RVOSimulator();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOSimulator constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSimulator(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Pathfinding.RVO.Simulator gen_ret = gen_to_be_invoked.GetSimulator(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_active(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.RVO.RVOSimulator.active);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_desiredSimulationFPS(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.desiredSimulationFPS);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_workerThreads(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                translator.PushPFThreadCount(L, gen_to_be_invoked.workerThreads);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_doubleBuffering(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.doubleBuffering);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_symmetryBreakingBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.symmetryBreakingBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_movementPlane(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVOMovementPlane(L, gen_to_be_invoked.movementPlane);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drawObstacles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.drawObstacles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_desiredSimulationFPS(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.desiredSimulationFPS = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_workerThreads(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                PF.ThreadCount gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.workerThreads = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_doubleBuffering(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.doubleBuffering = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_symmetryBreakingBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.symmetryBreakingBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_movementPlane(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.MovementPlane gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.movementPlane = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_drawObstacles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOSimulator gen_to_be_invoked = (Pathfinding.RVO.RVOSimulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.drawObstacles = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
