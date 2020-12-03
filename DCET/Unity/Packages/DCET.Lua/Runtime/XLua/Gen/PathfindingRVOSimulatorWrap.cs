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
    public class PathfindingRVOSimulatorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.Simulator);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 7, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAgents", _m_GetAgents);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObstacles", _m_GetObstacles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearAgents", _m_ClearAgents);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAgent", _m_AddAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveAgent", _m_RemoveAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddObstacle", _m_AddObstacle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateObstacle", _m_UpdateObstacle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveObstacle", _m_RemoveObstacle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateObstacles", _m_UpdateObstacles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getQuadtree", _g_get_Quadtree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDeltaTime", _g_get_DeltaTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMultithreading", _g_get_Multithreading);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDesiredDeltaTime", _g_get_DesiredDeltaTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getobstacles", _g_get_obstacles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsymmetryBreakingBias", _g_get_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmovementPlane", _g_get_movementPlane);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setDesiredDeltaTime", _s_set_DesiredDeltaTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setobstacles", _s_set_obstacles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsymmetryBreakingBias", _s_set_symmetryBreakingBias);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Quadtree", _g_get_Quadtree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeltaTime", _g_get_DeltaTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Multithreading", _g_get_Multithreading);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DesiredDeltaTime", _g_get_DesiredDeltaTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "obstacles", _g_get_obstacles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "symmetryBreakingBias", _g_get_symmetryBreakingBias);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "movementPlane", _g_get_movementPlane);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "DesiredDeltaTime", _s_set_DesiredDeltaTime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "obstacles", _s_set_obstacles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "symmetryBreakingBias", _s_set_symmetryBreakingBias);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && translator.Assignable<Pathfinding.RVO.MovementPlane>(L, 4))
				{
					int _workers = LuaAPI.xlua_tointeger(L, 2);
					bool _doubleBuffering = LuaAPI.lua_toboolean(L, 3);
					Pathfinding.RVO.MovementPlane _movementPlane;translator.Get(L, 4, out _movementPlane);
					
					Pathfinding.RVO.Simulator gen_ret = new Pathfinding.RVO.Simulator(_workers, _doubleBuffering, _movementPlane);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.Simulator constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAgents(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<Pathfinding.RVO.Sampled.Agent> gen_ret = gen_to_be_invoked.GetAgents(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObstacles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<Pathfinding.RVO.ObstacleVertex> gen_ret = gen_to_be_invoked.GetObstacles(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAgents(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearAgents(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAgent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<Pathfinding.RVO.IAgent>(L, 2)) 
                {
                    Pathfinding.RVO.IAgent _agent = (Pathfinding.RVO.IAgent)translator.GetObject(L, 2, typeof(Pathfinding.RVO.IAgent));
                    
                        Pathfinding.RVO.IAgent gen_ret = gen_to_be_invoked.AddAgent( 
                        _agent );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _position;translator.Get(L, 2, out _position);
                    float _elevationCoordinate = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        Pathfinding.RVO.IAgent gen_ret = gen_to_be_invoked.AddAgent( 
                        _position, 
                        _elevationCoordinate );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.Simulator.AddAgent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAgent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RVO.IAgent _agent = (Pathfinding.RVO.IAgent)translator.GetObject(L, 2, typeof(Pathfinding.RVO.IAgent));
                    
                    gen_to_be_invoked.RemoveAgent( 
                        _agent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddObstacle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<Pathfinding.RVO.ObstacleVertex>(L, 2)) 
                {
                    Pathfinding.RVO.ObstacleVertex _v = (Pathfinding.RVO.ObstacleVertex)translator.GetObject(L, 2, typeof(Pathfinding.RVO.ObstacleVertex));
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _v );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _cycle = LuaAPI.lua_toboolean(L, 4);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _vertices, 
                        _height, 
                        _cycle );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _vertices, 
                        _height );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 2, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 3, out _b);
                    float _height = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _a, 
                        _b, 
                        _height );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Matrix4x4>(L, 4)&& translator.Assignable<Pathfinding.RVO.RVOLayer>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 4, out _matrix);
                    Pathfinding.RVO.RVOLayer _layer;translator.Get(L, 5, out _layer);
                    bool _cycle = LuaAPI.lua_toboolean(L, 6);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _vertices, 
                        _height, 
                        _matrix, 
                        _layer, 
                        _cycle );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Matrix4x4>(L, 4)&& translator.Assignable<Pathfinding.RVO.RVOLayer>(L, 5)) 
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 4, out _matrix);
                    Pathfinding.RVO.RVOLayer _layer;translator.Get(L, 5, out _layer);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _vertices, 
                        _height, 
                        _matrix, 
                        _layer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Matrix4x4>(L, 4)) 
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 4, out _matrix);
                    
                        Pathfinding.RVO.ObstacleVertex gen_ret = gen_to_be_invoked.AddObstacle( 
                        _vertices, 
                        _height, 
                        _matrix );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.Simulator.AddObstacle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateObstacle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RVO.ObstacleVertex _obstacle = (Pathfinding.RVO.ObstacleVertex)translator.GetObject(L, 2, typeof(Pathfinding.RVO.ObstacleVertex));
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 4, out _matrix);
                    
                    gen_to_be_invoked.UpdateObstacle( 
                        _obstacle, 
                        _vertices, 
                        _matrix );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveObstacle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RVO.ObstacleVertex _v = (Pathfinding.RVO.ObstacleVertex)translator.GetObject(L, 2, typeof(Pathfinding.RVO.ObstacleVertex));
                    
                    gen_to_be_invoked.RemoveObstacle( 
                        _v );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateObstacles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateObstacles(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quadtree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Quadtree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeltaTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.DeltaTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Multithreading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Multithreading);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DesiredDeltaTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.DesiredDeltaTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_obstacles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.obstacles);
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
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVOMovementPlane(L, gen_to_be_invoked.movementPlane);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DesiredDeltaTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DesiredDeltaTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_obstacles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.obstacles = (System.Collections.Generic.List<Pathfinding.RVO.ObstacleVertex>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.RVO.ObstacleVertex>));
            
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
			
                Pathfinding.RVO.Simulator gen_to_be_invoked = (Pathfinding.RVO.Simulator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.symmetryBreakingBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
