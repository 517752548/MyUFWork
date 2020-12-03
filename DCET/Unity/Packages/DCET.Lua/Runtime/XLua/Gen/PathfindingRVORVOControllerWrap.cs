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
    public class PathfindingRVORVOControllerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.RVOController);
			Utils.BeginObjectRegister(type, L, translator, 0, 36, 17, 13);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateMovementDelta", _m_CalculateMovementDelta);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCollisionNormal", _m_SetCollisionNormal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "To2D", _m_To2D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "To3D", _m_To3D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTarget", _m_SetTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Move", _m_Move);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmovementPlane", _g_get_movementPlane);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrvoAgent", _g_get_rvoAgent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsimulator", _g_get_simulator);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvelocity", _g_get_velocity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getradius", _g_get_radius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheight", _g_get_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlocked", _g_get_locked);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlockWhenNotMoving", _g_get_lockWhenNotMoving);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getagentTimeHorizon", _g_get_agentTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getobstacleTimeHorizon", _g_get_obstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxNeighbours", _g_get_maxNeighbours);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlayer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcollidesWith", _g_get_collidesWith);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpriority", _g_get_priority);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcenter", _g_get_center);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebug", _g_get_debug);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvelocity", _s_set_velocity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setradius", _s_set_radius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheight", _s_set_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlocked", _s_set_locked);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlockWhenNotMoving", _s_set_lockWhenNotMoving);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setagentTimeHorizon", _s_set_agentTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setobstacleTimeHorizon", _s_set_obstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxNeighbours", _s_set_maxNeighbours);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlayer", _s_set_layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcollidesWith", _s_set_collidesWith);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpriority", _s_set_priority);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcenter", _s_set_center);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebug", _s_set_debug);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "movementPlane", _g_get_movementPlane);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rvoAgent", _g_get_rvoAgent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "simulator", _g_get_simulator);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "velocity", _g_get_velocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "radius", _g_get_radius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "height", _g_get_height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "locked", _g_get_locked);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lockWhenNotMoving", _g_get_lockWhenNotMoving);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "agentTimeHorizon", _g_get_agentTimeHorizon);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "obstacleTimeHorizon", _g_get_obstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNeighbours", _g_get_maxNeighbours);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "collidesWith", _g_get_collidesWith);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "priority", _g_get_priority);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "center", _g_get_center);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debug", _g_get_debug);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "velocity", _s_set_velocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "radius", _s_set_radius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "height", _s_set_height);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "locked", _s_set_locked);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lockWhenNotMoving", _s_set_lockWhenNotMoving);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "agentTimeHorizon", _s_set_agentTimeHorizon);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "obstacleTimeHorizon", _s_set_obstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxNeighbours", _s_set_maxNeighbours);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layer", _s_set_layer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "collidesWith", _s_set_collidesWith);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "priority", _s_set_priority);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "center", _s_set_center);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debug", _s_set_debug);
            
			
			
			
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
					
					Pathfinding.RVO.RVOController gen_ret = new Pathfinding.RVO.RVOController();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOController constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateMovementDelta(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.CalculateMovementDelta( 
                        _deltaTime );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.CalculateMovementDelta( 
                        _position, 
                        _deltaTime );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOController.CalculateMovementDelta!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCollisionNormal(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _normal;translator.Get(L, 2, out _normal);
                    
                    gen_to_be_invoked.SetCollisionNormal( 
                        _normal );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_To2D(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.To2D( 
                        _p );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    float _elevation;
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.To2D( 
                        _p, 
                        out _elevation );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _elevation);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOController.To2D!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_To3D(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _p;translator.Get(L, 2, out _p);
                    float _elevationCoordinate = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.To3D( 
                        _p, 
                        _elevationCoordinate );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTarget(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 2, out _pos);
                    float _speed = (float)LuaAPI.lua_tonumber(L, 3);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetTarget( 
                        _pos, 
                        _speed, 
                        _maxSpeed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Move(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _vel;translator.Get(L, 2, out _vel);
                    
                    gen_to_be_invoked.Move( 
                        _vel );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_movementPlane(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVOMovementPlane(L, gen_to_be_invoked.movementPlane);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rvoAgent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.rvoAgent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_simulator(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.simulator);
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
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_velocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.velocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.radius);
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
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.locked);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lockWhenNotMoving(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.lockWhenNotMoving);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_agentTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.agentTimeHorizon);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_obstacleTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.obstacleTimeHorizon);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxNeighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxNeighbours);
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
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_collidesWith(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.collidesWith);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.priority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.center);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debug(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.debug);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_velocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.velocity = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.radius = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.height = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.locked = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lockWhenNotMoving(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lockWhenNotMoving = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_agentTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.agentTimeHorizon = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_obstacleTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.obstacleTimeHorizon = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxNeighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxNeighbours = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.layer = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_collidesWith(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.collidesWith = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.priority = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.center = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debug(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOController gen_to_be_invoked = (Pathfinding.RVO.RVOController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debug = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
