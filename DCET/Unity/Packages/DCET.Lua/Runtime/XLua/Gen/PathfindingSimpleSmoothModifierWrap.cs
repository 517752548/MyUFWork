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
    public class PathfindingSimpleSmoothModifierWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.SimpleSmoothModifier);
			Utils.BeginObjectRegister(type, L, translator, 0, 24, 10, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CurvedNonuniform", _m_CurvedNonuniform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SmoothOffsetSimple", _m_SmoothOffsetSimple);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SmoothSimple", _m_SmoothSimple);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SmoothBezier", _m_SmoothBezier);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsmoothType", _g_get_smoothType);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsubdivisions", _g_get_subdivisions);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getiterations", _g_get_iterations);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstrength", _g_get_strength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuniformLength", _g_get_uniformLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxSegmentLength", _g_get_maxSegmentLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbezierTangentLength", _g_get_bezierTangentLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoffset", _g_get_offset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfactor", _g_get_factor);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsmoothType", _s_set_smoothType);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsubdivisions", _s_set_subdivisions);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setiterations", _s_set_iterations);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstrength", _s_set_strength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuniformLength", _s_set_uniformLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxSegmentLength", _s_set_maxSegmentLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbezierTangentLength", _s_set_bezierTangentLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoffset", _s_set_offset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfactor", _s_set_factor);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "smoothType", _g_get_smoothType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "subdivisions", _g_get_subdivisions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "iterations", _g_get_iterations);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "strength", _g_get_strength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uniformLength", _g_get_uniformLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxSegmentLength", _g_get_maxSegmentLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bezierTangentLength", _g_get_bezierTangentLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "offset", _g_get_offset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "factor", _g_get_factor);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "smoothType", _s_set_smoothType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "subdivisions", _s_set_subdivisions);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "iterations", _s_set_iterations);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "strength", _s_set_strength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uniformLength", _s_set_uniformLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxSegmentLength", _s_set_maxSegmentLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bezierTangentLength", _s_set_bezierTangentLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "offset", _s_set_offset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "factor", _s_set_factor);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPointOnCubic", _m_GetPointOnCubic_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.SimpleSmoothModifier gen_ret = new Pathfinding.SimpleSmoothModifier();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.SimpleSmoothModifier constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.Apply( 
                        _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CurvedNonuniform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _path = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = gen_to_be_invoked.CurvedNonuniform( 
                        _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPointOnCubic_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    UnityEngine.Vector3 _tan1;translator.Get(L, 3, out _tan1);
                    UnityEngine.Vector3 _tan2;translator.Get(L, 4, out _tan2);
                    float _t = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        UnityEngine.Vector3 gen_ret = Pathfinding.SimpleSmoothModifier.GetPointOnCubic( 
                        _a, 
                        _b, 
                        _tan1, 
                        _tan2, 
                        _t );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothOffsetSimple(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _path = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = gen_to_be_invoked.SmoothOffsetSimple( 
                        _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothSimple(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _path = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = gen_to_be_invoked.SmoothSimple( 
                        _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothBezier(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _path = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = gen_to_be_invoked.SmoothBezier( 
                        _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Order(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_smoothType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingSimpleSmoothModifierSmoothType(L, gen_to_be_invoked.smoothType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_subdivisions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.subdivisions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_iterations(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.iterations);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_strength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.strength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uniformLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.uniformLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxSegmentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxSegmentLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bezierTangentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.bezierTangentLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_offset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.offset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_factor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.factor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_smoothType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                Pathfinding.SimpleSmoothModifier.SmoothType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.smoothType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_subdivisions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.subdivisions = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_iterations(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.iterations = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_strength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.strength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uniformLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.uniformLength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxSegmentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxSegmentLength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bezierTangentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bezierTangentLength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_offset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.offset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_factor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.SimpleSmoothModifier gen_to_be_invoked = (Pathfinding.SimpleSmoothModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.factor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
