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
    public class PFPolygonWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.Polygon);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 10, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ContainsPointXZ", _m_ContainsPointXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ContainsPoint", _m_ContainsPoint_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SampleYCoordinateInTriangle", _m_SampleYCoordinateInTriangle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ConvexHullXZ", _m_ConvexHullXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnTriangle", _m_ClosestPointOnTriangle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPointOnTriangleXZ", _m_ClosestPointOnTriangleXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CompressMesh", _m_CompressMesh_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TraceContours", _m_TraceContours_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Subdivide", _m_Subdivide_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.Polygon does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsPointXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3[]>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3[] _polyPoints = (UnityEngine.Vector3[])translator.GetObject(L, 1, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        bool gen_ret = PF.Polygon.ContainsPointXZ( 
                        _polyPoints, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    UnityEngine.Vector3 _p;translator.Get(L, 4, out _p);
                    
                        bool gen_ret = PF.Polygon.ContainsPointXZ( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.Int3>(L, 1)&& translator.Assignable<PF.Int3>(L, 2)&& translator.Assignable<PF.Int3>(L, 3)&& translator.Assignable<PF.Int3>(L, 4)) 
                {
                    PF.Int3 _a;translator.Get(L, 1, out _a);
                    PF.Int3 _b;translator.Get(L, 2, out _b);
                    PF.Int3 _c;translator.Get(L, 3, out _c);
                    PF.Int3 _p;translator.Get(L, 4, out _p);
                    
                        bool gen_ret = PF.Polygon.ContainsPointXZ( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Polygon.ContainsPointXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsPoint_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2[]>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)) 
                {
                    UnityEngine.Vector2[] _polyPoints = (UnityEngine.Vector2[])translator.GetObject(L, 1, typeof(UnityEngine.Vector2[]));
                    UnityEngine.Vector2 _p;translator.Get(L, 2, out _p);
                    
                        bool gen_ret = PF.Polygon.ContainsPoint( 
                        _polyPoints, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.Int2>(L, 1)&& translator.Assignable<PF.Int2>(L, 2)&& translator.Assignable<PF.Int2>(L, 3)&& translator.Assignable<PF.Int2>(L, 4)) 
                {
                    PF.Int2 _a;translator.Get(L, 1, out _a);
                    PF.Int2 _b;translator.Get(L, 2, out _b);
                    PF.Int2 _c;translator.Get(L, 3, out _c);
                    PF.Int2 _p;translator.Get(L, 4, out _p);
                    
                        bool gen_ret = PF.Polygon.ContainsPoint( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Polygon.ContainsPoint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SampleYCoordinateInTriangle_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _p1;translator.Get(L, 1, out _p1);
                    PF.Int3 _p2;translator.Get(L, 2, out _p2);
                    PF.Int3 _p3;translator.Get(L, 3, out _p3);
                    PF.Int3 _p;translator.Get(L, 4, out _p);
                    
                        int gen_ret = PF.Polygon.SampleYCoordinateInTriangle( 
                        _p1, 
                        _p2, 
                        _p3, 
                        _p );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConvexHullXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3[] _points = (UnityEngine.Vector3[])translator.GetObject(L, 1, typeof(UnityEngine.Vector3[]));
                    
                        UnityEngine.Vector3[] gen_ret = PF.Polygon.ConvexHullXZ( 
                        _points );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnTriangle_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& translator.Assignable<UnityEngine.Vector2>(L, 4)) 
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector2 _c;translator.Get(L, 3, out _c);
                    UnityEngine.Vector2 _p;translator.Get(L, 4, out _p);
                    
                        UnityEngine.Vector2 gen_ret = PF.Polygon.ClosestPointOnTriangle( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    UnityEngine.Vector3 _p;translator.Get(L, 4, out _p);
                    
                        UnityEngine.Vector3 gen_ret = PF.Polygon.ClosestPointOnTriangle( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Polygon.ClosestPointOnTriangle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnTriangleXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 3, out _c);
                    UnityEngine.Vector3 _p;translator.Get(L, 4, out _p);
                    
                        UnityEngine.Vector3 gen_ret = PF.Polygon.ClosestPointOnTriangleXZ( 
                        _a, 
                        _b, 
                        _c, 
                        _p );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompressMesh_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<PF.Int3> _vertices = (System.Collections.Generic.List<PF.Int3>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<PF.Int3>));
                    System.Collections.Generic.List<int> _triangles = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
                    PF.Int3[] _outVertices;
                    int[] _outTriangles;
                    
                    PF.Polygon.CompressMesh( 
                        _vertices, 
                        _triangles, 
                        out _outVertices, 
                        out _outTriangles );
                    translator.Push(L, _outVertices);
                        
                    translator.Push(L, _outTriangles);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TraceContours_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.Dictionary<int, int> _outline = (System.Collections.Generic.Dictionary<int, int>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Dictionary<int, int>));
                    System.Collections.Generic.HashSet<int> _hasInEdge = (System.Collections.Generic.HashSet<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.HashSet<int>));
                    System.Action<System.Collections.Generic.List<int>, bool> _results = translator.GetDelegate<System.Action<System.Collections.Generic.List<int>, bool>>(L, 3);
                    
                    PF.Polygon.TraceContours( 
                        _outline, 
                        _hasInEdge, 
                        _results );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subdivide_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _points = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    System.Collections.Generic.List<UnityEngine.Vector3> _result = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    int _subSegments = LuaAPI.xlua_tointeger(L, 3);
                    
                    PF.Polygon.Subdivide( 
                        _points, 
                        _result, 
                        _subSegments );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
