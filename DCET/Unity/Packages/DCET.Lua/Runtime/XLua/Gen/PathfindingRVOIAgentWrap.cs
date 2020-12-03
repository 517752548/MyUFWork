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
    public class PathfindingRVOIAgentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.IAgent);
			Utils.BeginObjectRegister(type, L, translator, 0, 31, 15, 13);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTarget", _m_SetTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCollisionNormal", _m_SetCollisionNormal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForceSetVelocity", _m_ForceSetVelocity);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPosition", _g_get_Position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getElevationCoordinate", _g_get_ElevationCoordinate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCalculatedTargetPoint", _g_get_CalculatedTargetPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCalculatedSpeed", _g_get_CalculatedSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLocked", _g_get_Locked);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getRadius", _g_get_Radius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getHeight", _g_get_Height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getAgentTimeHorizon", _g_get_AgentTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getObstacleTimeHorizon", _g_get_ObstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMaxNeighbours", _g_get_MaxNeighbours);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getNeighbourCount", _g_get_NeighbourCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLayer", _g_get_Layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCollidesWith", _g_get_CollidesWith);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDebugDraw", _g_get_DebugDraw);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPriority", _g_get_Priority);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPosition", _s_set_Position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setElevationCoordinate", _s_set_ElevationCoordinate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setLocked", _s_set_Locked);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setRadius", _s_set_Radius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setHeight", _s_set_Height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setAgentTimeHorizon", _s_set_AgentTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setObstacleTimeHorizon", _s_set_ObstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setMaxNeighbours", _s_set_MaxNeighbours);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setLayer", _s_set_Layer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setCollidesWith", _s_set_CollidesWith);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setDebugDraw", _s_set_DebugDraw);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPriority", _s_set_Priority);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPreCalculationCallback", _s_set_PreCalculationCallback);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Position", _g_get_Position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ElevationCoordinate", _g_get_ElevationCoordinate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CalculatedTargetPoint", _g_get_CalculatedTargetPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CalculatedSpeed", _g_get_CalculatedSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Locked", _g_get_Locked);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Radius", _g_get_Radius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Height", _g_get_Height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AgentTimeHorizon", _g_get_AgentTimeHorizon);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ObstacleTimeHorizon", _g_get_ObstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxNeighbours", _g_get_MaxNeighbours);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "NeighbourCount", _g_get_NeighbourCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Layer", _g_get_Layer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CollidesWith", _g_get_CollidesWith);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DebugDraw", _g_get_DebugDraw);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Priority", _g_get_Priority);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Position", _s_set_Position);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ElevationCoordinate", _s_set_ElevationCoordinate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Locked", _s_set_Locked);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Radius", _s_set_Radius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Height", _s_set_Height);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AgentTimeHorizon", _s_set_AgentTimeHorizon);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ObstacleTimeHorizon", _s_set_ObstacleTimeHorizon);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaxNeighbours", _s_set_MaxNeighbours);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Layer", _s_set_Layer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CollidesWith", _s_set_CollidesWith);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DebugDraw", _s_set_DebugDraw);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Priority", _s_set_Priority);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PreCalculationCallback", _s_set_PreCalculationCallback);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.RVO.IAgent does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTarget(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _targetPoint;translator.Get(L, 2, out _targetPoint);
                    float _desiredSpeed = (float)LuaAPI.lua_tonumber(L, 3);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetTarget( 
                        _targetPoint, 
                        _desiredSpeed, 
                        _maxSpeed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCollisionNormal(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _normal;translator.Get(L, 2, out _normal);
                    
                    gen_to_be_invoked.SetCollisionNormal( 
                        _normal );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceSetVelocity(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _velocity;translator.Get(L, 2, out _velocity);
                    
                    gen_to_be_invoked.ForceSetVelocity( 
                        _velocity );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.Position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ElevationCoordinate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.ElevationCoordinate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CalculatedTargetPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.CalculatedTargetPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CalculatedSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.CalculatedSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Locked);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Radius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AgentTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.AgentTimeHorizon);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ObstacleTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.ObstacleTimeHorizon);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxNeighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxNeighbours);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeighbourCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.NeighbourCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.Layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CollidesWith(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.CollidesWith);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugDraw(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.DebugDraw);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Priority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Position = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ElevationCoordinate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ElevationCoordinate = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Locked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Locked = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Radius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Height = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AgentTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AgentTimeHorizon = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ObstacleTimeHorizon(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ObstacleTimeHorizon = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxNeighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaxNeighbours = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Layer = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CollidesWith(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.CollidesWith = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DebugDraw(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DebugDraw = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Priority = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreCalculationCallback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.IAgent gen_to_be_invoked = (Pathfinding.RVO.IAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.PreCalculationCallback = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
