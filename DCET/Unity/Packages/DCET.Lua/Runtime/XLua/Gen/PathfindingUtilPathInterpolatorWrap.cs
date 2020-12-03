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
    public class PathfindingUtilPathInterpolatorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.PathInterpolator);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 6, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPath", _m_SetPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveToSegment", _m_MoveToSegment);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveToClosestPoint", _m_MoveToClosestPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveToLocallyClosestPoint", _m_MoveToLocallyClosestPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveToCircleIntersection2D", _m_MoveToCircleIntersection2D);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettangent", _g_get_tangent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getremainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdistance", _g_get_distance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsegmentIndex", _g_get_segmentIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvalid", _g_get_valid);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setremainingDistance", _s_set_remainingDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdistance", _s_set_distance);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tangent", _g_get_tangent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "remainingDistance", _g_get_remainingDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distance", _g_get_distance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "segmentIndex", _g_get_segmentIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "valid", _g_get_valid);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "remainingDistance", _s_set_remainingDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distance", _s_set_distance);
            
			
			
			
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
					
					Pathfinding.Util.PathInterpolator gen_ret = new Pathfinding.Util.PathInterpolator();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.PathInterpolator constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _path = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                    gen_to_be_invoked.SetPath( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveToSegment(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    float _fractionAlongSegment = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.MoveToSegment( 
                        _index, 
                        _fractionAlongSegment );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveToClosestPoint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                    gen_to_be_invoked.MoveToClosestPoint( 
                        _point );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveToLocallyClosestPoint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    bool _allowForwards = LuaAPI.lua_toboolean(L, 3);
                    bool _allowBackwards = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.MoveToLocallyClosestPoint( 
                        _point, 
                        _allowForwards, 
                        _allowBackwards );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    bool _allowForwards = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.MoveToLocallyClosestPoint( 
                        _point, 
                        _allowForwards );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                    gen_to_be_invoked.MoveToLocallyClosestPoint( 
                        _point );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.PathInterpolator.MoveToLocallyClosestPoint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveToCircleIntersection2D(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _circleCenter3D;translator.Get(L, 2, out _circleCenter3D);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    PF.IMovementPlane _transform = (PF.IMovementPlane)translator.GetObject(L, 4, typeof(PF.IMovementPlane));
                    
                    gen_to_be_invoked.MoveToCircleIntersection2D( 
                        _circleCenter3D, 
                        _radius, 
                        _transform );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tangent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.tangent);
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
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.remainingDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_segmentIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.segmentIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_valid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.valid);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_remainingDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.remainingDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.PathInterpolator gen_to_be_invoked = (Pathfinding.Util.PathInterpolator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
