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
    public class PathfindingAILerpWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AILerp);
			Utils.BeginObjectRegister(type, L, translator, 0, 43, 20, 15);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDisable", _m_OnDisable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Teleport", _m_Teleport);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SearchPath", _m_SearchPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTargetReached", _m_OnTargetReached);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPath", _m_SetPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFeetPosition", _m_GetFeetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MovementUpdate", _m_MovementUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FinalizeMovement", _m_FinalizeMovement);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getreachedEndOfPath", _g_get_reachedEndOfPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdestination", _g_get_destination);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrotation", _g_get_rotation);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getremainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethasPath", _g_get_hasPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathPending", _g_get_pathPending);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getisStopped", _g_get_isStopped);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonSearchPath", _g_get_onSearchPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrepathRate", _g_get_repathRate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcanSearch", _g_get_canSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcanMove", _g_get_canMove);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getspeed", _g_get_speed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getenableRotation", _g_get_enableRotation);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrotationIn2D", _g_get_rotationIn2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrotationSpeed", _g_get_rotationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinterpolatePathSwitches", _g_get_interpolatePathSwitches);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getswitchPathInterpolationSpeed", _g_get_switchPathInterpolationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdatePosition", _g_get_updatePosition);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdateRotation", _g_get_updateRotation);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdestination", _s_set_destination);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setremainingDistance", _s_set_remainingDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setisStopped", _s_set_isStopped);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setonSearchPath", _s_set_onSearchPath);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrepathRate", _s_set_repathRate);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcanSearch", _s_set_canSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcanMove", _s_set_canMove);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setspeed", _s_set_speed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setenableRotation", _s_set_enableRotation);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrotationIn2D", _s_set_rotationIn2D);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrotationSpeed", _s_set_rotationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinterpolatePathSwitches", _s_set_interpolatePathSwitches);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setswitchPathInterpolationSpeed", _s_set_switchPathInterpolationSpeed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdatePosition", _s_set_updatePosition);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdateRotation", _s_set_updateRotation);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "reachedEndOfPath", _g_get_reachedEndOfPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "destination", _g_get_destination);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotation", _g_get_rotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "remainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hasPath", _g_get_hasPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathPending", _g_get_pathPending);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isStopped", _g_get_isStopped);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onSearchPath", _g_get_onSearchPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "repathRate", _g_get_repathRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canSearch", _g_get_canSearch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canMove", _g_get_canMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "speed", _g_get_speed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enableRotation", _g_get_enableRotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationIn2D", _g_get_rotationIn2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotationSpeed", _g_get_rotationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "interpolatePathSwitches", _g_get_interpolatePathSwitches);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "switchPathInterpolationSpeed", _g_get_switchPathInterpolationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updatePosition", _g_get_updatePosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updateRotation", _g_get_updateRotation);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "destination", _s_set_destination);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "remainingDistance", _s_set_remainingDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isStopped", _s_set_isStopped);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onSearchPath", _s_set_onSearchPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "repathRate", _s_set_repathRate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canSearch", _s_set_canSearch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canMove", _s_set_canMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "speed", _s_set_speed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enableRotation", _s_set_enableRotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotationIn2D", _s_set_rotationIn2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotationSpeed", _s_set_rotationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "interpolatePathSwitches", _s_set_interpolatePathSwitches);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "switchPathInterpolationSpeed", _s_set_switchPathInterpolationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updatePosition", _s_set_updatePosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updateRotation", _s_set_updateRotation);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.AILerp does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDisable(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDisable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Teleport(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    bool _clearPath = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Teleport( 
                        _position, 
                        _clearPath );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    
                    gen_to_be_invoked.Teleport( 
                        _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AILerp.Teleport!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SearchPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SearchPath(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTargetReached(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnTargetReached(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.SetPath( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFeetPosition(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetFeetPosition(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MovementUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 _nextPosition;
                    UnityEngine.Quaternion _nextRotation;
                    
                    gen_to_be_invoked.MovementUpdate( 
                        _deltaTime, 
                        out _nextPosition, 
                        out _nextRotation );
                    translator.PushUnityEngineVector3(L, _nextPosition);
                        
                    translator.PushUnityEngineQuaternion(L, _nextRotation);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinalizeMovement(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _nextPosition;translator.Get(L, 2, out _nextPosition);
                    UnityEngine.Quaternion _nextRotation;translator.Get(L, 3, out _nextRotation);
                    
                    gen_to_be_invoked.FinalizeMovement( 
                        _nextPosition, 
                        _nextRotation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reachedEndOfPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.reachedEndOfPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_destination(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.destination);
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
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineQuaternion(L, gen_to_be_invoked.rotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_remainingDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.remainingDistance);
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
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.pathPending);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isStopped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isStopped);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSearchPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onSearchPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_repathRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.repathRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canSearch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.speed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enableRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.enableRotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotationIn2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.rotationIn2D);
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
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.rotationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_interpolatePathSwitches(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.interpolatePathSwitches);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_switchPathInterpolationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.switchPathInterpolationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updatePosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updatePosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updateRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.updateRotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_destination(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.destination = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_remainingDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.remainingDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isStopped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isStopped = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSearchPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onSearchPath = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_repathRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.repathRate = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canSearch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canMove = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.speed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enableRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enableRotation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotationIn2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rotationIn2D = LuaAPI.lua_toboolean(L, 2);
            
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
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rotationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_interpolatePathSwitches(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.interpolatePathSwitches = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_switchPathInterpolationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.switchPathInterpolationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updatePosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updatePosition = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updateRotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AILerp gen_to_be_invoked = (Pathfinding.AILerp)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.updateRotation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
