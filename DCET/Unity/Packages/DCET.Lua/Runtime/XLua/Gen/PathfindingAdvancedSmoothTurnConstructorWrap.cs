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
    public class PathfindingAdvancedSmoothTurnConstructorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AdvancedSmooth.TurnConstructor);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Prepare", _m_Prepare);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTangentUpdate", _m_OnTangentUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PointToTangent", _m_PointToTangent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TangentToPoint", _m_TangentToPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TangentToTangent", _m_TangentToTangent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPath", _m_GetPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddCircleSegment", _m_AddCircleSegment);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugCircleSegment", _m_DebugCircleSegment);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugCircle", _m_DebugCircle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLengthFromAngle", _m_GetLengthFromAngle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClockwiseAngle", _m_ClockwiseAngle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CounterClockwiseAngle", _m_CounterClockwiseAngle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AngleToVector", _m_AngleToVector);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToDegrees", _m_ToDegrees);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClampAngle", _m_ClampAngle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Atan2", _m_Atan2);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstantBias", _g_get_constantBias);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfactorBias", _g_get_factorBias);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstantBias", _s_set_constantBias);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfactorBias", _s_set_factorBias);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "constantBias", _g_get_constantBias);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "factorBias", _g_get_factorBias);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "constantBias", _s_set_constantBias);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "factorBias", _s_set_factorBias);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 41, 9, 9);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Setup", _m_Setup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PostPrepare", _m_PostPrepare_xlua_st_);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getThreeSixtyRadians", Pathfinding.AdvancedSmooth.TurnConstructor.ThreeSixtyRadians);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getturningRadius", _g_get_turningRadius);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getprev", _g_get_prev);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getcurrent", _g_get_current);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getnext", _g_get_next);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "gett1", _g_get_t1);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "gett2", _g_get_t2);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getnormal", _g_get_normal);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getprevNormal", _g_get_prevNormal);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getchangedPreviousTangent", _g_get_changedPreviousTangent);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setturningRadius", _s_set_turningRadius);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setprev", _s_set_prev);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setcurrent", _s_set_current);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setnext", _s_set_next);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "sett1", _s_set_t1);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "sett2", _s_set_t2);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setnormal", _s_set_normal);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setprevNormal", _s_set_prevNormal);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setchangedPreviousTangent", _s_set_changedPreviousTangent);
            
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ThreeSixtyRadians", Pathfinding.AdvancedSmooth.TurnConstructor.ThreeSixtyRadians);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "turningRadius", _g_get_turningRadius);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "prev", _g_get_prev);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "current", _g_get_current);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "next", _g_get_next);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "t1", _g_get_t1);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "t2", _g_get_t2);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "normal", _g_get_normal);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "prevNormal", _g_get_prevNormal);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "changedPreviousTangent", _g_get_changedPreviousTangent);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "turningRadius", _s_set_turningRadius);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "prev", _s_set_prev);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "current", _s_set_current);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "next", _s_set_next);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "t1", _s_set_t1);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "t2", _s_set_t2);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "normal", _s_set_normal);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "prevNormal", _s_set_prevNormal);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "changedPreviousTangent", _s_set_changedPreviousTangent);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.AdvancedSmooth.TurnConstructor does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Prepare(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Vector3[] _vectorPath = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.Prepare( 
                        _i, 
                        _vectorPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTangentUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnTangentUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PointToTangent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.PointToTangent( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TangentToPoint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.TangentToPoint( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TangentToTangent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.TangentToTangent( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.AdvancedSmooth.Turn _turn;translator.Get(L, 2, out _turn);
                    System.Collections.Generic.List<UnityEngine.Vector3> _output = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                    gen_to_be_invoked.GetPath( 
                        _turn, 
                        _output );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Setup_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    UnityEngine.Vector3[] _vectorPath = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    
                    Pathfinding.AdvancedSmooth.TurnConstructor.Setup( 
                        _i, 
                        _vectorPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostPrepare_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.AdvancedSmooth.TurnConstructor.PostPrepare(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddCircleSegment(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _startAngle = LuaAPI.lua_tonumber(L, 2);
                    double _endAngle = LuaAPI.lua_tonumber(L, 3);
                    bool _clockwise = LuaAPI.lua_toboolean(L, 4);
                    UnityEngine.Vector3 _center;translator.Get(L, 5, out _center);
                    System.Collections.Generic.List<UnityEngine.Vector3> _output = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    float _radius = (float)LuaAPI.lua_tonumber(L, 7);
                    
                    gen_to_be_invoked.AddCircleSegment( 
                        _startAngle, 
                        _endAngle, 
                        _clockwise, 
                        _center, 
                        _output, 
                        _radius );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugCircleSegment(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    double _startAngle = LuaAPI.lua_tonumber(L, 3);
                    double _endAngle = LuaAPI.lua_tonumber(L, 4);
                    double _radius = LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.Color _color;translator.Get(L, 6, out _color);
                    
                    gen_to_be_invoked.DebugCircleSegment( 
                        _center, 
                        _startAngle, 
                        _endAngle, 
                        _radius, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugCircle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    double _radius = LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.DebugCircle( 
                        _center, 
                        _radius, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLengthFromAngle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _angle = LuaAPI.lua_tonumber(L, 2);
                    double _radius = LuaAPI.lua_tonumber(L, 3);
                    
                        double gen_ret = gen_to_be_invoked.GetLengthFromAngle( 
                        _angle, 
                        _radius );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClockwiseAngle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _from = LuaAPI.lua_tonumber(L, 2);
                    double _to = LuaAPI.lua_tonumber(L, 3);
                    
                        double gen_ret = gen_to_be_invoked.ClockwiseAngle( 
                        _from, 
                        _to );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CounterClockwiseAngle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _from = LuaAPI.lua_tonumber(L, 2);
                    double _to = LuaAPI.lua_tonumber(L, 3);
                    
                        double gen_ret = gen_to_be_invoked.CounterClockwiseAngle( 
                        _from, 
                        _to );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AngleToVector(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _a = LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.AngleToVector( 
                        _a );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToDegrees(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _rad = LuaAPI.lua_tonumber(L, 2);
                    
                        double gen_ret = gen_to_be_invoked.ToDegrees( 
                        _rad );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClampAngle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _a = LuaAPI.lua_tonumber(L, 2);
                    
                        double gen_ret = gen_to_be_invoked.ClampAngle( 
                        _a );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Atan2(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _v;translator.Get(L, 2, out _v);
                    
                        double gen_ret = gen_to_be_invoked.Atan2( 
                        _v );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constantBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.constantBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_factorBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.factorBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_turningRadius(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, Pathfinding.AdvancedSmooth.TurnConstructor.turningRadius);
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
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.prev);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.current);
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
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.next);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_t1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.t1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_t2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.t2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.normal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prevNormal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, Pathfinding.AdvancedSmooth.TurnConstructor.prevNormal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_changedPreviousTangent(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, Pathfinding.AdvancedSmooth.TurnConstructor.changedPreviousTangent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constantBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.constantBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_factorBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.TurnConstructor gen_to_be_invoked = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.factorBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_turningRadius(RealStatePtr L)
        {
		    try {
                
			    Pathfinding.AdvancedSmooth.TurnConstructor.turningRadius = (float)LuaAPI.lua_tonumber(L, 1);
            
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
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.prev = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.current = gen_value;
            
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
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.next = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_t1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.t1 = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_t2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.t2 = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_normal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.normal = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prevNormal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AdvancedSmooth.TurnConstructor.prevNormal = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_changedPreviousTangent(RealStatePtr L)
        {
		    try {
                
			    Pathfinding.AdvancedSmooth.TurnConstructor.changedPreviousTangent = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
