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
    public class PFVectorMathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.VectorMath);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 36, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ComplexMultiply", _m_ComplexMultiply_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ComplexMultiplyConjugate", _m_ComplexMultiplyConjugate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnLine", _m_ClosestPointOnLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnLineFactor", _m_ClosestPointOnLineFactor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnSegment", _m_ClosestPointOnSegment_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnSegmentXZ", _m_ClosestPointOnSegmentXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SqrDistancePointSegmentApproximate", _m_SqrDistancePointSegmentApproximate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SqrDistancePointSegment", _m_SqrDistancePointSegment_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SqrDistanceSegmentSegment", _m_SqrDistanceSegmentSegment_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SqrDistanceXZ", _m_SqrDistanceXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SignedTriangleAreaTimes2XZ", _m_SignedTriangleAreaTimes2XZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RightXZ", _m_RightXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SideXZ", _m_SideXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RightOrColinear", _m_RightOrColinear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RightOrColinearXZ", _m_RightOrColinearXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsClockwiseMarginXZ", _m_IsClockwiseMarginXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsClockwiseXZ", _m_IsClockwiseXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsClockwiseOrColinearXZ", _m_IsClockwiseOrColinearXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsClockwiseOrColinear", _m_IsClockwiseOrColinear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsColinear", _m_IsColinear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsColinearXZ", _m_IsColinearXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsColinearAlmostXZ", _m_IsColinearAlmostXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SegmentsIntersect", _m_SegmentsIntersect_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SegmentsIntersectXZ", _m_SegmentsIntersectXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineDirIntersectionPointXZ", _m_LineDirIntersectionPointXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RaySegmentIntersectXZ", _m_RaySegmentIntersectXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineIntersectionFactorXZ", _m_LineIntersectionFactorXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineRayIntersectionFactorXZ", _m_LineRayIntersectionFactorXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineIntersectionPointXZ", _m_LineIntersectionPointXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineIntersectionPoint", _m_LineIntersectionPoint_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SegmentIntersectionPointXZ", _m_SegmentIntersectionPointXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineCircleIntersectionFactor", _m_LineCircleIntersectionFactor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Normalize", _m_Normalize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClampMagnitudeXZ", _m_ClampMagnitudeXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MagnitudeXZ", _m_MagnitudeXZ_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.VectorMath does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ComplexMultiply_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    
                        UnityEngine.Vector2 gen_ret = PF.VectorMath.ComplexMultiply( 
                        _a, 
                        _b );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ComplexMultiplyConjugate_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    
                        UnityEngine.Vector2 gen_ret = PF.VectorMath.ComplexMultiplyConjugate( 
                        _a, 
                        _b );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnLine_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _lineStart;translator.Get(L, 1, out _lineStart);
                    UnityEngine.Vector3 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    UnityEngine.Vector3 _point;translator.Get(L, 3, out _point);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.ClosestPointOnLine( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnLineFactor_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _lineStart;translator.Get(L, 1, out _lineStart);
                    UnityEngine.Vector3 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    UnityEngine.Vector3 _point;translator.Get(L, 3, out _point);
                    
                        float gen_ret = PF.VectorMath.ClosestPointOnLineFactor( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _lineStart;translator.Get(L, 1, out _lineStart);
                    PF.Int3 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    PF.Int3 _point;translator.Get(L, 3, out _point);
                    
                        float gen_ret = PF.VectorMath.ClosestPointOnLineFactor( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int2>(L, 1)&& translator.Assignable<PF.Int2>(L, 2)&& translator.Assignable<PF.Int2>(L, 3)) 
                {
                    PF.Int2 _lineStart;translator.Get(L, 1, out _lineStart);
                    PF.Int2 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    PF.Int2 _point;translator.Get(L, 3, out _point);
                    
                        float gen_ret = PF.VectorMath.ClosestPointOnLineFactor( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.ClosestPointOnLineFactor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnSegment_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _lineStart;translator.Get(L, 1, out _lineStart);
                    UnityEngine.Vector3 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    UnityEngine.Vector3 _point;translator.Get(L, 3, out _point);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.ClosestPointOnSegment( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnSegmentXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _lineStart;translator.Get(L, 1, out _lineStart);
                    UnityEngine.Vector3 _lineEnd;translator.Get(L, 2, out _lineEnd);
                    UnityEngine.Vector3 _point;translator.Get(L, 3, out _point);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.ClosestPointOnSegmentXZ( 
                        _lineStart, 
                        _lineEnd, 
                        _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SqrDistancePointSegmentApproximate_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    int _px = LuaAPI.xlua_tointeger(L, 3);
                    int _pz = LuaAPI.xlua_tointeger(L, 4);
                    int _qx = LuaAPI.xlua_tointeger(L, 5);
                    int _qz = LuaAPI.xlua_tointeger(L, 6);
                    
                        float gen_ret = PF.VectorMath.SqrDistancePointSegmentApproximate( 
                        _x, 
                        _z, 
                        _px, 
                        _pz, 
                        _qx, 
                        _qz );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _p;translator.Get(L, 3, out _p);
                    
                        float gen_ret = PF.VectorMath.SqrDistancePointSegmentApproximate( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.SqrDistancePointSegmentApproximate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SqrDistancePointSegment_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _p;translator.Get(L, 3, out _p);
                    
                        float gen_ret = PF.VectorMath.SqrDistancePointSegment( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SqrDistanceSegmentSegment_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _s1;translator.Get(L, 1, out _s1);
                    UnityEngine.Vector3 _e1;translator.Get(L, 2, out _e1);
                    UnityEngine.Vector3 _s2;translator.Get(L, 3, out _s2);
                    UnityEngine.Vector3 _e2;translator.Get(L, 4, out _e2);
                    
                        float gen_ret = PF.VectorMath.SqrDistanceSegmentSegment( 
                        _s1, 
                        _e1, 
                        _s2, 
                        _e2 );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SqrDistanceXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    
                        float gen_ret = PF.VectorMath.SqrDistanceXZ( 
                        _a, 
                        _b );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SignedTriangleAreaTimes2XZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    
                        long gen_ret = PF.VectorMath.SignedTriangleAreaTimes2XZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    
                        float gen_ret = PF.VectorMath.SignedTriangleAreaTimes2XZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.SignedTriangleAreaTimes2XZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RightXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightXZ( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightXZ( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.RightXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SideXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _p;translator.Get(L, 3, out _p);
                    
                        PF.Side gen_ret = PF.VectorMath.SideXZ( 
                        _a, 
                        _b, 
                        _p );
                        translator.PushPFSide(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RightOrColinear_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector2 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightOrColinear( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int2>(L, 1)&& translator.Assignable<PF.Int2>(L, 2)&& translator.Assignable<PF.Int2>(L, 3)) 
                {
                    PF.Int2 _a;translator.Get(L, 1, out _a);
                    PF.Int2 _b;translator.Get(L, 2, out _b);
                    PF.Int2 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightOrColinear( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.RightOrColinear!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RightOrColinearXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightOrColinearXZ( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _p;translator.Get(L, 3, out _p);
                    
                        bool gen_ret = PF.VectorMath.RightOrColinearXZ( 
                        _a, 
                        _b, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.RightOrColinearXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsClockwiseMarginXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsClockwiseMarginXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsClockwiseXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsClockwiseXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsClockwiseXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.IsClockwiseXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsClockwiseOrColinearXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsClockwiseOrColinearXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsClockwiseOrColinear_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int2 _a;translator.Get(L, 1, out _a);
                    PF.Int2 _b;translator.Get(L, 2, out _b);
                    PF.Int2 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsClockwiseOrColinear( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsColinear_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsColinear( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector2 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsColinear( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.IsColinear!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsColinearXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsColinearXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsColinearXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.IsColinearXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsColinearAlmostXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    
                        bool gen_ret = PF.VectorMath.IsColinearAlmostXZ( 
                        _a, 
                        _b, 
                        _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SegmentsIntersect_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int2 _start1;translator.Get(L, 1, out _start1);
                    PF.Int2 _end1;translator.Get(L, 2, out _end1);
                    PF.Int2 _start2;translator.Get(L, 3, out _start2);
                    PF.Int2 _end2;translator.Get(L, 4, out _end2);
                    
                        bool gen_ret = PF.VectorMath.SegmentsIntersect( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SegmentsIntersectXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)&& translator.Assignable<PF.Int3>(L, 4)) 
                {
                    PF.Int3 _start1;translator.Get(L, 1, out _start1);
                    PF.Int3 _end1;translator.Get(L, 2, out _end1);
                    PF.Int3 _start2;translator.Get(L, 3, out _start2);
                    PF.Int3 _end2;translator.Get(L, 4, out _end2);
                    
                        bool gen_ret = PF.VectorMath.SegmentsIntersectXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    
                        bool gen_ret = PF.VectorMath.SegmentsIntersectXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.SegmentsIntersectXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineDirIntersectionPointXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _dir1;translator.Get(L, 2, out _dir1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _dir2;translator.Get(L, 4, out _dir2);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.LineDirIntersectionPointXZ( 
                        _start1, 
                        _dir1, 
                        _start2, 
                        _dir2 );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _dir1;translator.Get(L, 2, out _dir1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _dir2;translator.Get(L, 4, out _dir2);
                    bool _intersects;
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.LineDirIntersectionPointXZ( 
                        _start1, 
                        _dir1, 
                        _start2, 
                        _dir2, 
                        out _intersects );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _intersects);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.LineDirIntersectionPointXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RaySegmentIntersectXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _start1;translator.Get(L, 1, out _start1);
                    PF.Int3 _end1;translator.Get(L, 2, out _end1);
                    PF.Int3 _start2;translator.Get(L, 3, out _start2);
                    PF.Int3 _end2;translator.Get(L, 4, out _end2);
                    
                        bool gen_ret = PF.VectorMath.RaySegmentIntersectXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineIntersectionFactorXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    
                        float gen_ret = PF.VectorMath.LineIntersectionFactorXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)&& translator.Assignable<PF.Int3>(L, 4)) 
                {
                    PF.Int3 _start1;translator.Get(L, 1, out _start1);
                    PF.Int3 _end1;translator.Get(L, 2, out _end1);
                    PF.Int3 _start2;translator.Get(L, 3, out _start2);
                    PF.Int3 _end2;translator.Get(L, 4, out _end2);
                    float _factor1;
                    float _factor2;
                    
                        bool gen_ret = PF.VectorMath.LineIntersectionFactorXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2, 
                        out _factor1, 
                        out _factor2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _factor1);
                        
                    LuaAPI.lua_pushnumber(L, _factor2);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    float _factor1;
                    float _factor2;
                    
                        bool gen_ret = PF.VectorMath.LineIntersectionFactorXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2, 
                        out _factor1, 
                        out _factor2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _factor1);
                        
                    LuaAPI.lua_pushnumber(L, _factor2);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.LineIntersectionFactorXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineRayIntersectionFactorXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _start1;translator.Get(L, 1, out _start1);
                    PF.Int3 _end1;translator.Get(L, 2, out _end1);
                    PF.Int3 _start2;translator.Get(L, 3, out _start2);
                    PF.Int3 _end2;translator.Get(L, 4, out _end2);
                    
                        float gen_ret = PF.VectorMath.LineRayIntersectionFactorXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineIntersectionPointXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.LineIntersectionPointXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    bool _intersects;
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.LineIntersectionPointXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2, 
                        out _intersects );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _intersects);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.LineIntersectionPointXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineIntersectionPoint_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& translator.Assignable<UnityEngine.Vector2>(L, 4)) 
                {
                    UnityEngine.Vector2 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector2 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector2 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector2 _end2;translator.Get(L, 4, out _end2);
                    
                        UnityEngine.Vector2 gen_ret = PF.VectorMath.LineIntersectionPoint( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2 );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& translator.Assignable<UnityEngine.Vector2>(L, 4)) 
                {
                    UnityEngine.Vector2 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector2 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector2 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector2 _end2;translator.Get(L, 4, out _end2);
                    bool _intersects;
                    
                        UnityEngine.Vector2 gen_ret = PF.VectorMath.LineIntersectionPoint( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2, 
                        out _intersects );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _intersects);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.LineIntersectionPoint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SegmentIntersectionPointXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _start1;translator.Get(L, 1, out _start1);
                    UnityEngine.Vector3 _end1;translator.Get(L, 2, out _end1);
                    UnityEngine.Vector3 _start2;translator.Get(L, 3, out _start2);
                    UnityEngine.Vector3 _end2;translator.Get(L, 4, out _end2);
                    bool _intersects;
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.SegmentIntersectionPointXZ( 
                        _start1, 
                        _end1, 
                        _start2, 
                        _end2, 
                        out _intersects );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _intersects);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineCircleIntersectionFactor_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _circleCenter;translator.Get(L, 1, out _circleCenter);
                    UnityEngine.Vector3 _linePoint1;translator.Get(L, 2, out _linePoint1);
                    UnityEngine.Vector3 _linePoint2;translator.Get(L, 3, out _linePoint2);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        float gen_ret = PF.VectorMath.LineCircleIntersectionFactor( 
                        _circleCenter, 
                        _linePoint1, 
                        _linePoint2, 
                        _radius );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Normalize_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 _v;translator.Get(L, 1, out _v);
                    float _magnitude;
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.Normalize( 
                        _v, 
                        out _magnitude );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _magnitude);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2>(L, 1)) 
                {
                    UnityEngine.Vector2 _v;translator.Get(L, 1, out _v);
                    float _magnitude;
                    
                        UnityEngine.Vector2 gen_ret = PF.VectorMath.Normalize( 
                        _v, 
                        out _magnitude );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _magnitude);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.VectorMath.Normalize!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClampMagnitudeXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _v;translator.Get(L, 1, out _v);
                    float _maxMagnitude = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = PF.VectorMath.ClampMagnitudeXZ( 
                        _v, 
                        _maxMagnitude );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MagnitudeXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _v;translator.Get(L, 1, out _v);
                    
                        float gen_ret = PF.VectorMath.MagnitudeXZ( 
                        _v );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
