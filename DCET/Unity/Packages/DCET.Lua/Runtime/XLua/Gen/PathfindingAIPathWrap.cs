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
    public class PathfindingAIPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AIPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 25, 14, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Teleport", _m_Teleport);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTargetReached", _m_OnTargetReached);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getremainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getreachedEndOfPath", _g_get_reachedEndOfPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethasPath", _g_get_hasPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathPending", _g_get_pathPending);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsteeringTarget", _g_get_steeringTarget);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxAcceleration", _g_get_maxAcceleration);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrotationSpeed", _g_get_rotationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getslowdownDistance", _g_get_slowdownDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpickNextWaypointDist", _g_get_pickNextWaypointDist);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendReachedDistance", _g_get_endReachedDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getalwaysDrawGizmos", _g_get_alwaysDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getslowWhenNotFacingTarget", _g_get_slowWhenNotFacingTarget);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwhenCloseToDestination", _g_get_whenCloseToDestination);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstrainInsideGraph", _g_get_constrainInsideGraph);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxAcceleration", _s_set_maxAcceleration);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrotationSpeed", _s_set_rotationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setslowdownDistance", _s_set_slowdownDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpickNextWaypointDist", _s_set_pickNextWaypointDist);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendReachedDistance", _s_set_endReachedDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setalwaysDrawGizmos", _s_set_alwaysDrawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setslowWhenNotFacingTarget", _s_set_slowWhenNotFacingTarget);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwhenCloseToDestination", _s_set_whenCloseToDestination);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstrainInsideGraph", _s_set_constrainInsideGraph);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "remainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "reachedEndOfPath", _g_get_reachedEndOfPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hasPath", _g_get_hasPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathPending", _g_get_pathPending);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "steeringTarget", _g_get_steeringTarget);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxAcceleration", _g_get_maxAcceleration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationSpeed", _g_get_rotationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "slowdownDistance", _g_get_slowdownDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pickNextWaypointDist", _g_get_pickNextWaypointDist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endReachedDistance", _g_get_endReachedDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "alwaysDrawGizmos", _g_get_alwaysDrawGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "slowWhenNotFacingTarget", _g_get_slowWhenNotFacingTarget);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "whenCloseToDestination", _g_get_whenCloseToDestination);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constrainInsideGraph", _g_get_constrainInsideGraph);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxAcceleration", _s_set_maxAcceleration);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotationSpeed", _s_set_rotationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "slowdownDistance", _s_set_slowdownDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pickNextWaypointDist", _s_set_pickNextWaypointDist);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endReachedDistance", _s_set_endReachedDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "alwaysDrawGizmos", _s_set_alwaysDrawGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "slowWhenNotFacingTarget", _s_set_slowWhenNotFacingTarget);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "whenCloseToDestination", _s_set_whenCloseToDestination);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constrainInsideGraph", _s_set_constrainInsideGraph);
            
			
			
			
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
					
					Pathfinding.AIPath gen_ret = new Pathfinding.AIPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AIPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Teleport(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _newPosition;translator.Get(L, 2, out _newPosition);
                    bool _clearPath = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Teleport( 
                        _newPosition, 
                        _clearPath );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _newPosition;translator.Get(L, 2, out _newPosition);
                    
                    gen_to_be_invoked.Teleport( 
                        _newPosition );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AIPath.Teleport!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTargetReached(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnTargetReached(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_remainingDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.remainingDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reachedEndOfPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.reachedEndOfPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hasPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.hasPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathPending(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.pathPending);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_steeringTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.steeringTarget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxAcceleration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxAcceleration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.rotationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_slowdownDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.slowdownDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pickNextWaypointDist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.pickNextWaypointDist);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endReachedDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.endReachedDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alwaysDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.alwaysDrawGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_slowWhenNotFacingTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.slowWhenNotFacingTarget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_whenCloseToDestination(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                translator.PushPFCloseToDestinationMode(L, gen_to_be_invoked.whenCloseToDestination);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constrainInsideGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.constrainInsideGraph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxAcceleration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxAcceleration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rotationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_slowdownDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.slowdownDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pickNextWaypointDist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pickNextWaypointDist = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endReachedDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.endReachedDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alwaysDrawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.alwaysDrawGizmos = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_slowWhenNotFacingTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.slowWhenNotFacingTarget = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_whenCloseToDestination(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                PF.CloseToDestinationMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.whenCloseToDestination = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constrainInsideGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AIPath gen_to_be_invoked = (Pathfinding.AIPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constrainInsideGraph = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
